﻿using System;
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
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new RecipeIndexData();
            viewModel.Recipes = await _context.Recipe
                  .Include(i => i.Name)
                  .Include(i => i.TotalTime)
                  .Include(i => i.Difficulty)
                  .Include(i => i.DateCreated)
                  .Include(i => i.Ingredients)
                        .ThenInclude(i => i.Name)
                  .Include(i => i.Ingredients)
                        .ThenInclude(i => i.Amount)
                  .Include(i => i.Ingredients)
                        .ThenInclude(i => i.Unit)
                  .Include(i => i.Instructions)
                    .ThenInclude(i => i.InstructionText)
                  .AsNoTracking()
                  .OrderBy(i => i.DateCreated)
                  .ToListAsync();

            //if (id != null)
            //{
            //    ViewData["InstructorID"] = id.Value;
            //    Instructor instructor = viewModel.Instructors.Where(
            //        i => i.ID == id.Value).Single();
            //    viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);
            //}
            if (id != null)
            {
                ViewData["RecipeID"] = id.Value;
                Recipe recipe = viewModel.Recipes.Where(
                    i => i.RecipeID == id.Value).Single();
                viewModel.Ingredients = recipe.Ingredients;
                viewModel.Instructions = recipe.Instructions;
            }

            //if (courseID != null)
            //{
            //    ViewData["CourseID"] = courseID.Value;
            //    viewModel.Enrollments = viewModel.Courses.Where(
            //        x => x.CourseID == courseID).Single().Enrollments;
            //}

            //if (instructionID != null)
            //{
            //    ViewData["InstructionID"] = instructionID.Value;
            //    viewModel.Instructions = viewModel.Instructions.Where(
            //        x => x.InstructionID == instructionID).Single().Instructions;
            //}

            return View(viewModel);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,Name,TotalTime,Difficulty,DateCreated")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,Name,TotalTime,Difficulty,DateCreated")] Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeID))
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
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.RecipeID == id);
        }
    }
}