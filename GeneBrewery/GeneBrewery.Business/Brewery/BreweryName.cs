using System;

using CSharpFunctionalExtensions;

namespace GeneBrewery.Business.Brewery
{
    public class BreweryName : ValueObject<BreweryName>
    {
        public string Value { get; set; }

        private BreweryName(string value)
        {
            Value = value;
        }

        public static Result<BreweryName> Create(string breweryName)
        {
            breweryName = breweryName ?? string.Empty;

            if (breweryName.Length == 0)
            {
                return Result.Failure<BreweryName>("Brewery name should not be empty");
            }

            if (breweryName.Length > 150)
            {
                return Result.Failure<BreweryName>("Brewery name should not be longer than 150 characters");
            }

            return Result.Ok(new BreweryName(breweryName));
        }

        protected override bool EqualsCore(BreweryName other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}