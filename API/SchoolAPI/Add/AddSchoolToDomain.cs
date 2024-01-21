using Application.SchoolFeatures.Add;

namespace API.SchoolAPI.Add;

public static class AddSchoolToDomain
{
    public static AddSchool.Command AsCommand(this AddSchoolRequest request)
    {
        return new AddSchool.Command(request.Name, request.Description);
    }
}