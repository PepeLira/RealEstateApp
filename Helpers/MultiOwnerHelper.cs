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
            newMultiOwner.Fojas = buyer.Inscription.Fojas;
            newMultiOwner.InscriptionYear = buyer.Inscription.InscriptionDate.Year;
            newMultiOwner.InscriptionNumber = buyer.Inscription.InscriptionNumber;
            newMultiOwner.InscriptionDate = buyer.Inscription.InscriptionDate;
            newMultiOwner.InitialEffectiveYear = ValidateInitialEffectiveYear(buyer.Inscription.InscriptionDate.Year);
            newMultiOwner.FinalEffectiveYear = null;

            _dbContext.Add(newMultiOwner);


            _dbContext.SaveChanges();
        }

        public int ValidateInitialEffectiveYear(int year)
        {
            if (year < 2019)
            {
                year = 2019;
            }
            return year;
        }

        public void ValidateActiveMultiOwnerYear(MultiOwner multiOwner)
        {
            var latestMultiOwner = _dbContext.MultiOwners
            .OrderByDescending(mo => mo.InscriptionDate)
            .FirstOrDefault();

            

        }

        public bool IsMultiOwner1LaterThanMultiOwner2(MultiOwner multiOwner1, MultiOwner multiOwner2)
        {
            return multiOwner1.InscriptionDate > multiOwner2.InscriptionDate;
        }
    }
}
