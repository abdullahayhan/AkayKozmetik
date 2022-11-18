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
        IProductRepository repoProduct;
        IRepository<Category> repoCategory;
        public ProductController(IProductRepository repoProduct, IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
            this.repoProduct = repoProduct;
        }

        public IActionResult ProductDetail(int id)
        {
            Product product = repoProduct.GetProducts().Find(x=>x.ID == id);
            List<Product> productsByCategory = repoProduct.GetProductByCategory(product.Category.CategoryName,product.ProductName);
            return View((product,productsByCategory));
        }
        public IActionResult ProductByCategoryId(int id)
        {
            Category category = repoCategory.GetById(id);
            List<Category> categories = repoCategory.GetActives();
            List<Product> productsByCategory = repoProduct.GetProductByCategory(category.CategoryName,null);
            return View("~/Views/Home/AllProduct.cshtml", (categories, productsByCategory));
        }
        public IActionResult GetProductByPrice(int id)
        {
            List<Product> products = repoProduct.GetProductsByPrice(id);
            List<Category> categories = repoCategory.GetActives();
            return View("~/Views/Home/AllProduct.cshtml", (categories, products));
        }
    }
}
