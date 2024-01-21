using Application.SchoolFeatures.Get;

namespace API.SchoolAPI.Get;

public static class GetSchoolToDomain
{
    public static GetSchool.Query AsQuery(this GetSchoolRequest request)
    {
        return new GetSchool.Query
        {
            Id = request.Id
        };
    }
}