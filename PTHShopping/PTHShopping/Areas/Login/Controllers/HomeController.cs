using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PTHShopping.Areas.Login.Controllers
{
    [Area("Login")]
    public class HomeController : Controller
    {
        private readonly PTHShoppingContext _context;

        public HomeController(PTHShoppingContext context)
        {
            _context = context;

        }

        public ActionResult Index()
        {
            return View();
        }
  
        [HttpPost]
        public async Task<IActionResult> Index(string sdt, string Password)
        {
            if(sdt == null || Password == null)
            {
                ViewBag.notFound = "0";
                return View();
            }
            //xet trong tai khoan quan tri
            var result = (from a in _context.Accounts
                          where Convert.ToString(a.Sdt)==sdt && Convert.ToString(a.Password) == Password
                          select a).ToList();
           
             if (result.Count() == 0)
             {
                //xet trong tai khoan khach hang
                var kh = (from a in _context.KhachHangs
                              where Convert.ToString(a.Sdt) == sdt && Convert.ToString(a.MatKhau) == Password
                              select a).ToList();
                if (kh.Count() == 0)
                {
                    ViewBag.notFound = "1";
                     return View();
                }
                else
                {
                    KhachHang account = kh[0];
                    ClaimsIdentity userIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                    userIdentity.AddClaim(new Claim(ClaimTypes.Role,"KH"));
                    userIdentity.AddClaim(new Claim(ClaimTypes.Name, account.HoTen));
                    userIdentity.AddClaim(new Claim("SDT", account.Sdt));
                    userIdentity.AddClaim(new Claim("Email", account.Email));
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                    return Redirect("/Home/");
                }
               
             }
             else
             {
                Account account = result[0];
                var Role = (from a in _context.Roles
                            where account.RoleId==a.RoleId
                            select a).ToList()[0];
                ClaimsIdentity userIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, Role.RoleName));
                userIdentity.AddClaim(new Claim(ClaimTypes.Name, account.HoTen));
                userIdentity.AddClaim(new Claim("SDT", account.Sdt));
                userIdentity.AddClaim(new Claim("Email", account.Email));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                return Redirect("/Admin/");
                
             }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Login");
        }
    }
}
