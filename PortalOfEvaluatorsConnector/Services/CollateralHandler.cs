namespace PortalOfEvaluatorsConnector.Services;

public class CollateralHandler : ICollateralHandler
{
    private readonly IAddCollateralService _addCollateralService;
    private readonly ILogger<CollateralHandler> _logger;

    public CollateralHandler(IAddCollateralService addCollateralService, ILogger<CollateralHandler> logger)
    {
        _addCollateralService = addCollateralService;
        _logger = logger;
    }
}
