using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data;
using RealEstateApp.Models;
using System;

namespace RealEstateApp.Helpers
{
    public class MultiOwnerHelper
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEnumerable<Buyer> _buyers;
        private readonly Inscription? _newInscription;

        public MultiOwnerHelper(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _newInscription = dbContext.Inscriptions.Where(e => e.AttentionID > 0)
            .OrderByDescending(e => e.AttentionID)
            .FirstOrDefault();

            _buyers = dbContext.Buyers.Where(b => b.Inscription.AttentionID == _newInscription.AttentionID);

            foreach (var buyer in _buyers)
            {
                AddMultiOwners(buyer);
            }
        }

        public void AddMultiOwners(Buyer buyer)
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

        public int ValidateInitialEffectiveYear(int year)
        {
            if (year < 2019)
            {
                year = 2019;
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
