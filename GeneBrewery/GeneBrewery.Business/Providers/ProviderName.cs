using System;

using CSharpFunctionalExtensions;

namespace GeneBrewery.Business.Providers
{
    public class ProviderName : ValueObject<ProviderName>
    {
        public string Value { get; }

        private ProviderName(string value)
        {
            Value = value;
        }

        public static Result<ProviderName> Create(string providerName)
        {
            providerName = providerName ?? string.Empty;
            if (providerName.Length == 0)
            {
                return Result.Failure<ProviderName>("Provider name should not be empty");
            }

            if (providerName.Length > 100)
            {
                return Result.Failure<ProviderName>("Provider name is too long");
            }

            return Result.Ok(new ProviderName(providerName));
        }

        protected override bool EqualsCore(ProviderName other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
