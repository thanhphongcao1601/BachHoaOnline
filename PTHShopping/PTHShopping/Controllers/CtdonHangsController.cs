﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Helper;
using PTHShopping.Models;

namespace PTHShopping.Controllers
{
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

        public async Task<IActionResult> TaoCT(string iddh, int pt)
        {
            int i = 0;
            string k = "";
            var myCart = Carts;
            foreach (var item in myCart)
            {
                var sanPham = _context.SanPhams.SingleOrDefault(p => p.IdsanPham == item.MaSp);
                var ct = new CtdonHang
                {
                    IdctdonHang = iddh+"_"+ i,
                    IddonHang = iddh,
                    IdsanPham = item.MaSp,
                    SoLuong = item.SoLuong,
                    Tong = item.DonGia * item.SoLuong,
                    KhuyenMai = pt,
                    NgayGiaoHang = null
                };
                _context.Add(ct);
                await _context.SaveChangesAsync();
                k = k + ct.IdsanPham + "-" + ct.SoLuong + "-" + ct.IddonHang +"\n";
                i = i + 1;
            }
            return RedirectToAction("Index");
        }

        // GET: CtdonHangs
        public async Task<IActionResult> Index()
        {
            var pTHShoppingContext = _context.CtdonHangs.Include(c => c.IddonHangNavigation).Include(c => c.IdsanPhamNavigation);
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