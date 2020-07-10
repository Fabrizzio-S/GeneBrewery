using CSharpFunctionalExtensions;

using FluentAssert;

using GeneBrewery.Business.BeerProviders;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.BeerProviders
{
    [TestClass]
    public class BeerProviderQuantityTest
    {
        [TestMethod]
        public void Create_beer_provider_quantity_without_error()
        {
            Result<BeerProviderQuantity> beerProviderQuantityResult = BeerProviderQuantity.Create(10);

            beerProviderQuantityResult.IsFailure.ShouldBeFalse();

            BeerProviderQuantity beerProviderQuantity = beerProviderQuantityResult.Value;

            beerProviderQuantity.Value.ShouldBeEqualTo(10);
        }

        [TestMethod]
        public void Create_beer_provider_quantity_with_negative_value_should_return_an_error()
        {
            Result<BeerProviderQuantity> beerProviderQuantityResult = BeerProviderQuantity.Create(-5);

            beerProviderQuantityResult.IsFailure.ShouldBeTrue();

            beerProviderQuantityResult.Error.ShouldNotBeEmpty();
        }
    }
}
