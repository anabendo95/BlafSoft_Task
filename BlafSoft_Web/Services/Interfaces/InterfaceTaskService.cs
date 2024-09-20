using BlafSoft_Web.Models;

namespace BlafSoft_Web.Services.Interfaces
{
    public interface InterfaceTaskService
    {
        List<TaskT> GetAll();
        TaskT GetById(int id);
        void Create(List<TaskT> _tasks, TaskT task);
        void Update(int id, TaskT task, List<TaskT> _tasks);
        void Delete(List<TaskT> _tasks, int id);
    }
}
