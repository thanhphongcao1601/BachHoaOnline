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
        public IActionResult Index(PTHShoppingContext modelz, string id, int? currentPage)
        {
            ViewBag.pageSize = 2;
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
