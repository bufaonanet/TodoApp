using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidComand;
        private readonly CreateTodoCommand _validComand;
        private readonly TodoHandler _handler;
        private GenericCommandResult _result;

        public CreateTodoHandlerTests()
        {
            _invalidComand = new CreateTodoCommand("", "", DateTime.Now);
            _validComand = new CreateTodoCommand("criando tarefa", "douglas", DateTime.Now);
            _handler = new TodoHandler(new FakeTodoRepository());
            _result = new GenericCommandResult();
        }

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_execução()
        {            
            _result = (GenericCommandResult) _handler.Handle(_invalidComand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_interromper_execução()
        {            
            _result = (GenericCommandResult) _handler.Handle(_validComand);
            Assert.AreEqual(_result.Success, true);
        }

    }
}