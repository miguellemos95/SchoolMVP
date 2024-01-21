using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Persistence.Common;

namespace Persistence.SchoolPersistence;

internal class SchoolAuditConfiguration : IEntityTypeConfiguration<SchoolAudit>
{
    public void Configure(EntityTypeBuilder<SchoolAudit> builder)
    {
        builder
            .ToTable(TablesNames.SchoolAudit);

        builder
            .HasKey(x => x.Id);
    }
}