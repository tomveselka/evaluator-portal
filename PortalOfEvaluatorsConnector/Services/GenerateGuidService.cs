namespace PortalOfEvaluatorsConnector.Services;

public class GenerateGuidService : IGenerateGuidService
{
    public Guid GenerateGuid()
    {
        return new Guid();
    }
}
