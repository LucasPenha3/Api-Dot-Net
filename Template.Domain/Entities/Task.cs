using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class TaskTodo : Entity
    {
        public TaskTodo(string title, DateTime date, string userRefer)
        {
            Title = title;
            Date = date;
            UserRefer = userRefer;
            Done = false;
            DateDone = null;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime? DateDone { get; private set; }
        public string UserRefer { get; private set; }

        public void SetDone()
        {
            Done = true;
            DateDone = DateTime.Now.Date;
        }

        public void SetUndone()
        {
            Done = false;
            DateDone = null;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}
