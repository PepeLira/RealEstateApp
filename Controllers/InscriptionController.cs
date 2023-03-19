using RealEstateApp.Data;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;

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
    }
}
