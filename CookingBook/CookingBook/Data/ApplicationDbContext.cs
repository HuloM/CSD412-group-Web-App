using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CookingBook.Models;

namespace CookingBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Instruction> Instruction { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
    }
}
