using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interfaces.Commands;

namespace Template.Domain.Commands.Task
{
    public class MarkUndoneCommand : Notifiable<Notification>, ICommand
    {
        public MarkUndoneCommand(){}

        public MarkUndoneCommand(Guid id)
        {
            Id = id;
            Validate();
        }

        public Guid Id { get; set; }

       
        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNull(Id,nameof(Id),"Id da tarefa não pode ser nulo"));
        }
        
    }
}
