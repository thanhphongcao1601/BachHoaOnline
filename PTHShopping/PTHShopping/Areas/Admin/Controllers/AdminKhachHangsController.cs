using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PTHShopping.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace PTHShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Staff")]
    public class AdminKhachHangsController : Controller
    {
        private readonly PTHShoppingContext _context;
        public INotyfService _notifService { get; }
        private readonly IHostingEnvironment _environment;

        public AdminKhachHangsController(PTHShoppingContext context, INotyfService notifService, IHostingEnvironment IHostingEnvironment)
        {
            _context = context;
            _notifService = notifService;
            _environment = IHostingEnvironment;
        }

        // GET: Admin/AdminKhachHangs
        [Route("Admin/KhachHangs/{page?}")]
        [Route("Admin/KhachHangs/{page?}/{active?}")]
        public IActionResult Index(int page = 1, int active = -1)
        {
            var pageNumber = page;
            var pageSize = 10;
            var lsCustomer = _context.KhachHangs.AsNoTracking()
                .Include(x => x.IdvitriNavigation)
                .OrderByDescending(x => x.NgayTao);
            if (active == 1)
            {
                lsCustomer = _context.KhachHangs.AsNoTracking()
                .Include(x => x.IdvitriNavigation)
                .Where(x=>x.Active==true)
                .OrderByDescending(x => x.NgayTao);
            }
            if (active == 0)
            {
                lsCustomer = _context.KhachHangs.AsNoTracking()
                .Include(x => x.IdvitriNavigation)
                .Where(x => x.Active == false)
                .OrderByDescending(x => x.NgayTao);
            }
            PagedList<KhachHang> models = new PagedList<KhachHang>(lsCustomer, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.CurrentFilter = active;
            return View(models);
        }

        // GET: Admin/AdminKhachHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(m => m.IdkhachHang == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: Admin/AdminKhachHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminKhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdkhachHang,HoTen,SinhNhat,Avatar,DiaChi,Email,Sdt,Idvitri,Quan,Phuong,NgayTao,MatKhau,Salt,LastLogin,Active")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                var lis_IdKH = _context.KhachHangs.Select(x => x.IdkhachHang).ToList();
                var err = 0;
                foreach (var x in lis_IdKH)
                {
                    var xn = x.Trim();
                    if (khachHang.IdkhachHang.Equals(xn))
                    {
                        ViewBag.TrungID = xn;
                        err = 1;
                    }
                }
                if(khachHang.IdkhachHang==null || khachHang.IdkhachHang == string.Empty)
                {
                    ViewBag.nullID = "nullID";
                    err = 1;
                }
                if (khachHang.HoTen == null || khachHang.HoTen == string.Empty)
                {
                    ViewBag.nullHT = "nullHoTen";
                    err = 1;
                }
                if (khachHang.Sdt == null || khachHang.Sdt == string.Empty)
                {
                    ViewBag.nullSDT = "nullSDT";
                    err = 1;
                }
                if (khachHang.MatKhau == null || khachHang.MatKhau == string.Empty)
                {
                    ViewBag.nullPass = "nullPass";
                    err = 1;
                }
                var sdt = _context.KhachHangs.Where(x => x.Sdt == khachHang.Sdt).ToList();
                if (sdt.Count != 0)
                {
                    ViewBag.sdtTrung = sdt[0].Sdt;
                    err = 1;
                }
                if (err == 1)
                {
                    return View(khachHang);
                }
                khachHang.NgayTao = DateTime.Now;
                khachHang.Active = true;
                khachHang.MatKhau = BCrypt.Net.BCrypt.HashPassword(khachHang.MatKhau, khachHang.Salt); 
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                _notifService.Success("Thêm mới thành công!");
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }

        // GET: Admin/AdminKhachHangs/Edit/5
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
            return View(khachHang);
        }

        // POST: Admin/AdminKhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdkhachHang,HoTen,SinhNhat,Avatar,DiaChi,Email,Sdt,Idvitri,Quan,Phuong,NgayTao,MatKhau,Salt,LastLogin,Active")] KhachHang khachHang, string pass2)
        {
            if (id != khachHang.IdkhachHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var err = 0;
                    if (khachHang.HoTen == null || khachHang.HoTen == string.Empty)
                    {
                        ViewBag.nullHT = "nullName";
                        err = 1;
                    }
                    if (err == 1)
                    {
                        return View(khachHang);
                    }
                    if (pass2 != string.Empty && pass2 != null)
                    {
                        khachHang.MatKhau = BCrypt.Net.BCrypt.HashPassword(pass2, khachHang.Salt);
                    }
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                    _notifService.Success("Chỉnh sửa thành công!");
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
            return View(khachHang);
        }

        // GET: Admin/AdminKhachHangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(m => m.IdkhachHang == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // POST: Admin/AdminKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang.Avatar != string.Empty && khachHang.Avatar != null)
            {
                if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, khachHang.Avatar.ToString())))
                {
                    System.IO.File.Delete(Path.Combine(_environment.WebRootPath, khachHang.Avatar.ToString()));

                }
            }
            _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();
            _notifService.Success("Xóa thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(string id)
        {
            return _context.KhachHangs.Any(e => e.IdkhachHang == id);
        }
    }
}
