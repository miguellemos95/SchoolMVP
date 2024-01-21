using Application.Common.Contracts;
using Application.Common.Errors;
using Application.SchoolFeatures.Contracts;
using Domain;
using MediatR;
using Messaging;

namespace Application.SchoolFeatures.Update;

public static class UpdateSchool
{
    public record Command(Guid Id, string Name, string Description) : IRequest<Result<UpdateSchoolResponse>>;

    internal sealed class Handler : IRequestHandler<Command, Result<UpdateSchoolResponse>>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork)
        {
            _schoolRepository = schoolRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UpdateSchoolResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request is null || request.Id == Guid.Empty || string.IsNullOrEmpty(request.Name)
                || string.IsNullOrEmpty(request.Description))
                return DomainErrors.School.UpdateSchoolInvalidRequest;

            School? school = await _schoolRepository.GetAsync(school => school.Id == request.Id);
            
            if (school is null)
                return DomainErrors.School.GetSchoolNotFound;

            School updatedSchool = new(request.Name, request.Description);

            school.Update(updatedSchool);

            _schoolRepository.Update(school);

            if (!await _unitOfWork.CommitAsync(cancellationToken))
                return DomainErrors.School.UpdateSchoolSavingFailure;

            return school.AsUpdateDto();
        }
    }

    public record UpdateSchoolResponse(Guid Id);
}