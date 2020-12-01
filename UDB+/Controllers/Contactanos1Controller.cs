using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcContactanos.Data;
using UDB_.Models;

namespace UDB_.Controllers
{
    public class Contactanos1Controller : Controller
    {
        private readonly MvcContactanosContext _context;

        public Contactanos1Controller(MvcContactanosContext context)
        {
            _context = context;
        }

        // GET: Contactanos1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactanos.ToListAsync());
        }

        // GET: Contactanos1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactanos = await _context.Contactanos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactanos == null)
            {
                return NotFound();
            }

            return View(contactanos);
        }

        // GET: Contactanos1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactanos1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,TipoConsulta,Consulta")] Contactanos contactanos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactanos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactanos);
        }

        // GET: Contactanos1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactanos = await _context.Contactanos.FindAsync(id);
            if (contactanos == null)
            {
                return NotFound();
            }
            return View(contactanos);
        }

        // POST: Contactanos1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,TipoConsulta,Consulta")] Contactanos contactanos)
        {
            if (id != contactanos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactanos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactanosExists(contactanos.Id))
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
            return View(contactanos);
        }

        // GET: Contactanos1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactanos = await _context.Contactanos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactanos == null)
            {
                return NotFound();
            }

            return View(contactanos);
        }

        // POST: Contactanos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactanos = await _context.Contactanos.FindAsync(id);
            _context.Contactanos.Remove(contactanos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactanosExists(int id)
        {
            return _context.Contactanos.Any(e => e.Id == id);
        }
    }
}
