using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin,Staff")]
    public class AdminCategoriesController : Controller
    {
        private readonly PTHShoppingContext _context;
        private readonly IHostingEnvironment _environment;
        public INotyfService _notifService { get; }
        public AdminCategoriesController(PTHShoppingContext context, INotyfService notifService, IHostingEnvironment IHostingEnvironment)
        {
            _context = context;
            _environment = IHostingEnvironment;
            _notifService = notifService;
        }

        // GET: Admin/AdminCategories
        [Route("Admin/Categories/{page?}")]
        [Route("Admin/Categories/{page?}/{published?}")]

        public async Task<IActionResult> Index(int page=1, int published = -1)
        {
            var pageNumber = page;
            var pageSize = 10;
            var lsCat = _context.Categories.OrderByDescending(x => x.Published);
            if (published == 1)
            {
                lsCat = (IOrderedQueryable<Category>)_context.Categories.Where(x => x.Published==true);
            }
            if (published == 0)
            {
                lsCat = (IOrderedQueryable<Category>)_context.Categories.Where(x => x.Published == false);
            }
            PagedList<Category> models = new PagedList<Category>(lsCat, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.CurrentFilter = published;
            return View(models);
        }

        // GET: Admin/AdminCategories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/AdminCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatId,CatName,MoTa,ParrentId,Levels,Ordering,Published,Thumb,TieuDe,KyHieu,MetaDesc,MetaKey,Cover,SchemaMarkup")] Category category, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var err = 0;
                var lis_IdCat = _context.Categories.Select(x => x.CatId).ToList();
                foreach (var x in lis_IdCat)
                {
                    var xn = x.Trim();
                    if (category.CatId.Equals(xn))
                    {
                        ViewBag.TrungID = xn;
                        err = 1;
                    }
                }
                if(category.CatName == null || category.CatName == string.Empty)
                {
                    err = 1;
                    ViewBag.nullName = "nullName";
                }
                if (err == 1)
                {
                    return View(category);
                }

                string PathDB = string.Empty;
                if (file != null) //Luu Anh
                {
                    PathDB = saveImg(file);
                    category.Thumb = PathDB;
                }
                _context.Add(category);
                await _context.SaveChangesAsync();
                _notifService.Success("Thêm mới thành công!");
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/AdminCategories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CatId,CatName,MoTa,ParrentId,Levels,Ordering,Published,Thumb,TieuDe,KyHieu,MetaDesc,MetaKey,Cover,SchemaMarkup")] Category category,  IFormFile file)
        {
            if (id != category.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var err = 0;
                    if (category.CatName == null || category.CatName == string.Empty)
                    {
                        err = 1;
                        ViewBag.nullName = "nullName";
                    }
                    if (err == 1)
                    {
                        return View(category);
                    }
                    string thumbOld = category.Thumb;
                    string PathDB = string.Empty;
                    if (file != null) //Luu Anh
                    {
                        PathDB=saveImg(file);
                        category.Thumb = PathDB;
                        if (thumbOld != string.Empty && thumbOld!=null)
                        {
                            if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, thumbOld)))
                            {
                                System.IO.File.Delete(Path.Combine(_environment.WebRootPath, thumbOld));

                            }
                        }
                    }
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    _notifService.Success("Chỉnh sửa thành công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CatId))
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
            return View(category);
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
                fileName = Path.Combine(_environment.WebRootPath, "CatImages") + $@"\{newFileName}";
                // path de luu DB
                PathDB = "CatImages/" + newFileName;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return PathDB;
        }
        // GET: Admin/AdminCategories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                var thumb = category.Thumb;
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                _notifService.Success("Xóa thành công!");
                if (thumb != string.Empty && thumb != null)
                {
                    if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, thumb.ToString())))
                    {
                        System.IO.File.Delete(Path.Combine(_environment.WebRootPath, thumb.ToString()));

                    }
                }
            }
            catch
            {
                _notifService.Error("Không thể xóa do có sản phẩm thuộc danh mục!");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(string id)
        {
            return _context.Categories.Any(e => e.CatId == id);
        }
    }
}
