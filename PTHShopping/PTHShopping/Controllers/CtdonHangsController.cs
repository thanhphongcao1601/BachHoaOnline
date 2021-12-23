﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Helper;
using PTHShopping.Models;
using System.Security.Claims;

namespace PTHShopping.Controllers
{
    [Authorize]
    public class CtdonHangsController : Controller
    {
        private readonly PTHShoppingContext _context;

        public CtdonHangsController(PTHShoppingContext context)
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

        public async Task<IActionResult> TaoCT(string iddh, int pt, string dcm)
        {
            var myCart = Carts;
            foreach (var item in myCart)
            {
                var sanPham = _context.SanPhams.SingleOrDefault(p => p.IdsanPham == item.MaSp);
                var ct = new CtdonHang
                {
                    IdctdonHang = RandomID.generateID(),
                    IddonHang = iddh,
                    IdsanPham = item.MaSp,
                    SoLuong = item.SoLuong,
                    Tong = item.DonGia * item.SoLuong,
                    KhuyenMai = pt,
                    NgayGiaoHang = null
                };
                _context.SanPhams.SingleOrDefault(p => p.IdsanPham == item.MaSp).UnitsInStock -= ct.SoLuong;
                _context.SanPhams.SingleOrDefault(p => p.IdsanPham == item.MaSp).Slban += ct.SoLuong;
                _context.Add(ct);
                await _context.SaveChangesAsync();
            }

            myCart.Clear();
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index", new { dcm = dcm});
        }

        // GET: CtdonHangs
        [Route("/CTDonHang/{dcm?}")]
        public async Task<IActionResult> Index(string dcm)
        {
            var idKH = User.Claims.First(c => c.Type == "IdKH").Value.Trim();

            if (dcm != null)
            {
                _context.KhachHangs.Where(c => c.IdkhachHang.Trim() == idKH).FirstOrDefault().DiaChi = dcm;
                await _context.SaveChangesAsync();
            }

            var pTHShoppingContext = _context.CtdonHangs.Include(c => c.IddonHangNavigation).Include(c => c.IdsanPhamNavigation);
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

            //dia chi moi
            @ViewBag.diachimoi = dcm;
            return View(await pTHShoppingContext.ToListAsync());
        }

        // GET: CtdonHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctdonHang = await _context.CtdonHangs
                .Include(c => c.IddonHangNavigation)
                .Include(c => c.IdsanPhamNavigation)
                .FirstOrDefaultAsync(m => m.IdctdonHang == id);
            if (ctdonHang == null)
            {
                return NotFound();
            }

            return View(ctdonHang);
        }

        // GET: CtdonHangs/Create
        public IActionResult Create()
        {
            ViewData["IddonHang"] = new SelectList(_context.DonHangs, "IddonHang", "IddonHang");
            ViewData["IdsanPham"] = new SelectList(_context.SanPhams, "IdsanPham", "IdsanPham");
            return View();
        }

        // POST: CtdonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdctdonHang,IddonHang,IdsanPham,SoDonHang,SoLuong,KhuyenMai,Tong,NgayGiaoHang")] CtdonHang ctdonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctdonHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IddonHang"] = new SelectList(_context.DonHangs, "IddonHang", "IddonHang", ctdonHang.IddonHang);
            ViewData["IdsanPham"] = new SelectList(_context.SanPhams, "IdsanPham", "IdsanPham", ctdonHang.IdsanPham);
            return View(ctdonHang);
        }

        // GET: CtdonHangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctdonHang = await _context.CtdonHangs.FindAsync(id);
            if (ctdonHang == null)
            {
                return NotFound();
            }
            ViewData["IddonHang"] = new SelectList(_context.DonHangs, "IddonHang", "IddonHang", ctdonHang.IddonHang);
            ViewData["IdsanPham"] = new SelectList(_context.SanPhams, "IdsanPham", "IdsanPham", ctdonHang.IdsanPham);
            return View(ctdonHang);
        }

        // POST: CtdonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdctdonHang,IddonHang,IdsanPham,SoDonHang,SoLuong,KhuyenMai,Tong,NgayGiaoHang")] CtdonHang ctdonHang)
        {
            if (id != ctdonHang.IdctdonHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctdonHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtdonHangExists(ctdonHang.IdctdonHang))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IddonHang"] = new SelectList(_context.DonHangs, "IddonHang", "IddonHang", ctdonHang.IddonHang);
            ViewData["IdsanPham"] = new SelectList(_context.SanPhams, "IdsanPham", "IdsanPham", ctdonHang.IdsanPham);
            return View(ctdonHang);
        }

        // GET: CtdonHangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctdonHang = await _context.CtdonHangs
                .Include(c => c.IddonHangNavigation)
                .Include(c => c.IdsanPhamNavigation)
                .FirstOrDefaultAsync(m => m.IdctdonHang == id);
            if (ctdonHang == null)
            {
                return NotFound();
            }

            return View(ctdonHang);
        }

        // POST: CtdonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ctdonHang = await _context.CtdonHangs.FindAsync(id);
            _context.CtdonHangs.Remove(ctdonHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtdonHangExists(string id)
        {
            return _context.CtdonHangs.Any(e => e.IdctdonHang == id);
        }
    }
}
