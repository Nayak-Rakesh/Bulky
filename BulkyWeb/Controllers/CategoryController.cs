using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryController(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
             List<Category> categories = _dbContext.Categories.ToList();
            return View(categories);
            //return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
