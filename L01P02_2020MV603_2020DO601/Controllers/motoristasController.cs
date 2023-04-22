using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2020MV603_2020DO601.Models;

namespace L01P02_2020MV603_2020DO601.Controllers
{
    public class motoristasController : Controller
    {
        private readonly restauranteContext _context;

        public motoristasController(restauranteContext context)
        {
            _context = context;
        }

        // GET: motoristas
        public async Task<IActionResult> Index()
        {
              return _context.motoristas != null ? 
                          View(await _context.motoristas.ToListAsync()) :
                          Problem("Entity set 'restauranteContext.motoristas'  is null.");
        }

        // GET: motoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.motoristas == null)
            {
                return NotFound();
            }

            var motorista = await _context.motoristas
                .FirstOrDefaultAsync(m => m.motoristaId == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // GET: motoristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: motoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("motoristaId,nombreMotorista")] motorista motorista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: motoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.motoristas == null)
            {
                return NotFound();
            }

            var motorista = await _context.motoristas.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }
            return View(motorista);
        }

        // POST: motoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("motoristaId,nombreMotorista")] motorista motorista)
        {
            if (id != motorista.motoristaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!motoristaExists(motorista.motoristaId))
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
            return View(motorista);
        }

        // GET: motoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.motoristas == null)
            {
                return NotFound();
            }

            var motorista = await _context.motoristas
                .FirstOrDefaultAsync(m => m.motoristaId == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // POST: motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.motoristas == null)
            {
                return Problem("Entity set 'restauranteContext.motoristas'  is null.");
            }
            var motorista = await _context.motoristas.FindAsync(id);
            if (motorista != null)
            {
                _context.motoristas.Remove(motorista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool motoristaExists(int id)
        {
          return (_context.motoristas?.Any(e => e.motoristaId == id)).GetValueOrDefault();
        }
    }
}
