using RealEstateApp.Data;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var options = Enum.GetNames(typeof(CommuneOptions));
            var selectList = new SelectList(options);

            ViewBag.CommuneOptions = selectList;

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
