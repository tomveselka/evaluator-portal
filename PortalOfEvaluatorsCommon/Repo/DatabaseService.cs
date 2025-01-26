using Microsoft.EntityFrameworkCore;
using PortalOfEvaluatorsCommon.Models;

namespace PortalOfEvaluatorsCommon.Repo;

public class DatabaseService : IDatabaseService
{
    DataContextEF _context;

    public DatabaseService(IConfiguration configuration)
    {
        _context = new DataContextEF(configuration);
    }

    public async Task AddCollateral(AddCollateralRequestDto dto)
    {
        await _context.AddAsync(dto);
        await _context.SaveChangesAsync();
    }

    public async Task<ApplicationStatusDto> GetCollateralStatus(string applicationNumber)
    {
        var collateral = await GetAllCollateral().Where(c => c.ApplicationNumber == applicationNumber).FirstAsync();
        return new ApplicationStatusDto
        {
            ApplicationNumber = collateral.ApplicationNumber,
            Status = collateral.Status
        };
    }

    public IQueryable<Collateral> GetAllCollateral()
    {
        return _context.Collaterals.AsQueryable();
    }
}
