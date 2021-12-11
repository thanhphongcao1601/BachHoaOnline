using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PTHShopping.Models;

namespace PTHShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTinTucController : Controller
    {
        private readonly PTHShoppingContext _context;
        private readonly IHostingEnvironment _environment;
        public AdminTinTucController(PTHShoppingContext context, IHostingEnvironment IHostingEnvironment)
        {
            _context = context;
            _environment = IHostingEnvironment;
        }

        // GET: Admin/AdminTinTuc
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsNews = _context.Trangs.AsNoTracking()
                .OrderByDescending(x => x.NgayTao);
            PagedList<Trang> models = new PagedList<Trang>(lsNews, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminTinTuc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trang = await _context.Trangs
                .FirstOrDefaultAsync(m => m.Idtrang == id);
            if (trang == null)
            {
                return NotFound();
            }

            return View(trang);
        }

        // GET: Admin/AdminTinTuc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminTinTuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtrang,TenTrang,NoiDung,Thumb,Published,TieuDe,MetaDesc,MetaKey,KiHieu,NgayTao,Ordering")] Trang trang, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var lis_IdTT = _context.Trangs.Select(x => x.Idtrang).ToList();
                foreach (var x in lis_IdTT)
                {
                    var xn = x.Trim();
                    if (trang.Idtrang.Equals(xn))
                    {
                        ViewBag.TrungID = xn;
                        return View(trang);
                    }
                }
                string PathDB = string.Empty;
                if (file != null) //Luu Anh
                {
                    PathDB = saveImg(file);
                    trang.Thumb = PathDB;
                }
                _context.Add(trang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trang);
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
                fileName = Path.Combine(_environment.WebRootPath, "TintucImages") + $@"\{newFileName}";
                // path de luu DB
                PathDB = "TintucImages/" + newFileName;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return PathDB;
        }

        // GET: Admin/AdminTinTuc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trang = await _context.Trangs.FindAsync(id);
            if (trang == null)
            {
                return NotFound();
            }
            return View(trang);
        }

        // POST: Admin/AdminTinTuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idtrang,TenTrang,NoiDung,Thumb,Published,TieuDe,MetaDesc,MetaKey,KiHieu,NgayTao,Ordering")] Trang trang, IFormFile file)
        {
            if (id != trang.Idtrang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string thumbOld = trang.Thumb;
                   
                    string PathDB = string.Empty;
                    if (file != null) //Luu Anh
                    {
                        PathDB = saveImg(file);
                        trang.Thumb = PathDB;
                        if (thumbOld != string.Empty && thumbOld!=null)
                        {
                            if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, thumbOld)))
                            {
                                System.IO.File.Delete(Path.Combine(_environment.WebRootPath, thumbOld));

                            }
                        }

                    }
                    _context.Update(trang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrangExists(trang.Idtrang))
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
            return View(trang);
        }

        // GET: Admin/AdminTinTuc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trang = await _context.Trangs
                .FirstOrDefaultAsync(m => m.Idtrang == id);
            if (trang == null)
            {
                return NotFound();
            }

            return View(trang);
        }

        // POST: Admin/AdminTinTuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trang = await _context.Trangs.FindAsync(id);
            if (trang.Thumb != string.Empty && trang.Thumb != null)
            {
                if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, trang.Thumb.ToString())))
                {
                    System.IO.File.Delete(Path.Combine(_environment.WebRootPath, trang.Thumb.ToString()));

                }
            }
            _context.Trangs.Remove(trang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrangExists(string id)
        {
            return _context.Trangs.Any(e => e.Idtrang == id);
        }
    }
}
