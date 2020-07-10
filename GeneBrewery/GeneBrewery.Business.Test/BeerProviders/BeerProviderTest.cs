using System;

using FluentAssert;

using GeneBrewery.Business.BeerProviders;
using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Breweries;
using GeneBrewery.Business.Providers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.BeerProviders
{
    [TestClass]
    public class BeerProviderTest
    {
        [TestMethod]
        public void Create_beer_provider_without_error()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(BeerName.Create("Leffe Blonde").Value, 
                BeerPrice.Create(2.55m).Value, 
                BeerAlcoholDegree.Create(5.5m).Value,
                brewery);

            var provider = new Provider(ProviderName.Create("GeneDrinks").Value);

            BeerProvider beerProvider = new BeerProvider(BeerProviderQuantity.Create(10).Value, beer, provider);

            beerProvider.ShouldNotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_beer_provider_with_null_beer_provider_quantity_should_raise_an_exception()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(BeerName.Create("Leffe Blonde").Value,
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value,
                brewery);

            var provider = new Provider(ProviderName.Create("GeneDrinks").Value);
            var beerProvider = new BeerProvider(null, beer, provider);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_beer_provider_with_null_beer_should_raise_an_exception()
        {
            var provider = new Provider(ProviderName.Create("GeneDrinks").Value);
            var beerProvider = new BeerProvider(BeerProviderQuantity.Create(10).Value, null, provider);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_beer_provider_with_null_provider_should_raise_an_exception()
        {
            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(BeerName.Create("Leffe Blonde").Value,
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value,
                brewery);

            var beerProvider = new BeerProvider(BeerProviderQuantity.Create(10).Value, beer, null);
        }
    }
}