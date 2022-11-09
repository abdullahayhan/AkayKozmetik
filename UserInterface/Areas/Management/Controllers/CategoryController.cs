using BLL.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Areas.Management.Controllers
{
    [Area("Management")] // başka bir area'da aynı isimli controller açabilirsin karışıklık olmasın diye.
    [Authorize(Policy = "AdminPolicy")]
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
            return RedirectToAction("GetList", "Category", new { area = "Management" });
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
            return RedirectToAction("GetList","Category", new { area = "Management" });
        }
        public IActionResult Delete(int id)
        {
            repoCategory.Delete(id);
            return RedirectToAction("GetList", "Category", new { area = "Management" });
        }
    }
}
