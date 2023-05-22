using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var filteredMultiOwners = applicationDbContext.MultiOwners.AsQueryable();
            var communes = filteredMultiOwners.Select(m => m.Commune).Distinct().ToList();
            ViewBag.Communes = new SelectList(communes);

            if (year != null)
            {
                filteredMultiOwners = filteredMultiOwners.Where(
                    multiOwner => multiOwner.InitialEffectiveYear <= year && 
                    (multiOwner.FinalEffectiveYear == null || multiOwner.FinalEffectiveYear >= year)
                    );
            }

            if (!string.IsNullOrEmpty(commune))
            {
                filteredMultiOwners = filteredMultiOwners.Where(multiOwner => multiOwner.Commune.Equals(commune));
            }

            if (block != null)
            {
                filteredMultiOwners = filteredMultiOwners.Where(multiOwner => multiOwner.Block == block);
            }

            if (property != null)
            {
                filteredMultiOwners = filteredMultiOwners.Where(multiOwner => multiOwner.Property == property);
            }

            return View(filteredMultiOwners.ToList());
        }

    }
}
