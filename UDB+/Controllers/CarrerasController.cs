using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCarreras.Data;
using UDB_.Models;

namespace UDB_.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly MvcCarrerasContext _context;

        public CarrerasController(MvcCarrerasContext context)
        {
            _context = context;
        }

        // GET: Carreras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carreras.ToListAsync());
        }

        // GET: Carreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carreras == null)
            {
                return NotFound();
            }

            return View(carreras);
        }

        // GET: Carreras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Carrera,Facultad")] Carreras carreras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carreras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carreras);
        }

        // GET: Carreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras.FindAsync(id);
            if (carreras == null)
            {
                return NotFound();
            }
            return View(carreras);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Carrera,Facultad")] Carreras carreras)
        {
            if (id != carreras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carreras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrerasExists(carreras.Id))
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
            return View(carreras);
        }

        // GET: Carreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carreras == null)
            {
                return View();
            }

            return View(carreras);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carreras = await _context.Carreras.FindAsync(id);
            _context.Carreras.Remove(carreras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrerasExists(int id)
        {
            return _context.Carreras.Any(e => e.Id == id);
        }
    }
}
