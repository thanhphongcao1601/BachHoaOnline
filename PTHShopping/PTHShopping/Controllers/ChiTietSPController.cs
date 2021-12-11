using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTHShopping.Models;
using Microsoft.AspNetCore.Http;
using PTHShopping.Helper;

namespace PTHShopping.Controllers
{
    public class ChiTietSPController : Controller
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
        public IActionResult Index(PTHShoppingContext modelz, int id)
        {
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

            ViewBag.idctsp = id;
            return View(objSanpham_Danhmuc);
        }
    }
}
