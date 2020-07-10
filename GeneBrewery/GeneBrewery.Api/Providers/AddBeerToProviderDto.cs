namespace GeneBrewery.Api.Providers
{
    public class AddBeerToProviderDto
    {
        public long BeerId { get; set; }
        public long ProviderId { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
