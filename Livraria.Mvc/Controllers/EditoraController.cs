using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Livraria.Mvc.Models;

namespace Livraria.Mvc.Controllers
{
    public class EditoraController : Controller
    {
        private readonly LivrariaMvcContext _context;

        public EditoraController(LivrariaMvcContext context)
        {
            _context = context;
        }

        // GET: Editora
        public async Task<IActionResult> Index()
        {
            return View(await _context.EditoraViewModel.ToListAsync());
        }

        // GET: Editora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoraViewModel = await _context.EditoraViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editoraViewModel == null)
            {
                return NotFound();
            }

            return View(editoraViewModel);
        }

        // GET: Editora/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataCadastro,Status")] EditoraViewModel editoraViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editoraViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editoraViewModel);
        }

        // GET: Editora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoraViewModel = await _context.EditoraViewModel.FindAsync(id);
            if (editoraViewModel == null)
            {
                return NotFound();
            }
            return View(editoraViewModel);
        }

        // POST: Editora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataCadastro,Status")] EditoraViewModel editoraViewModel)
        {
            if (id != editoraViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editoraViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditoraViewModelExists(editoraViewModel.Id))
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
            return View(editoraViewModel);
        }

        // GET: Editora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoraViewModel = await _context.EditoraViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editoraViewModel == null)
            {
                return NotFound();
            }

            return View(editoraViewModel);
        }

        // POST: Editora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editoraViewModel = await _context.EditoraViewModel.FindAsync(id);
            _context.EditoraViewModel.Remove(editoraViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditoraViewModelExists(int id)
        {
            return _context.EditoraViewModel.Any(e => e.Id == id);
        }
    }
}
