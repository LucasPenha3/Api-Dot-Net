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
    public class UpdateTaskHandler : Notifiable<Notification>, IHandler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _repository;

        public UpdateTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(UpdateTaskCommand command)
        {
            if (!command.IsValid)
                return new CommandResult(false, "Sua task está inválida", command.Notifications);

            var task = ConvertCommandToTask(command);

            _repository.UpdateTask(task);

            return new CommandResult(true, "Atualizado com sucesso", task);

        }

        private Entities.TaskTodo ConvertCommandToTask(UpdateTaskCommand command)
        {
            var task = _repository.GetById(command.Id);
            task.UpdateTitle(command.Title);

            return task;
        }
    }
}
