using System;

using FluentAssert;

using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Breweries;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.Beers
{
    [TestClass]
    public class BeerTest
    {
        [TestMethod]
        public void Create_beer_without_error()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(BeerName.Create("Leffe Blonde").Value,
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value,
                brewery);

            beer.ShouldNotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_beer_with_null_beer_name_should_raise_an_exception()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(null,
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value,
                brewery);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_beer_with_null_beer_price_should_raise_an_exception()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(BeerName.Create("Leffe Blonde").Value,
                null,
                BeerAlcoholDegree.Create(5.5m).Value,
                brewery);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_beer_with_null_beer_alcohol_degree_should_raise_an_exception()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(BeerName.Create("Leffe Blonde").Value,
                BeerPrice.Create(2.55m).Value,
                null,
                brewery);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_beer_with_null_beer_brewery_should_raise_an_exception()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(BeerName.Create("Leffe Blonde").Value,
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value,
                null);
        }

    }
}