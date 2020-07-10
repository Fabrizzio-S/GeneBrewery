using System.Collections.Generic;
using System.Linq;

using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Beers
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BreweryContext breweryContext;

        public BeerRepository(BreweryContext breweryContext)
        {
            this.breweryContext = breweryContext;
        }

        public Beer GetById(long id)
        {
            return breweryContext.Beers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Beer> GetByBreweryId(long breweryId)
        {
            return breweryContext.Beers.Where(x => x.Brewery.Id == breweryId);
        }

        public void Delete(Beer beer)
        {
            var beerProviders = breweryContext.BeerProviders.Where(x => x.Beer == beer);
            breweryContext.BeerProviders.RemoveRange(beerProviders);
            breweryContext.Beers.Remove(beer);
        }
    }
}
