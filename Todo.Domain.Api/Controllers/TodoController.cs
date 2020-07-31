using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    //[Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;
            return repository.GetAll(user);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;
            return repository.GetAllDone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForDoDay(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                true
            );
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                true
            );
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            return repository.GetAllUnDone(user);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForDoDay(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                false
            );
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForTomorrow(
            [FromServices] ITodoRepository repository
        )
        {
            var user = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                false
            );
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;
            //command.User = "douglas";

            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUnDone(
            [FromBody] MarkTodoAsUndoneCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            return (GenericCommandResult)handler.Handle(command);
        }

    }
}