using System;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Persons.Commands.Delete
{
	public class DeletePersonCommandRequest : IRequest<IDataResult<PersonDTO>>
    {
        public string? Id { get; set; }
    }
}

