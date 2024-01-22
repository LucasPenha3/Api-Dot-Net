using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Commands;
using Template.Domain.Commands.Task;
using Template.Domain.Interfaces.Commands;
using Template.Domain.Interfaces.Handler;
using Template.Domain.Interfaces.Repositories;

namespace Template.Domain.Handlers.Task
{
    public class CreateTaskHandler : Notifiable<Notification>, IHandler<CreateTaskCommand>
    {
        private readonly ITaskRepository _repository;

        public CreateTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTaskCommand command)
        {
            if (!command.IsValid)
                return new CommandResult(false, "Sua task está inválida", command.Notifications);

            var task = ConvertCommandToTask(command);

            _repository.CreateTask(task);

            return new CommandResult(true, "Criado com sucesso", task);

        }

        private Entities.TaskTodo ConvertCommandToTask(CreateTaskCommand command)
        {
            return new Entities.TaskTodo(command.Title, DateTime.Now, command.User);
            
        }
    }
}
