using CSharpFunctionalExtensions;

using FluentAssert;

using GeneBrewery.Business.Providers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneBrewery.Business.Test.Providers
{
    [TestClass]
    public class ProviderNameTest
    {
        [TestMethod]
        public void Create_provider_name_without_error()
        {
            Result<ProviderName> providerNameResult = ProviderName.Create("GeneDrinks");

            providerNameResult.IsFailure.ShouldBeFalse();

            ProviderName providerName = providerNameResult.Value;

            providerName.Value.ShouldBeEqualTo("GeneDrinks");
        }

        [TestMethod]
        public void Create_provider_name_with_empty_string_value_should_return_an_error()
        {
            Result<ProviderName> providerNameResult = ProviderName.Create("");

            providerNameResult.IsFailure.ShouldBeTrue();

            providerNameResult.Error.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Create_provider_name_with_too_long_string_value_should_return_an_error()
        {
            Result<ProviderName> providerNameResult = ProviderName.Create("GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks-GeneDrinks");

            providerNameResult.IsFailure.ShouldBeTrue();

            providerNameResult.Error.ShouldNotBeEmpty();
        }
    }
}