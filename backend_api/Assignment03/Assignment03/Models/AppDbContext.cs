using TheSandwichShop.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSandwichShop.Models
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<BreadType> BreadTypes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemBasePrice> ItemBasePrices { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboBasePrice> ComboBasePrices { get; set; }
        public DbSet<ComboItem> ComboItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);      
        }
    }
}
