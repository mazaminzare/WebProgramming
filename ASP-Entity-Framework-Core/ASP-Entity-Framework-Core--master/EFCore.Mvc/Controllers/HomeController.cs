using EFCore.Data.Context;
using EFCore.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
    

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {
            List<Category> list = _context.Categories.ToList();
            return View(list);
        }

        public IActionResult Upsert(int? id) 
        {
            Category category = new Category();
            if (id == null)
                return View(category);

            category = _context.Categories.FirstOrDefault(c=>c.CategoryId==id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Upsert(Category category) 
        {
            if (category.CategoryId == 0)
                _context.Add(category);
            else 
            {
            
                _context.Categories.Update(category);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id) 
        {
            var category = _context.Categories.Find(id);
            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddMultipleRecord() 
        {
            for (int i = 0; i < 9; i++)
            {
                _context.Categories.Add(new Category()
                {
                    Name = "category" + i
                });


            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        
        }



        public IActionResult AddMultipleRecord2()
        {
            List<Category> list = new List<Category>();

            for (int i = 0; i < 9; i++)
            {

                list.Add(new Category() 
                {
                    Name=$"category {i} add range" 
                });

            }
            _context.Categories.AddRange(list);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult RemoveRange() 
        {
            List<Category> list = _context.Categories.OrderByDescending(c=>c.CategoryId).Take(5).ToList();
            _context.Categories.RemoveRange(list);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
    }
}