using CSharpFunctionalExtensions;

namespace GeneBrewery.Business.BeerProviders
{
    public class BeerProviderQuantity
    {
        public int Value { get; private set; }

        private BeerProviderQuantity(int value)
        {
            Value = value;
        }

        public static Result<BeerProviderQuantity> Create(int beerProviderQuantity)
        {
            if (beerProviderQuantity < 0)
            {
                return Result.Failure<BeerProviderQuantity>("Beer quantity cannot be negative");
            }

            return Result.Ok(new BeerProviderQuantity(beerProviderQuantity));
        }

        public void UpdateValue(BeerProviderQuantity beerProviderQuantity)
        {
            Value = beerProviderQuantity.Value;
        }
    }
}
