﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PTHShopping.Helper;
using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PTHShopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        PTHShoppingContext objModel = new PTHShoppingContext();
        public IActionResult Index()
        {
            int cartNum = 0;
            var myCart = Carts;
            double total = 0;

            foreach (var i in myCart)
            {
                total = total + i.ThanhTien;
                cartNum = cartNum + i.SoLuong;
            }
            ViewBag.cartNum = cartNum;
            ViewBag.totalprice = total;

            var lstSanpham = objModel.SanPhams.Where(x => x.Active == true).ToList();
            var lstCategory = objModel.Categories.Where(x=>x.Published==true).ToList();
            var lsNew = objModel.Trangs.Where(x => x.Published == true).OrderByDescending(x=>x.NgayTao).ToList();
            ViewBag.news = lsNew;
            Sanpham_Danhmuc objSanpham_Danhmuc = new Sanpham_Danhmuc();
            objSanpham_Danhmuc.ListSanpham = lstSanpham;
            objSanpham_Danhmuc.ListDanhmuc = lstCategory;

            ViewData["Danhsach"] = objSanpham_Danhmuc;

            return View(objSanpham_Danhmuc);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



      
    }
}
