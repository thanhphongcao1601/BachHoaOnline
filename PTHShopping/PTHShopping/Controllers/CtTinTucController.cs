using Microsoft.AspNetCore.Mvc;
using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTHShopping.Controllers
{
    public class CtTinTucController : Controller
    {
        private readonly PTHShoppingContext _context;

        public CtTinTucController(PTHShoppingContext context)
        {
            _context = context;
        }

        [Route("CtTintuc/{id}")]
        public IActionResult Index(string id)
        {
            Trang cttt = _context.Trangs.Where(x => x.Idtrang.Equals(id)).First();
            var lsNews = _context.Trangs.Where(x => x.Published == true);
            ViewBag.listNew = lsNews.ToList();
            return View(cttt);
        }
    }
}
