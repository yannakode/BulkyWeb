using BulkyWeb.Date;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
namespace BulkyWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _db.Products.ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if(p.Name == p.Price.ToString())
            {
                ModelState.AddModelError("", "The price cannot exactly match the name");
            }
            if(ModelState.IsValid)
            {
                _db.Products.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();           
        }
    }
}
