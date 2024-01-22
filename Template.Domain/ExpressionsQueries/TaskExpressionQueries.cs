using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.ExpressionsQueries
{
    public static class TaskExpressionQueries
    {
        public static Expression<Func<Domain.Entities.TaskTodo, bool>> GetAll(string userRefer)
        {
            return x => x.UserRefer == userRefer;
        }

        public static Expression<Func<Domain.Entities.TaskTodo, bool>> GetAllDone(string userRefer)
        {
            return x => x.UserRefer == userRefer && x.Done;
        }

        public static Expression<Func<Domain.Entities.TaskTodo, bool>> GetAllUndone(string userRefer)
        {
            return x => x.UserRefer == userRefer && !x.Done;
        }

        public static Expression<Func<Domain.Entities.TaskTodo, bool>> GetByPeriod(string userRefer, DateTime date, bool done)
        {
            return x => x.UserRefer == userRefer && x.Done == done && x.Date.Date == date.Date;
        }
    }
}
