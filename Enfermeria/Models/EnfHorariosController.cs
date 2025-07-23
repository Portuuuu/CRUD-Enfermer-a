using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Enfermeria.Models
{
    public class EnfHorariosController : Controller
    {
        private readonly EnfermeriaContext _context;

        public EnfHorariosController(EnfermeriaContext context)
        {
            _context = context;
        }

        // GET: EnfHorarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnfHorarios.ToListAsync());
        }

        // GET: EnfHorarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfHorario = await _context.EnfHorarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfHorario == null)
            {
                return NotFound();
            }

            return View(enfHorario);
        }

        // GET: EnfHorarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnfHorarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Hora,Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion")] EnfHorario enfHorario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfHorario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfHorario);
        }

        // GET: EnfHorarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfHorario = await _context.EnfHorarios.FindAsync(id);
            if (enfHorario == null)
            {
                return NotFound();
            }
            return View(enfHorario);
        }

        // POST: EnfHorarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Hora,Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion")] EnfHorario enfHorario)
        {
            if (id != enfHorario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfHorario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfHorarioExists(enfHorario.Id))
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
            return View(enfHorario);
        }

        // GET: EnfHorarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfHorario = await _context.EnfHorarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfHorario == null)
            {
                return NotFound();
            }

            return View(enfHorario);
        }

        // POST: EnfHorarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfHorario = await _context.EnfHorarios.FindAsync(id);
            if (enfHorario != null)
            {
                _context.EnfHorarios.Remove(enfHorario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfHorarioExists(int id)
        {
            return _context.EnfHorarios.Any(e => e.Id == id);
        }
    }
}
