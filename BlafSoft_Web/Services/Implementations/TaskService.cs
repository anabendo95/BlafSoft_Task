using BlafSoft_Web.Models;
using BlafSoft_Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Linq;

namespace BlafSoft_Web.Services.Implementations
{
    public class TaskService : InterfaceTaskService
    {
        string path = $"{Environment.CurrentDirectory}\\jsonDatabaseForTasks.json";

        public void Create(List<TaskT> _tasks, TaskT task)
        {
            task.Id = _tasks.Count();
            _tasks.Add(task);
            

            using (StreamWriter writer = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(_tasks);
                writer.Write(output);
            }
        }

        public void Delete(List<TaskT> _tasks, int id)
        {
            TaskT toremove = _tasks.FirstOrDefault(x => x.Id == id);
            _tasks.Remove(toremove);

            using (StreamWriter writer = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(_tasks);
                writer.Write(output);
            }
        }

        public List<TaskT> GetAll()
        {
            List<TaskT> tasks = new List<TaskT>();
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                tasks = JsonConvert.DeserializeObject<List<TaskT>>(json);
            }
            return tasks;
        }

        public TaskT GetById(int id)
        {
            return GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(int id, TaskT task, List<TaskT> _tasks)
        {
            TaskT toremove = _tasks.FirstOrDefault(x => x.Id == id);
            _tasks.Remove(toremove);
            _tasks.Add(task);

            using (StreamWriter writer = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(_tasks);
                writer.Write(output);
            }

        }
    }
}
