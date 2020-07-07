using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Beer
{
    public class Beer : Entity
    {
        public BeerName Name { get;  }
        public BeerPrice Price { get; }
        public BeerAlcoholDegree AlcoholDegree { get; }

        public Beer(BeerName name, BeerPrice price, BeerAlcoholDegree beerAlcoholDegree)
        {
            Name = name;
            Price = price;
            AlcoholDegree = beerAlcoholDegree;
        }
    }
}
