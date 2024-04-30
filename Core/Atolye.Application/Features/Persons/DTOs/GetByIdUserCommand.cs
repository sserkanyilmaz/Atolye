using System;
namespace Atolye.Application.Features.Persons.DTOs
{
	public class GetByIdUserCommand
	{

        public string? Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? TeamName { get; set; }
    }
}

