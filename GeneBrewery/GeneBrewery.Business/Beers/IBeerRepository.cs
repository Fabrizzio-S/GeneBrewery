using System.Collections.Generic;

namespace GeneBrewery.Business.Beers
{
    public interface IBeerRepository
    {
        Beer GetById(long id);

        IEnumerable<Beer> GetByBreweryId(long breweryId);

        void Delete(Beer beer);
    }
}