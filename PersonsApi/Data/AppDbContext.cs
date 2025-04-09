using Microsoft.EntityFrameworkCore;
using PersonsApi.Models;

namespace PersonsApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PersonModel> person { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuración del indice unico en la cédula
            modelBuilder.Entity<PersonModel>()
                .HasIndex(p => p.person_id)
                .IsUnique();
        }
    }
}
