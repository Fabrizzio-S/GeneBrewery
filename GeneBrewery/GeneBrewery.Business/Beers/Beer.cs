using System;
using System.Collections.Generic;

using GeneBrewery.Business.BeerProviders;
using GeneBrewery.Business.Breweries;
using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Beers
{
    public class Beer : Entity
    {
        public virtual BeerName Name { get;  }
        public virtual BeerPrice Price { get; }
        public virtual BeerAlcoholDegree AlcoholDegree { get; }
        public virtual Brewery Brewery { get; }
        public virtual IReadOnlyList<BeerProvider> BeerProviders { get; }

        protected Beer()
        {
            BeerProviders = new List<BeerProvider>();
        }

        public Beer(BeerName name, BeerPrice price, BeerAlcoholDegree beerAlcoholDegree, Brewery brewery) : this()
        {
            Name = name ?? throw new ArgumentNullException($"{nameof(BeerName)} cannot be null");
            Price = price ?? throw new ArgumentNullException($"{nameof(BeerPrice)} cannot be null");
            AlcoholDegree = beerAlcoholDegree ?? throw new ArgumentNullException($"{nameof(BeerAlcoholDegree)} cannot be null");
            Brewery = brewery ?? throw new ArgumentNullException($"{nameof(Brewery)} cannot be null");
        }
    }
}
