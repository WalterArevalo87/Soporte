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
    public class AgenciasController : Controller
    {
        private readonly SoporteDbContext _context;

        public AgenciasController(SoporteDbContext context)
        {
            _context = context;
        }

        // GET: Agencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agencias.ToListAsync());
        }

        // GET: Agencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciasModel = await _context.Agencias
                .FirstOrDefaultAsync(m => m.id == id);
            if (agenciasModel == null)
            {
                return NotFound();
            }

            return View(agenciasModel);
        }

        // GET: Agencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,telefono,direccion,ciudad")] AgenciasModel agenciasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenciasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenciasModel);
        }

        // GET: Agencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciasModel = await _context.Agencias.FindAsync(id);
            if (agenciasModel == null)
            {
                return NotFound();
            }
            return View(agenciasModel);
        }

        // POST: Agencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,telefono,direccion,ciudad")] AgenciasModel agenciasModel)
        {
            if (id != agenciasModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenciasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenciasModelExists(agenciasModel.id))
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
            return View(agenciasModel);
        }

        // GET: Agencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciasModel = await _context.Agencias
                .FirstOrDefaultAsync(m => m.id == id);
            if (agenciasModel == null)
            {
                return NotFound();
            }

            return View(agenciasModel);
        }

        // POST: Agencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenciasModel = await _context.Agencias.FindAsync(id);
            if (agenciasModel != null)
            {
                _context.Agencias.Remove(agenciasModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenciasModelExists(int id)
        {
            return _context.Agencias.Any(e => e.id == id);
        }
    }
}
