using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soporte.Models;

namespace Soporte.Controllers
{
    public class GestoresController : Controller
    {
        private readonly SoporteDbContext _context;

        public GestoresController(SoporteDbContext context)
        {
            _context = context;
        }

        // GET: Gestores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gestores.ToListAsync());
        }

        // GET: Gestores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestoresModel = await _context.Gestores
                .FirstOrDefaultAsync(m => m.id == id);
            if (gestoresModel == null)
            {
                return NotFound();
            }

            return View(gestoresModel);
        }

        // GET: Gestores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gestores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombres,apellido,cargo,direccion")] GestoresModel gestoresModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestoresModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gestoresModel);
        }

        // GET: Gestores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestoresModel = await _context.Gestores.FindAsync(id);
            if (gestoresModel == null)
            {
                return NotFound();
            }
            return View(gestoresModel);
        }

        // POST: Gestores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombres,apellido,cargo,direccion")] GestoresModel gestoresModel)
        {
            if (id != gestoresModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestoresModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestoresModelExists(gestoresModel.id))
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
            return View(gestoresModel);
        }

        // GET: Gestores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestoresModel = await _context.Gestores
                .FirstOrDefaultAsync(m => m.id == id);
            if (gestoresModel == null)
            {
                return NotFound();
            }

            return View(gestoresModel);
        }

        // POST: Gestores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestoresModel = await _context.Gestores.FindAsync(id);
            if (gestoresModel != null)
            {
                _context.Gestores.Remove(gestoresModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestoresModelExists(int id)
        {
            return _context.Gestores.Any(e => e.id == id);
        }
    }
}
