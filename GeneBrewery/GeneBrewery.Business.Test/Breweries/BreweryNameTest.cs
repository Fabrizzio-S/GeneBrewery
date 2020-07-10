using CSharpFunctionalExtensions;

using FluentAssert;

using GeneBrewery.Business.Breweries;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.Breweries
{
    [TestClass]
    public class BreweryNameTest
    {
        [TestMethod]
        public void Create_brewery_name_without_error()
        {
            Result<BreweryName> breweryNameResult = BreweryName.Create("Abbaye de Leffe");

            breweryNameResult.IsFailure.ShouldBeFalse();

            BreweryName breweryName = breweryNameResult.Value;

            breweryName.Value.ShouldBeEqualTo("Abbaye de Leffe");
        }

        [TestMethod]
        public void Create_brewery_name_with_empty_string_value_should_return_an_error()
        {
            Result<BreweryName> breweryNameResult = BreweryName.Create("");

            breweryNameResult.IsFailure.ShouldBeTrue();

            breweryNameResult.Error.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Create_brewery_name_with_too_long_string_value_should_return_an_error()
        {
            Result<BreweryName> breweryNameResult = BreweryName.Create("Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe-Abbaye de Leffe");

            breweryNameResult.IsFailure.ShouldBeTrue();

            breweryNameResult.Error.ShouldNotBeEmpty();
        }
    }
}
