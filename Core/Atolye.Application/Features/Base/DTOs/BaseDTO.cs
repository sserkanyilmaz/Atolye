using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Domain.Entities;

namespace Atolye.Application.Features.Base.DTOs
{
    public class BaseDTO : IDTO
    {

        public string? BaseId { get; set; }
        public string? Name { get; set; }
        public List<TeamDTO>? Teams { get; set; }

        public List<ImageDTO>? Images { get; set; }

        public List<FixtureInventoryDTO>? fixtureInventories { get; set; }


        public Guid? FixtureInformationId { get; set; }
        public FixtureInformationDTO?  FixtureInformation { get; set; }

        public List<BaseNewDTO>? BaseNews { get; set; }

        public List<ActivityLogDTO>? ActivityLogs { get; set; }
    }
}

