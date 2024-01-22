using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using template.Infra.Queries;
using Template.Domain.Commands;
using Template.Domain.Commands.Task;
using Template.Domain.Entities;
using Template.Domain.Handlers.Task;
using Template.Domain.Interfaces.Handler;
using Template.Domain.Interfaces.Queries;

namespace template.Api.Controllers
{
    [ApiController]
    [Route("v1/task")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(
            [FromBody] CreateTaskCommand commad,
            [FromServices] IHandler<CreateTaskCommand> handler)
        {
            // pegando o usuário do token para criar
            commad.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            if(!commad.IsValid)
                return BadRequest();

            return Ok(handler.Handle(commad));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(
           [FromBody] UpdateTaskCommand commad,
           [FromServices] IHandler<UpdateTaskCommand> handler)
        {
            // pegando o usuário do token para atualizar
            commad.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            if (!commad.IsValid)
                return BadRequest();

            return Ok(handler.Handle(commad));
        }

        [HttpPut("Undone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult MarkDone(
           [FromBody] MarkUndoneCommand commad,
           [FromServices] IHandler<MarkUndoneCommand> handler)
        {
            if (!commad.IsValid)
                return BadRequest();

            return Ok(handler.Handle(commad));
        }

        [HttpPut("Done")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult MarkUndone(
           [FromBody] MarkDoneCommand commad,
           [FromServices] IHandler<MarkDoneCommand> handler)
        {
            if (!commad.IsValid)
                return BadRequest();

            return Ok(handler.Handle(commad));
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskTodo>))]
        public IActionResult GetAll(
            [FromServices] ITaskQuery query)
        {
            // pegando o usuário do token
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            if (string.IsNullOrEmpty(user))
                return BadRequest(new{ Error = "Usuário não autenticado"});

            return Ok(query.GetAll(user));
        }

        [HttpGet("Done")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskTodo>))]
        public IActionResult GetAllDone(
            [FromServices] ITaskQuery query)
        {
            // pegando o usuário do token
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            if (string.IsNullOrEmpty(user))
                return BadRequest(new { Error = "Usuário não autenticado" });

            return Ok(query.GetAllDone(user));
        }

        [HttpGet("Undone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskTodo>))]
        public IActionResult GetAllUndone(
            [FromServices] ITaskQuery query)
        {
            // pegando o usuário do token
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            if (string.IsNullOrEmpty(user))
                return BadRequest(new { Error = "Usuário não autenticado" });

            return Ok(query.GetAllDone(user));
        }

    }
}
