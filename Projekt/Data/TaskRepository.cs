using Microsoft.EntityFrameworkCore;
using Projekt.Domain;

namespace Projekt.Data;
public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public void Add(TeamTask task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void Update(TeamTask task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public TeamTask? GetById(int id)
    {
        return _context.Tasks.FirstOrDefault(t => t.Id == id);
    }

    public IEnumerable<TeamTask> GetAll()
    {
        return _context.Tasks.Include(t => t.Assignee).ToList();
    }
    public void Delete(TeamTask task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }
}