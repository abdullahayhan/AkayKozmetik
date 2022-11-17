using BLL.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    public class CategoriesViewComponent : ViewComponent
    {
        IRepository<Category> repoCategory;
        public CategoriesViewComponent(IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
        }
        async public Task<IViewComponentResult> InvokeAsync()
        {
            return View("Categories" , this.repoCategory.GetActives());
        }
    }
}
