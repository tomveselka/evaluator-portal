namespace PortalOfEvaluatorsCommon.Models;

public class Address
{
    public int Id { get; set; }
    public string? Number { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Postcode { get; set; }
    public string? Country { get; set; }
    public string? AddressCode { get; set; }
    public DateTime CreatedAt { get; set; }
}
