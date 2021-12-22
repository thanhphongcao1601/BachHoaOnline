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

namespace PTHShopping.Controllers
{
    [Authorize(Roles = "Admin,Staff,Shipper")]
    public class ShipperController : Controller
    {
        private readonly PTHShoppingContext _context;

        public ShipperController(PTHShoppingContext context)
        {
            _context = context;
        }
        [Route("Shipper/{page?}/{filter?}")]
        [Route("Shipper/{page?}")]
        public IActionResult Index(int page=1, string filter="all")
        {
            var pageNumber = page;
            var pageSize = 10;
            var pTHShoppingContext = _context.DonHangs.Include(d => d.IdkhachHangNavigation)
                .Include(d => d.IdtrangThaiGiaoDichNavigation)
                .Where(x => x.Deleted == false)
                .Where(x => x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Chưa giao") || x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đang giao"));
            if(filter  == "kh")
            {
                pTHShoppingContext = pTHShoppingContext.OrderByDescending(x => x.IdkhachHang);
            }
            if (filter == "ndh")
            {
                pTHShoppingContext = pTHShoppingContext.OrderByDescending(x => x.NgayDatHang);
            }
            if (filter == "dagiao")
            {
                pTHShoppingContext = _context.DonHangs.Include(d => d.IdkhachHangNavigation)
                .Include(d => d.IdtrangThaiGiaoDichNavigation)
                .Where(x => x.Deleted == false)
                .Where(x => x.IdtrangThaiGiaoDichNavigation.TrangThai.Contains("Đã giao"));
            }
            ViewBag.CurrentFiller = filter;
            PagedList<DonHang> models = new PagedList<DonHang>(pTHShoppingContext, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        [Route("Shipper/ctdh/{id?}")]
        public async Task<IActionResult> Ctdonhang(string? id)
        {
            var kh = _context.DonHangs.Where(x => x.IddonHang == id).Select(x => x.IdkhachHangNavigation.HoTen).ToList()[0].ToString();
            var dckh = _context.DonHangs.Where(x => x.IddonHang == id).Select(x => x.IdkhachHangNavigation.DiaChi).ToList();
            var dc = "";
            if (dckh[0] == null)
            {
                dc = "Chưa cập nhật";
            }
            else
            {
                dc = dckh[0].ToString();
            }
            ViewBag.kh = kh;
            ViewBag.dckh = dc;
            ViewBag.Id = id;
            var pTHShoppingContext = _context.CtdonHangs.Include(c => c.IddonHangNavigation).Include(c => c.IdsanPhamNavigation).Where(x => x.IddonHang == id);
            return View(await pTHShoppingContext.ToListAsync());
        }

        [Route("Shipper/tienhanh/{id?}")]
        public IActionResult tienhanh(string? id)
        {
            DonHang dh = _context.DonHangs.Where(x => x.IddonHang == id).ToList()[0];
            dh.IdtrangThaiGiaoDich = _context.TrangThaiGiaoDiches.Where(x => x.TrangThai.Contains("Đang giao")).Select(x => x.IdtrangThaiGiaoDich).ToList()[0];
            _context.Update(dh);
            _context.SaveChangesAsync();
            return Redirect("/Shipper");
        }
        [Route("Shipper/hoanthanh/{id?}")]
        public IActionResult hoanthanh(string? id)
        {
            DonHang dh = _context.DonHangs.Where(x => x.IddonHang == id).ToList()[0];
            dh.IdtrangThaiGiaoDich = _context.TrangThaiGiaoDiches.Where(x => x.TrangThai.Contains("Đã giao")).Select(x => x.IdtrangThaiGiaoDich).ToList()[0];
            dh.NgayGiaoHang = DateTime.Now;
            dh.NgayThanhToan = DateTime.Now;
            dh.DaThanhToan = true;
            _context.Update(dh);
            _context.SaveChangesAsync();
            return Redirect("/Shipper");
        }
    }
}
