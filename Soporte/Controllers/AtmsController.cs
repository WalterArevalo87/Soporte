using System;
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
            var atms = _context.Atms
                .Include(a => a.AgenciasModel)
                .Include(a => a.BancosModel)
                .Include(a => a.GestoresModel)
                .Include(a => a.MantenimientosModel);

            return View(await atms.ToListAsync());
        }

        // GET: Atms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var atm = await _context.Atms
                .Include(a => a.AgenciasModel)
                .Include(a => a.BancosModel)
                .Include(a => a.GestoresModel)
                .Include(a => a.MantenimientosModel)
                .FirstOrDefaultAsync(m => m.id == id);

            if (atm == null) return NotFound();

            return View(atm);
        }

        // GET: Atms/Create
        public IActionResult Create()
        {
            CargarDropdowns();
            return View();
        }

        // POST: Atms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtmsModel atmsModel)
        {
            Console.WriteLine("Entró al POST Create"); // 👈 prueba
            if (ModelState.IsValid)
            {
                _context.Add(atmsModel);
                await _context.SaveChangesAsync();
                Console.WriteLine("ATM guardado correctamente con ID: " + atmsModel.id);
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine("Error: " + error.ErrorMessage);
            }

            return View(atmsModel);
        }


        // GET: Atms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var atm = await _context.Atms.FindAsync(id);
            if (atm == null) return NotFound();

            CargarDropdowns(atm);
            return View(atm);
        }

        // POST: Atms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,direccion,tipo,modelo,GestoresModelId,MantenimientosModelId,AgenciasModelId,BancosModelId")] AtmsModel atmsModel)
        {
            if (id != atmsModel.id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atmsModel);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("ATM actualizado correctamente.");
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtmsModelExists(atmsModel.id)) return NotFound();
                    else throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar: " + ex.Message);
                }
            }
            else
            {
                var errores = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errores)
                {
                    Console.WriteLine("Error de validación: " + error.ErrorMessage);
                }
            }

            CargarDropdowns(atmsModel);
            return View(atmsModel);
        }

        // GET: Atms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var atm = await _context.Atms
                .Include(a => a.AgenciasModel)
                .Include(a => a.BancosModel)
                .Include(a => a.GestoresModel)
                .Include(a => a.MantenimientosModel)
                .FirstOrDefaultAsync(m => m.id == id);

            if (atm == null) return NotFound();

            return View(atm);
        }

        // POST: Atms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atm = await _context.Atms.FindAsync(id);
            if (atm != null)
            {
                _context.Atms.Remove(atm);
                await _context.SaveChangesAsync();
                Console.WriteLine("ATM eliminado.");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AtmsModelExists(int id)
        {
            return _context.Atms.Any(e => e.id == id);
        }

        private void CargarDropdowns(AtmsModel? atm = null)
        {
            ViewData["AgenciasModelId"] = new SelectList(_context.Agencias, "id", "nombre", atm?.AgenciasModelId);
            ViewData["BancosModelId"] = new SelectList(_context.Bancos, "id", "nombre", atm?.BancosModelId);
            ViewData["GestoresModelId"] = new SelectList(_context.Gestores, "id", "nombres", atm?.GestoresModelId);
            ViewData["MantenimientosModelId"] = new SelectList(_context.Mantenimientos, "id", "tipo", atm?.MantenimientosModelId);
        }
    }
}
