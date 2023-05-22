using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data;
using RealEstateApp.Models;
using System;

namespace RealEstateApp.Helpers
{
    public class RegularizacionDePatrimonioHelper
    {   
        const int YEAR_MINIMUM = 2019;
        private readonly ApplicationDbContext _dbContext;
        private readonly IEnumerable<Buyer> _buyers;
        private readonly Inscription? _newInscription;

        public RegularizacionDePatrimonioHelper(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _newInscription = dbContext.Inscriptions.Where(e => e.AttentionID > 0)
            .OrderByDescending(e => e.AttentionID)
            .FirstOrDefault();

            _buyers = dbContext.Buyers.Where(b => b.Inscription.AttentionID == _newInscription.AttentionID);

            double remainingBuyersPercentage = RemainingRoyaltyPercentage(_buyers);
            int numBuyers = NotCreditedRoyaltyPercentageBuyers(_buyers);

            foreach (var buyer in _buyers)
            {
                AddMultiOwners(buyer, remainingBuyersPercentage, numBuyers);
            }
        }

        public void AddMultiOwners(Buyer buyer, double remainingBuyersPercentage, int numBuyers)
        {
            MultiOwner newMultiOwner = new MultiOwner();

            newMultiOwner.Commune = buyer.Inscription.Commune;
            newMultiOwner.Block = buyer.Inscription.Block;
            newMultiOwner.Property = buyer.Inscription.Property;
            newMultiOwner.Owner = buyer.Rut;
            newMultiOwner.RoyaltyPercentage = ValidateRoyaltyPercentage(buyer.RoyaltyPercentage, remainingBuyersPercentage, numBuyers);
            newMultiOwner.Fojas = buyer.Inscription.Fojas;
            newMultiOwner.InscriptionYear = buyer.Inscription.InscriptionDate.Year;
            newMultiOwner.InscriptionNumber = buyer.Inscription.InscriptionNumber;
            newMultiOwner.InscriptionDate = buyer.Inscription.InscriptionDate;
            newMultiOwner.InitialEffectiveYear = ValidateInitialEffectiveYear(buyer.Inscription.InscriptionDate.Year);
            newMultiOwner.FinalEffectiveYear = null;

            _dbContext.Add(newMultiOwner);
        }

        public double ValidateRoyaltyPercentage(double royaltyPercentage, double remainingBuyersPercentage, int numBuyers)
        {
            if (royaltyPercentage == 0)
            {
                royaltyPercentage = remainingBuyersPercentage / numBuyers;
            }

            return royaltyPercentage;
        }

        public double RemainingRoyaltyPercentage(IEnumerable<Buyer> buyers)
        {
            double totalBuyersPercentage = 0;
            double maxPercentage = 100;

            foreach (var buyer in buyers)
            {
                if (buyer.RoyaltyPercentage > 0)
                {
                    totalBuyersPercentage += buyer.RoyaltyPercentage;
                }
            }

            double remainingBuyersPercentage = maxPercentage - totalBuyersPercentage;
            return remainingBuyersPercentage;
        }

        public int NotCreditedRoyaltyPercentageBuyers(IEnumerable<Buyer> buyers)
        {
            int buyersQuantity = 0;

            foreach (var buyer in buyers)
            {
                if (buyer.RoyaltyPercentage == 0)
                {
                    buyersQuantity += 1;
                }
            }

            return buyersQuantity;
        }

        public int ValidateInitialEffectiveYear(int year)
        {
            if (year < YEAR_MINIMUM)
            {
                year = YEAR_MINIMUM;
            }

            return year;
        }

        public void ValidateActiveMultiOwnerYear(MultiOwner newMultiOwner)
        { 
            var latestMultiOwner = _dbContext.MultiOwners.Where(mo => mo.InscriptionNumber== newMultiOwner.InscriptionNumber)
            .OrderByDescending(mo => mo.InscriptionDate)
            .FirstOrDefault();

            if (IsMultiOwner1LaterThanMultiOwner2(newMultiOwner, latestMultiOwner))
            {
                latestMultiOwner.InitialEffectiveYear = newMultiOwner.InscriptionYear - 1;
            }
            else
            {
                newMultiOwner.InitialEffectiveYear = latestMultiOwner.InscriptionYear - 1;
            }
        }

        public bool IsMultiOwner1LaterThanMultiOwner2(MultiOwner multiOwner1, MultiOwner multiOwner2)
        {
            return multiOwner1.InscriptionDate > multiOwner2.InscriptionDate;
        }
    }
}
