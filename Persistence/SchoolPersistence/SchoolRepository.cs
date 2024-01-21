using Application.SchoolFeatures.Contracts;
using Domain;
using Persistence.Common;

namespace Persistence.SchoolPersistence;

internal class SchoolRepository : Repository<School>, ISchoolRepository
{
    private readonly CoreContext _context;

    public SchoolRepository(CoreContext context) : base(context)
    {
        _context = context;
    }
}