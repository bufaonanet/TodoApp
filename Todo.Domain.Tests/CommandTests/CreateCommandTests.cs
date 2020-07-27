using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateCommandTests
    {
        private readonly CreateTodoCommand _invalidComand;
        private readonly CreateTodoCommand _validComand;

        public CreateCommandTests()
        {
            _invalidComand = new CreateTodoCommand("", "", DateTime.Now);
            _invalidComand.Validate();

            _validComand = new CreateTodoCommand("criando tarefa", "douglas", DateTime.Now);
            _validComand.Validate();
        }
        
        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidComand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validComand.Valid, true);
        }
    }
}
