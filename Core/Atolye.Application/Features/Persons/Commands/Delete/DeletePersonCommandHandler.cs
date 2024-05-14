using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using Mapster;
using MediatR;

namespace Atolye.Application.Features.Persons.Commands.Delete
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommandRequest, IDataResult<PersonDTO>>
    {
        ICommandRepository<Person> _personCommandRepository;

        public DeletePersonCommandHandler(ICommandRepository<Person> personCommandRepository)
        {
            _personCommandRepository = personCommandRepository;
        }

        public async Task<IDataResult<PersonDTO>> Handle(DeletePersonCommandRequest request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out _))
            {
                return new ErrorDataResult<PersonDTO>("TeamId is not a valid GUID.");
            }
            Person  person = await _personCommandRepository.RemoveAsync(request.Id);
            
            return new SuccessDataResult<PersonDTO>(person.Name + "Kullanıcı Silindi.", person.Adapt<PersonDTO>());
        }
        
    }
}

