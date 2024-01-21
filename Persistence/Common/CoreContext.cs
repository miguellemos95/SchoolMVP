using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.SchoolPersistence;

namespace Persistence.Common;

public class CoreContext : DbContext
{
    public DbSet<School> Schools => Set<School>();
    public DbSet<SchoolAudit> SchoolAudit => Set<SchoolAudit>();

    public CoreContext(DbContextOptions<CoreContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntitiesInterceptor()); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {       
        modelBuilder.ApplyConfiguration(new SchoolConfiguration());
        modelBuilder.ApplyConfiguration(new SchoolAuditConfiguration());
    }
}