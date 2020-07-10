using CSharpFunctionalExtensions;

using GeneBrewery.Api.Utils;
using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Breweries;
using GeneBrewery.Business.Common;

using Microsoft.AspNetCore.Mvc;

namespace GeneBrewery.Api.Beers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : CoreController
    {
        private readonly IBreweryRepository breweryRepository;
        private readonly IBeerRepository beerRepository;

        public BeersController(IBreweryRepository breweryRepository,
            IBeerRepository beerRepository,
            BreweryContext breweryContext) : base(breweryContext)
        {
            this.breweryRepository = breweryRepository;
            this.beerRepository = beerRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBeerDto beer)
        {
            Brewery brewery = breweryRepository.GetById(beer.BreweryId);
            if(brewery == null)
            {
                return BadRequest($"Brewery with id {beer.BreweryId} does not exists");
            }

            Result<BeerName> beerNameResult = BeerName.Create(beer.Name);
            Result<BeerPrice> beerPriceResult = BeerPrice.Create(beer.Price);
            Result<BeerAlcoholDegree> beerAlcoholDegreeResult = BeerAlcoholDegree.Create(beer.AlcoholDegree);
            Result result = Result.Combine(beerNameResult, beerPriceResult, beerAlcoholDegreeResult);
            if (result.IsFailure)
            {
                return BadRequest(beerNameResult.Error);
            }

            Result<Brewery> breweryResult = brewery.AddBeer(beerNameResult.Value, beerPriceResult.Value, beerAlcoholDegreeResult.Value);
            if (breweryResult.IsFailure)
            {
                return BadRequest(breweryResult.Error);
            }

            return Ok(breweryResult.Value);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            Beer beer = beerRepository.GetById(id);
            if (beer == null)
            {
                return BadRequest($"Beer with id {id} does not exists");
            }

            beerRepository.Delete(beer);

            return Ok();
        }
    }
}
