using System;
using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Persons.DTOs
{
	public class PersonDTO: IDTO
	{
        public string? Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
    }
}

