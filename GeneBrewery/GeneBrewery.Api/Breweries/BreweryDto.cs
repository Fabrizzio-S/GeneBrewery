using System.Collections.Generic;

namespace GeneBrewery.Api.Breweries
{
    public class BreweryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<BeerDto> Beers { get; set; }
}
}
