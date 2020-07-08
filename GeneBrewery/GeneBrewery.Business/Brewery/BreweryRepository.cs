using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Brewery
{
    public class BreweryRepository
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

            breweryContext.Entry(brewery).Collection(x => x.Beers).Load();
            return brewery;
        }
    }
}
