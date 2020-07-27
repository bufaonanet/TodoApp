using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntitiesTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo;

        public TodoItemTests()
        {
            _validTodo = new TodoItem("nova tarefa", "douglas", DateTime.Now);
        }

        [TestMethod]
        public void test()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }

    }
}