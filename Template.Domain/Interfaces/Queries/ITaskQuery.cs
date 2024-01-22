using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces.Queries
{
    public interface ITaskQuery
    {
        IEnumerable<TaskTodo> GetAll(string userRefer);

        IEnumerable<TaskTodo> GetAllDone(string userRefer);

        IEnumerable<TaskTodo> GetAllUndone(string userRefer);

        IEnumerable<TaskTodo> GetByPeriod(string userRefer, DateTime date, bool done);
    }
}
