using CSharpFunctionalExtensions;

using GeneBrewery.Api.Utils;
using GeneBrewery.Business.BeerProviders;
using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Common;
using GeneBrewery.Business.Providers;

using Microsoft.AspNetCore.Mvc;

namespace GeneBrewery.Api.Providers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : CoreController
    {
        private readonly IProviderRepository providerRepository;
        private readonly IBeerRepository beerRepository;
        private readonly IBeerProviderRepository beerProviderRepository;

        public ProvidersController(IProviderRepository providerRepository, 
            IBeerRepository beerRepository,
            IBeerProviderRepository beerProviderRepository, 
            BreweryContext breweryContext) : base(breweryContext)
        {
            this.providerRepository = providerRepository;
            this.beerRepository = beerRepository;
            this.beerProviderRepository = beerProviderRepository;
        }

        [HttpPost]
        [Route("beer")]
        public IActionResult AddBeerToProvider([FromBody] AddBeerToProviderDto addBeerToProvider)
        {
            Provider provider = providerRepository.GetById(addBeerToProvider.ProviderId);
            if (provider == null)
            {
                return BadRequest($"Provider with id {addBeerToProvider.ProviderId} does not exists");
            }

            Beer beer = beerRepository.GetById(addBeerToProvider.BeerId);
            if (beer == null)
            {
                return BadRequest($"Beer with id {addBeerToProvider.BeerId} does not exists");
            }

            Result<BeerProviderQuantity> beerProviderQuantityResult =
                BeerProviderQuantity.Create(addBeerToProvider.AvailableQuantity);
            if (beerProviderQuantityResult.IsFailure)
            {
                return BadRequest(beerProviderQuantityResult.Error);
            }

            Result<Provider> result = provider.ProvideBeer(beer, beerProviderQuantityResult.Value);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            
            return Ok(result.Value);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateBeerQuantity(long id, [FromBody] UpdateBeerQuantityDto updateBeerQuantity)
        {
            Provider provider = providerRepository.GetById(id);
            if (provider == null)
            {
                return BadRequest($"Provider with id {id} does not exists");
            }

            Beer beer = beerRepository.GetById(updateBeerQuantity.BeerId);
            if (beer == null)
            {
                return BadRequest($"Beer with id {updateBeerQuantity.BeerId} does not exists");
            }

            Result<BeerProviderQuantity> beerProviderQuantityResult =
                BeerProviderQuantity.Create(updateBeerQuantity.AvailableQuantity);
            if (beerProviderQuantityResult.IsFailure)
            {
                return BadRequest(beerProviderQuantityResult.Error);
            }
            
            Result<BeerProvider> beerProvider = provider.UpdateBeerQuantity(beer, beerProviderQuantityResult.Value);
            if (beerProvider.IsFailure)
            {
                return BadRequest(beerProvider.Error);
            }

            beerProviderRepository.Save(beerProvider.Value);
            
            return Ok(provider);
        }
    }
}
