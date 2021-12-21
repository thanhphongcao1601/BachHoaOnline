using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTHShopping.Helper;
using PTHShopping.Models;

namespace PTHShopping.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly PTHShoppingContext _context;
        private readonly IHostingEnvironment _environment;

        public ProfileController(PTHShoppingContext context, IHostingEnvironment IHostingEnvironment)
        {
            _context = context;
            _environment = IHostingEnvironment;
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

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var pTHShoppingContext = _context.KhachHangs.Include(k => k.IdvitriNavigation);
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
        public async Task<IActionResult> Edit(string id, IFormFile file, string pass1, string pass2, [Bind("IdkhachHang,HoTen,SinhNhat,Avatar,DiaChi,Email,Sdt,Idvitri,Quan,Phuong,NgayTao,MatKhau,Salt,LastLogin,Active,Giotinh")] KhachHang khachHang)
        {
            var newFileName = string.Empty;

            if (pass1 != string.Empty && pass2 != string.Empty && pass2 != null && pass1 == pass2)
            {
                khachHang.MatKhau = BCrypt.Net.BCrypt.HashPassword(pass2, khachHang.Salt);
            }

            if (pass1 != string.Empty && pass2 != string.Empty && pass2 != pass1) { 
                ViewBag.saimk = "Đôi mật khẩu không hợp lệ";
                return View();
            }
            _context.Update(khachHang);
            await _context.SaveChangesAsync();

            if (id != khachHang.IdkhachHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string thumbOld = khachHang.Avatar;
                    string PathDB = string.Empty;
                    if (file != null) //Luu Anh
                    {
                        PathDB = saveImg(file);
                        khachHang.Avatar = PathDB;
                        if (thumbOld != string.Empty && thumbOld != null)
                        {
                            if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, thumbOld)))
                            {
                                System.IO.File.Delete(Path.Combine(_environment.WebRootPath, thumbOld));

                            }
                        }
                    }
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

        public string saveImg(IFormFile file)
        {
            var newFileName = string.Empty;
            var fileName = string.Empty;
            string PathDB = string.Empty;
            if (file.Length > 0)
            {
                // lay FileName
                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                //tao ten tep chong trung
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                // lay duoi file
                var FileExtension = Path.GetExtension(fileName);
                // FileName + FileExtension
                newFileName = myUniqueFileName + FileExtension;
                // tao path de dua file vo root
                fileName = Path.Combine(_environment.WebRootPath, "AvatarImages") + $@"\{newFileName}";
                // path de luu DB
                PathDB = "AvatarImages/" + newFileName;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return PathDB;
        }
    }
}
