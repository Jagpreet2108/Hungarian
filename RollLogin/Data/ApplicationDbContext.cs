using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RollLogin.Models;

namespace RollLogin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RollLogin.Models.Emps> Emps { get; set; }
        public DbSet<RollLogin.Models.FoodManagment> FoodManagment { get; set; }
    }
}
