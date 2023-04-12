using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Data;
using RealEstateApp.Models;
using System.Linq.Expressions;

namespace RealEstateApp.Controllers
{
    public class MultiOwnerController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public MultiOwnerController(ApplicationDbContext dbContext)
        {
            applicationDbContext = dbContext;
        }

        public ActionResult Index(int? year, string commune, int? block, int? property)
        {
            var multiOwners = applicationDbContext.MultiOwners.AsQueryable();

            if (year != null)
            {
                multiOwners = multiOwners.Where(multiOwner => multiOwner.InscriptionYear == year);
            }

            if (!string.IsNullOrEmpty(commune))
            {
                multiOwners = multiOwners.Where(multiOwner => multiOwner.Commune.Equals(commune));
            }

            if (block != null)
            {
                multiOwners = multiOwners.Where(multiOwner => multiOwner.Block == block);
            }

            if (property != null)
            {
                multiOwners = multiOwners.Where(multiOwner => multiOwner.Property == property);
            }

            return View(multiOwners.ToList());
        }
    }
}
