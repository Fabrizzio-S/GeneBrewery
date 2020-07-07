using System;
using System.Collections.Generic;

using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Brewery
{
    public class Brewery : Entity
    {
        public BreweryName Name { get; }
        public IReadOnlyList<Beer.Beer> Beers { get; private set; }

        private Brewery()
        {
            Beers = new List<Beer.Beer>();
        }

        public Brewery(BreweryName breweryName) : this()
        {
            Name = breweryName ?? throw new ArgumentNullException(nameof(breweryName));
        }
        
        //public CanAddBeer()
        //{

        //}
    }
}
