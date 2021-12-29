using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PTHShopping.Models;

namespace PTHShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Staff")]
    public class ThongkeController : Controller
    {
        private readonly PTHShoppingContext _context;

        public ThongkeController(PTHShoppingContext context)
        {
            _context = context;
        }

       
        [Route("/Admin/Thongke")]
        [Route("/Admin/Thongke/{date?}")]
        public IActionResult Index(string date)
        {

            //lay thang hien tai
            var thang = DateTime.Now.Month;
            ViewBag.CurrentMonth = thang;
            var nam = DateTime.Now.Year;
            ViewBag.CurrentYear = nam;
            //

            //lay thong tin so  luong
            var kh = _context.KhachHangs.Where(x => x.Active == true).ToList();
            ViewBag.sokhachhang = kh.Count;
            var dh = _context.DonHangs.ToList();
            ViewBag.sodonhang = dh.Count;
            var tt = _context.Trangs.Where(x => x.Published == true).ToList();
            ViewBag.sotintuc = tt.Count;
            var sp = _context.SanPhams.Where(x => x.Active == true).ToList();
            ViewBag.sosanpham = sp.Count;
            //
            //san pham ban chay
            var spbc = _context.SanPhams.AsNoTracking().Include(x => x.Cat).OrderByDescending(x => x.Slban).ToList();
            ViewBag.sp = spbc;
            //san pham chay hang
            var sphethang = _context.SanPhams.AsNoTracking()
                .Include(x => x.Cat)
                .Where(x=>x.UnitsInStock<10)
                .OrderByDescending(x => x.UnitsInStock).ToList();
            ViewBag.sphh = sphethang;

            //khach hang tiem nang
            var khtn = _context.DonHangs
               .Where(x => !x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã hủy"))
               .AsEnumerable()
               .Where(x=>x.IdkhachHangNavigation!=null)
               .GroupBy(x => x.IdkhachHangNavigation)
               .Select(x => new { kh = x.Key, count = x.Count()})
               .OrderByDescending(x => x.count)
               .ToList();
            var newkhtn = new List<khachhangtiemnang>();
            foreach(var x in khtn)
            {
                newkhtn.Add(new khachhangtiemnang { kh = x.kh, count = x.count });
            }
            ViewBag.c = khtn.Count;
            ViewData["khtn"] = newkhtn;

            //khach hang moi
            var khNew = _context.KhachHangs.Where(x => x.Active == true).OrderByDescending(x => x.NgayTao).ToList();
            ViewBag.khm = khNew;
            //du lieu bieu do tron
            ViewBag.dagiao = _context.DonHangs
                .Where(x=>x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã giao"))
                .Where(x => x.Deleted == false)
                .Where(x=>x.NgayDatHang.Value.Month == thang && x.NgayDatHang.Value.Year == nam)
                .Where(x => x.Deleted == false)
                .ToList().Count;
            ViewBag.danggiao = _context.DonHangs
                .Where(x=>x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đang giao"))
                .Where(x=>x.NgayDatHang.Value.Month == thang && x.NgayDatHang.Value.Year == nam)
                .Where(x => x.Deleted == false)
                .ToList().Count;
            ViewBag.chuagiao = _context.DonHangs
                .Where(x=>x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Chưa giao"))
                .Where(x=>x.NgayDatHang.Value.Month == thang && x.NgayDatHang.Value.Year == nam)
                .Where(x => x.Deleted == false)
                .ToList().Count;
            ViewBag.dahuy = _context.DonHangs
                .Where(x=>x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã hủy"))
                .Where(x=>x.NgayDatHang.Value.Month == thang && x.NgayDatHang.Value.Year == nam)
                .Where(x => x.Deleted == false)
                .ToList().Count;
            //don hang hoan thanh trong thang
            var dhht = _context.DonHangs.Where(x => x.NgayGiaoHang.Value.Month == thang && x.NgayGiaoHang.Value.Year == nam).ToList();
            ViewBag.dhht = dhht;

            //loc theo ngay
            if (date != null)
            {
                ViewBag.date = DateTime.Parse(date).ToShortDateString();
                //
                var dagiao = _context.DonHangs
                    .Where(x => x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã giao"))
                    .Where(x => x.NgayDatHang.Value.Date == DateTime.Parse(date))
                    .ToList();
                ViewBag.sldagiao = dagiao.Count;
                var ctdh = _context.CtdonHangs
                   .Where(x => x.IddonHangNavigation.NgayDatHang.Value.Date == DateTime.Parse(date))
                   .Where(x => x.IddonHangNavigation.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã giao"))
                   .Select(x => x.Tong).ToList();
                var sum = 0.0;
                if (ctdh != null)
                {
                    for (int i = 0; i < ctdh.Count; i++)
                    {
                        sum += (double)ctdh[i];
                    }

                }
                ViewBag.slspdagiao = ctdh.Count;
                ViewBag.dsdagiao = sum;
                //
                //
                var danggiao = _context.DonHangs
                    .Where(x => x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đang giao"))
                    .Where(x => x.NgayDatHang.Value.Date == DateTime.Parse(date))
                    .ToList();
                ViewBag.sldanggiao = danggiao.Count;
                var ctdh2 = _context.CtdonHangs
                   .Where(x => x.IddonHangNavigation.NgayDatHang.Value.Date == DateTime.Parse(date))
                   .Where(x => x.IddonHangNavigation.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đang giao"))
                   .Select(x => x.Tong).ToList();
                var sum2 = 0.0;
                if (ctdh2 != null)
                {
                    for (int i = 0; i < ctdh2.Count; i++)
                    {
                        sum2 += (double)ctdh2[i];
                    }

                }
                ViewBag.dsdanggiao = sum2;
                ViewBag.slspdanggiao = ctdh2.Count;
                //
                //
                var chuagiao = _context.DonHangs
                    .Where(x => x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Chưa giao"))
                    .Where(x => x.NgayDatHang.Value.Date == DateTime.Parse(date))
                    .ToList();
                ViewBag.slchuagiao = chuagiao.Count;
                var ctdh3 = _context.CtdonHangs
                   .Where(x => x.IddonHangNavigation.NgayDatHang.Value.Date == DateTime.Parse(date))
                   .Where(x => x.IddonHangNavigation.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Chưa giao"))
                   .Select(x => x.Tong).ToList();
                var sum3 = 0.0;
                if (ctdh3 != null)
                {
                    for (int i = 0; i < ctdh3.Count; i++)
                    {
                        sum3 += (double)ctdh3[i];
                    }

                }
                ViewBag.dschuagiao = sum3;
                ViewBag.slspchuagiao = ctdh3.Count;
                //
                //
                var dahuy = _context.DonHangs
                    .Where(x => x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã hủy"))
                    .Where(x => x.NgayDatHang.Value.Date == DateTime.Parse(date))
                    .ToList();
                ViewBag.sldahuy = dahuy.Count;
                var ctdh4 = _context.CtdonHangs
                   .Where(x => x.IddonHangNavigation.NgayDatHang.Value.Date == DateTime.Parse(date))
                   .Where(x => x.IddonHangNavigation.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã hủy"))
                   .Select(x => x.Tong).ToList();
                var sum4 = 0.0;
                if (ctdh4 != null)
                {
                    for (int i = 0; i < ctdh4.Count; i++)
                    {
                        sum4 += (double)ctdh4[i];
                    }

                }
                ViewBag.slspdahuy = ctdh4.Count;
                ViewBag.dsdahuy = sum4;
                //
            }
            return View();
        }

        //theo ngay
        [Route("/Admin/Thongke/datecontact/{date?}")]
        public IActionResult datecontact(string date)
        {
            return Json(new { status = "success", redirectUrl = $"/Admin/Thongke/{date}" });
        }
    }
}
