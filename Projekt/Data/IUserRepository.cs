using Projekt.Domain;
namespace Projekt.Data;

public interface IUserRepository
{
    void Add(User user);
    void Delete(User user);
    User? GetById(int id);
    IEnumerable<User> GetAll();
}