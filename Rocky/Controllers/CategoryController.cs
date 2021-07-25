using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// using System.Collections.Generic.IEnumerable<T>;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.Sig;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
            {
            IEnumerable<Category> objList = _db.Category;
  
                // objList=  objList.Where(x => x.DisplayOrder == 1);
                
        
            return View(objList);
        }

        //get create
        public IActionResult Create()
        {
            return View();
        }

        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            // ReSharper disable once InvertIf
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }

            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            // ReSharper disable once InvertIf
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // public IActionResult Delete(int? id)
        // {
        //     if (id == null||id==0)
        //     {
        //         return NotFound();  
        //     }
        //
        //     var obj=_db.Category.Find(id);
        //     if (obj== null)
        //     {
        //         return NotFound();
        //     }
        //     return View(obj);
        // }
    
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);
            // ReSharper disable once InvertIf
            if (obj == null)
            {
                return NotFound();
            }

            _db.Category.Remove(obj);
            _db.SaveChanges();
            Console.WriteLine("Here");
            return RedirectToAction("Index","Category");
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }

            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        
    }
}