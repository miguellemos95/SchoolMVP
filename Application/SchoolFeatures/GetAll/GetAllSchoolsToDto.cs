using Application.SchoolFeatures.Get;
using Domain;

namespace Application.SchoolFeatures.GetAll;

internal static class GetAllSchoolsToDto
{
    internal static GetAllSchools.GetAllSchoolsResponse AsGetAllDto(this IEnumerable<School> schools)
    {
        ICollection<GetSchool.GetSchoolResponse> dtos = new List<GetSchool.GetSchoolResponse>();

        foreach (School school in schools)
        {
            dtos.Add(school.AsGetDto());
        }

        return new GetAllSchools.GetAllSchoolsResponse(dtos);
    }
}