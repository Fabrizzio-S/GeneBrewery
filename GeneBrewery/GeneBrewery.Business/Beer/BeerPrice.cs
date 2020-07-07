using CSharpFunctionalExtensions;

namespace GeneBrewery.Business.Beer
{
    public class BeerPrice : ValueObject<BeerPrice>
    {
        private const decimal MaxBeerPrice = 100;
        public decimal Value { get; }

        private BeerPrice(decimal value)
        {
            Value = value;
        }

        public static Result<BeerPrice> Create(decimal beerPrice)
        {
            if (beerPrice <= 0)
            {
                return Result.Failure<BeerPrice>("Beer price cannot be negative or equals to zero");
            }

            if (beerPrice > MaxBeerPrice)
            {
                return Result.Failure<BeerPrice>("Beer price is too expensive");
            }

            if (beerPrice % 0.01m > 0)
            {
                return Result.Failure<BeerPrice>("Beer price cannot be more precis than a cent");
            }

            return Result.Ok(new BeerPrice(beerPrice));
        }

        protected override bool EqualsCore(BeerPrice other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}