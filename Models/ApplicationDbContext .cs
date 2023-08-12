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
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Filename=invoice.db");
            }

    }
}

    
 