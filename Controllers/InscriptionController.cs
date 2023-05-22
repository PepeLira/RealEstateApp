using RealEstateApp.Data;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateApp.Helpers;
using System.Linq;
using NuGet.Protocol.Plugins;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System;

namespace RealEstateApp.Controllers
{
    public class InscriptionController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        const int YEAR_MINIMUM = 2019;
        public InscriptionController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Inscription> objInscriptionList = _dbContext.Inscriptions.ToList();
            return View(objInscriptionList);
        }

        public IActionResult Create()
        {
            var communes = _dbContext.Communes.Select(c => c.Name).ToList();
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
            var inscription = _dbContext.Inscriptions.Include(i => i.Sellers)
                                           .Include(i => i.Buyers)
                                           .FirstOrDefault(i => i.AttentionID == id);
            return View(inscription);
        }

        private bool notValidRegularizaciónDePatrimonio(
            Inscription inscription, 
            int buyersCount,
            double[] buyerRoyalties, 
            int sellersCount)
        {
            var isNull = inscription == null;
            var hasNoBuyers = buyersCount == 0;
            var invalidBuyerRoyalties = !ValidPercentage(buyerRoyalties);
            var hasSellers = sellersCount > 0;

            return isNull | hasNoBuyers | invalidBuyerRoyalties | hasSellers;
        }

        private bool notValidCompraventa(
            Inscription inscription,
            int buyersCount,
            double[] buyerRoyalties,
            double[] sellerRoyalties,
            int sellersCount)
        {
            var isNull = inscription == null;
            var hasNoBuyers = buyersCount == 0;
            var hasNoSellers = sellersCount == 0;
            var invalidBuyerRoyalties = !ValidPercentage(buyerRoyalties);
            var invalidSellerRoyalties = !ValidPercentage(sellerRoyalties);

            return isNull | hasNoBuyers | invalidBuyerRoyalties | invalidSellerRoyalties | hasNoSellers;
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inscription inscription,
                            string[] sellerRuts,
                            double[] sellerRoyalties,
                            bool[] sellerUnaccreditedPer,
                            string[] buyerRuts,
                            double[] buyerRoyalties,
                            bool[] buyerUnaccreditedPer)
        { 
            var buyersCount = buyerRuts.Length;
            var sellersCount = sellerRuts.Length;

            if (inscription.Cne == CneOptions.RegularizaciónDePatrimonio.ToString())
            {
                if (notValidRegularizaciónDePatrimonio(inscription, buyersCount, buyerRoyalties, sellersCount))
                {
                    return RedirectToAction("Create");
                }

                handleRegularizacionDePatrimonio(
                    inscription, 
                    buyerRuts, 
                    sellerRoyalties, 
                    sellerUnaccreditedPer, 
                    buyerRoyalties, 
                    buyerUnaccreditedPer);
            }
            else if (inscription.Cne == CneOptions.Compraventa.ToString())
            {
                if (!sellersExist(sellerRuts, inscription) | notValidCompraventa(inscription, buyersCount, buyerRoyalties, sellerRoyalties, sellersCount))
                {
                    return RedirectToAction("Create");
                }

                handleCompraventa(
                    inscription,
                    sellerRuts,
                    sellerRoyalties,
                    sellerUnaccreditedPer,
                    buyerRuts,
                    buyerRoyalties,
                    buyerUnaccreditedPer);
            }
            else
            {
                return RedirectToAction("Create");
            }

            fixActiveMultiOwnersfRoyalies(inscription);

            return RedirectToAction("Index");
        }

        private void fixActiveMultiOwnersfRoyalies(Inscription inscription)
        {
            var activeMultiOwners = _dbContext.MultiOwners
                .Where(m => m.Commune == inscription.Commune
                            && m.Block == inscription.Block
                            && m.Property == inscription.Property
                            && m.FinalEffectiveYear == null)
                .ToList();
           
            var totalActiveMultiOwnersRoyalties = activeMultiOwners.Select(m => m.RoyaltyPercentage).ToArray().Sum();

            foreach (var multiOwner in activeMultiOwners)
            {            
                var royaltyPercentage = multiOwner.RoyaltyPercentage / totalActiveMultiOwnersRoyalties * 100;                
                multiOwner.RoyaltyPercentage = royaltyPercentage;

                if (multiOwner.RoyaltyPercentage == 0)
                {
                    _dbContext.MultiOwners.Remove(multiOwner);
                }
            }

            _dbContext.SaveChanges();
        }

        private void handleRegularizacionDePatrimonio (
            Inscription inscription,
            string[] buyerRuts,
            double[] sellerRoyalties,
            bool[] sellerUnaccreditedPer,
            double[] buyerRoyalties,
            bool[] buyerUnaccreditedPer)
        {
            
            (sellerRoyalties, buyerRoyalties) = NullifyUnaccreditedPercentage
            (sellerRoyalties,
            sellerUnaccreditedPer,
            buyerRoyalties,
            buyerUnaccreditedPer);

            PopulateBuyers(inscription, buyerRuts, buyerRoyalties, buyerUnaccreditedPer);
            _dbContext.SaveChanges();

            RegularizacionDePatrimonioHelper multiOwnerHelper = new RegularizacionDePatrimonioHelper(_dbContext);
            _dbContext.SaveChanges();
        }

        private void handleCompraventa(
            Inscription inscription,
            string[] sellersRuts,
            double[] sellerRoyalties,
            bool[] sellerUnaccreditedPer,
            string[] buyerRuts,
            double[] buyerRoyalties,
            bool[] buyerUnaccreditedPer)
        {
            List<MultiOwner> sellersMultiOwners = getRelatedMultiOwners(sellersRuts, inscription);

            if (totalRoyaltyPercentage(buyerRoyalties) == 100.0)
            {
                double totalSellerRoyalties = sellersMultiOwners.Select(s => s.RoyaltyPercentage).ToArray().Sum();
                buyerRoyalties = CalculateBuyerRoyalties(buyerRoyalties, totalSellerRoyalties);
                var buyers = PopulateBuyers(inscription, buyerRuts, buyerRoyalties, buyerUnaccreditedPer);
                var sellers = PopulateSellers(inscription, sellersRuts, sellerRoyalties, sellerUnaccreditedPer);

                foreach (Buyer buyer in buyers)
                {
                    AddBuyerToMultiOwners(buyer);
                }

                foreach (MultiOwner seller in sellersMultiOwners)
                {
                    if (seller.InitialEffectiveYear == inscription.InscriptionDate.Year)
                        _dbContext.MultiOwners.Remove(seller);
                }
            }
            else if (sellersRuts.Count() == 1 && buyerRuts.Count() == 1)
            {
                var sellerMultiOwner = sellersMultiOwners[0];
                var offeredRoyalty = sellerMultiOwner.RoyaltyPercentage * sellerRoyalties[0] / 100.0;
                buyerRoyalties[0] = buyerRoyalties[0] * offeredRoyalty / 100.0;
                sellerRoyalties[0] = sellerMultiOwner.RoyaltyPercentage - buyerRoyalties[0];

                if (sellerMultiOwner.InitialEffectiveYear == inscription.InscriptionDate.Year)
                {
                    _dbContext.MultiOwners.Remove(sellerMultiOwner);
                }

                var buyer = PopulateBuyers(inscription, buyerRuts, buyerRoyalties, buyerUnaccreditedPer)[0];
                var seller = PopulateSellers(inscription, sellersRuts, sellerRoyalties, sellerUnaccreditedPer)[0];

                AddBuyerToMultiOwners(buyer);
                AddSellerToMultiOwners(seller);
            }
            else
            {
                for (int i = 0; i < sellersMultiOwners.Count; i++)
                {            
                    //Calcular el porcentaje restante del vendedor
                    sellerRoyalties[0] = sellersMultiOwners[i].RoyaltyPercentage - sellerRoyalties[0];

                    if (sellerRoyalties[0] < 0)
                    {
                        sellerRoyalties[0] = 0;
                    }

                    if (sellersMultiOwners[i].InitialEffectiveYear == inscription.InscriptionDate.Year)
                    {
                        _dbContext.MultiOwners.Remove(sellersMultiOwners[i]);
                    }
                }

                var buyers = PopulateBuyers(inscription, buyerRuts, buyerRoyalties, buyerUnaccreditedPer);
                var sellers = PopulateSellers(inscription, sellersRuts, sellerRoyalties, sellerUnaccreditedPer);

                foreach (Buyer buyer in buyers)
                {
                    AddBuyerToMultiOwners(buyer);
                }

                foreach (Seller seller in sellers)
                {
                    AddSellerToMultiOwners(seller);
                }
            }

            _dbContext.SaveChanges();
            updatePreviousMultiOwner(inscription);
        }

        private double[] CalculateBuyerRoyalties(double[] buyerRoyalties, double totalSellerRoyalties)
        {
            for (int i = 0; i < buyerRoyalties.Length; i++)
            {
                buyerRoyalties[i] = buyerRoyalties[i] * totalSellerRoyalties / 100.0;
            }

            return buyerRoyalties;
        }

        private List<MultiOwner> getRelatedMultiOwners(string[] rutsList, Inscription inscription)
        {
            List<MultiOwner> multiOwners = new List<MultiOwner>();

            foreach (string seller in rutsList)
            {
                var multiOwner = _dbContext.MultiOwners.FirstOrDefault(m => 
                m.Owner == seller &&
                m.Commune == inscription.Commune &&
                m.Block == inscription.Block &&
                m.Property == inscription.Property &&
                m.FinalEffectiveYear == null);

                multiOwners.Add(multiOwner);
            }

            return multiOwners;
        }

        private bool sellersExist(string[] sellersRuts, Inscription inscription)
        {
            foreach(string seller in sellersRuts)
            {
                if (!_dbContext.MultiOwners.Any(m => 
                    m.Owner == seller &&
                    m.Commune == inscription.Commune &&
                    m.Block == inscription.Block &&
                    m.Property == inscription.Property &&
                    m.FinalEffectiveYear == null))
                {
                    return false;
                }
            }

            return true;
        }

        private double totalRoyaltyPercentage(double[] royalties)
        {
            double totalPercentage = royalties.Sum();
            return totalPercentage;
        }

        private bool ValidPercentage(double[] royalties)
        {
            double totalPercentage = totalRoyaltyPercentage(royalties);
            return totalPercentage >= 0 && totalPercentage <= 100;
        }

        private Tuple<double[], double[]> NullifyUnaccreditedPercentage 
            (double[] sellerRoyalties, 
            bool[] sellerUnaccreditedPer,
            double[] buyerRoyalties,
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

            return new Tuple<double[], double[]>(sellerRoyalties, buyerRoyalties);
        }       

        private List<Buyer> PopulateBuyers(Inscription inscription, 
                                    string[] buyerRuts,
                                    double[] buyerRoyalties, 
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

                _dbContext.Add(buyer);
            }

            return (List < Buyer >) inscription.Buyers;
        }

        private List<Seller> PopulateSellers(Inscription inscription,
                            string[] sellerRuts,
                            double[] sellerRoyalties,
                            bool[] sellerUnaccreditedPer)
        {
            inscription.Sellers = new List<Seller>();

            for (int i = 0; i < sellerRuts.Length; i++)
            {
                var buyer = new Seller
                {
                    Rut = sellerRuts[i],
                    RoyaltyPercentage = sellerRoyalties[i],
                    UnaccreditedRoyaltyPercentage = sellerUnaccreditedPer[i]
                };
                buyer.Inscription = inscription;

                _dbContext.Add(buyer);
            }

            return (List<Seller>)inscription.Sellers;
        }

        private void updatePreviousMultiOwner(Inscription inscription)
        {
            var latestMultiOwners = GetActiveOwnersInMultiOwnerTable(inscription);

            foreach (var multiOwner in latestMultiOwners)
            {
                if (multiOwner.InitialEffectiveYear < inscription.InscriptionDate.Year)
                {
                    multiOwner.FinalEffectiveYear = ValidateInitialEffectiveYear(inscription.InscriptionDate.Year - 1);
                }
            }

            _dbContext.SaveChanges();
        }

        private List<MultiOwner> GetActiveOwnersInMultiOwnerTable(Inscription inscription)
        {
            var latestMultiOwners = _dbContext.MultiOwners
                .Where(m => m.Commune == inscription.Commune
                            && m.Block == inscription.Block
                            && m.Property == inscription.Property
                            && m.FinalEffectiveYear == null)
                .ToList();

            return latestMultiOwners;
        }

        private void AddSellerToMultiOwners(Seller seller)
        {
            MultiOwner newMultiOwner = new MultiOwner();

            newMultiOwner.Commune = seller.Inscription.Commune;
            newMultiOwner.Block = seller.Inscription.Block;
            newMultiOwner.Property = seller.Inscription.Property;
            newMultiOwner.Owner = seller.Rut;
            newMultiOwner.RoyaltyPercentage = seller.RoyaltyPercentage;
            newMultiOwner.Fojas = seller.Inscription.Fojas;
            newMultiOwner.InscriptionYear = seller.Inscription.InscriptionDate.Year;
            newMultiOwner.InscriptionNumber = seller.Inscription.InscriptionNumber;
            newMultiOwner.InscriptionDate = seller.Inscription.InscriptionDate;
            newMultiOwner.InitialEffectiveYear = ValidateInitialEffectiveYear(seller.Inscription.InscriptionDate.Year);
            newMultiOwner.FinalEffectiveYear = null;

            _dbContext.Add(newMultiOwner);
        }

        private void AddBuyerToMultiOwners(Buyer buyer)
        {
            MultiOwner newMultiOwner = new MultiOwner();

            newMultiOwner.Commune = buyer.Inscription.Commune;
            newMultiOwner.Block = buyer.Inscription.Block;
            newMultiOwner.Property = buyer.Inscription.Property;
            newMultiOwner.Owner = buyer.Rut;
            newMultiOwner.RoyaltyPercentage = buyer.RoyaltyPercentage;
            newMultiOwner.Fojas = buyer.Inscription.Fojas;
            newMultiOwner.InscriptionYear = buyer.Inscription.InscriptionDate.Year;
            newMultiOwner.InscriptionNumber = buyer.Inscription.InscriptionNumber;
            newMultiOwner.InscriptionDate = buyer.Inscription.InscriptionDate;
            newMultiOwner.InitialEffectiveYear = ValidateInitialEffectiveYear(buyer.Inscription.InscriptionDate.Year);
            newMultiOwner.FinalEffectiveYear = null;

            _dbContext.Add(newMultiOwner);
        }

        private int ValidateInitialEffectiveYear(int year)
        {
            if (year < YEAR_MINIMUM)
            {
                year = YEAR_MINIMUM;
            }
            return year;
        }
    }
}
