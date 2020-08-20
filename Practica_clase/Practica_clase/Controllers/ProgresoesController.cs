using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica_clase.Data;
using Practica_clase.Models;

namespace Practica_clase.Controllers
{
    public class ProgresoesController : Controller
    {
        private readonly ProgresoContext _context;

        public ProgresoesController(ProgresoContext context)
        {
            _context = context;
        }

        // GET: Progresoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Progreso.ToListAsync());
        }

        // GET: Progresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progreso = await _context.Progreso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progreso == null)
            {
                return NotFound();
            }

            return View(progreso);
        }

        // GET: Progresoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Progresoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Duracion")] Progreso progreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(progreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(progreso);
        }

        // GET: Progresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progreso = await _context.Progreso.FindAsync(id);
            if (progreso == null)
            {
                return NotFound();
            }
            return View(progreso);
        }

        // POST: Progresoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Duracion")] Progreso progreso)
        {
            if (id != progreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(progreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgresoExists(progreso.Id))
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
            return View(progreso);
        }

        // GET: Progresoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progreso = await _context.Progreso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progreso == null)
            {
                return NotFound();
            }

            return View(progreso);
        }

        // POST: Progresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var progreso = await _context.Progreso.FindAsync(id);
            _context.Progreso.Remove(progreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgresoExists(int id)
        {
            return _context.Progreso.Any(e => e.Id == id);
        }
    }
}
