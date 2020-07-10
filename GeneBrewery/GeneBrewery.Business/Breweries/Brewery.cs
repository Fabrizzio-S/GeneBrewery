using System;
using System.Collections.Generic;
using System.Linq;

using CSharpFunctionalExtensions;

using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Breweries
{
    public class Brewery : Entity
    {
        public virtual BreweryName Name { get; }
        private readonly List<Beer> beers;
        public virtual IReadOnlyList<Beer> Beers => beers.ToList();

        protected Brewery()
        {
            beers = new List<Beer>();
        }

        public Brewery(BreweryName breweryName) : this()
        {
            Name = breweryName ?? throw new ArgumentNullException(nameof(breweryName));
        }
        
        public Result<Brewery> AddBeer(BeerName beerName, BeerPrice beerPrice, BeerAlcoholDegree beerAlcoholDegree)
        {
            if (beers.Any(x => x.Name == beerName))
            {
                return Result.Failure<Brewery>($"Beer {beerName.Value} with same name already exists in this brewery");
            }

            beers.Add(new Beer(beerName, beerPrice, beerAlcoholDegree, this));

            return Result.Ok(this);
        }
    }
}
