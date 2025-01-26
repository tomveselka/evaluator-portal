namespace PortalOfEvaluatorsCommon.Models;

public class Collateral
{
    public int Id { get; set; }
    public string CollateralIdentifier { get; set; }
    public string ApplicationNumber { get; set; }
    public string CollateralType { get; set; }
    public int? EvaluatorId { get; set; }
    public int? EvaluationReportId { get; set; }
    public int? PaymentId { get; set; }
    public int? AddressId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool LatestRecord { get; set; }
    public DateTime? DateOfUpdate { get; set; }
}
