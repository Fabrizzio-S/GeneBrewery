using System;
using System.Collections.Generic;
using System.Linq;

using CSharpFunctionalExtensions;

using GeneBrewery.Business.Beer;
using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Brewery
{
    public class Brewery : Entity
    {
        public BreweryName Name { get; }
        private readonly List<Beer.Beer> beers = new List<Beer.Beer>();
        public IReadOnlyList<Beer.Beer> Beers => beers.ToList();

        private Brewery()
        {
        }

        public Brewery(BreweryName breweryName) : this()
        {
            Name = breweryName ?? throw new ArgumentNullException(nameof(breweryName));
        }

        public Result<Brewery> AddBeer(BeerName beerName, BeerPrice beerPrice, BeerAlcoholDegree beerAlcoholDegree)
        {
            if (beers.Any(x => x.Name == beerName))
            {
                Result.Failure<Brewery>($"Beer {beerName.Value} with same name already exists in this brewery");
            }

            var beer = new Beer.Beer(beerName, beerPrice, beerAlcoholDegree);
            beers.Add(beer);

            return Result.Ok(this);
        }
    }
}
