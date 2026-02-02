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
    public class AtmsController : Controller
    {
        private readonly SoporteDbContext _context;

        public AtmsController(SoporteDbContext context)
        {
            _context = context;
        }

        // GET: Atms
        public async Task<IActionResult> Index()
        {
            var soporteDbContext = _context.Atms.Include(a => a.AgenciasModel).Include(a => a.BancosModel).Include(a => a.GestoresModel).Include(a => a.MantenimientosModel);
            return View(await soporteDbContext.ToListAsync());
        }

        // GET: Atms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atmsModel = await _context.Atms
                .Include(a => a.AgenciasModel)
                .Include(a => a.BancosModel)
                .Include(a => a.GestoresModel)
                .Include(a => a.MantenimientosModel)
                .FirstOrDefaultAsync(m => m.id == id);
            if (atmsModel == null)
            {
                return NotFound();
            }

            return View(atmsModel);
        }

        // GET: Atms/Create
        public IActionResult Create()
        {
            ViewData["AgenciasModelId"] = new SelectList(_context.Agencias, "id", "ciudad");
            ViewData["BancosModelId"] = new SelectList(_context.Bancos, "id", "correo");
            ViewData["GestoresModelId"] = new SelectList(_context.Gestores, "id", "apellido");
            ViewData["MantenimientosModelId"] = new SelectList(_context.Mantenimientos, "id", "Observaciones");
            return View();
        }

        // POST: Atms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,direccion,tipo,modelo,GestoresModelId,MantenimientosModelId,AgenciasModelId,BancosModelId")] AtmsModel atmsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atmsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgenciasModelId"] = new SelectList(_context.Agencias, "id", "ciudad", atmsModel.AgenciasModelId);
            ViewData["BancosModelId"] = new SelectList(_context.Bancos, "id", "correo", atmsModel.BancosModelId);
            ViewData["GestoresModelId"] = new SelectList(_context.Gestores, "id", "apellido", atmsModel.GestoresModelId);
            ViewData["MantenimientosModelId"] = new SelectList(_context.Mantenimientos, "id", "Observaciones", atmsModel.MantenimientosModelId);
            return View(atmsModel);
        }

        // GET: Atms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atmsModel = await _context.Atms.FindAsync(id);
            if (atmsModel == null)
            {
                return NotFound();
            }
            ViewData["AgenciasModelId"] = new SelectList(_context.Agencias, "id", "ciudad", atmsModel.AgenciasModelId);
            ViewData["BancosModelId"] = new SelectList(_context.Bancos, "id", "correo", atmsModel.BancosModelId);
            ViewData["GestoresModelId"] = new SelectList(_context.Gestores, "id", "apellido", atmsModel.GestoresModelId);
            ViewData["MantenimientosModelId"] = new SelectList(_context.Mantenimientos, "id", "Observaciones", atmsModel.MantenimientosModelId);
            return View(atmsModel);
        }

        // POST: Atms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,direccion,tipo,modelo,GestoresModelId,MantenimientosModelId,AgenciasModelId,BancosModelId")] AtmsModel atmsModel)
        {
            if (id != atmsModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atmsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtmsModelExists(atmsModel.id))
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
            ViewData["AgenciasModelId"] = new SelectList(_context.Agencias, "id", "ciudad", atmsModel.AgenciasModelId);
            ViewData["BancosModelId"] = new SelectList(_context.Bancos, "id", "correo", atmsModel.BancosModelId);
            ViewData["GestoresModelId"] = new SelectList(_context.Gestores, "id", "apellido", atmsModel.GestoresModelId);
            ViewData["MantenimientosModelId"] = new SelectList(_context.Mantenimientos, "id", "Observaciones", atmsModel.MantenimientosModelId);
            return View(atmsModel);
        }

        // GET: Atms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atmsModel = await _context.Atms
                .Include(a => a.AgenciasModel)
                .Include(a => a.BancosModel)
                .Include(a => a.GestoresModel)
                .Include(a => a.MantenimientosModel)
                .FirstOrDefaultAsync(m => m.id == id);
            if (atmsModel == null)
            {
                return NotFound();
            }

            return View(atmsModel);
        }

        // POST: Atms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atmsModel = await _context.Atms.FindAsync(id);
            if (atmsModel != null)
            {
                _context.Atms.Remove(atmsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtmsModelExists(int id)
        {
            return _context.Atms.Any(e => e.id == id);
        }
    }
}
