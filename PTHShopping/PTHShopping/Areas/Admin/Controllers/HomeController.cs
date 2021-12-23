using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Helper;
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
            ViewBag.now = DateTime.Now.Date.ToShortDateString();
            var thang = DateTime.Now.Month;
            var nam = DateTime.Now.Year;
            ViewBag.CurrentMonth = thang;
            var ctdh = _context.CtdonHangs
                .Where(x=>x.IddonHangNavigation.NgayGiaoHang.Value.Month == thang && x.IddonHangNavigation.NgayGiaoHang.Value.Year == nam)
                .Where(x=>x.IddonHangNavigation.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã giao"))
                .Select(x => x.Tong).ToList();
            var sum = 0.0;
            if (ctdh!= null)
            {
                for(int i = 0; i < ctdh.Count; i++)
                {
                    sum += (double)ctdh[i];
                }
            }
            ViewBag.danhso = sum;
            var dh = _context.DonHangs.ToList();
            ViewBag.sodh = dh.Count;
            var magiamgia = _context.MaGiamGia.ToList();
            if (magiamgia != null)
            {
                ViewBag.magiamgia = magiamgia;
            }
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


        [Route("Admin/Home/magiamgia/{ma?}")]
        public async Task<IActionResult> magiamgia(string ma)
        {
            if(ma==null || ma == string.Empty)
            {
                return Redirect("/Admin");
            }
            var str = ma.Substring(ma.Length - 2, 2);
            if (int.TryParse(str, out int value))
            {
                MaGiamGium sale = new MaGiamGium();
                sale.Ma = RandomID.generateID();
                sale.Magiamgia = ma;
                _context.Add(sale);
                await _context.SaveChangesAsync();
                var url = $"/Admin";
                return Json(new { status = "success", redirectUrl = url });
            }
            return Redirect("/Admin");

        }
        [Route("Admin/Home/del/{ma?}")]
        public async Task<IActionResult> del(string ma)
        {
            var sale = _context.MaGiamGia.FindAsync(ma);
            _context.MaGiamGia.Remove(await sale);
            await _context.SaveChangesAsync();
            return Redirect("/Admin");
        }
    }
}
