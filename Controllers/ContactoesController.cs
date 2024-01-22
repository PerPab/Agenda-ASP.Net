using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaContactos.Data;
using AgendaContactos.Models;

namespace AgendaContactos.Controllers
{
    public class ContactoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contactoes
        public async Task<IActionResult> Index()
        {
              return _context.contactos != null ? 
                          View(await _context.contactos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.contactos'  is null.");
        }

        // GET: Contactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.contactos
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contactoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,Nombre,Telefono,Direccion,Email,Tipo")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
        }

        // GET: Contactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // POST: Contactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,Nombre,Telefono,Direccion,Email,Tipo")] Contacto contacto)
        {
            if (id != contacto.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.IdPersona))
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
            return View(contacto);
        }

        // GET: Contactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.contactos
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.contactos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.contactos'  is null.");
            }
            var contacto = await _context.contactos.FindAsync(id);
            if (contacto != null)
            {
                _context.contactos.Remove(contacto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
          return (_context.contactos?.Any(e => e.IdPersona == id)).GetValueOrDefault();
        }
    }
}
