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

            var viewModel = new CreateViewModel
            {
                NewInscription = new Inscription(),               
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

            if (inscription != null )
            {
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }
    }
}
