using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTHShopping.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin,Staff")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly PTHShoppingContext _context;

        public HomeController(PTHShoppingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var kh = _context.KhachHangs.Where(x => x.Active == true).ToList();
            var news = _context.Trangs.Where(x => x.Published == true).OrderByDescending(x=>x.NgayTao).ToList();
            var sp = _context.SanPhams.AsNoTracking().Include(x => x.Cat).OrderByDescending(x => x.Slban).ToList();
            var khNew = _context.KhachHangs.Where(x => x.Active == true).OrderByDescending(x => x.NgayTao).ToList();
            ViewBag.SLKH = kh.Count;
            ViewBag.sp = sp;
            ViewBag.kh = khNew;
            ViewBag.news = news;
            return View();
        }
    }
}
