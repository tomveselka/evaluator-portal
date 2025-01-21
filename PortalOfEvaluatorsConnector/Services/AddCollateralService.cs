using PortalOfEvaluatorsCommon.Repo;

namespace PortalOfEvaluatorsConnector.Services;

public class AddCollateralService : IAddCollateralService
{
    private readonly IDatabaseService _databaseService;
    private readonly ILogger<AddCollateralService> _logger;

    public AddCollateralService(IDatabaseService databaseService, ILogger<AddCollateralService> logger)
    {
        _databaseService = databaseService;
        _logger = logger;
    }
}
