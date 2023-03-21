using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Data;
using RealEstateApp.Models;

namespace RealEstateApp.Controllers
{
    public class MultiOwnerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MultiOwnerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<MultiOwner> objMultiOwnerList = _db.MultiOwners.ToList();
            return View(objMultiOwnerList);
        }
    }
}
