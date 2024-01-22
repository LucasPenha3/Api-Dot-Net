using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.Infra.Contexts;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repositories;

namespace template.Infra.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateTask(TaskTodo task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public TaskTodo GetById(Guid id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateTask(TaskTodo task)
        {
            _context.Update(task).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
