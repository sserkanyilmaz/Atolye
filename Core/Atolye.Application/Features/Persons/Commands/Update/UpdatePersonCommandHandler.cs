using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Persons.Commands.Update
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommandRequest, IDataResult<PersonDTO>>
    {
        ICommandRepository<Person> _personCommandRepository;
        IQueryRepository<Person> _personQueryRepository;

        public UpdatePersonCommandHandler(IQueryRepository<Person> personQueryRepository, ICommandRepository<Person> personCommandRepository)
        {
            _personQueryRepository = personQueryRepository;
            _personCommandRepository = personCommandRepository;
        }

        public async Task<IDataResult<PersonDTO>> Handle(UpdatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            
            if (!Guid.TryParse(request.Id, out _))
            {
                return new ErrorDataResult<PersonDTO>("TeamId is not a valid GUID.");
            }
            if (request == null)
            {
                return new ErrorDataResult<PersonDTO>("The update request is null.");
            }

            if (string.IsNullOrEmpty(request.Id) || string.IsNullOrEmpty(request.Mail) || string.IsNullOrEmpty(request.PhoneNumber))
            {
                return new ErrorDataResult<PersonDTO>("Invalid request parameters.");
            }

            Person person = await _personQueryRepository.GetByIdAsync(request.Id);

            if (person == null)
            {
                return new ErrorDataResult<PersonDTO>("Person not found.");
            }

            if (!person.IsActive)
            {
                return new ErrorDataResult<PersonDTO>("Person is not active.");
            }

            person.Email = request.Mail;
            person.PhoneNumber = request.PhoneNumber;
            await _personCommandRepository.UpdateAsync(person);
            return new SuccessDataResult<PersonDTO>(person.Name + "Kullanıcı Güncellendi.", person.Adapt<PersonDTO>());
        }
    }
}

