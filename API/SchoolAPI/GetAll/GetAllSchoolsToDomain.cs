using Application.SchoolFeatures.GetAll;

namespace API.SchoolAPI.GetAll;

public static class GetAllSchoolsToDomain
{
    public static GetAllSchools.Query AsQuery(this GetAllSchoolRequest request)
    {
        return new GetAllSchools.Query();
    }
}