using Microsoft.AspNetCore.Mvc;
using PortalOfEvaluatorsConnector.Models;
using PortalOfEvaluatorsConnector.Services;

namespace PortalOfEvaluatorsConnector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollateralController : ControllerBase
    {
        private readonly ILogger<CollateralController> _logger;
        private readonly ICollateralHandler _collateralHandler;

        public CollateralController(ILogger<CollateralController> logger, ICollateralHandler collateralHandler)
        {
            _logger = logger;
            _collateralHandler = collateralHandler;
        }

        [HttpPost(Name = "AddProperty")]
        public AddPropertyResponse AddProperty(AddPropertyRequest request)
        {
            return new AddPropertyResponse { };
        }
    }
}
