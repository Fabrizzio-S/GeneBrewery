using GeneBrewery.Business.Common;

using Microsoft.AspNetCore.Mvc;

namespace GeneBrewery.Api.Utils
{
    public class CoreController : ControllerBase
    {
        private readonly BreweryContext breweryContext;

        public CoreController(BreweryContext breweryContext)
        {
            this.breweryContext = breweryContext;
        }

        protected new IActionResult Ok()
        {
            breweryContext.SaveChanges();
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            breweryContext.SaveChanges();
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }
    }
}
