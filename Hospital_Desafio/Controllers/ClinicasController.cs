using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Desafio.Dados;
using Hospital_Desafio.Models;

namespace Hospital_Desafio.Controllers
{
    public class ClinicasController : Controller
    {
        private readonly Hospital _context;

        public ClinicasController(Hospital context)
        {
            _context = context;
        }

        // GET: Clinicas
        public async Task<IActionResult> Index()
        {
            var clinicas = _context.Clinicas
                .Include(c => c.Departamento)
                .AsNoTracking();
            return View(await clinicas.ToListAsync());
        }

        // GET: Clinicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await _context.Clinicas
                .Include(c => c.Departamento)
                .SingleOrDefaultAsync(m => m.ClinicasID == id);
            if (clinicas == null)
            {
                return NotFound();
            }

            return View(clinicas);
        }

        // GET: Clinicas/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "DepartamentoID");
            return View();
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClinicasID,NomeClinica,Estrelas,DepartamentoID")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "DepartamentoID", clinicas.DepartamentoID);
            return View(clinicas);
        }

        // GET: Clinicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await _context.Clinicas.SingleOrDefaultAsync(m => m.ClinicasID == id);
            if (clinicas == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "DepartamentoID", clinicas.DepartamentoID);
            return View(clinicas);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClinicasID,NomeClinica,Estrelas,DepartamentoID")] Clinicas clinicas)
        {
            if (id != clinicas.ClinicasID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicasExists(clinicas.ClinicasID))
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
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "DepartamentoID", clinicas.DepartamentoID);
            return View(clinicas);
        }

        // GET: Clinicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await _context.Clinicas
                .Include(c => c.Departamento)
                .SingleOrDefaultAsync(m => m.ClinicasID == id);
            if (clinicas == null)
            {
                return NotFound();
            }

            return View(clinicas);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clinicas = await _context.Clinicas.SingleOrDefaultAsync(m => m.ClinicasID == id);
            _context.Clinicas.Remove(clinicas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicasExists(int id)
        {
            return _context.Clinicas.Any(e => e.ClinicasID == id);
        }
    }
}
