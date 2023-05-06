using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.DataAccess.Migrations
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(p);
                _unitOfWork.Save();
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
            Product? productFromDb = _unitOfWork.Product.Get(u=>u.Id == id);
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
                _unitOfWork.Product.Update(p);
                _unitOfWork.Save();
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
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {           
            Product? productObj = _unitOfWork.Product.Get(u => u.Id == id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(productObj);
            _unitOfWork.Save();
            TempData["success"] = "Product has been deleted";
            return RedirectToAction("Index");
        }
    }
}
