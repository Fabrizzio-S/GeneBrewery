using System;

using CSharpFunctionalExtensions;

using FluentAssert;

using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Breweries;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.Breweries
{
    [TestClass]
    public class BreweryTest
    {
        [TestMethod]
        public void Create_brewery_without_error()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            brewery.ShouldNotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_brewery_with_null_brewery_name_should_raise_an_exception()
        {
            var brewery = new Brewery(null);
        }

        [TestMethod]
        public void Add_beer_without_error()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            Result<Brewery> breweryResult = brewery.AddBeer(BeerName.Create("Leffe Blonde").Value, 
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value);

            breweryResult.IsFailure.ShouldBeFalse();
        }

        [TestMethod]
        public void Add_beer_that_already_exists_should_return_an_error()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            brewery.AddBeer(BeerName.Create("Leffe Blonde").Value,
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value);

            Result<Brewery> breweryResult = brewery.AddBeer(BeerName.Create("Leffe Blonde").Value,
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value);

            breweryResult.IsFailure.ShouldBeTrue();
        }
    }
}