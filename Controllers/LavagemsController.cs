using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WashCarLavaDevagar.Data;
using WashCarLavaDevagar.Models;

namespace WashCarLavaDevagar.Controllers
{
    [Authorize]
    public class LavagemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LavagemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lavagems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lavagem.Include(l => l.Carro).Include(l => l.TipoLavagem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lavagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lavagem = await _context.Lavagem
                .Include(l => l.Carro)
                .Include(l => l.TipoLavagem)
                .FirstOrDefaultAsync(m => m.IDLavagem == id);
            if (lavagem == null)
            {
                return NotFound();
            }

            return View(lavagem);
        }

        // GET: Lavagems/Create
        public IActionResult Create()
        {
            ViewData["CarroID"] = new SelectList(_context.Carro, "IDCarro", "Placa");
            ViewData["TipoLavagemID"] = new SelectList(_context.TipoLavagem, "IDTipoLavagem", "Descricao");
            return View();
        }

        // POST: Lavagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDLavagem,TipoLavagemID,DataLavagem,ValorLavagem,DescontoLavagem,CarroID")] Lavagem lavagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lavagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroID"] = new SelectList(_context.Carro, "IDCarro", "Placa", lavagem.CarroID);
            ViewData["TipoLavagemID"] = new SelectList(_context.TipoLavagem, "IDTipoLavagem", "Descricao", lavagem.TipoLavagemID);
            return View(lavagem);
        }

        // GET: Lavagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lavagem = await _context.Lavagem.FindAsync(id);
            if (lavagem == null)
            {
                return NotFound();
            }
            ViewData["CarroID"] = new SelectList(_context.Carro, "IDCarro", "Placa", lavagem.CarroID);
            ViewData["TipoLavagemID"] = new SelectList(_context.TipoLavagem, "IDTipoLavagem", "Descricao", lavagem.TipoLavagemID);
            return View(lavagem);
        }

        // POST: Lavagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDLavagem,TipoLavagemID,DataLavagem,ValorLavagem,DescontoLavagem,CarroID")] Lavagem lavagem)
        {
            if (id != lavagem.IDLavagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lavagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LavagemExists(lavagem.IDLavagem))
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
            ViewData["CarroID"] = new SelectList(_context.Carro, "IDCarro", "Placa", lavagem.CarroID);
            ViewData["TipoLavagemID"] = new SelectList(_context.TipoLavagem, "IDTipoLavagem", "Descricao", lavagem.TipoLavagemID);
            return View(lavagem);
        }

        // GET: Lavagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lavagem = await _context.Lavagem
                .Include(l => l.Carro)
                .Include(l => l.TipoLavagem)
                .FirstOrDefaultAsync(m => m.IDLavagem == id);
            if (lavagem == null)
            {
                return NotFound();
            }

            return View(lavagem);
        }

        // POST: Lavagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lavagem = await _context.Lavagem.FindAsync(id);
            if (lavagem != null)
            {
                _context.Lavagem.Remove(lavagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LavagemExists(int id)
        {
            return _context.Lavagem.Any(e => e.IDLavagem == id);
        }
    }
}
