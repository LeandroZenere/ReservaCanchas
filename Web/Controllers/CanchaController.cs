using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Repos;

namespace Web.Controllers
{
    public class CanchaController : Controller
    {
        private readonly ReservaCanchaContext _context;

        public CanchaController(ReservaCanchaContext context)
        {
            _context = context;
        }

        // GET: Cancha
        public async Task<IActionResult> Index()
        {
              return _context.Cancha != null ? 
                          View(await _context.Cancha.ToListAsync()) :
                          Problem("Entity set 'ReservaCanchaContext.Cancha'  is null.");
        }

        // GET: Cancha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cancha == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        // GET: Cancha/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cancha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Disponible,Precio")] Cancha cancha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cancha);
        }

        // GET: Cancha/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cancha == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha.FindAsync(id);
            if (cancha == null)
            {
                return NotFound();
            }
            return View(cancha);
        }

        // POST: Cancha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Disponible,Precio")] Cancha cancha)
        {
            if (id != cancha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanchaExists(cancha.Id))
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
            return View(cancha);
        }

        // GET: Cancha/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cancha == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        // POST: Cancha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cancha == null)
            {
                return Problem("Entity set 'ReservaCanchaContext.Cancha'  is null.");
            }
            var cancha = await _context.Cancha.FindAsync(id);
            if (cancha != null)
            {
                _context.Cancha.Remove(cancha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanchaExists(int id)
        {
          return (_context.Cancha?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
