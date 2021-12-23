using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Models;

namespace PTHShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Staff")]
    public class AdminCtdonHangsController : Controller
    {
        private readonly PTHShoppingContext _context;

        public AdminCtdonHangsController(PTHShoppingContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminCtdonHangs
        public async Task<IActionResult> Index(string? id)
        {
            var kh = _context.DonHangs
                .Where(x => x.IddonHang == id)
                .Select(x => x.IdkhachHangNavigation.HoTen)
                .ToList()[0].ToString();
            var dckh = _context.DonHangs
                .Where(x => x.IddonHang == id)
                .Select(x => x.IdkhachHangNavigation.DiaChi).ToList();
            var dc = "";
            if( dckh[0]==null)
            {
                dc = "Chưa cập nhật";
            }
            else
            {
                dc = dckh[0].ToString();
            }

          
            ViewBag.kh = kh;
            ViewBag.dckh = dc;
            ViewBag.Id = id;

            var pTHShoppingContext = _context.CtdonHangs
                .Include(c => c.IddonHangNavigation)
                .Include(c => c.IdsanPhamNavigation)
                .Where(x=>x.IddonHang==id);

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

        public int slOld = 0;
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
            var ten = _context.SanPhams.Where(x => x.IdsanPham == ctdonHang.IdsanPham).Select(x => x.TenSanPham).ToList()[0];
            var maxsl = _context.SanPhams.Where(x => x.IdsanPham == ctdonHang.IdsanPham).Select(x => x.UnitsInStock).ToList()[0];
            ViewBag.sp = ten;
            ViewBag.slmax = maxsl;
            slOld = (int)ctdonHang.SoLuong;
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
                    var sp = await _context.SanPhams.FindAsync(ctdonHang.IdsanPham);
                    if (slOld > ctdonHang.SoLuong)
                    {
                        sp.Slban = sp.Slban - (slOld - ctdonHang.SoLuong);
                        sp.UnitsInStock = sp.UnitsInStock + (slOld - ctdonHang.SoLuong);
                    }
                    if (slOld < ctdonHang.SoLuong)
                    {
                        sp.Slban = sp.Slban + (ctdonHang.SoLuong -slOld);
                        sp.UnitsInStock = sp.UnitsInStock - (ctdonHang.SoLuong - slOld);
                    }
                    _context.Update(sp);
                    var gia = _context.SanPhams.Where(x => x.IdsanPham == ctdonHang.IdsanPham).Select(x=>x.Gia).ToList()[0];
                    var km = _context.SanPhams.Where(x => x.IdsanPham == ctdonHang.IdsanPham).Select(x=>x.KhuyenMai).ToList()[0];
                    if (km == null) km = 0;
                    ctdonHang.Tong = (gia * ctdonHang.SoLuong) - (gia * ctdonHang.SoLuong) * (km / 100); 
              
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
                return Redirect("/Admin/AdminCtDonHangs/Index/"+ctdonHang.IddonHang);
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
            var ten = _context.SanPhams.Where(x => x.IdsanPham == ctdonHang.IdsanPham).Select(x => x.TenSanPham).ToList()[0];
            ViewBag.sp = ten;
            return View(ctdonHang);
        }

        // POST: Admin/AdminCtdonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ctdonHang = await _context.CtdonHangs.FindAsync(id);
            var sp = await _context.SanPhams.FindAsync(ctdonHang.IdsanPham);
            sp.Slban = sp.Slban - ctdonHang.SoLuong;
            sp.UnitsInStock = sp.UnitsInStock + ctdonHang.SoLuong;
            _context.Update(sp);
            _context.CtdonHangs.Remove(ctdonHang);
            await _context.SaveChangesAsync();
            return Redirect("/Admin/AdminCtDonHangs/Index/" + ctdonHang.IddonHang);
        }

        private bool CtdonHangExists(string id)
        {
            return _context.CtdonHangs.Any(e => e.IdctdonHang == id);
        }
    }
}
