using BulkyWeb.Date;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();           
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _db.Products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {           
            if (ModelState.IsValid)
            {
                _db.Products.Update(p);
                _db.SaveChanges();
                TempData["success"] = "Product has been edited";
                return RedirectToAction("Index");
            }
            return View();
        }
   
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _db.Products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {           
            Product? productObj = _db.Products.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _db.Products.Remove(productObj);
            _db.SaveChanges();
            TempData["success"] = "Product has been deleted";
            return RedirectToAction("Index");
        }
    }
}
