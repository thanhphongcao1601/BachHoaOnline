using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTHShopping.Helper;
using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PTHShopping.Controllers
{
    public class LienHeController : Controller
    {
        public INotyfService _notifService { get; }
        public LienHeController(INotyfService notifService)
        {
            _notifService = notifService;
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
            int cartNum = 0;

            foreach (var i in myCart)
            {
                total = total + i.ThanhTien;
                cartNum = cartNum + i.SoLuong;
            }
            ViewBag.cartNum = cartNum;
            ViewBag.totalprice = total;
            return View();
        }
        [HttpPost]
        public IActionResult Mail(string ten, string mail, string loinhan)
        {

            try {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("bachhoaonlinepth@gmail.com", "CTPctp123456"),
                    EnableSsl = true,
                };

                smtpClient.Send("bachhoaonlinepth@gmail.com", "bachhoaonlinepth@gmail.com", "[Liên hệ từ khách hàng "+ten+"]", "Khách hàng: "+ten+"\nĐịa chỉ mail: "+mail+"\nNội dung: "+loinhan);
                _notifService.Success("Đã nhận lời nhắn của bạn! Hãy tiếp tục mua sắm.");
            }
            catch {
                _notifService.Error("Đã xảy ra lỗi.");
            }

            return Redirect("/LienHe");
        }
    }
}
