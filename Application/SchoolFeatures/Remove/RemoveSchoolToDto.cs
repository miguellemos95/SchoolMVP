using Domain;

namespace Application.SchoolFeatures.Remove;

internal static class RemoveSchoolToDto
{
    internal static RemoveSchool.RemoveSchoolResponse AsRemoveDto(this School school)
    {
        return new RemoveSchool.RemoveSchoolResponse(school.Id);
    }
}