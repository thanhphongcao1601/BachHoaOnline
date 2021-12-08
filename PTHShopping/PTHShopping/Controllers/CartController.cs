using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTHShopping.Helper;
using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTHShopping.Controllers
{
    public class CartController : Controller
    {
        private readonly PTHShoppingContext _context;

        public CartController(PTHShoppingContext context)
        {
            _context = context;
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

        public IActionResult Index()
        {
            var myCart = Carts;
            double total = 0;

            foreach (var i in myCart)
            {
                total = total + i.ThanhTien;
            }
            ViewBag.totalprice = total;
            return View(Carts);
        }

        public IActionResult AddToCart(string id,int sl)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaSp == id);

            if (item == null)//chưa có
            {
                var sanPham = _context.SanPhams.SingleOrDefault(p => p.IdsanPham == id);
                item = new CartItem
                {
                    MaSp = id,
                    TenSp = sanPham.TenSanPham,
                    DonGia = (sanPham.Gia * (100 - sanPham.KhuyenMai) / 100).Value,
                    SoLuong = sl,
                    Hinh = sanPham.Thumb
                };
                myCart.Add(item);
            }
            else
            {
                item.SoLuong +=sl; //sl
            }

            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
            //return Content(item.SoLuong.ToString());
        }
    }
}
