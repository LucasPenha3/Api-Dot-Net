using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.Infra.Contexts;
using Template.Domain.Entities;
using Template.Domain.ExpressionsQueries;
using Template.Domain.Interfaces.Queries;

namespace template.Infra.Queries
{
    public class TaskQuery : ITaskQuery
    {
        private readonly DataContext _context;

        public TaskQuery(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskTodo> GetAll(string userRefer)
        {
            var a = _context.Tasks.ToList();
            return _context.Tasks
                .AsNoTracking()
                .Where(TaskExpressionQueries.GetAll(userRefer))
                .OrderBy(x => x.Date)
                .AsEnumerable();
        }

        public IEnumerable<TaskTodo> GetAllDone(string userRefer)
        {
            return _context.Tasks
                .AsNoTracking()
                .Where(TaskExpressionQueries.GetAllDone(userRefer))
                .OrderBy(x => x.Date)
                .AsEnumerable();
        }

        public IEnumerable<TaskTodo> GetAllUndone(string userRefer)
        {
            return _context.Tasks
                .AsNoTracking()
                .Where(TaskExpressionQueries.GetAllUndone(userRefer))
                .OrderBy(x => x.Date)
                .AsEnumerable();
        }

        public IEnumerable<TaskTodo> GetByPeriod(string userRefer, DateTime date, bool done)
        {
            return _context.Tasks
                .AsNoTracking()
                .Where(TaskExpressionQueries.GetByPeriod(userRefer,date,done))
                .OrderBy(x => x.Date)
                .AsEnumerable();
        }
    }
}
