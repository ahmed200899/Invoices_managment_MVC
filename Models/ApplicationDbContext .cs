using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=invoice.db");
        }
    }
}
