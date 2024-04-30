
using System;
using System.Data;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class Person : BaseEntity
    {
        public string? TC { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; } // Gerçek uygulamada şifrelenmiş olmalı
        public string? Email { get; set; }
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

        public Role UserRole { get; set; }

        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}

