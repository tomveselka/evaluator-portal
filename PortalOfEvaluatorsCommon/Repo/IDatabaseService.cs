using PortalOfEvaluatorsCommon.Models;

namespace PortalOfEvaluatorsCommon.Repo;

public interface IDatabaseService
{
    public Task AddCollateral(AddCollateralRequestDto dto);
    public Task<ApplicationStatusDto> GetCollateralStatus(string applicationNumber);
}
