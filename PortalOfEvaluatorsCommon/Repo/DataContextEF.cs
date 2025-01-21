using Microsoft.EntityFrameworkCore;
using PortalOfEvaluatorsCommon.Models;

namespace PortalOfEvaluatorsCommon.Repo;

public class DataContextEF : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContextEF(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Collateral> Collaterals { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"),
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("PortalOfEvaluatorsSchema");

        modelBuilder.Entity<Address>()
            .ToTable("Addresses", "PortalOfEvaluatorsSchema")
            .HasKey(a => a.Id);

        modelBuilder.Entity<Collateral>()
            .ToTable("Collaterals", "PortalOfEvaluatorsSchema")
            .HasKey(c => c.Id);
    }
}
