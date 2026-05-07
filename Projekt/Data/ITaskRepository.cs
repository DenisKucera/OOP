using Projekt.Domain;
namespace Projekt.Data;
public interface ITaskRepository
{
    void Add(TeamTask task);
    void Update(TeamTask task);
    void Delete(TeamTask task);
    TeamTask? GetById(int id);
    IEnumerable<TeamTask> GetAll();

}

