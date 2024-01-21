using Application.Common.Contracts;
using Application.Common.Errors;
using Application.SchoolFeatures.Contracts;
using Domain;
using MediatR;
using Messaging;

namespace Application.SchoolFeatures.Remove;

public static class RemoveSchool
{
    public record Command(Guid Id) : IRequest<Result<RemoveSchoolResponse>>;

    internal sealed class Handler : IRequestHandler<Command, Result<RemoveSchoolResponse>>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork)
        {
            _schoolRepository = schoolRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<RemoveSchoolResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request is null || request.Id == Guid.Empty)
                return DomainErrors.School.RemoveSchoolInvalidRequest;

            School? school = await _schoolRepository.GetAsync(school => school.Id == request.Id);
            
            if (school is null)
                return DomainErrors.School.GetSchoolNotFound;

            _schoolRepository.Delete(school);

            if (!await _unitOfWork.CommitAsync(cancellationToken))
                return DomainErrors.School.RemoveSchoolSavingFailure;

            return school.AsRemoveDto();
        }
    }

    public record RemoveSchoolResponse(Guid Id);
}