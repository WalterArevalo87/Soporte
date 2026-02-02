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
    public class BancosController : Controller
    {
        private readonly SoporteDbContext _context;

        public BancosController(SoporteDbContext context)
        {
            _context = context;
        }

        // GET: Bancos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bancos.ToListAsync());
        }

        // GET: Bancos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancosModel = await _context.Bancos
                .FirstOrDefaultAsync(m => m.id == id);
            if (bancosModel == null)
            {
                return NotFound();
            }

            return View(bancosModel);
        }

        // GET: Bancos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bancos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,direccion,telefono,correo")] BancosModel bancosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bancosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bancosModel);
        }

        // GET: Bancos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancosModel = await _context.Bancos.FindAsync(id);
            if (bancosModel == null)
            {
                return NotFound();
            }
            return View(bancosModel);
        }

        // POST: Bancos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,direccion,telefono,correo")] BancosModel bancosModel)
        {
            if (id != bancosModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bancosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BancosModelExists(bancosModel.id))
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
            return View(bancosModel);
        }

        // GET: Bancos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancosModel = await _context.Bancos
                .FirstOrDefaultAsync(m => m.id == id);
            if (bancosModel == null)
            {
                return NotFound();
            }

            return View(bancosModel);
        }

        // POST: Bancos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bancosModel = await _context.Bancos.FindAsync(id);
            if (bancosModel != null)
            {
                _context.Bancos.Remove(bancosModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BancosModelExists(int id)
        {
            return _context.Bancos.Any(e => e.id == id);
        }
    }
}
