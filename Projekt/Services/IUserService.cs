using Projekt.Domain;

namespace Projekt.Services;

public interface IUserService
{
    void CreateUser(string fullName, string email);
    void DeleteUser(int userId);
    IEnumerable<User> GetAllUsers();
}