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
    public class LienHeController : Controller
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
        public IActionResult Index()
        {
            var myCart = Carts;
            double total = 0;

            foreach (var i in myCart)
            {
                total = total + i.ThanhTien;
            }
            ViewBag.totalprice = total;
            return View();
        }
    }
}
