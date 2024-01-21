using Application.SchoolFeatures.Update;

namespace API.SchoolAPI.Update;

public static class UpdateSchoolToDomain
{
    public static UpdateSchool.Command AsCommand(this UpdateSchoolRequest request, Guid id)
    {
        return new UpdateSchool.Command(id, request.Name, request.Description);
    }
}