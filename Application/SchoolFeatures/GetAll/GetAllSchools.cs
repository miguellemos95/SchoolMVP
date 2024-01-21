using Application.Common.Errors;
using Application.SchoolFeatures.Contracts;
using Application.SchoolFeatures.Get;
using Domain;
using MediatR;
using Messaging;

namespace Application.SchoolFeatures.GetAll;

public static class GetAllSchools
{
    public record Query() : IRequest<Result<GetAllSchoolsResponse>>;

    internal sealed class Handler : IRequestHandler<Query, Result<GetAllSchoolsResponse>>
    {
        private readonly ISchoolRepository _schoolRepository;

        public Handler(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<Result<GetAllSchoolsResponse>> Handle(Query query, CancellationToken cancellationToken)
        {
            if (query is null)
                return DomainErrors.School.GetAllSchoolsInvalidRequest;

            IEnumerable<School> schools = await _schoolRepository.GetAllAsync();

            if (schools is null || !schools.Any())
                return DomainErrors.School.GetAllSchoolsEmpty;

            return schools.AsGetAllDto();
        }
    }

    public record GetAllSchoolsResponse(IEnumerable<GetSchool.GetSchoolResponse> response);
}