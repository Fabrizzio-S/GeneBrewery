using System.Linq;

using GeneBrewery.Api.Utils;
using GeneBrewery.Business.Breweries;
using GeneBrewery.Business.Common;

using Microsoft.AspNetCore.Mvc;

namespace GeneBrewery.Api.Breweries
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweriesController : CoreController
    {
        private readonly IBreweryRepository breweryRepository;

        public BreweriesController(BreweryContext breweryContext, 
            IBreweryRepository breweryRepository) : base(breweryContext)
        
        {
            this.breweryRepository = breweryRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(long id)
        {
            Brewery brewery = breweryRepository.GetById(id);
            if (brewery == null)
            {
                return NotFound();
            }

            var result = new BreweryDto()
            {
                Id = brewery.Id,
                Name = brewery.Name.Value,
                Beers = brewery.Beers?.Select(x => new BeerDto()
                {
                    Name = x.Name.Value,
                    Price = x.Price.Value,
                    AlcoholDegree = x.AlcoholDegree.Value,
                    Providers = x.BeerProviders?.Select(y => new ProviderDto()
                    {
                        Name = y.Provider.Name.Value
                    }).ToList()
                }).ToList()
            };

            return Ok(result);
        }
    }
}
