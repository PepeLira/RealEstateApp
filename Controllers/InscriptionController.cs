using RealEstateApp.Data;
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
        private readonly ApplicationDbContext _db;

        public InscriptionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Inscription> objInscriptionList = _db.Inscriptions.ToList();
            return View(objInscriptionList);
        }
        public IActionResult Create()
        {
            var communeOptions = Enum.GetNames(typeof(CommuneOptions));
            var ComuneSelectList = new SelectList(communeOptions);

            var cneOptions = Enum.GetNames(typeof(CneOptions));
            var CneSelectList = new SelectList(cneOptions);

            var buyersOptions = _db.Buyers.Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Rut
            }).ToList();

            var sellersOptions = _db.Sellers.Select(item => new SelectListItem
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

            ViewBag.CommuneOptions = ComuneSelectList;
            ViewBag.CneOptions = CneSelectList;

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            Inscription inscription = _db.Inscriptions.Find(id);
            return View(inscription);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateViewModel viewModel)
        {
            var inscription = viewModel.NewInscription;
            Buyer? selected_buyer = _db.Buyers.Find(viewModel.SelectedBuyerId);
            Seller? selected_seller = _db.Sellers.Find(viewModel.SelectedSellerId);

            if (inscription != null && selected_buyer != null && selected_seller != null)
            {
                selected_buyer.Inscriptions.Add(inscription);
                selected_seller.Inscriptions.Add(inscription);

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
    }
}
