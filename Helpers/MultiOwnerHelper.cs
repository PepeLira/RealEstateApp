using RealEstateApp.Data;
using RealEstateApp.Models;
using System;

namespace RealEstateApp.Helpers
{
    public class MultiOwnerHelper
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Buyer? _buyer;

        public MultiOwnerHelper(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _buyer = dbContext.Buyers.Where(e => e.Id > 0)
            .OrderByDescending(e => e.Id)
            .FirstOrDefault();

            AddMultiOwners(_buyer);
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
            newMultiOwner.InitialEffectiveYear = buyer.Inscription.InscriptionDate.Year;
            newMultiOwner.FinalEffectiveYear = null;

            _dbContext.Add(newMultiOwner);

            _dbContext.SaveChanges();
        }
    }
}
