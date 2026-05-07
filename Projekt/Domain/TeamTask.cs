namespace Projekt.Domain;
// Třída Úkol
public class TeamTask : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TaskState State { get; private set; }
    
    public int? AssigneeId { get; private set; }
    public User? Assignee { get; private set; }

    // Konstruktor
    public TeamTask(string title, string description)
    {
        Title = title;
        Description = description;
        State = TaskState.New; 
    }

    public void AssignToUser(int userId)
    {
        AssigneeId = userId;
    }

    public void StartProgress()
    {
        if (State == TaskState.Completed)
            throw new InvalidOperationException("Nelze začít práci na již hotovém úkolu.");
        
        State = TaskState.InProgress;
    }

    public void MarkAsCompleted()
    {
        State = TaskState.Completed;
    }
}