using System;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Utilities.Common;
using MediatR;

namespace Atolye.Application.Features.Persons.Commands.UpdateFamily
{
	public class UpdateFamilyCommandRequest : IRequest<IDataResult<PersonDTO>>
    {
        public string? PersonId { get; set; }
        public string? MotherName { get; set; }
        public string? FatherName { get; set; }
        public string? MothersJob { get; set; }
        public string? FathersJob { get; set; }
        public bool IsFatherAlive { get; set; }
        public bool IsMotherAlive { get; set; }
        public decimal MothersSalary { get; set; }
        public decimal FathersSalary { get; set; }
        public bool IsMotherRetired { get; set; }
        public bool IsFatherRetired { get; set; }
    }
}

