using BLL.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository repoProduct;
        IRepository<Category> repoCategory;
        IRepository<AppUser> repoUser;
        public HomeController(IProductRepository repoProduct, IRepository<Category> repoCategory, IRepository<AppUser> repoUser)
        {
            this.repoCategory = repoCategory;
            this.repoProduct = repoProduct;
            this.repoUser = repoUser;
        }
        public IActionResult Index()
        {
            List<Product> products = repoProduct.GetProducts();
            List<Category> categories = repoCategory.GetActives();
            return View((categories,products));
        }
        public IActionResult AllProduct()
        {
            List<Category> categories = repoCategory.GetActives();
            List<Product> products = repoProduct.GetProducts();
            return View((categories,products));
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult LoginAsAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsAdmin(AppUser user)
        {
            AppUser selectedUser = repoUser.Default(x => x.UserName == user.UserName &&
               x.Status != Directory.MODEL.Enums.DataStatus.Deleted);
            if (selectedUser==null)
            {
                return View();
            }
            else
            {
                bool isValid = BCrypt.Net.BCrypt.Verify(user.Password, selectedUser.Password);
                if (isValid)
                {
                    List<Claim> claims = new List<Claim>() {

                        new Claim("userName",selectedUser.UserName),
                        new Claim("userId",selectedUser.ID.ToString()),
                        new Claim("role",selectedUser.Role.ToString())
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    if (selectedUser.Role == MODEL.Enums.Role.admin)
                    {
                        return RedirectToAction("GetList", "Product", new {area="Management"});
                    }
                }
            }
            return View();
        }
    }
}
