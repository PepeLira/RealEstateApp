using RealEstateApp.Data;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace RealEstateApp.Controllers
{
    public class InscriptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscriptionController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Inscription> objInscriptionList = _context.Inscriptions.ToList();
            return View(objInscriptionList);
        }

        public IActionResult Create()
        {
            var communes = _context.Communes.Select(c => c.Name).ToList();
            var communeSelectList = new SelectList(communes);
            var cneOptions = Enum.GetNames(typeof(CneOptions));
            var cneSelectList = new SelectList(cneOptions);
            var inscription = new Inscription();;
            ViewBag.CommuneSelectList = communeSelectList;
            ViewBag.CneOptions = cneSelectList;
            return View(inscription);
        }

        public ViewResult Details(int id)
        {
            var inscription = _context.Inscriptions.Include(i => i.Sellers)
                                           .Include(i => i.Buyers)
                                           .FirstOrDefault(i => i.AttentionID == id);
            return View(inscription);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inscription inscription,
                            string[] sellerRuts,
                            int[] sellerRoyalties,
                            bool[] sellerUnaccreditedPer,
                            string[] buyerRuts,
                            int[] buyerRoyalties,
                            bool[] buyerUnaccreditedPer)
        {
            var buyersCount = buyerRuts.Length;
            var sellersCount = sellerRuts.Length;

            if (inscription.Cne == "RegularizaciónDePatrimonio")
            {
                if (inscription == null | buyersCount == 0 | !ValidPercentage(buyerRoyalties))
                {
                    return RedirectToAction("Create");
                }

                if (sellersCount > 0)
                {
                    return RedirectToAction("Create");
                }

                (sellerRoyalties, buyerRoyalties) = NullifyUnaccreditedPercentage
                                                            (sellerRoyalties,
                                                            sellerUnaccreditedPer,
                                                            buyerRoyalties,
                                                            buyerUnaccreditedPer);

                PopulateBuyers(inscription, buyerRuts, buyerRoyalties, buyerUnaccreditedPer);
                _context.SaveChanges();
            }
            else
            {
                return RedirectToAction("Create");
            }

            return RedirectToAction("Index");
        }

        private bool ValidPercentage(int[] royalties)
        {
            int totalPercentage = royalties.Sum();
            return totalPercentage >= 0 && totalPercentage <= 100;
        }

        private Tuple<int[], int[]> NullifyUnaccreditedPercentage 
            (int[] sellerRoyalties, 
            bool[] sellerUnaccreditedPer,
            int[] buyerRoyalties,
            bool[] buyerUnaccreditedPer)
        {
            for (int i = 0; i < sellerUnaccreditedPer.Length; i++)
            {
                var unaccreditedSeller = sellerUnaccreditedPer[i];
                if (unaccreditedSeller)
                {
                    sellerRoyalties[i] = 0;
                }
            }

            for (int i = 0;i  < buyerRoyalties.Length;i++)
            {
                var unaccreditedBuyer = buyerUnaccreditedPer[i];
                if (unaccreditedBuyer)
                {
                    buyerRoyalties[i] = 0;
                }
            }

            return new Tuple<int[], int[]>(sellerRoyalties, buyerRoyalties);
        }

        private void PopulateSellers(Inscription inscription, 
                                     string[] sellerRuts, 
                                     int[] sellerRoyalties, 
                                     bool[] sellerUnaccreditedPer)
        {
            inscription.Sellers = new List<Seller>();
            for (int i = 0; i < sellerRuts.Length; i++)
            {
                var seller = new Seller
                {
                    Rut = sellerRuts[i],
                    RoyaltyPercentage = sellerRoyalties[i],
                    UnaccreditedRoyaltyPercentage = sellerUnaccreditedPer[i]
                };

                seller.Inscription = inscription;
                _context.Add(seller);
            }
        }

        private void PopulateBuyers(Inscription inscription, 
                                    string[] buyerRuts, 
                                    int[] buyerRoyalties, 
                                    bool[] buyerUnaccreditedPer)
        {
            inscription.Buyers = new List<Buyer>();
            for (int i = 0; i < buyerRuts.Length; i++)
            {
                var buyer = new Buyer
                {
                    Rut = buyerRuts[i],
                    RoyaltyPercentage = buyerRoyalties[i],
                    UnaccreditedRoyaltyPercentage = buyerUnaccreditedPer[i]
                };

                buyer.Inscription = inscription;
                _context.Add(buyer);
            }
        }

    }
}
