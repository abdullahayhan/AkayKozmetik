using BLL.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    public class SharedController : Controller
    {
        IRepository<Category> repoCategory;
        public SharedController(IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
        }
        public IActionResult _Layout()
        {
            this.ViewData["cats"] = this.repoCategory.GetActives();
            return View();
        }
    }
}
