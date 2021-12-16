using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Core;
using PTHShopping.Helper;
using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using PagedList.Core.Mvc;


namespace PTHShopping.Controllers
{
    public class MuaSamController : Controller
    {

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

        public IActionResult Index(PTHShoppingContext modelz, string id, int? currentPage, string timkiem, string loc_km, string loc_new, string loc_slban, int vmin, int vmax)
        {
            ViewBag.loc_km = loc_km;
            ViewBag.loc_new = loc_new;
            ViewBag.loc_slban = loc_slban;
            ViewBag.vmin = vmin;
            ViewBag.vmax = vmax;

            ViewBag.timkiem = timkiem;
            ViewBag.pageSize = 3;
            if (currentPage == null)
            {
                currentPage = 1;
            }
            ViewBag.currentPage = currentPage;

            var myCart = Carts;
            double total = 0;

            foreach (var i in myCart)
            {
                total = total + i.ThanhTien;
            }
            ViewBag.totalprice = total;

            if (modelz == null) return Content("Errrrrrrrr");
            var lstSanpham = modelz.SanPhams.ToList();
            var lstCategory = modelz.Categories.ToList();

            Sanpham_Danhmuc objSanpham_Danhmuc = new Sanpham_Danhmuc();
            objSanpham_Danhmuc.ListSanpham = lstSanpham;
            objSanpham_Danhmuc.ListDanhmuc = lstCategory;

            ViewBag.idspdm = id;
            return View(objSanpham_Danhmuc);
        }
    }
}
