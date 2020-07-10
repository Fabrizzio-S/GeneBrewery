using GeneBrewery.Business.Common;

using Microsoft.EntityFrameworkCore;

namespace GeneBrewery.Business.BeerProviders
{
    public class BeerProviderRepository : IBeerProviderRepository
    {
        private readonly BreweryContext breweryContext;

        public BeerProviderRepository(BreweryContext breweryContext)
        {
            this.breweryContext = breweryContext;
        }

        public void Save(BeerProvider beerProvider)
        {
            breweryContext.Entry(beerProvider).State = EntityState.Modified;
        }
    }
}
