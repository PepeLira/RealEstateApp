using RealEstateApp.Data;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }

        public IActionResult Details(int id)
        {
            Inscription inscription = _db.Inscriptions.Find(id);
            return View(inscription);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inscription obj)
        {
            _db.Inscriptions.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
