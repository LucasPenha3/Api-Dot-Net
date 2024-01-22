
namespace Template.Domain.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        void CreateTask(Entities.TaskTodo task);
        void UpdateTask(Entities.TaskTodo task);
        Entities.TaskTodo GetById(Guid id);
    }
}
