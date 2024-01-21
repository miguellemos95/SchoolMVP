using Application.Common.Contracts;
using Application.Common.Errors;
using Application.SchoolFeatures.Contracts;
using Domain;
using MediatR;
using Messaging;

namespace Application.SchoolFeatures.Add;

public static class AddSchool
{
    public record Command(string Name, string Description) : IRequest<Result<AddSchoolResponse>>;

    internal sealed class Handler : IRequestHandler<Command, Result<AddSchoolResponse>>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork)
        {
            _schoolRepository = schoolRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AddSchoolResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request is null || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description))
                return DomainErrors.School.AddSchoolInvalidRequest;

            School school = new(request.Name, request.Description);

            _schoolRepository.Insert(school);

            if (!await _unitOfWork.CommitAsync(cancellationToken))
                return DomainErrors.School.AddSchoolSavingFailure;

            return school.AsCreateDto();
        }
    }

    public record AddSchoolResponse(Guid Id);
}