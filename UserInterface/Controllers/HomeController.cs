using BLL.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository repoProduct;
        IRepository<Category> repoCategory;
        public HomeController(IProductRepository repoProduct, IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
            this.repoProduct = repoProduct;
        }
        public IActionResult Index()
        {
            List<Category> categories = repoCategory.GetActives();
            return View(categories);
        }
    }
}
