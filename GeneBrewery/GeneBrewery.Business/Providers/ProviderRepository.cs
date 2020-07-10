using GeneBrewery.Business.Common;

using Microsoft.EntityFrameworkCore;

namespace GeneBrewery.Business.Providers
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly BreweryContext breweryContext;

        public ProviderRepository(BreweryContext breweryContext)
        {
            this.breweryContext = breweryContext;
        }

        public Provider GetById(long id)
        {
            Provider provider = breweryContext.Providers.Find(id);

            if (provider == null)
            {
                return null;
            }

            breweryContext.Entry(provider).Collection(x => x.BeerProviders).Query()
                .Include(x => x.Beer)
                .Load();
            
            return provider;
        }
    }
}
