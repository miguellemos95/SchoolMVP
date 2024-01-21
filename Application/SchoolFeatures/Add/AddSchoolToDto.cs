using Domain;

namespace Application.SchoolFeatures.Add;

internal static class AddSchoolToDto
{
    internal static AddSchool.AddSchoolResponse AsCreateDto(this School school)
    {
        return new AddSchool.AddSchoolResponse(school.Id);
    }
}