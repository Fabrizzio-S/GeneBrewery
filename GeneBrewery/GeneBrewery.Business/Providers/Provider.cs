using System;
using System.Collections.Generic;
using System.Linq;

using CSharpFunctionalExtensions;

using GeneBrewery.Business.BeerProviders;
using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Providers
{
    public class Provider : Entity
    {
        public virtual ProviderName Name { get; }
        private List<BeerProvider> beerProviders;
        public virtual IReadOnlyList<BeerProvider> BeerProviders => beerProviders.ToList();

        protected Provider()
        {
            beerProviders = new List<BeerProvider>();
        }

        public Provider(ProviderName providerName) : this()
        {
            Name = providerName ?? throw new ArgumentNullException($"{nameof(ProviderName)} cannot be null");
        }

        public Result<Provider> ProvideBeer(Beer beer, BeerProviderQuantity beerProviderQuantity)
        {
            if (BeerProviders.Any(x => x.Beer.Id == beer.Id))
            {
                return Result.Failure<Provider>($"Beer {beer.Name.Value} already exists for this provider");
            }

            beerProviders.Add(new BeerProvider(beerProviderQuantity, beer, this));

            return Result.Ok(this);
        }

        public Result<BeerProvider> UpdateBeerQuantity(Beer beer, BeerProviderQuantity beerProviderQuantity)
        {
            BeerProvider beerProvider = BeerProviders.FirstOrDefault(x => x.Beer.Id == beer.Id);
            if (beerProvider == null)
            {
                return Result.Failure<BeerProvider>($"Beer {beer.Name.Value} does not exists for this provider");
            }
            beerProvider.BeerProviderQuantity.UpdateValue(beerProviderQuantity);
            
            return Result.Ok(beerProvider);
        }
    }
}
