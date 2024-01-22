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
    
    public class MarkDoneTaskHandler : Notifiable<Notification>, IHandler<MarkDoneCommand>
    {

        private readonly ITaskRepository _taskRepository;

        public MarkDoneTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public ICommandResult Handle(MarkDoneCommand command)
        {
            if(!command.IsValid)
                return new CommandResult(false, "Sua task está inválida", command.Notifications);

            var domain = _taskRepository.GetById(command.Id);
            domain.SetDone();

            _taskRepository.UpdateTask(domain);

            return new CommandResult(true, "success", domain);

        }
    }
}
