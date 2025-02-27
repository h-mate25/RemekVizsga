using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model
{
    internal class WarehouseDbContext : DbContext
    {
        public DbSet<Process> Processes { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Pallet> Pallet { get; set; }
        public DbSet<Pallets> Pallets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .HasKey(p => new { p.process_id, p.product_id });
            modelBuilder.Entity<Products>()
                .HasOne(p => p.Process)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.process_id);
            modelBuilder.Entity<Products>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Products)
                .HasForeignKey(cp => cp.product_id);


            modelBuilder.Entity<Pallets>()
                .HasKey(p => new { p.process_id, p.pallet_id });
            modelBuilder.Entity<Pallets>()
                .HasOne(p => p.Process)
                .WithMany(p => p.Pallets)
                .HasForeignKey(p => p.process_id);
            modelBuilder.Entity<Pallets>()
                .HasOne(p => p.pallet)
                .WithMany(p => p.Pallets)
                .HasForeignKey(cp => cp.pallet_id);


            modelBuilder.Entity<Pallet>()
                .HasMany(p => p.Product)
                .WithOne(p => p.pallet)
                .HasForeignKey(p => p.pallet_id)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WarehouseDb;Trusted_Connection=True;");
        }
    }
}
