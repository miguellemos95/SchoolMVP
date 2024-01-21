using Domain;

namespace Application.SchoolFeatures.Update;

internal static class UpdateSchoolToDto
{
    internal static UpdateSchool.UpdateSchoolResponse AsUpdateDto(this School school)
    {
        return new UpdateSchool.UpdateSchoolResponse(school.Id);
    }
}