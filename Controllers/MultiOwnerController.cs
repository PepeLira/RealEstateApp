﻿using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Data;
using RealEstateApp.Models;
using System.Linq.Expressions;

namespace RealEstateApp.Controllers
{
    public class MultiOwnerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MultiOwnerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index(int? year, string commune, int? block, int? property)
        {
            var multiOwners = _db.MultiOwners.AsQueryable();

            if (year != null)
            {
                multiOwners = multiOwners.Where(m => m.InscriptionYear == year);
            }

            if (!string.IsNullOrEmpty(commune))
            {
                multiOwners = multiOwners.Where(m => m.Commune.Equals(commune));
            }

            if (block != null)
            {
                multiOwners = multiOwners.Where(m => m.Block == block);
            }

            if (property != null)
            {
                multiOwners = multiOwners.Where(m => m.Property == property);
            }

            return View(multiOwners.ToList());
        }
    }
}
