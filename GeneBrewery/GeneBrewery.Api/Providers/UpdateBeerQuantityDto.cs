namespace GeneBrewery.Api.Providers
{
    public class UpdateBeerQuantityDto
    {
        public long BeerId { get; set; }
        public int AvailableQuantity { get; set; }
    }
}