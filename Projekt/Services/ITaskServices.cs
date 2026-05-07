// Rozhraní pro aplikační logiku
namespace Projekt.Services;
using Projekt.Domain;
public interface ITaskService
{
    void CreateNewTask(string title, string description);
    void ChangeTaskState(int taskId, TaskState newState);
    void AssignTaskToUser(int taskId, int userId);
    void DeleteTask(int taskId);
    IEnumerable<TeamTask> GetTasksFiltered(int? assigneeId, bool? isCompleted);
}