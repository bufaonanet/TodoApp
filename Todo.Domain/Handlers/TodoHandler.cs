using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private static ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validate
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, tarefa inválida", command.Notifications);
            }

            //Gerar o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //Salvar no banco
            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa Criada", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validate
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, tarefa inválida", command.Notifications);
            }

            //Recuperar um TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            //Salvar no banco
            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa Atualizada", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            //Fail Fast Validate
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, tarefa inválida", command.Notifications);
            }

            //Recuperar um TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            //Alterando Status da tarefa
            todo.MarkAsDone();

            //Salvar no banco
            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa Atualizada", todo); 
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            //Fail Fast Validate
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, tarefa inválida", command.Notifications);
            }

            //Recuperar um TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            //Alterando Status da tarefa
            todo.MarkAsUndone();

            //Salvar no banco
            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa Atualizada", todo); ;
        }
    }
}