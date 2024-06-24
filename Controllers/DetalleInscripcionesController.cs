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
    public class DetalleInscripcionesController : Controller
    {
        private readonly InscripcionesContext _context;

        public DetalleInscripcionesController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: DetalleInscripciones
        public async Task<IActionResult> IndexPorInscripcion(int? idinscripcion = 1)
        {
            var inscripciones = _context.DetalleInscripciones.Include(d => d.Materia).ThenInclude(m => m.AnioCarrera).ThenInclude(a => a.Carrera).Where(d => d.InscripcionId.Equals(idinscripcion)).OrderBy(d => d.Materia.AnioCarreraId);
            ViewData["Inscripciones"] = new SelectList(_context.inscripciones.Include(i => i.Alumno), "Id", "Inscripto", idinscripcion);
            ViewData["IdInscripcion"] = idinscripcion;
            return View(await inscripciones.ToListAsync());
        }

        // GET: DetalleInscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.DetalleInscripciones
                .Include(d => d.Inscripcion)
                .Include(d => d.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return View(detalleInscripcion);
        }

        // GET: DetalleInscripciones/Create
        public IActionResult Create()
        {
            ViewData["InscripcionId"] = new SelectList(_context.inscripciones.Include(i => i.Alumno), "Id", "Inscripto");
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Nombre");
            return View();
        }

        public IActionResult CreateConInscripcion(int idinscripcion = 1, int? idaniocarrera = null)
        {
            //ARMANDO LA LISTA DE INSCRIPCIONES Y SELECCIONO LA INSCRIPCION ACTUAL, AL PASAR LA VARIABLE ID INSCRIPCIONES.
            ViewData["Inscripciones"] = new SelectList(_context.inscripciones.Include(i => i.Alumno).Include(i => i.Carrera), "Id", "Inscripto", idinscripcion);

            //SE OBTIENE EL REGISTRO DE LA INSCRIPCION PUNTUAL.
            Inscripcion inscripcion = _context.inscripciones.FirstOrDefault(i => i.Id == idinscripcion);

            //SI NO TENGO DEFINIDO UN AÑO CARRERA, BUSCA EL PRIMER AÑO CARRERA USANDO FirstOrDefault().
            idaniocarrera ??= _context.AnioCarreras.Where(i => i.CarreraId == inscripcion.CarreraId).FirstOrDefault().Id;

            //ARMO LA LIST DE AÑOS DE LA CARRERA SELECCIONADA, SELECCIONANDO EL ID AÑO CARRERA
            ViewData["AniosCarreras"] = new SelectList(_context.AnioCarreras.Include(a => a.Carrera).Where(_i => _i.CarreraId == inscripcion.CarreraId), "Id", "AñoYCarrera", idaniocarrera);

            //ALMACENAMOS EL ID PARA QUE SE MANTENGA EN LOS DIFERENTES CREATES QUE EJECUTEMOS.
            ViewData["IdInscripcion"] = idinscripcion;
            ViewData["IdAnioCarrera"] = idaniocarrera;

            //ARMAMOS UNA LISTA DE MATERIAS QUE PERTENEZCA AL AÑO CARRERA SELECCIONADO.
            ViewData["Materias"] = new SelectList(_context.Materias.Where(m => m.AnioCarreraId.Equals(idaniocarrera)), "Id", "Nombre");

            //ENVIAMOS LA LISTA DE LOS DETALLES DE INSCRIPCION DE LA INCRIPCION ACTUAL PARA QUE SE ARME LA TABLA QUE LAS MUESTRA MIENTRAS CARGAMOS NUEVAS.
            ViewData["DetallesInscripciones"] = _context.DetalleInscripciones.Include(d => d.Materia).ThenInclude(m => m.AnioCarrera).ThenInclude(a => a.Carrera).Where(d => d.InscripcionId.Equals(idinscripcion)).OrderBy(d => d.Materia.AnioCarreraId);
            return View();
        }

        // POST: DetalleInscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModalidadCursado,InscripcionId,MateriaId")] DetalleInscripcion detalleInscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleInscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InscripcionId"] = new SelectList(_context.inscripciones, "Id", "Id", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Id", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }
        // POST: DetalleInscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConInscripcion([Bind("Id,ModalidadCursado,InscripcionId,MateriaId")] DetalleInscripcion detalleInscripcion)
        {
            var detalleExistente = _context.DetalleInscripciones
                .Where(d=>d.InscripcionId.Equals(detalleInscripcion.InscripcionId)
                &&d.MateriaId.Equals(detalleInscripcion.MateriaId)).FirstOrDefault();

            if (ModelState.IsValid && detalleExistente == null)
            {
                _context.Add(detalleInscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexPorInscripcion), new { idinscripcion = detalleInscripcion.InscripcionId });
            }
            return View(detalleInscripcion);
        }


        // GET: DetalleInscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.DetalleInscripciones.FindAsync(id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }
            ViewData["InscripcionId"] = new SelectList(_context.inscripciones, "Id", "Id", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Id", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }

        // POST: DetalleInscripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModalidadCursado,InscripcionId,MateriaId")] DetalleInscripcion detalleInscripcion)
        {
            if (id != detalleInscripcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleInscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleInscripcionExists(detalleInscripcion.Id))
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
            ViewData["InscripcionId"] = new SelectList(_context.inscripciones, "Id", "Id", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Id", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }

        // GET: DetalleInscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.DetalleInscripciones
                .Include(d => d.Inscripcion)
                .Include(d => d.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return View(detalleInscripcion);
        }

        // POST: DetalleInscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleInscripcion = await _context.DetalleInscripciones.FindAsync(id);
            if (detalleInscripcion != null)
            {
                _context.DetalleInscripciones.Remove(detalleInscripcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleInscripcionExists(int id)
        {
            return _context.DetalleInscripciones.Any(e => e.Id == id);
        }
    }
}
