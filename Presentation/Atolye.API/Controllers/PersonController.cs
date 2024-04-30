using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Atolye.Application.Features.Auth.Commands.Login;
using Atolye.Application.Utilities.Common;
using Atolye.Application.Features.Auth.Commands.Register;
using Atolye.Application.Features.Persons.Queries.GetAll;
using Atolye.Application.Features.Persons.Commands.Update;
using Atolye.Application.Features.Persons.DTOs;
using Atolye.Application.Features.Persons.Commands.Delete;
using Atolye.Application.Features.Persons.Commands.UpdateFamily;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atolye.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IDataResult<GetAllPersonsQueryResponse> response = await _mediator.Send(new GetAllPersonsQueryRequest());
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePersonCommandRequest updatePersonCommandRequest)
        {
            IDataResult<PersonDTO> response = await _mediator.Send(updatePersonCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Delete(DeletePersonCommandRequest deletePersonCommandRequest)
        {
            IDataResult<PersonDTO> response = await _mediator.Send(deletePersonCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFamily(UpdateFamilyCommandRequest updateFamilyCommandRequest)
        {
            IDataResult<PersonDTO> response = await _mediator.Send(updateFamilyCommandRequest);
            return Ok(response);
        }
    }
}

