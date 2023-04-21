using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Models;
namespace BulkyWeb.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
