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
            
            Person person = await _personQueryRepository.GetByIdAsync(request.Id);
            person.Email = request.Mail;
            person.PhoneNumber = request.PhoneNumber;
            _personCommandRepository.UpdateAsync(person);
            return new SuccessDataResult<PersonDTO>(person.Name + "Kullanıcı Güncellendi.", person.Adapt<PersonDTO>());
        }
    }
}

