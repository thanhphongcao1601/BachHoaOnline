using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PTHShopping.Helper;
using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace PTHShopping.Controllers
{
    public class TinTucController : Controller
    {
        private readonly PTHShoppingContext _context;

        public TinTucController(PTHShoppingContext context)
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

        [Route("Tintuc/{page}")]
        [Route("Tintuc/{page}/{Cat}")]
        [Route("Tintuc/{page}/{Cat}/{searchStr}")]
        [Route("Tintuc")]
        public IActionResult Index(int? page, string Cat, string searchStr)
        {
            var myCart = Carts;
            double total = 0;

            foreach (var i in myCart)
            {
                total = total + i.ThanhTien;
            }
            ViewBag.totalprice = total;

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 4;
            var lsNews = _context.Trangs.Where(x => x.Published == true);

            if (Cat == null || Cat == string.Empty)
            {
                Cat = "all";
            }
            if (searchStr == null || searchStr == string.Empty)
            {
                searchStr = "";
            }
            if (Cat!=null && Cat != string.Empty)
            {
                searchStr.Trim();
                switch (Cat)
                {
                    case "all":
                        lsNews = _context.Trangs.Where(x => x.Published == true).Where(x => Convert.ToString(x.TieuDe).Contains(searchStr));
                        break;
                    case "new":
                        lsNews = _context.Trangs.Where(x => x.Published == true).Where(x => x.TenTrang.Contains("Tin tức về sản phẩm mới")).Where(x => Convert.ToString(x.TieuDe).Contains(searchStr));
                        break;
                    case "sale":
                        lsNews = _context.Trangs.Where(x => x.Published == true).Where(x => x.TenTrang.Contains("Tin tức về khuyến mãi")).Where(x => Convert.ToString(x.TieuDe).Contains(searchStr));
                        break;
                    case "market":
                        lsNews = _context.Trangs.Where(x => x.Published == true).Where(x => x.TenTrang.Contains("Tin tức về thị trường")).Where(x => Convert.ToString(x.TieuDe).Contains(searchStr));
                        break;
                    case "shop":
                        lsNews = _context.Trangs.Where(x => x.Published == true).Where(x => x.TenTrang.Contains("Tin tức về của hàng")).Where(x => Convert.ToString(x.TieuDe).Contains(searchStr));
                        break;
                }
                ViewBag.Cat = Cat;
                ViewBag.Search = searchStr;
            }

            PagedList<Trang> models = new PagedList<Trang>(lsNews, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.pageSize = pageSize;

            var lstTintuc = models;
            var lstCategory = _context.Categories.ToList();

            Sanpham_Danhmuc obj = new Sanpham_Danhmuc();
            obj.ListTintuc = lstTintuc;
            obj.ListDanhmuc = lstCategory;

            return View(obj);
        }

        
    }
}
