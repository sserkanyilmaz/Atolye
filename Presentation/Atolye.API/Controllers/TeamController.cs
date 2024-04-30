using Atolye.Application.Features.Team.Commands.Add;
using Atolye.Application.Features.Team.Commands.AddInventoryToTeam;
using Atolye.Application.Features.Team.Commands.AddMemberToTeam;
using Atolye.Application.Features.Team.Commands.AddProjectToTeam;
using Atolye.Application.Features.Team.Commands.AddReportToTeam;
using Atolye.Application.Features.Team.Commands.Delete;
using Atolye.Application.Features.Team.Commands.DeleteConsumableInventory;
using Atolye.Application.Features.Team.Commands.DeleteMember;
using Atolye.Application.Features.Team.Commands.DeleteProject;
using Atolye.Application.Features.Team.Commands.DeleteReport;
using Atolye.Application.Features.Team.Commands.Update;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Features.Team.Queries.GetAll;
using Atolye.Application.Features.Team.Queries.GetById;
using Atolye.Application.Utilities.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atolye.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IDataResult<GetAllTeamsQueryResponse> response = await _mediator.Send(new GetAllTeamsQueryRequest());
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> GetById(GetByIdTeamQueryRequest getByIdTeamQueryRequest)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(getByIdTeamQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(AddTeamCommandRequest addTeamCommandRequest)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(addTeamCommandRequest);
            return Ok(response);
        }
        [HttpPut] 
        public async Task<IActionResult> AddProjectToTeam(AddProjectToTeamRequest addProjectToTeamRequest)
        {
            IDataResult<ProjectDTO> response = await _mediator.Send(addProjectToTeamRequest);
            return Ok(response);
        }
        
        [HttpPut] 
        public async Task<IActionResult> AddConsumableInventoryToTeam(AddConsumableInventoryTeamCommandRequest addConsumableInventoryTeamCommandRequest)
        {
            IDataResult<ConsumableInventoryDTO> response = await _mediator.Send(addConsumableInventoryTeamCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AddReportToTeam(AddReportToTeamCommandRequest addReportToTeamRequest)
        {
            IDataResult<ReportDTO> response = await _mediator.Send(addReportToTeamRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AddMemberToTeam(AddMemberToTeamCommandRequest  addMemberToTeamCommandRequest)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(addMemberToTeamCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTeamName(UpdateTeamCommandRequest updateTeamCommandRequest)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(updateTeamCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteTeam(DeleteTeamCommandRequest deleteTeamCommandRequest)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(deleteTeamCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> DeleteConsumableInventoryFromTeam(DeleteConsumableInventoryCommandRequest deleteConsumableInventoryCommandRequest)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(deleteConsumableInventoryCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> DeleteMemberFromTeam(DeleteMemberCommandRequest deleteMemberCommandRequest)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(deleteMemberCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> DeleteProjectFromTeam(DeleteProjectCommandRequest request)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> DeleteReportFromTeam(DeleteReportCommandRequest request)
        {
            IDataResult<TeamDTO> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

