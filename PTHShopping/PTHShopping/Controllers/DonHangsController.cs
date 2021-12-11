using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Models;

namespace PTHShopping.Controllers
{
    public class DonHangsController : Controller
    {
        private readonly PTHShoppingContext _context;

        public DonHangsController(PTHShoppingContext context)
        {
            _context = context;
        }

        // GET: DonHangs
        public async Task<IActionResult> Index()
        {
            var pTHShoppingContext = _context.DonHangs.Include(d => d.IdkhachHangNavigation).Include(d => d.IdtrangThaiGiaoDichNavigation);
            return View(await pTHShoppingContext.ToListAsync());
        }

        // GET: DonHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.IdkhachHangNavigation)
                .Include(d => d.IdtrangThaiGiaoDichNavigation)
                .FirstOrDefaultAsync(m => m.IddonHang == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHangs/Create
        public IActionResult Create()
        {
            ViewData["IdkhachHang"] = new SelectList(_context.KhachHangs, "IdkhachHang", "IdkhachHang");
            ViewData["IdtrangThaiGiaoDich"] = new SelectList(_context.TrangThaiGiaoDiches, "IdtrangThaiGiaoDich", "IdtrangThaiGiaoDich");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IddonHang,IdkhachHang,NgayDatHang,NgayGiaoHang,IdtrangThaiGiaoDich,Deleted,DaThanhToan,NgayThanhToan,IdthanhToan,GhiChu")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();


                return RedirectToAction("TaoCT", "CtdonHangs",new { iddh=donHang.IddonHang });

                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdkhachHang"] = new SelectList(_context.KhachHangs, "IdkhachHang", "IdkhachHang", donHang.IdkhachHang);
            ViewData["IdtrangThaiGiaoDich"] = new SelectList(_context.TrangThaiGiaoDiches, "IdtrangThaiGiaoDich", "IdtrangThaiGiaoDich", donHang.IdtrangThaiGiaoDich);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["IdkhachHang"] = new SelectList(_context.KhachHangs, "IdkhachHang", "IdkhachHang", donHang.IdkhachHang);
            ViewData["IdtrangThaiGiaoDich"] = new SelectList(_context.TrangThaiGiaoDiches, "IdtrangThaiGiaoDich", "IdtrangThaiGiaoDich", donHang.IdtrangThaiGiaoDich);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IddonHang,IdkhachHang,NgayDatHang,NgayGiaoHang,IdtrangThaiGiaoDich,Deleted,DaThanhToan,NgayThanhToan,IdthanhToan,GhiChu")] DonHang donHang)
        {
            if (id != donHang.IddonHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.IddonHang))
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
            ViewData["IdkhachHang"] = new SelectList(_context.KhachHangs, "IdkhachHang", "IdkhachHang", donHang.IdkhachHang);
            ViewData["IdtrangThaiGiaoDich"] = new SelectList(_context.TrangThaiGiaoDiches, "IdtrangThaiGiaoDich", "IdtrangThaiGiaoDich", donHang.IdtrangThaiGiaoDich);
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.IdkhachHangNavigation)
                .Include(d => d.IdtrangThaiGiaoDichNavigation)
                .FirstOrDefaultAsync(m => m.IddonHang == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            _context.DonHangs.Remove(donHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(string id)
        {
            return _context.DonHangs.Any(e => e.IddonHang == id);
        }
    }
}
