using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Models;

namespace PTHShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCtdonHangsController : Controller
    {
        private readonly PTHShoppingContext _context;

        public AdminCtdonHangsController(PTHShoppingContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminCtdonHangs
        public async Task<IActionResult> Index()
        {
            var pTHShoppingContext = _context.CtdonHangs.Include(c => c.IddonHangNavigation).Include(c => c.IdsanPhamNavigation);
            return View(await pTHShoppingContext.ToListAsync());
        }

        // GET: Admin/AdminCtdonHangs/Details/5
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

        // GET: Admin/AdminCtdonHangs/Create
        public IActionResult Create()
        {
            ViewData["IddonHang"] = new SelectList(_context.DonHangs, "IddonHang", "IddonHang");
            ViewData["IdsanPham"] = new SelectList(_context.SanPhams, "IdsanPham", "IdsanPham");
            return View();
        }

        // POST: Admin/AdminCtdonHangs/Create
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

        // GET: Admin/AdminCtdonHangs/Edit/5
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

        // POST: Admin/AdminCtdonHangs/Edit/5
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

        // GET: Admin/AdminCtdonHangs/Delete/5
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

        // POST: Admin/AdminCtdonHangs/Delete/5
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
