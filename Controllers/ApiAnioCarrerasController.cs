using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    public class ApiAnioCarrerasController : Controller
    {
        private readonly InscripcionesContext _context;

        public ApiAnioCarrerasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: ApiAnioCarreras
        public async Task<IActionResult> Index()
        {
            var inscripcionesContext = _context.AnioCarreras.Include(a => a.Carrera);
            return View(await inscripcionesContext.ToListAsync());
        }

        // GET: ApiAnioCarreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.AnioCarreras
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anioCarrera == null)
            {
                return NotFound();
            }

            return View(anioCarrera);
        }

        // GET: ApiAnioCarreras/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.carreras, "Id", "Id");
            return View();
        }

        // POST: ApiAnioCarreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CarreraId")] AnioCarrera anioCarrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anioCarrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.carreras, "Id", "Id", anioCarrera.CarreraId);
            return View(anioCarrera);
        }

        // GET: ApiAnioCarreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.AnioCarreras.FindAsync(id);
            if (anioCarrera == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.carreras, "Id", "Id", anioCarrera.CarreraId);
            return View(anioCarrera);
        }

        // POST: ApiAnioCarreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CarreraId")] AnioCarrera anioCarrera)
        {
            if (id != anioCarrera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anioCarrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnioCarreraExists(anioCarrera.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.carreras, "Id", "Id", anioCarrera.CarreraId);
            return View(anioCarrera);
        }

        // GET: ApiAnioCarreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.AnioCarreras
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anioCarrera == null)
            {
                return NotFound();
            }

            return View(anioCarrera);
        }

        // POST: ApiAnioCarreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anioCarrera = await _context.AnioCarreras.FindAsync(id);
            if (anioCarrera != null)
            {
                _context.AnioCarreras.Remove(anioCarrera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnioCarreraExists(int id)
        {
            return _context.AnioCarreras.Any(e => e.Id == id);
        }
    }
}
