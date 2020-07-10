using System;

using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Common;
using GeneBrewery.Business.Providers;

namespace GeneBrewery.Business.BeerProviders
{
    public class BeerProvider : Entity
    {
        public virtual BeerProviderQuantity BeerProviderQuantity { get; }
        public virtual Beer Beer { get; }
        public virtual Provider Provider { get; }

        protected BeerProvider()
        {
        }

        public BeerProvider(BeerProviderQuantity beerProviderQuantity, Beer beer, Provider provider) : this()
        {
            BeerProviderQuantity = beerProviderQuantity ?? throw new ArgumentNullException($"{nameof(BeerProviderQuantity)} cannot be null");
            Beer = beer ?? throw new ArgumentNullException($"{nameof(Beer)} cannot be null");
            Provider = provider ?? throw new ArgumentNullException($"{nameof(Provider)} cannot be null");
        }
    }
}
