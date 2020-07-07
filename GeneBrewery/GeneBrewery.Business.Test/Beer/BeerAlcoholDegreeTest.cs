using CSharpFunctionalExtensions;

using FluentAssert;

using GeneBrewery.Business.Beer;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.Beer
{
    [TestClass]
    public class BeerAlcoholDegreeTest
    {
        [TestMethod]
        public void Create_beer_alcohol_degree_without_error()
        {
            Result<BeerAlcoholDegree> beerAlcoholDegreeResult = BeerAlcoholDegree.Create(1.1m);

            beerAlcoholDegreeResult.IsFailure.ShouldBeFalse();

            BeerAlcoholDegree beerAlcoholDegree = beerAlcoholDegreeResult.Value;

            beerAlcoholDegree.Value.ShouldBeEqualTo(1.1m);
        }

        [TestMethod]
        public void Create_beer_alcohol_degree_with_negative_value_should_return_an_error()
        {
            Result<BeerAlcoholDegree> beerAlcoholDegreeResult = BeerAlcoholDegree.Create(-5);

            beerAlcoholDegreeResult.IsFailure.ShouldBeTrue();

            beerAlcoholDegreeResult.Error.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Create_beer_alcohol_degree_with_too_high_value_should_return_an_error()
        {
            Result<BeerAlcoholDegree> beerAlcoholDegreeResult = BeerAlcoholDegree.Create(50);

            beerAlcoholDegreeResult.IsFailure.ShouldBeTrue();

            beerAlcoholDegreeResult.Error.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Create_beer_alcohol_degree_with_too_precis_value_should_return_an_error()
        {
            Result<BeerAlcoholDegree> beerAlcoholDegreeResult = BeerAlcoholDegree.Create(1.0001m);

            beerAlcoholDegreeResult.IsFailure.ShouldBeTrue();

            beerAlcoholDegreeResult.Error.ShouldNotBeEmpty();
        }
    }
}
