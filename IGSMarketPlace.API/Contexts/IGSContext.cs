using IGSMarketPlace.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IGSMarketPlace.API.Contexts
{
    public class IGSContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public IGSContext(DbContextOptions<IGSContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // link the product class to the table and seed it.
            modelBuilder.Entity<Product>().ToTable("Products").HasData(
                    new Product()
                    {
                        Id = 1,
                        Name = "Lavender heart",
                        Price = "9.25"
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Personalised cufflinks",
                        Price = "45.00"
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "Kids T-shirt",
                        Price = "19.95"
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
