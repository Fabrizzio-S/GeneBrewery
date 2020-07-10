using System.Collections.Generic;

namespace GeneBrewery.Api.Breweries
{
    public class BeerDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal AlcoholDegree { get; set; }
        public List<ProviderDto> Providers { get; set; }
    }
}
