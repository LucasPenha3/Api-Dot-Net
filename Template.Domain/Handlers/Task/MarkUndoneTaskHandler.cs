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
    public class MarkUndoneTaskHandler : Notifiable<Notification>, IHandler<MarkUndoneCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public MarkUndoneTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public ICommandResult Handle(MarkUndoneCommand command)
        {
            if (!command.IsValid)
                return new CommandResult(false, "Sua task está inválida", command.Notifications);

            var domain = _taskRepository.GetById(command.Id);
            domain.SetUndone();

            _taskRepository.UpdateTask(domain);

            return new CommandResult(true, "success", domain);
        }
    }
}
