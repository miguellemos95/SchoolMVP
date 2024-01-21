using Application.SchoolFeatures.Remove;

namespace API.SchoolAPI.Remove;

public static class RemoveSchoolToDomain
{
    public static RemoveSchool.Command AsCommand(this RemoveSchoolRequest request)
    {
        return new RemoveSchool.Command(request.Id);
    }
}