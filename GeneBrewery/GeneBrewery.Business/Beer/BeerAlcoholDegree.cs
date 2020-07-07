using CSharpFunctionalExtensions;

namespace GeneBrewery.Business.Beer
{
    public class BeerAlcoholDegree : ValueObject<BeerAlcoholDegree>
    {
        private const decimal MaxAlcoholDegree = 30;
        public decimal Value { get; }

        private BeerAlcoholDegree(decimal value)
        {
            Value = value;
        }

        public static Result<BeerAlcoholDegree> Create(decimal alcoholDegree)
        {
            if (alcoholDegree < 0)
            {
                return Result.Failure<BeerAlcoholDegree>("Beer alcohol cannot be negative");
            }

            if (alcoholDegree > MaxAlcoholDegree)
            {
                return Result.Failure<BeerAlcoholDegree>("Beer alcohol degree is too high");
            }

            if (alcoholDegree % 0.1m > 0)
            {
                return Result.Failure<BeerAlcoholDegree>("Beer alcohol degree is too precis");
            }

            return Result.Ok(new BeerAlcoholDegree(alcoholDegree));
        }

        protected override bool EqualsCore(BeerAlcoholDegree other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}