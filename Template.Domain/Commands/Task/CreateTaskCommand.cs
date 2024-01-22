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
    public class CreateTaskCommand : Notifiable<Notification> , ICommand
    {
        public CreateTaskCommand(){}

        public CreateTaskCommand(string title, string user)
        {
            Title = title;
            User = user;

            Validate();
        }

        public string Title { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Title.Length,6,nameof(Title),"Titulo deve ter mais de 6 caracteres")
                .IsGreaterOrEqualsThan(User.Length, 6, nameof(User), "Usuario deve ter mais de 6 caracteres"));
        }
    }
}
