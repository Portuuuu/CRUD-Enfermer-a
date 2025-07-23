using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Enfermeria.Models
{
    public class EnfPersonasController : Controller
    {
        private readonly EnfermeriaContext _context;

        public EnfPersonasController(EnfermeriaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.EnfPersonas
                .Where(p => p.Activo)
                .ToListAsync());
        }

        public async Task<IActionResult> Inactivos()
        {
            var inactivos = await _context.EnfPersonas
                .Where(p => !p.Activo)
                .ToListAsync();

            return View(inactivos);
        }

        [HttpPost]
        public async Task<IActionResult> Reactivar(int id)
        {
            var persona = await _context.EnfPersonas.FindAsync(id);
            if (persona != null)
            {
                persona.Activo = true;
                _context.Update(persona);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Inactivos));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var enfPersona = await _context.EnfPersonas
                .FirstOrDefaultAsync(m => m.Id == id);

            if (enfPersona == null)
                return NotFound();

            return View(enfPersona);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula,Nombre,Telefono,Email,Usuario,Password,Departamento,Tipo,Seccion,FechaNacimiento,Sexo")] EnfPersona enfPersona)
        {
            if (ModelState.IsValid)
            {
                enfPersona.Activo = true;
                _context.Add(enfPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfPersona);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var enfPersona = await _context.EnfPersonas.FindAsync(id);
            if (enfPersona == null)
                return NotFound();

            return View(enfPersona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula,Nombre,Telefono,Email,Usuario,Password,Departamento,Tipo,Seccion,FechaNacimiento,Sexo,Activo")] EnfPersona enfPersona)
        {
            if (id != enfPersona.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.EnfPersonas.Any(e => e.Id == enfPersona.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enfPersona);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var enfPersona = await _context.EnfPersonas
                .FirstOrDefaultAsync(m => m.Id == id);

            if (enfPersona == null)
                return NotFound();

            return View(enfPersona);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfPersona = await _context.EnfPersonas.FindAsync(id);
            if (enfPersona != null)
            {
                enfPersona.Activo = false;
                _context.Update(enfPersona);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
