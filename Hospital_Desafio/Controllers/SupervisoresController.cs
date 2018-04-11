using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Desafio.Dados;
using Hospital_Desafio.Models;
using Hospital_Desafio.Models.HospitalViewsModels;

namespace Hospital_Desafio.Controllers
{
    public class SupervisoresController : Controller
    {
        private readonly Hospital _context;

        public SupervisoresController(Hospital context)
        {
            _context = context;
        }

        // GET: Supervisores
        public async Task<IActionResult> Index(int? id, int? clinicaID)
        {
            var viewModel = new SupervisorIndexMode();
            viewModel.Supervisores = await _context.Supervisores
                .Include(i => i.TarefasInstrutor)
                .Include(i => i.AtribuicaodeTarefas)
                    .ThenInclude(i => i.Clinicas)
                        .ThenInclude(i => i.Colecaos)
                            .ThenInclude(i => i.Medicos)
                .Include(i => i.AtribuicaodeTarefas)
                    .ThenInclude(i => i.Clinicas)
                        .ThenInclude(i => i.Departamento)
                .AsNoTracking()
                .OrderBy(i => i.PrimeiroNome)
                .ToListAsync();

            if(id != null)
            {
                ViewData["SupervisorID"] = id.Value;
                Supervisor supervisor = viewModel.Supervisores.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Clinicas = supervisor.AtribuicaodeTarefas.Select(s => s.Clinicas);
            }

            if(clinicaID != null)
            {
                ViewData["ClinicaID"] = clinicaID.Value;
                viewModel.Colecaos = viewModel.Clinicas.Where(
                    x => x.ClinicasID == clinicaID).Single().Colecaos;
            }

            return View(viewModel);
        }

        // GET: Supervisores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisores
                .SingleOrDefaultAsync(m => m.ID == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // GET: Supervisores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supervisores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Sobrenome,FirstMidName,Experiencia")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supervisor);
        }

        // GET: Supervisores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisores.SingleOrDefaultAsync(m => m.ID == id);
            if (supervisor == null)
            {
                return NotFound();
            }
            return View(supervisor);
        }

        // POST: Supervisores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Sobrenome,FirstMidName,Experiencia")] Supervisor supervisor)
        {
            if (id != supervisor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorExists(supervisor.ID))
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
            return View(supervisor);
        }

        // GET: Supervisores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisores
                .SingleOrDefaultAsync(m => m.ID == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // POST: Supervisores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisor = await _context.Supervisores.SingleOrDefaultAsync(m => m.ID == id);
            _context.Supervisores.Remove(supervisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorExists(int id)
        {
            return _context.Supervisores.Any(e => e.ID == id);
        }
    }
}
