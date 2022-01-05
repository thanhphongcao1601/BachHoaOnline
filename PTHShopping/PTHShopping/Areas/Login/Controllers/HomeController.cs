using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Models;
using PTHShopping.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Net.Mail;
using System.Net;

namespace PTHShopping.Areas.Login.Controllers
{
    [Area("Login")]
    public class HomeController : Controller
    {
        private readonly PTHShoppingContext _context;
        public INotyfService _notifService { get; }

        public HomeController(PTHShoppingContext context, INotyfService notifService)
        {
            _context = context;
            _notifService = notifService;
        }

        public ActionResult Index()
        {
            return View();
        }
  
        [HttpPost]
        public async Task<IActionResult> Index(string sdt, string Password, Boolean nhomk)
        {
            
            ViewBag.sdt = sdt;
            if(sdt == null || Password == null)
            {
                ViewBag.notFound = "0";
                return View();
            }
 
            //xet trong tai khoan quan tri
            var result = (from a in _context.Accounts
                          where Convert.ToString(a.Sdt).Trim() == sdt.Trim() && a.Active ==true
                          select a).ToList();
           
             if (result.Count() == 0)
             {
                //xet trong tai khoan khach hang
                var kh = (from a in _context.KhachHangs
                              where Convert.ToString(a.Sdt) == sdt && a.Active == true
                          select a).ToList();
                if (kh.Count() == 0)
                {
                    ViewBag.notFound = "1";
                     return View();
                }
                else
                {
                    if (BCrypt.Net.BCrypt.Verify(Password, kh[0].MatKhau))
                    {
                        KhachHang account = kh[0];
                        DateTime date = DateTime.Now;
                        account.LastLogin = date;
                        _context.Update(account);
                        await _context.SaveChangesAsync();
                        ClaimsIdentity userIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                        userIdentity.AddClaim(new Claim(ClaimTypes.Role, "KH"));
                        userIdentity.AddClaim(new Claim(ClaimTypes.Name, account.HoTen));
                        userIdentity.AddClaim(new Claim("SDT", account.Sdt));
                        userIdentity.AddClaim(new Claim("Email", account.Email));
                        userIdentity.AddClaim(new Claim("IdKH",account.IdkhachHang));
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                        return Redirect("/Home");
                    }
                    else
                    {
                        ViewBag.notFound = "1";
                        return View();
                    }
                }
               
             }
             else
             {
                if (BCrypt.Net.BCrypt.Verify(Password, result[0].Password))
                {
                    Account account = result[0];
                    DateTime date = DateTime.Now;
                    account.LastLogin = date;
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                    var Role = (from a in _context.Roles
                                where account.RoleId == a.RoleId
                                select a).ToList()[0];
                    ClaimsIdentity userIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                    userIdentity.AddClaim(new Claim(ClaimTypes.Role, Role.RoleName));
                    userIdentity.AddClaim(new Claim(ClaimTypes.Name, account.HoTen));
                    userIdentity.AddClaim(new Claim("SDT", account.Sdt));
                    userIdentity.AddClaim(new Claim("Email", account.Email));
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                    if (Role.RoleName.Contains("Shipper")){
                        return Redirect("/Shipper");
                    }
                    return Redirect("/Admin");
                }
                else
                {
                    ViewBag.notFound = "1";
                    return View();
                }
                
             }
        }

        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }

        public IActionResult Logout()
        {
            var myCart = Carts;
            myCart.Clear();
            HttpContext.Session.Set("GioHang", myCart);
            HttpContext.SignOutAsync();
            return Redirect("/Login");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string HoTen, string Sdt, string mail, string gioitinh, string pass1, string pass2)
        {
            ViewBag.ten = HoTen;
            ViewBag.phone = Sdt;
            ViewBag.mail = mail;
            ViewBag.gioitinh = gioitinh;
            if (ModelState.IsValid)
            {
                var err = 0;
                if(HoTen==null || HoTen == string.Empty)
                {
                    ViewBag.name = "ErrName";
                    err = 1;
                }
                if (Sdt == null || Sdt == string.Empty)
                {
                    ViewBag.sdt = "ErrSdt";
                    err = 1;
                }
                if (mail == null || mail == string.Empty)
                {
                    ViewBag.errmail = "ErrMail";
                    err = 1;
                }
                if (pass1 == null || pass1 == string.Empty || pass1 == null || pass1 == string.Empty)
                {
                    ViewBag.passN = "ErrPassN";
                    err = 1;
                }
                if (pass1 != pass2)
                {
                    ViewBag.pass = "ErrPass";
                    err = 1;
                }
             
                KhachHang khachHang = new KhachHang();
                var id = RandomID.generateID();
                khachHang.IdkhachHang = id;
                var lis_IdKH = _context.KhachHangs.Select(x => x.IdkhachHang).ToList();
                var sdt = _context.KhachHangs.Where(x => x.Sdt == Sdt).ToList();
                if (sdt.Count!=0)
                {
                    ViewBag.sdtTrung = sdt[0].Sdt;
                    err = 1;

                }
                if (err == 1)
                {
                    return View();
                }

                khachHang.Active = true;
                khachHang.HoTen = HoTen;
                khachHang.Sdt = Sdt;
                khachHang.Email = mail;
                khachHang.Giotinh = true ? gioitinh == "1" : false;
                khachHang.Salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                khachHang.MatKhau = BCrypt.Net.BCrypt.HashPassword(pass1, khachHang.Salt);
                DateTime localDate = DateTime.Now;
                khachHang.NgayTao = localDate;
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
            }
            return Redirect("/Login");
        }
        public async Task<IActionResult> Reset(string sdt)
        {
            //Sent mail
            try {
                var mail = "";
                var newpass = "";
                if (sdt != null)
                {
                    var kh = _context.KhachHangs.Where(x => x.Sdt == sdt).ToList();
                    if (kh != null && kh.Count > 0)
                    {
                        mail = kh[0].Email;
                        newpass = PTHShopping.Helper.RandomID.generateID();
                        kh[0].MatKhau = BCrypt.Net.BCrypt.HashPassword(newpass, kh[0].Salt);
                        _context.Update(kh[0]);
                        await _context.SaveChangesAsync();
                    }
                }
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("bachhoaonlinepth@gmail.com", "CTPctp123456"),
                    EnableSsl = true,
                };

                smtpClient.Send("bachhoaonlinepth@gmail.com", mail, "[PTHShoppping] Reset Password", "Mật khẩu mới của bạn là: "+ newpass + "\nHãy đổi lại mật khẩu mới để tăng tính bảo mật! \n\n\nCửa hàng Bách Hóa Online - PTHShopping");
                _notifService.Success("Đã reset lại mật khẩu, vui lòng kiểm tra mail!");

                
            }
            catch (SmtpException e) { 
                _notifService.Error("Đã xảy ra lỗi: "+e.ToString());
            }
            return Redirect("/Login");
        }
    }
}
