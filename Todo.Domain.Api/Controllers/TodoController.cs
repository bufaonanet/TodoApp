using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
            [FromServices] ITodoRepository repository
        )
        {
            return repository.GetAll("douglas");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices] ITodoRepository repository
        )
        {
            return repository.GetAllDone("douglas");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForDoDay(
            [FromServices] ITodoRepository repository
        )
        {
            return repository.GetByPeriod(
                "douglas",
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
            return repository.GetByPeriod(
                "douglas",
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
            return repository.GetAllUnDone("douglas");
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForDoDay(
            [FromServices] ITodoRepository repository
        )
        {
            return repository.GetByPeriod(
                "douglas",
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
            return repository.GetByPeriod(
                "douglas",
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
            command.User = "douglas";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = "douglas";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = "douglas";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUnDone(
            [FromBody] MarkTodoAsUndoneCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = "douglas";
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}