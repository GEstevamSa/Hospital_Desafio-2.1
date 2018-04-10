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
    public class MedicosController : Controller
    {
        private readonly Hospital _context;

        public MedicosController(Hospital context)
        {
            _context = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index(String sortOrder,String currentFilter, String searchString, int ? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var medicos = from m in _context.Medicos
                          select m;

            if(!String.IsNullOrEmpty(searchString))
            {
                medicos = medicos.Where(m => m.PrimeiroNome.Contains(searchString) || m.Sobrenome.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    medicos = medicos.OrderByDescending(m => m.PrimeiroNome);
                    break;
                case "Date":
                    medicos = medicos.OrderBy(m => m.ColecaoDate);
                    break;
                case "date_desc":
                    medicos = medicos.OrderByDescending(m => m.ColecaoDate);
                    break;
                default:
                    medicos = medicos.OrderBy(m => m.PrimeiroNome);
                    break;
            }

            int pageSize = 3;
            return View(await PaginasLista<Medicos>.CreateAsync(medicos.AsNoTracking(), page ?? 1, pageSize));
            
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicos = await _context.Medicos
                .Include(me => me.Colecaos)
                    .ThenInclude(c => c.Clinicas)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (medicos == null)
            {
                return NotFound();
            }

            return View(medicos);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("PrimeiroNome,Sobrenome,ColecaoDate")] Medicos medicos)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(medicos);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            catch(DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Pronto para salvar as alteraçoes. " +
                    "Tente de novo e se o problema persistir. " +
                    "Verifique o seu sistema de administrador. ");
            }
            
            return View(medicos);
        }

        // GET: Medicos/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medicoToUpdate = await _context.Medicos.SingleOrDefaultAsync(m => m.ID == id);
            if (await TryUpdateModelAsync<Medicos>(
                medicoToUpdate,
                "",
                m => m.PrimeiroNome, m => m.Sobrenome, m => m.ColecaoDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Habilite para salvar as informaçoes. " +
                        "Tente novamente, e se o problema persistir, " +
                        "veja seu sistema de administrador.");
                }
            }
            return View(medicoToUpdate);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("ID,PrimeiroNome,Sobrenome,ColecaoDate")] Medicos medicos)
        {
            if (id != medicos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicosExists(medicos.ID))
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
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicos = await _context.Medicos
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (medicos == null)
            {
                return NotFound();
            }

            if(saveChangesError.GetValueOrDefault())
            {
                ViewData["Error Message"] =
                    "Falha na exclusao. Tente Novamente e se o problema persistir. "
                    + "Veja seu sistema de Administrador ";
            }

            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicos = await _context.Medicos
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if(medicos == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Medicos.Remove(medicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            catch (DbUpdateException /*  ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool MedicosExists(int id)
        {
            return _context.Medicos.Any(e => e.ID == id);
        }
    }
}
