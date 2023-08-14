using System;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceItem>()
                .HasKey(ii => new { ii.InvoiceId, ii.ItemId });

            modelBuilder.Entity<InvoiceItem>()
                .HasOne(ii => ii.Invoice)
                .WithMany(i => i.InvoiceItems)
                .HasForeignKey(ii => ii.InvoiceId);

            modelBuilder.Entity<InvoiceItem>()
                .HasOne(ii => ii.Item)
                .WithMany(i => i.InvoiceItems)
                .HasForeignKey(ii => ii.ItemId);


            modelBuilder.Entity<item>().HasData(
                    new item{Id = '1', Itemname = "Milk", itemprice = 40},
                    new item{Id = '2', Itemname = "Rice", itemprice = 50},
                    new item{Id = '3', Itemname = "cheese", itemprice = 20},
                    new item{Id = '4', Itemname = "Apples", itemprice = 100},
                    new item{Id = '5', Itemname = "orange", itemprice=70}
                );   

   
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Filename=invoice.db");

            }


    }
}

    
 