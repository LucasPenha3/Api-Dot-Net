using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interfaces.Repositories;

namespace template.Tests.Repositories
{
    class TaskRepositoryFake : ITaskRepository
    {
        public void CreateTask(Template.Domain.Entities.TaskTodo task)
        {
            
        }

        public Template.Domain.Entities.TaskTodo GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Template.Domain.Entities.TaskTodo task)
        {
            
        }
    }
}
