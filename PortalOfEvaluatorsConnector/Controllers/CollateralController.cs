using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PortalOfEvaluatorsConnector.Models;
using PortalOfEvaluatorsConnector.Services;

namespace PortalOfEvaluatorsConnector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollateralController : ControllerBase
    {
        private readonly ICollateralHandler _collateralHandler;

        public CollateralController(ICollateralHandler collateralHandler)
        {
            _collateralHandler = collateralHandler;
        }

        [HttpPost("AddCollateral")]
        public async Task<IActionResult> AddCollateral(AddCollateralRequest request)
        {
            var response = await _collateralHandler.AddCollateral(request);
            return response;
        }

        /*
        [ProducesResponseType(typeof(GetCollateralStatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(Name = "GetCollateralStatus/{applicationNumber}")]
        public async Task<IActionResult> GetCollateralStatus(string applicationNumber)
        {
            var response = await _collateralHandler.GetCollateralStatus(applicationNumber);
            if(response.ExceptionName is null)
            {
                return Ok(response);
            }
            if (response.ExceptionName.Equals("InvalidOperationException")){
                return StatusCode(404, new { Message = response.Message, Error = response.ExceptionName });
            }
            else
            {
                return StatusCode(500, new { Message = response.Message, Error = response.ExceptionName });
            }
        }*/

        [ProducesResponseType(typeof(GetCollateralStatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetCollateralStatus/{applicationNumber}")]
        public async Task<IActionResult> GetCollateralStatus(string applicationNumber)
        {
            var response = await _collateralHandler.GetCollateralStatus(applicationNumber);
            return response;
        }
    }
}
