using Application.Common.Errors;
using Application.SchoolFeatures.Contracts;
using Domain;
using MediatR;
using Messaging;

namespace Application.SchoolFeatures.Get;

public static class GetSchool
{
    public record Query : IRequest<Result<GetSchoolResponse>>
    {
        public Guid Id { get; init; }
    }

    internal sealed class Handler : IRequestHandler<Query, Result<GetSchoolResponse>>
    {
        private readonly ISchoolRepository _schoolRepository;

        public Handler(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<Result<GetSchoolResponse>> Handle(Query query, CancellationToken cancellationToken)
        {
            if (query is null || query.Id == Guid.Empty)
                return DomainErrors.School.GetSchoolInvalidRequest;

            School? school = await _schoolRepository.GetAsync(school => school.Id == query.Id);

            if (school is null)
                return DomainErrors.School.GetSchoolNotFound;

            return school.AsGetDto();
        }
    }

    public record GetSchoolResponse(Guid Id, string Name, string Description);
}