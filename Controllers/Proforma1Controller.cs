using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppDilleto.Data;
using AppDilleto.Models;
using Microsoft.AspNetCore.Identity;

namespace plantitas.Controllers
{
    public class Proforma1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Proforma1Controller(ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Proforma
        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataCarrito select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));
            
            return View(await items.ToListAsync());
        }

        // GET: Proforma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma1 = await _context.DataCarrito
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proforma1 == null)
            {
                return NotFound();
            }

            return View(proforma1);
        }

        // GET: Proforma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proforma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,Quantity,Price")] Proforma1 proforma1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proforma1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proforma1);
        }

        // GET: Proforma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma1 = await _context.DataCarrito.FindAsync(id);
            if (proforma1 == null)
            {
                return NotFound();
            }
            return View(proforma1);
        }

        // POST: Proforma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,Quantity,Price")] Proforma1 proforma1)
        {
            if (id != proforma1.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proforma1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProformaExists(proforma1.ID))
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
            return View(proforma1);
        }

        // GET: Proforma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma1 = await _context.DataCarrito
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proforma1 == null)
            {
                return NotFound();
            }

            return View(proforma1);
        }

        // POST: Proforma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proforma1 = await _context.DataCarrito.FindAsync(id);
            _context.DataCarrito.Remove(proforma1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProformaExists(int id)
        {
            return _context.DataCarrito.Any(e => e.ID == id);
        }
    }
}