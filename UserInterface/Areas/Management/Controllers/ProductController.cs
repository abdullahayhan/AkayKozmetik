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
    [Area("Management")]
    [Authorize(Policy = "AdminPolicy")]
    public class ProductController : Controller
    {
        IProductRepository repoProduct;
        IRepository<Category> repoCategory;
        public ProductController(IProductRepository repoProduct, IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
            this.repoProduct = repoProduct;
        }
        public IActionResult GetList()
        {
            List<Product> products = repoProduct.GetProducts();
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
            return RedirectToAction("GetList","Product",new {area="Management" });
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
            return RedirectToAction("GetList", "Product", new { area = "Management" });
        }
        public IActionResult Delete(int id)
        {
            repoProduct.Delete(id);
            return RedirectToAction("GetList", "Product", new { area = "Management" });
        }
       
    }
}
