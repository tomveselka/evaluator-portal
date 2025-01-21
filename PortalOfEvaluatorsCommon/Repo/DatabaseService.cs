using PortalOfEvaluatorsCommon.Models;

namespace PortalOfEvaluatorsCommon.Repo;

public class DatabaseService : IDatabaseService
{
    
    public DatabaseService(IConfiguration configuration)
    {

    }

    public Task AddCollateral(AddCollateralDto dto)
    {
        return Task.CompletedTask;
    }
}
