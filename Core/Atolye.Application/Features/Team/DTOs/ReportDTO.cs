using System;
using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Team.DTOs
{
	public class ReportDTO : IDTO
	{
        public string? TeamId { get; set; }
        public string? ReportId { get; set; }
        public string? Content { get; set; }
    }
}

