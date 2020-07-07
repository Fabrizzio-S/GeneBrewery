using CSharpFunctionalExtensions;

using FluentAssert;

using GeneBrewery.Business.Beer;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.Beer
{
    [TestClass]
    public class BeerNameTest
    {
        [TestMethod]
        public void Create_beer_name_without_error()
        {
            Result<BeerName> beerNameResult = BeerName.Create("Leffe");

            beerNameResult.IsFailure.ShouldBeFalse();

            BeerName beerName = beerNameResult.Value;

            beerName.Value.ShouldBeEqualTo("Leffe");
        }

        [TestMethod]
        public void Create_beer_name_with_empty_string_value_should_return_an_error()
        {
            Result<BeerName> beerNameResult = BeerName.Create("");

            beerNameResult.IsFailure.ShouldBeTrue();

            beerNameResult.Error.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Create_beer_name_with_too_long_string_value_should_return_an_error()
        {
            Result<BeerName> beerNameResult = BeerName.Create("Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe-Leffe");

            beerNameResult.IsFailure.ShouldBeTrue();

            beerNameResult.Error.ShouldNotBeEmpty();
        }
    }
}