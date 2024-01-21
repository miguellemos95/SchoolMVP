using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistence.Common;

internal sealed class AuditableEntitiesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        DbContext? context = eventData.Context;

        if (context is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        IEnumerable<EntityEntry<School>> entries = context.ChangeTracker.Entries<School>();
                        
        ICollection<SchoolAudit> audits = new List<SchoolAudit>();

        foreach (EntityEntry<School> entityEntry in entries)
        {
            foreach (PropertyEntry propertyEntry in entityEntry.Properties)
                {
                //add just modified properties
                    audits.Add(new SchoolAudit(
                        $"{entityEntry.State}", 
                        $"{propertyEntry.Metadata.Name}",
                        $"{propertyEntry.OriginalValue}",
                        $"{propertyEntry.CurrentValue}",
                        DateTime.UtcNow,
                        "system"));
                }
        }

        context.AddRange(audits);
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
