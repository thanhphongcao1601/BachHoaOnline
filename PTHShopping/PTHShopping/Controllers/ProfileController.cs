using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Models;

namespace PTHShopping.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly PTHShoppingContext _context;

        public ProfileController(PTHShoppingContext context)
        {
            _context = context;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var pTHShoppingContext = _context.KhachHangs.Include(k => k.IdvitriNavigation);
            return View(await pTHShoppingContext.ToListAsync());
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs
                .Include(k => k.IdvitriNavigation)
                .FirstOrDefaultAsync(m => m.IdkhachHang == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: Profile/Create
        public IActionResult Create()
        {
            ViewData["Idvitri"] = new SelectList(_context.Locations, "IdviTri", "IdviTri");
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdkhachHang,HoTen,SinhNhat,Avatar,DiaChi,Email,Sdt,Idvitri,Quan,Phuong,NgayTao,MatKhau,Salt,LastLogin,Active,Giotinh")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idvitri"] = new SelectList(_context.Locations, "IdviTri", "IdviTri", khachHang.Idvitri);
            return View(khachHang);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            ViewData["Idvitri"] = new SelectList(_context.Locations, "IdviTri", "IdviTri", khachHang.Idvitri);
            return View(khachHang);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdkhachHang,HoTen,SinhNhat,Avatar,DiaChi,Email,Sdt,Idvitri,Quan,Phuong,NgayTao,MatKhau,Salt,LastLogin,Active,Giotinh")] KhachHang khachHang)
        {
            if (id != khachHang.IdkhachHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.IdkhachHang))
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
            ViewData["Idvitri"] = new SelectList(_context.Locations, "IdviTri", "IdviTri", khachHang.Idvitri);
            return View(khachHang);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs
                .Include(k => k.IdvitriNavigation)
                .FirstOrDefaultAsync(m => m.IdkhachHang == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(string id)
        {
            return _context.KhachHangs.Any(e => e.IdkhachHang == id);
        }
    }
}
