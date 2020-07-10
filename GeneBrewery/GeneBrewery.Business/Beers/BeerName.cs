using System;

using CSharpFunctionalExtensions;

namespace GeneBrewery.Business.Beers
{
    public class BeerName : ValueObject<BeerName>
    {
        public string Value { get; }
        
        private BeerName(string beerName)
        {
            Value = beerName;
        }

        public static Result<BeerName> Create(string beerName)
        {
            beerName = beerName ?? string.Empty;

            if (beerName.Length == 0)
            {
                return Result.Failure<BeerName>("Beer name should not be empty");
            }

            if (beerName.Length > 100)
            {
                return Result.Failure<BeerName>("Beer name is too long");
            }

            return Result.Ok(new BeerName(beerName));
        }

        protected override bool EqualsCore(BeerName other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}