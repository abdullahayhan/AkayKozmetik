using BLL.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> repoProduct;
        IRepository<Category> repoCategory;
        public ProductController(IRepository<Product> repoProduct, IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
            this.repoProduct = repoProduct;
        }
        public IActionResult GetList()
        {
            List<Product> products = repoProduct.GetActives();
            return View(products);
        }
        public IActionResult Create()
        {
            List<Category> categories = repoCategory.GetActives();
            return View((new Product(),categories));
        }
        [HttpPost]
        public IActionResult Create([Bind(Prefix = "Item1")] Product product)
        {
            repoProduct.Add(product);
            return RedirectToAction("GetList");
        }

        public IActionResult Edit(int id)
        {
            Product product = repoProduct.GetById(id);
            List<Category> categories = repoCategory.GetActives();
            return View((product,categories));
        }
        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "Item1")] Product product)
        {
            repoProduct.Update(product);
            return RedirectToAction("GetList");
        }

        public IActionResult Delete(int id)
        {
            repoCategory.Delete(id);
            return RedirectToAction("GetList");
        }
    }
}
