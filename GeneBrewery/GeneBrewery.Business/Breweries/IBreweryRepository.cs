namespace GeneBrewery.Business.Breweries
{
    public interface IBreweryRepository
    {
        Brewery GetById(long id);

        bool Exists(long id);
    }
}