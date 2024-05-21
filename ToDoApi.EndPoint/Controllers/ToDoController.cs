using Application.Dtos;
using Application.Dtos.Todo;
using Application.ToDo.Commands;
using Application.ToDo.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.EndPoint.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator mediator;

        public ToDoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public IActionResult GetAll([FromBody] PageDto PageDto)
        {
            GetToDooQuery x = new GetToDooQuery(PageDto);
            var res = mediator.Send(x);
            return Ok(res);
        }

        [Route("CreateToDo")]
        [HttpPost]
        public IActionResult Post(AddTodoDto AddTodoDto)
        {
            CreateToDooCommand x = new CreateToDooCommand(AddTodoDto);
            var res = mediator.Send(x);
            string url = "";
            return Created(url, res);
        }
        [HttpPut]
        public IActionResult Put([FromBody] EditToDoDto EditToDoDto)
        {
            EditToDooCommand x = new EditToDooCommand(EditToDoDto);
            var res = mediator.Send(x);
            return Ok();
        }

    }
}
