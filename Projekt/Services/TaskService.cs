namespace Projekt.Services;
using Projekt.Data;
using Projekt.Domain;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public TaskService(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public void CreateNewTask(string title, string description)
    {
        var newTask = new TeamTask(title, description);
        _taskRepository.Add(newTask);
    }

    public void ChangeTaskState(int taskId, TaskState newState)
    {
        var task = _taskRepository.GetById(taskId);
        if (task == null) throw new Exception("Úkol nenalezen.");

        switch (newState)
        {
            case TaskState.InProgress:
                task.StartProgress();
                break;
            case TaskState.Completed:
                task.MarkAsCompleted();
                break;
        }

        _taskRepository.Update(task);
    }

    public IEnumerable<TeamTask> GetTasksFiltered(int? assigneeId, bool? isCompleted)
    {
        var query = _taskRepository.GetAll().AsEnumerable();

        if (assigneeId.HasValue)
        {
            query = query.Where(t => t.AssigneeId == assigneeId.Value);
        }

        if (isCompleted.HasValue)
        {
            if (isCompleted.Value)
                query = query.Where(t => t.State == TaskState.Completed);
            else
                query = query.Where(t => t.State != TaskState.Completed);
        }

        return query.ToList();
    }
    public void AssignTaskToUser(int taskId, int userId)
    {
        var task = _taskRepository.GetById(taskId);
        if (task == null) throw new Exception("Úkol nenalezen.");

        var user = _userRepository.GetById(userId);
        if (user == null) throw new Exception("Uživatel nenalezen.");

        task.AssignToUser(user.Id);

        _taskRepository.Update(task);
    }
    public void DeleteTask(int taskId)
    {
        var task = _taskRepository.GetById(taskId);
        if (task == null) 
        {
            throw new Exception("Úkol s tímto ID neexistuje.");
        }

        _taskRepository.Delete(task);
    }
}