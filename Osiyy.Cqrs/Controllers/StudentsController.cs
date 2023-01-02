using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osiyy.Cqrs.CQRS.Commands;
using Osiyy.Cqrs.CQRS.Handlers;
using Osiyy.Cqrs.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Osiyy.Cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IMediator _meadiator;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _meadiator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        public StudentsController(IMediator mediator)
        {
            _meadiator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result =await  _meadiator.Send(new GetStudentByIdQuery(id));
            //var result = this.getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _meadiator.Send(command);
            return Created("", command.Name);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _meadiator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
           await _meadiator.Send(command);
            return NoContent();
        }
    }
}