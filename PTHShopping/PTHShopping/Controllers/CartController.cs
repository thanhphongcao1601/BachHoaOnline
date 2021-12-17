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

        public IActionResult Index(int phantram)
        {
            var myCart = Carts;
            double total = 0;
            int cartNum = 0;

            foreach (var i in myCart)
            {
                total = total + i.ThanhTien;
                cartNum = cartNum + i.SoLuong;
            }
            ViewBag.cartNum = cartNum;
            ViewBag.totalprice = total;
            ViewBag.phantram = phantram;
            return View(Carts);
        }

        public IActionResult AddToCart(string id,int sl,int current)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaSp == id);

            if (item == null)//chưa có
            {
                var km = 0;
                var sanPham = _context.SanPhams.SingleOrDefault(p => p.IdsanPham == id);
                if (sanPham.KhuyenMai != null)
                {
                    km = (int)sanPham.KhuyenMai.Value;
                }
                item = new CartItem
                {
                    MaSp = id,
                    TenSp = sanPham.TenSanPham,
                    DonGia = (sanPham.Gia * (100 - km) / 100).Value,
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
            return RedirectToAction("Index","ChiTietSP",new { id = current});
            //return Content(item.SoLuong.ToString());
        }

        public IActionResult RemoveFromCart(string id)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaSp == id);

            if (item != null)//chưa có
            {
                myCart.Remove(item);
            }
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
        }

        public IActionResult AddMaKM(string magg)
        {
            var phantram = 0;
            if (magg == "giam50")
            {
                phantram = 50;
            }
            else if (magg == "giam20")
            {
                phantram = 20;
            }
            return RedirectToAction("Index", new { phantram });
        }
    }
}
