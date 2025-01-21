using PortalOfEvaluatorsCommon.Models;

namespace PortalOfEvaluatorsCommon.Repo;

public interface IDatabaseService
{
    public Task AddCollateral(AddCollateralDto dto);
}
