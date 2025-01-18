using Microsoft.AspNetCore.Mvc;
using PortalOfEvaluatorsConnector.Models;

namespace PortalOfEvaluatorsConnector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(ILogger<PropertyController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "AddProperty")]
        public AddPropertyResponse AddProperty(AddPropertyRequest request)
        {
            return new AddPropertyResponse { };
        }
    }
}
