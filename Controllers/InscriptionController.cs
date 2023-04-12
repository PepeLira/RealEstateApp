﻿using RealEstateApp.Data;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;
using RealEstateApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateApp.ViewModels.Insciption;

namespace RealEstateApp.Controllers
{
    public class InscriptionController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public InscriptionController(ApplicationDbContext dbContext)
        {
            applicationDbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Inscription> objInscriptionList = applicationDbContext.Inscriptions.ToList();
            return View(objInscriptionList);
        }

        public IActionResult Create()
        {
            var communeOptions = Enum.GetNames(typeof(CommuneOptions));
            var comuneSelectList = new SelectList(communeOptions);
            var cneOptions = Enum.GetNames(typeof(CneOptions));
            var cneSelectList = new SelectList(cneOptions);

            var buyersOptions = applicationDbContext.Buyers.Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Rut
            }).ToList();

            var sellersOptions = applicationDbContext.Sellers.Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Rut
            }).ToList();

            var viewModel = new CreateViewModel
            {
                NewInscription = new Inscription(),
                AvailableBuyers = buyersOptions,
                AvailableSellers = sellersOptions
            };

            ViewBag.CommuneOptions = comuneSelectList;
            ViewBag.CneOptions = cneSelectList;
            return View(viewModel);
        }

        public ViewResult Details(int id)
        {
            Inscription inscription = applicationDbContext.Inscriptions.Find(id);
            return View(inscription);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateViewModel viewModel)
        {
            var inscription = viewModel.NewInscription;
            Buyer? selected_buyer = applicationDbContext.Buyers.Find(viewModel.SelectedBuyerId);
            Seller? selected_seller = applicationDbContext.Sellers.Find(viewModel.SelectedSellerId);

            if (inscription != null && selected_buyer != null && selected_seller != null)
            {
                selected_buyer.Inscriptions.Add(inscription);
                selected_seller.Inscriptions.Add(inscription);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }
    }
}
