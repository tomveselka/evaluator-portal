using Microsoft.AspNetCore.Mvc;
using PortalOfEvaluatorsConnector.Models;

namespace PortalOfEvaluatorsConnector.Services;

public interface ICollateralHandler
{
    public Task<IActionResult> AddCollateral(AddCollateralRequest request);
    public Task<IActionResult> GetCollateralStatus(string applicationNumber);
    public Task<IActionResult> EditCollateral(EditCollateralRequest request);
    public Task<IActionResult> DeleteCollateral(DeleteCollateralRequest request);
}
