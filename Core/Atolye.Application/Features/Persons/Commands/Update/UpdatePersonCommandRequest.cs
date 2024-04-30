using System;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Persons.Commands.Update
{
	public class UpdatePersonCommandRequest : IRequest<IDataResult<PersonDTO>>
    {
        public string Id { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
    }
}

