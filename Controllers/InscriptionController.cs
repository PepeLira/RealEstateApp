using RealEstateApp.Data;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;
using RealEstateApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateApp.ViewModels.Insciption;
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
        public IActionResult Create(Inscription inscription, string[] sellerRuts, string[] sellerNames, int[] sellerRoyalties, string[] buyerRuts, string[] buyerNames, int[] buyerRoyalties)
        {
            if (inscription != null)
            {
                inscription.Sellers = new List<Seller>();
                inscription.Buyers = new List<Buyer>();
                for (int i = 0; i < sellerNames.Length; i++)
                {

                    var seller = new Seller
                    {
                        Rut = sellerRuts[i],
                        Name = sellerNames[i],
                        RoyaltyPercentage = sellerRoyalties[i]
                    };
                    
                    seller.Inscription = inscription;
                    _context.Add(seller);
                }

                for (int i = 0; i < buyerNames.Length; i++)
                {

                    var buyer = new Buyer
                    {
                        Rut = buyerRuts[i],
                        Name = buyerNames[i],
                        RoyaltyPercentage = buyerRoyalties[i]
                    };

                    buyer.Inscription = inscription;
                    _context.Add(buyer);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inscription);
        }
    }
}
