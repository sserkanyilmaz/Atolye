using System;
using Atolye.Application.Features.Auth.Commands.Login;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Auth.Commands.Register
{
	public class RegisterPersonCommandRequest : IRequest<IDataResult<RegisterPersonCommandResponse>>
    {
        public string? TC { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; } 
        public string? Email { get; set; }
    }
}