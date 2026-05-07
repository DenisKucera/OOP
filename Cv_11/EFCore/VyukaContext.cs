using Microsoft.EntityFrameworkCore;

namespace Cv_11.EFCore
{
    public class VyukaContext : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Predmet> Predmety { get; set; }
        public DbSet<Hodnoceni> Hodnoceni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // pripojeni k SQL serveru
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Vyuka_EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // primary key Hodnoceni (tabulka Hodnoceni)
            modelBuilder.Entity<Hodnoceni>()
                .HasKey(h => new { h.StudentId, h.PredmetId });
            //negenerovat automaticke cislovani
            modelBuilder.Entity<Student>()
                .Property(s => s.StudentId)
                .ValueGeneratedNever();
        }
    }
}