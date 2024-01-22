using Template.Domain.Commands.Task;

namespace template.Tests.CommandTests;

[TestClass]
public class CreateTaskCommandTests
{
    private readonly CreateTaskCommand _validCommand = new CreateTaskCommand("Titulo da tarefa", "Lucas Penha");
    private readonly CreateTaskCommand _invalidCommand = new CreateTaskCommand("", "");

    [TestMethod]
    public void Enviado_command_invalido()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void Enviado_command_valido()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}