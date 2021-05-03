using CountriesChallenge.Domain;
using Microsoft.EntityFrameworkCore;

namespace CountriesChallenge.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Country>().HasKey(x => x.Id);

            modelBuilder.Entity<Country>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<Country>().Property(x => x.Area).IsRequired();
            modelBuilder.Entity<Country>().Property(x => x.Population).IsRequired();
            modelBuilder.Entity<Country>().Property(x => x.Capital).IsRequired();

            modelBuilder.Entity<Country>().Property(x => x.CountryInfo).IsRequired(false);

            modelBuilder.Entity<Country>().Ignore(x => x.Name);
            modelBuilder.Entity<Country>().Ignore(x => x.TopLevelDomains);
        }
    }
}
