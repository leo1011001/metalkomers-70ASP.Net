using Microsoft.EntityFrameworkCore;
using metal_komers70.Models;

namespace metal_komers70.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ContactFormModel> Contacts { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}