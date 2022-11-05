using BLL.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category> repoCategory;
        public CategoryController(IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
        }
        public IActionResult GetList()
        {
            List<Category> categories = repoCategory.GetActives();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            repoCategory.Add(category);
            return RedirectToAction("GetList");
        }
        public IActionResult Edit(int id)
        {
            Category category = repoCategory.GetById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            repoCategory.Update(category);
            return RedirectToAction("GetList");
        }
        public IActionResult Delete(int id)
        {
            repoCategory.Delete(id);
            return RedirectToAction("GetList");
        }
    }
}
