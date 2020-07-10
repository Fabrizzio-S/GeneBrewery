using GeneBrewery.Business.BeerProviders;
using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Breweries;
using GeneBrewery.Business.Providers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GeneBrewery.Business.Common
{
    public class BreweryContext : DbContext
    {
        private readonly string connectionString;
        private readonly bool useConsoleLogger;
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Provider> Providers { get; set; }
        internal DbSet<BeerProvider> BeerProviders { get; set; }

        public BreweryContext(string connectionString, bool useConsoleLogger)
        {
            this.connectionString = connectionString;
            this.useConsoleLogger = useConsoleLogger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Debug)
                    .AddConsole();
            });
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);

            if (useConsoleLogger)
            {
                optionsBuilder
                    .UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>(x =>
            {
                x.ToTable("Beer").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.Name)
                    .HasConversion(p => p.Value, p => BeerName.Create(p).Value);
                x.Property(p => p.Price)
                    .HasConversion(p => p.Value, p => BeerPrice.Create(p).Value);
                x.Property(p => p.AlcoholDegree)
                    .HasConversion(p => p.Value, p => BeerAlcoholDegree.Create(p).Value);
                x.HasOne(p => p.Brewery).WithMany(p=> p.Beers);
            });
            modelBuilder.Entity<Provider>(x =>
            {
                x.ToTable("Provider").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.Name)
                    .HasConversion(p => p.Value, p => ProviderName.Create(p).Value);
            });
            modelBuilder.Entity<BeerProvider>(x =>
            {
                x.ToTable("BeerProvider").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.BeerProviderQuantity)
                    .HasConversion(p => p.Value, p => BeerProviderQuantity.Create(p).Value).HasColumnName("AvailableQuantity");
                x.HasOne(bp => bp.Beer).WithMany(b => b.BeerProviders);
                x.HasOne(bp => bp.Provider).WithMany(p => p.BeerProviders);
            });
            modelBuilder.Entity<Brewery>(x =>
            {
                x.ToTable("Brewery").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.Name)
                    .HasConversion(p => p.Value, p => BreweryName.Create(p).Value);
            });
        }
    }
}
