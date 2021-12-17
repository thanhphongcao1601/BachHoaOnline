using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
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
    public class AdminSanPhamsController : Controller
    {
        private readonly PTHShoppingContext _context;
        private readonly IHostingEnvironment _environment;
        public INotyfService _notifService { get; }
        public AdminSanPhamsController(PTHShoppingContext context, INotyfService notifService, IHostingEnvironment IHostingEnvironment)
        {
            _context = context;
            _environment = IHostingEnvironment;
            _notifService = notifService;
        }



        // GET: Admin/AdminSanPhams

        [Route("Admin/AdminSanPhams/{page}/{CatID}/{trangthai}/{active}")]
        [Route("Admin/AdminSanPhams")]
        public IActionResult Index(int page = 1, string CatID = "all", string trangthai = "all", int active = -1)
        {

            List<SelectListItem> lsTrangThai = new List<SelectListItem>();
            lsTrangThai.Add(new SelectListItem { Text = "Còn Hàng", Value = "1" });
            lsTrangThai.Add(new SelectListItem { Text = "Hết hàng", Value = "0" });
            foreach(var item in lsTrangThai)
            {
                if (item.Value == trangthai.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewData["lsTrangThai"] = lsTrangThai;
            var pageNumber = page;
            var pageSize = 10;
            List<SanPham> lsProduct = new List<SanPham>();

            if (CatID != "all" && trangthai == "1")
            {
                lsProduct = _context.SanPhams
                   .AsNoTracking()
                   .Where(x => x.CatId == CatID)
                   .Where(x => x.UnitsInStock > 0)
                   .Include(x => x.Cat)
                   .OrderByDescending(x => x.Active).ToList();
            }
            else if (CatID != "all" && trangthai == "all")
            {
                lsProduct = _context.SanPhams
                   .AsNoTracking()
                   .Where(x => x.CatId == CatID)
                   .Include(x => x.Cat)
                   .OrderByDescending(x => x.Active).ToList();
            }
            else if (CatID != "all" && trangthai == "0")
            {
                lsProduct = _context.SanPhams
                   .AsNoTracking()
                   .Where(x => x.CatId == CatID)
                   .Where(x => x.UnitsInStock <= 0)
                   .Include(x => x.Cat)
                   .OrderByDescending(x => x.Active).ToList();
            }
            else if (CatID == "all" && trangthai == "1")
            {
                lsProduct = _context.SanPhams
                   .AsNoTracking()
                   .Where(x => x.UnitsInStock > 0)
                   .Include(x => x.Cat)
                   .OrderByDescending(x => x.Active).ToList();
            }
            else if (CatID == "all" && trangthai == "0")
            {
                lsProduct = _context.SanPhams
                   .AsNoTracking()
                   .Where(x => x.UnitsInStock <= 0)
                   .Include(x => x.Cat)
                   .OrderByDescending(x => x.Active).ToList();
            }
            else
            {
                lsProduct = _context.SanPhams
                    .AsNoTracking()
                    .Include(x => x.Cat)
                    .OrderByDescending(x => x.Active).ToList();
            }

            if (active == 1)
            {
                lsProduct = lsProduct.Where(x => x.Active == true).ToList();
            }
            if (active == 0)
            {
                lsProduct = lsProduct.Where(x => x.Active == false).ToList();
            }

            PagedList<SanPham> models = new PagedList<SanPham>(lsProduct.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.CurrentCatID = CatID;
            ViewBag.Currenttrangthai = trangthai;
            ViewBag.CurrentFilter = active;
            ViewData["Cat"] = new SelectList(_context.Categories.Where(x=>x.Published==true), "CatId", "CatName", CatID);
            return View(models);
        }

        [Route("Admin/AdminSanPhams/Filter/{page?}/{CatID?}/{trangthai?}/{active?}")]
        public IActionResult Filter(int page=1, string CatID = "all", string trangthai="all", int active=-1)
        {
            var url = $"/Admin/AdminSanphams/{page}/{CatID}/{trangthai}/{active}";
            if (CatID == "all" && trangthai == "all")
            {
                url = $"/Admin/AdminSanphams";
            }
            return Json(new { status = "success", redirectUrl = url });
        }
        // GET: Admin/AdminSanPhams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.IdsanPham == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/AdminSanPhams/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatName");
  

            return View();
        }

        // POST: Admin/AdminSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdsanPham,TenSanPham,ShortDesc,MoTa,CatId,Gia,KhuyenMai,Thumb,Video,NgayTao,BestSellers,HomeFlag,Active,Tags,TieuDe,Slban,MetaDesc,MetaKey,UnitsInStock")] SanPham sanPham, IFormFile file, IFormFile fileVideo)
        {
            var newFileName = string.Empty;
            if (ModelState.IsValid)
            {
                var err = 0;
                if(sanPham.IdsanPham==null || sanPham.IdsanPham == string.Empty)
                {
                    ViewBag.nullID = "nullId";
                    err = 1;
                }
                var lis_Id = _context.SanPhams.Select(x => x.IdsanPham).ToList();
                foreach (var x in lis_Id)
                {
                    var xn = x.Trim();
                    if (sanPham.IdsanPham.Equals(xn))
                    {
                        ViewBag.TrungID = xn;
                        err = 1;
                    }
                }
                if(sanPham.TenSanPham == null || sanPham.TenSanPham == string.Empty)
                {
                    ViewBag.nullName = "nullName";
                    err = 1;
                }
                if (sanPham.Gia == null || sanPham.Gia<=0)
                {
                    ViewBag.gia = "nullGia";
                    err = 1;
                }
                if (err == 1)
                {
                    return View(sanPham);
                }
                string PathDB = string.Empty;
                if (file != null) //Luu Anh
                {
                    PathDB = saveImg(file);
                    sanPham.Thumb = PathDB;
                }
                string PathDBVD = string.Empty;
                if (fileVideo != null) //Luu video
                {
                    PathDB = saveVideo(fileVideo);
                    sanPham.Video = PathDBVD;
                }

                sanPham.Slban = 0;
                sanPham.NgayTao = DateTime.Now;
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                _notifService.Success("Thêm mới thành công!");
                return RedirectToAction(nameof(Index));
            }
            return View(sanPham);
        }

        public string saveVideo(IFormFile file)
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
                fileName = Path.Combine(_environment.WebRootPath, "ProductVideos") + $@"\{newFileName}";
                // path de luu DB
                PathDB = "ProductVideos/" + newFileName;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return PathDB;
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
                fileName = Path.Combine(_environment.WebRootPath, "ProductImages") + $@"\{newFileName}";
                // path de luu DB
                PathDB = "ProductImages/" + newFileName;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return PathDB;
        }
        // GET: Admin/AdminSanPhams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatName");

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            
            return View(sanPham);
        }

        // POST: Admin/AdminSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdsanPham,TenSanPham,ShortDesc,MoTa,CatId,Gia,KhuyenMai,Thumb,Video,NgayTao,BestSellers,HomeFlag,Active,Tags,TieuDe,SLBan,MetaDesc,MetaKey,UnitsInStock")] SanPham sanPham, IFormFile file, IFormFile fileVideo)
        {
            if (id != sanPham.IdsanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var err = 0;
                    if (sanPham.IdsanPham == null || sanPham.IdsanPham == string.Empty)
                    {
                        ViewBag.nullID = "nullId";
                        err = 1;
                    }
                    if (sanPham.TenSanPham == null || sanPham.TenSanPham == string.Empty)
                    {
                        ViewBag.nullName = "nullName";
                        err = 1;
                    }
                    if (sanPham.Gia == null || sanPham.Gia <= 0)
                    {
                        ViewBag.gia = "nullGia";
                        err = 1;
                    }
                    if (err == 1)
                    {
                        return View(sanPham);
                    }
                    string thumbOld = sanPham.Thumb;
                    string videoOld = sanPham.Video;

                    string PathDB = string.Empty;
                    if (file != null) //Luu Anh
                    {
                        PathDB = saveImg(file);
                        sanPham.Thumb = PathDB;
                        if (thumbOld != string.Empty && thumbOld != null)
                        {
                            if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, thumbOld)))
                            {
                                System.IO.File.Delete(Path.Combine(_environment.WebRootPath, thumbOld));

                            }
                        }

                    }
                    string PathDBVD = string.Empty;
                    if (fileVideo != null) //Luu video
                    {
                        PathDBVD = saveVideo(fileVideo);
                        sanPham.Video = PathDBVD;
                        if (videoOld != string.Empty && videoOld != null)
                        {
                            if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, videoOld)))
                            {
                                System.IO.File.Delete(Path.Combine(_environment.WebRootPath, videoOld));

                            }
                        }
                    }
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                    _notifService.Success("Chỉnh sửa thành công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.IdsanPham))
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
            return View(sanPham);
        }

        // GET: Admin/AdminSanPhams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.IdsanPham == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/AdminSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham.Thumb != string.Empty && sanPham.Thumb!=null)
            {
                if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, sanPham.Thumb.ToString())))
                {
                    System.IO.File.Delete(Path.Combine(_environment.WebRootPath, sanPham.Thumb.ToString()));
      
                }
            }
            if (sanPham.Video != string.Empty && sanPham.Video!=null)
            {
                if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, sanPham.Video.ToString())))
                {
                    System.IO.File.Delete(Path.Combine(_environment.WebRootPath, sanPham.Video.ToString()));

                }
            }
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            _notifService.Success("Xóa thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(string id)
        {
            return _context.SanPhams.Any(e => e.IdsanPham == id);
        }
    }
}
