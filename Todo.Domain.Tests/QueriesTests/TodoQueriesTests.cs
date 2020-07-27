using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private IList<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "Usuário", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "douglas", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "Usuário", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "douglas", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "Usuário", DateTime.Now));

        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_douglas()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("douglas"));
            Assert.AreEqual(result.Count(), 2);
        }

    }
}