using System;
using System.Collections.Generic;

using CSharpFunctionalExtensions;

using FluentAssert;

using GeneBrewery.Business.BeerProviders;
using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Breweries;
using GeneBrewery.Business.Providers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace GeneBrewery.Business.Test.Providers
{
    [TestClass]
    public class ProviderTest
    {
        [TestMethod]
        public void Create_provider_without_error()
        {
            var provider = new Provider(ProviderName.Create("GeneDrinks").Value);

            provider.ShouldNotBeNull();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_provider_with_null_provider_name_should_raise_an_exception()
        {
            var provider = new Provider(null);
        }

        [TestMethod]
        public void Add_beer_without_error()
        {
            var provider = new Provider(ProviderName.Create("GeneDrinks").Value);

            var brewery = new Brewery(BreweryName.Create("Abbaye de Leffe").Value);

            var beer = new Beer(BeerName.Create("Leffe Blonde").Value,
                BeerPrice.Create(2.55m).Value,
                BeerAlcoholDegree.Create(5.5m).Value,
                brewery);

            Result<Provider> providerResult = provider.ProvideBeer(beer, BeerProviderQuantity.Create(10).Value);

            providerResult.IsFailure.ShouldBeFalse();
        }

        [TestMethod]
        public void Add_beer_that_already_exists_should_return_an_error()
        {
            Mock<Beer> beerMock = new Mock<Beer>();
            beerMock.SetupGet(x => x.Id).Returns(1);
            beerMock.SetupGet(x => x.Name).Returns(BeerName.Create("Leffe blonde").Value);

            Mock<BeerProvider> beerProviderMock = new Mock<BeerProvider>();
            beerProviderMock.SetupGet(x => x.Beer).Returns(beerMock.Object);

            Mock<Provider> providerMock = new Mock<Provider>();
            providerMock.SetupGet(x => x.BeerProviders).Returns(new List<BeerProvider>()
            {
                beerProviderMock.Object
            });
            
            Result<Provider> providerResult = providerMock.Object.ProvideBeer(beerMock.Object, BeerProviderQuantity.Create(10).Value);

            providerResult.IsFailure.ShouldBeTrue();
        }

        [TestMethod]
        public void Update_beer_quantity_without_error()
        {
            Mock<Beer> beerMock = new Mock<Beer>();
            beerMock.SetupGet(x => x.Id).Returns(1);
            beerMock.SetupGet(x => x.Name).Returns(BeerName.Create("Leffe blonde").Value);

            Mock<BeerProvider> beerProviderMock = new Mock<BeerProvider>();
            beerProviderMock.SetupGet(x => x.Beer).Returns(beerMock.Object);
            beerProviderMock.SetupGet(x => x.BeerProviderQuantity).Returns(BeerProviderQuantity.Create(10).Value);

            Mock<Provider> providerMock = new Mock<Provider>();
            providerMock.SetupGet(x => x.BeerProviders).Returns(new List<BeerProvider>()
            {
                beerProviderMock.Object
            });

            Result<BeerProvider> beerProviderResult =
                providerMock.Object.UpdateBeerQuantity(beerMock.Object, BeerProviderQuantity.Create(20).Value);

            beerProviderResult.IsFailure.ShouldBeFalse();

            beerProviderResult.Value.BeerProviderQuantity.Value.ShouldBeEqualTo(20);
        }

        [TestMethod]
        public void Update_beer_quantity_with_beer_that_does_not_exists_for_this_provider_should_return_an_error()
        {
            Mock<Beer> beerMock = new Mock<Beer>();
            beerMock.SetupGet(x => x.Id).Returns(1);
            beerMock.SetupGet(x => x.Name).Returns(BeerName.Create("Leffe blonde").Value);

            Mock<BeerProvider> beerProviderMock = new Mock<BeerProvider>();
            beerProviderMock.SetupGet(x => x.Beer).Returns(beerMock.Object);
            beerProviderMock.SetupGet(x => x.BeerProviderQuantity).Returns(BeerProviderQuantity.Create(10).Value);

            Mock<Provider> providerMock = new Mock<Provider>();
            providerMock.SetupGet(x => x.BeerProviders).Returns(new List<BeerProvider>());

            Result<BeerProvider> beerProviderResult =
                providerMock.Object.UpdateBeerQuantity(beerMock.Object, BeerProviderQuantity.Create(20).Value);

            beerProviderResult.IsFailure.ShouldBeTrue();

            beerProviderResult.Error.ShouldNotBeEmpty();
        }
    }
}
