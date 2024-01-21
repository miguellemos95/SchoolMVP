using Domain;

namespace Application.SchoolFeatures.Get;

internal static class GetSchoolToDto
{
    internal static GetSchool.GetSchoolResponse AsGetDto(this School school)
    {
        return new GetSchool.GetSchoolResponse(school.Id, school.Name, school.Description);
    }
}