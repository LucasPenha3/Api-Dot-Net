using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.Tests.Repositories;
using Template.Domain.Commands;
using Template.Domain.Commands.Task;
using Template.Domain.Handlers.Task;

namespace template.Tests.HandlerTests
{
    [TestClass]
    public class CreateTaskHandlerTests
    {
        private readonly CreateTaskCommand _validCommand = new CreateTaskCommand("Titulo da tarefa", "Lucas Penha");
        private readonly CreateTaskCommand _invalidCommand = new CreateTaskCommand("", "");
        private readonly CreateTaskHandler _handler = new CreateTaskHandler(new TaskRepositoryFake());

        [TestMethod]
        public void Dado_um_commando_invalido_deve_interromper()
        {
            var result = (CommandResult) _handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Dado_um_commando_valido_deve_executar_o_create()
        {
            var result = (CommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}
