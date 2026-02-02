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
    public class MantenimientosController : Controller
    {
        private readonly SoporteDbContext _context;

        public MantenimientosController(SoporteDbContext context)
        {
            _context = context;
        }

        // GET: Mantenimientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mantenimientos.ToListAsync());
        }

        // GET: Mantenimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientosModel = await _context.Mantenimientos
                .FirstOrDefaultAsync(m => m.id == id);
            if (mantenimientosModel == null)
            {
                return NotFound();
            }

            return View(mantenimientosModel);
        }

        // GET: Mantenimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mantenimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tipo,fechainicio,fechafin,Observaciones")] MantenimientosModel mantenimientosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mantenimientosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mantenimientosModel);
        }

        // GET: Mantenimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientosModel = await _context.Mantenimientos.FindAsync(id);
            if (mantenimientosModel == null)
            {
                return NotFound();
            }
            return View(mantenimientosModel);
        }

        // POST: Mantenimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tipo,fechainicio,fechafin,Observaciones")] MantenimientosModel mantenimientosModel)
        {
            if (id != mantenimientosModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mantenimientosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MantenimientosModelExists(mantenimientosModel.id))
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
            return View(mantenimientosModel);
        }

        // GET: Mantenimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientosModel = await _context.Mantenimientos
                .FirstOrDefaultAsync(m => m.id == id);
            if (mantenimientosModel == null)
            {
                return NotFound();
            }

            return View(mantenimientosModel);
        }

        // POST: Mantenimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mantenimientosModel = await _context.Mantenimientos.FindAsync(id);
            if (mantenimientosModel != null)
            {
                _context.Mantenimientos.Remove(mantenimientosModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MantenimientosModelExists(int id)
        {
            return _context.Mantenimientos.Any(e => e.id == id);
        }
    }
}
