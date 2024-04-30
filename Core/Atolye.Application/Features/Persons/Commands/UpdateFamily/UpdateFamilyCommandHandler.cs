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
            Person person = await _personQueryRepository.GetByIdAsync(request.PersonId);
            person = request.Adapt<Person>();
            await _personCommandRepository.UpdateAsync(person);
            return new SuccessDataResult<PersonDTO>(person.Name + "Kullanıcının aile bilgisi güncellendi.", person.Adapt<PersonDTO>());

        }
    }
}

