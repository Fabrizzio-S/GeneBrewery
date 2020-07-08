using Microsoft.EntityFrameworkCore;

namespace GeneBrewery.Business.Common
{
    public class BreweryContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<Brewery.Brewery> Breweries { get; set; }
        public BreweryContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
