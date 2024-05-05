using Atolye.Application.Features.Persons.DTOs;
using Atolye.Domain.Entities;

namespace Atolye.Application.Features.Base.DTOs
{
    public class ActivityLogDTO
    {
        public string? ActivityLogId { get; set; }
        public string PersonId { get; set; }

        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }
}