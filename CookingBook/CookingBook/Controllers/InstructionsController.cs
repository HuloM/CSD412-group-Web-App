using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookingBook.Data;
using CookingBook.Models;

namespace CookingBook.Controllers
{
    public class InstructionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instructions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instruction.ToListAsync());
        }

        // GET: Instructions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instruction
                .FirstOrDefaultAsync(m => m.InstructionID == id);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        // GET: Instructions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructionID,RecipeID,InstructionText")] Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instruction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instruction);
        }

        // GET: Instructions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instruction.FindAsync(id);
            if (instruction == null)
            {
                return NotFound();
            }
            return View(instruction);
        }

        // POST: Instructions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructionID,RecipeID,InstructionText")] Instruction instruction)
        {
            if (id != instruction.InstructionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instruction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructionExists(instruction.InstructionID))
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
            return View(instruction);
        }

        // GET: Instructions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _context.Instruction
                .FirstOrDefaultAsync(m => m.InstructionID == id);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        // POST: Instructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instruction = await _context.Instruction.FindAsync(id);
            _context.Instruction.Remove(instruction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructionExists(int id)
        {
            return _context.Instruction.Any(e => e.InstructionID == id);
        }
    }
}
