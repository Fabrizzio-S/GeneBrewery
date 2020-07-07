using System.Collections.Generic;

using GeneBrewery.Business.Common;

namespace GeneBrewery.Business.Provider
{
    public class Provider : Entity
    {
        public ProviderName Name { get; }
        public IReadOnlyList<Beer.Beer> Beers { get; private set; }
    }
}
