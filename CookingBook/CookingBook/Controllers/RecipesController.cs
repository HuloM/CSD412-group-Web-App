using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookingBook.Data;
using CookingBook.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Diagnostics;

namespace CookingBook.Controllers
{
    //[Authorize]
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipe
                .Where(r => r.OwnerID == GetUserId())
                .Include(r => r.Instructions)
                .Include(r => r.Ingredients)
                .ToListAsync());
        }

        // GET: Recipes/Search/
        [AllowAnonymous]
        public async Task<IActionResult> Search(string query)
        {   
            return View( new SearchViewModel{ DBObject = await getDBInformation(query), APIObject = await getAPIInformation(query) });
        }

        // Helper function
        [AllowAnonymous]
        public async Task<IEnumerable<CookingBook.Models.APIRecipe>> getAPIInformation(string query )
        {
            IEnumerable<CookingBook.Models.APIRecipe> recipes = new List<CookingBook.Models.APIRecipe>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=10&q=" + query),
                Headers =
            {
                { "x-rapidapi-host", "tasty.p.rapidapi.com" },
                { "x-rapidapi-key", Environment.GetEnvironmentVariable("APIKey") },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // Create object from text json response
                var jsonConversion = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(body);

                // Iterate through list of results

                foreach (var result in jsonConversion.results)
                {
                    // Add to the list of recipes
                    recipes = recipes.Append(new APIRecipe
                    {
                        Name = result.ContainsKey("name") ? result.name.ToString() : null,
                        TotalTime = result.ContainsKey("total_time_minutes") ? (!String.IsNullOrEmpty(result.total_time_minutes.ToString()) && int.TryParse(result.total_time_minutes.ToString(), out int test) ? int.Parse(result.total_time_minutes.ToString()) : 0) : 0,
                        DateCreated = result.ContainsKey("created_at") ? new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(int.Parse(result.created_at.ToString())).ToLocalTime() : DateTime.Now,
                        Instructions = result.ContainsKey("instructions") ? new Models.Instruction
                        {
                            InstructionText = ((Func<string>)(() =>
                            {
                                string instructions = "";
                                foreach (var instruction in result.instructions)
                                {
                                    instructions += instruction.display_text.ToString() + "\n";
                                }
                                return instructions;
                            }))()
                        } : new Models.Instruction
                        {
                            InstructionText = "None Provided",
                        },
                        Ingredients = result.ContainsKey("sections") && result.sections[0].ContainsKey("components") ? new Models.Ingredient
                        {
                            ingredient = ((Func<string>)(() =>
                            {
                                string ingredients = "";
                                int section = 1;
                                foreach (var sections in result.sections)
                                {
                                    ingredients += "Section " + section + ": \n";
                                    foreach (var ingredient in sections.components)
                                    {
                                        ingredients += ingredient.raw_text.ToString() + "\n";
                                    }
                                    ingredients += "\n";
                                    section += 1;
                                }

                                return ingredients;
                            }))()
                        } : new Models.Ingredient
                        {
                            ingredient = "None Provided",
                        },
                        VideoString = result.ContainsKey("renditions") && result.renditions.HasValues && result.renditions[0].ContainsKey("url") ? result.renditions[0].url.ToString() : ""
                    }).ToList();
                }
                return recipes;
            }
        }


        // Helper function
        [AllowAnonymous]
        public async Task<IEnumerable<CookingBook.Models.Recipe>> getDBInformation(string query) {
            IEnumerable<CookingBook.Models.Recipe> recipes = await _context.Recipe.Where(p =>
            p.Name.Contains(query) || p.Ingredients.ingredient.Contains(query))
            .OrderBy(i => i.Name)
            .ThenBy(i => i.Ingredients.ingredient)
            .ToListAsync();

            return recipes;
        }

        // GET: Recipes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.Instructions)
                .Include(r => r.Ingredients)

                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("RecipeID,Name,TotalTime,Difficulty,DateCreated,Ingredients,Instructions")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.OwnerID = GetUserId();
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,Name,TotalTime,Difficulty,DateCreated,Ingredients.ingredient,Instructions.InstructionText")] Recipe recipe)
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
        [Authorize]
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
        [Authorize]
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

        private string GetUserId()
        {
            //function to retrieve current user ID

            var userIdValue = "";
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    userIdValue = userIdClaim.Value;
                    Debug.WriteLine(userIdClaim.Value);
                }

            }
            return userIdValue;
        }

    }
}
