using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace template.Tests.EntityTests
{
    [TestClass]
    public class TaskTests
    {
        private readonly Template.Domain.Entities.TaskTodo _validTask = new Template.Domain.Entities.TaskTodo("Titulo Tarefa", DateTime.Now, "Lucas Penha");
        [TestMethod]
        public void Dado_uma_nova_task_done_deve_ser_false()
        {   
            Assert.AreEqual(_validTask.Done, false);
        }
    }
}
