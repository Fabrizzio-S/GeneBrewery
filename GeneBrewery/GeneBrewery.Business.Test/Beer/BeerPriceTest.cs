using CSharpFunctionalExtensions;

using FluentAssert;

using GeneBrewery.Business.Beer;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.Beer
{
    [TestClass]
    public class BeerPriceTest
    {
        [TestMethod]
        public void Create_beer_price_without_error()
        {
            Result<BeerPrice> beerPriceResult = BeerPrice.Create(2.55m);

            beerPriceResult.IsFailure.ShouldBeFalse();

            BeerPrice beerPrice = beerPriceResult.Value;

            beerPrice.Value.ShouldBeEqualTo(2.55m);
        }

        [TestMethod]
        public void Create_beer_price_with_zero_value_should_return_an_error()
        {
            Result<BeerPrice> beerPriceResult = BeerPrice.Create(0);

            beerPriceResult.IsFailure.ShouldBeTrue();

            beerPriceResult.Error.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Create_beer_price_with_negative_value_should_return_an_error()
        {
            Result<BeerPrice> beerPriceResult = BeerPrice.Create(-5);

            beerPriceResult.IsFailure.ShouldBeTrue();

            beerPriceResult.Error.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Create_beer_price_with_too_high_value_should_return_an_error()
        {
            Result<BeerPrice> beerPriceResult = BeerPrice.Create(200);

            beerPriceResult.IsFailure.ShouldBeTrue();

            beerPriceResult.Error.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Create_beer_price_with_too_precis_value_should_return_an_error()
        {
            Result<BeerPrice> beerPriceResult = BeerPrice.Create(2.555m);

            beerPriceResult.IsFailure.ShouldBeTrue();

            beerPriceResult.Error.ShouldNotBeEmpty();
        }
    }
}
