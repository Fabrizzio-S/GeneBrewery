using GeneBrewery.Business.Common;

using Microsoft.EntityFrameworkCore;

namespace GeneBrewery.Business.Breweries
{
    public class BreweryRepository : IBreweryRepository
    {
        private readonly BreweryContext breweryContext;

        public BreweryRepository(BreweryContext breweryContext)
        {
            this.breweryContext = breweryContext;
        }

        public Brewery GetById(long id)
        {
            Brewery brewery = breweryContext.Breweries.Find(id);

            if (brewery == null)
            {
                return null;
            }

            breweryContext.Entry(brewery).Collection(x => x.Beers).Query()
                .Include(x => x.BeerProviders)
                .ThenInclude(x => x.Provider)
                .Load();
            return brewery;
        }

        public bool Exists(long id)
        {
            Brewery brewery = breweryContext.Breweries.Find(id);
            return brewery != null;
        }
    }
}
