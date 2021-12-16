using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PTHShopping.Models;

namespace PTHShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AccountsController : Controller
    {
        private readonly PTHShoppingContext _context;

        public AccountsController(PTHShoppingContext context)
        {
            _context = context;
        }

        // GET: Admin/Accounts
        [Route("Admin/Accounts")]
        [Route("Admin/Accounts/{page}/{RoleID}/{trangthai}")]
        public async Task<IActionResult> Index(int page = 1, string RoleID="all", string trangthai="all")
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "RoleId", "MoTa",RoleID);
            List<SelectListItem> lsTrangThai = new List<SelectListItem>();
            lsTrangThai.Add(new SelectListItem { Text = "Active", Value="1"});
            lsTrangThai.Add(new SelectListItem { Text = "Inactive", Value="0"});
            foreach (var item in lsTrangThai)
            {
                if (item.Value == trangthai.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewData["lsTrangThai"] = lsTrangThai;
            List<Account> pTHShoppingContext = new List<Account>();

            if (RoleID != "all" && trangthai=="all")
            {
                 pTHShoppingContext = _context.Accounts.Where(x=>x.RoleId==RoleID).Include(a => a.Role).ToList();
            }
            else if(RoleID != "all" && trangthai == "1")
            {
                 pTHShoppingContext = _context.Accounts.Where(x => x.RoleId == RoleID && x.Active==true).Include(a => a.Role).ToList();
            }
            else if (RoleID == "all" && trangthai == "1")
            {
                pTHShoppingContext = _context.Accounts.Where(x => x.Active == true).Include(a => a.Role).ToList();
            }
            else if (RoleID == "all" && trangthai == "0")
            {
                pTHShoppingContext = _context.Accounts.Where(x => x.Active == false).Include(a => a.Role).ToList();
            }
            else if (RoleID != "all" && trangthai == "0")
            {
                 pTHShoppingContext = _context.Accounts.Where(x => x.RoleId == RoleID && x.Active == false).Include(a => a.Role).ToList();
            }
            else if (RoleID == "all" && trangthai == "all")
            {
                 pTHShoppingContext = _context.Accounts.Include(a => a.Role).ToList();
            }

            var pageNumber = page;
            var pageSize = 10;
            PagedList<Account> models = new PagedList<Account>(pTHShoppingContext.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.CurrentRoleID = RoleID;
            ViewBag.Currenttrangthai = trangthai;
            return View(models);
        }


        [Route("Admin/Accounts/Filter/{page?}/{RoleID?}/{trangthai?}")]
        public IActionResult Filter(int page=1,string RoleID = "all", string trangthai = "all")
        {
            var url = $"/Admin/Accounts/{page}/{RoleID}/{trangthai}";
            if (RoleID == "all" && trangthai == "all")
            {
                url = $"/Admin/Accounts";
            }
            return Json(new { status = "success", redirectUrl = url });
        }
        // GET: Admin/Accounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/Accounts/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Sdt,Email,Password,Salt,Active,HoTen,RoleId,LastLogin,NgayTao")] Account account)
        {
            if (ModelState.IsValid)
            {
                ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
                var err = 0;
                var id = _context.Accounts.Where(x => x.AccountId == account.AccountId).ToList();
                if (id.Count!=0)
                {
                    ViewBag.IDTrung = account.AccountId;
                    err = 1;
                }
                var sdt = _context.Accounts.Where(x => x.Sdt == account.Sdt).ToList();
                if (sdt.Count!=0)
                {
                    ViewBag.SDTTrung = account.Sdt;
                    err = 1;
                }
                 if(account.Sdt==null || account.Sdt == string.Empty)
                {
                    ViewBag.sdt = "nullSdt";
                    err = 1;
                }
                if(account.HoTen==null || account.HoTen == string.Empty)
                {
                    ViewBag.name = "nullName";
                    err = 1;
                }
                if (account.Password == null || account.Password == string.Empty)
                {
                    ViewBag.pass = "nullPass";
                    err = 1;
                }
                if (err == 1)
                {
                    return View(account);
                }
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password, account.Salt);
                account.NgayTao = DateTime.Now;
                account.Active = true;
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", account.RoleId);
            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccountId,Sdt,Email,Password,Salt,Active,HoTen,RoleId,LastLogin,NgayTao")] Account account, string pass2)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
                    var err = 0;
                    if (account.HoTen == null || account.HoTen == string.Empty)
                    {
                        ViewBag.name = "nullName";
                        err = 1;
                    }
                    if (err == 1)
                    {
                        return View(account);
                    }
                    if(pass2!=string.Empty && pass2 != null)
                    {
                        account.Password = BCrypt.Net.BCrypt.HashPassword(pass2, account.Salt);
                    }
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
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
           
            return View(account);
        }

        // GET: Admin/Accounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}
