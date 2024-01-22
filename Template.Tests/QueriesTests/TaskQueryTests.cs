using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.ExpressionsQueries;

namespace template.Tests.QueriesTests
{
    [TestClass]
    public class TaskQueryTests
    {
        private List<TaskTodo> _tasks = new List<TaskTodo>();

        public TaskQueryTests()
        {
            _tasks = new List<TaskTodo>();
            _tasks.Add(new TaskTodo("task 1", DateTime.Now, "Lucas"));
            _tasks.Add(new TaskTodo("task 2", DateTime.Now, "Pedro"));
            _tasks.Add(new TaskTodo("task 3", DateTime.Now, "Lucas"));
            _tasks.Add(new TaskTodo("task 4", DateTime.Now, "Paulo"));
            _tasks.Add(new TaskTodo("task 5", DateTime.Now, "Mateus"));

            _tasks[2].SetDone();
            _tasks[3].SetDone();
        }

        [TestMethod]
        public void Deve_retornar_tasks_apenas_do_userRefer()
        {
            var result = _tasks.AsQueryable().Where(TaskExpressionQueries.GetAll("Lucas"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_tasks_apenas_do_userRefer_que_estejam_done()
        {
            var result = _tasks.AsQueryable().Where(TaskExpressionQueries.GetAllDone("Lucas"));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_tasks_apenas_do_userRefer_que_estejam_done_na_data_passada()
        {
            var result = _tasks.AsQueryable().Where(TaskExpressionQueries.GetByPeriod("Lucas", DateTime.Now, true));
            Assert.AreEqual(1, result.Count());
        }
    }
}
