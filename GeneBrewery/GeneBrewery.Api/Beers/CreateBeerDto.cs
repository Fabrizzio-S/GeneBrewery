namespace GeneBrewery.Api.Beers
{
    public class CreateBeerDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal AlcoholDegree { get; set; }
        public long BreweryId { get; set; }
    }
}
