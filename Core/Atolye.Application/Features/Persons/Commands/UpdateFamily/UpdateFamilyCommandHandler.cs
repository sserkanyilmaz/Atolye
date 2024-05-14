using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Persons.Commands.UpdateFamily
{
    public class UpdateFamilyCommandHandler : IRequestHandler<UpdateFamilyCommandRequest, IDataResult<PersonDTO>>
	{
        ICommandRepository<Person> _personCommandRepository;
        IQueryRepository<Person> _personQueryRepository;

        public UpdateFamilyCommandHandler(IQueryRepository<Person> personQueryRepository, ICommandRepository<Person> personCommandRepository)
        {
            _personQueryRepository = personQueryRepository;
            _personCommandRepository = personCommandRepository;
        }

        public async Task<IDataResult<PersonDTO>> Handle(UpdateFamilyCommandRequest request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.PersonId, out _))
            {
                return new ErrorDataResult<PersonDTO>("TeamId is not a valid GUID.");
            }
            if (string.IsNullOrEmpty(request.PersonId) || string.IsNullOrEmpty(request.MotherName) || string.IsNullOrEmpty(request.FatherName))
            {
                return new SuccessDataResult<PersonDTO>("Invalid request. All request parameters must be provided.");
            }

            Person person = await _personQueryRepository.GetByIdAsync(request.PersonId);
            if (person == null)
            {
                return new SuccessDataResult<PersonDTO>("Invalid request. Person does not exist.");
            }

            if (!person.IsActive)
            {
                return new SuccessDataResult<PersonDTO>("Invalid request. Person is not active.");
            }
            person = request.Adapt<Person>();
            await _personCommandRepository.UpdateAsync(person);
            return new SuccessDataResult<PersonDTO>(person.Name + "Kullanıcının aile bilgisi güncellendi.", person.Adapt<PersonDTO>());

        }
    }
}

