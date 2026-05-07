using Projekt.Domain;
using Projekt.Data;

namespace Projekt.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser(string fullName, string email)
    {
        var user = new User(fullName, email);
        _userRepository.Add(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }
    public void DeleteUser(int userId)
    {
        var user = _userRepository.GetById(userId);
        if (user == null) 
        {
            throw new Exception("Uživatel s tímto ID neexistuje.");
        }

        _userRepository.Delete(user);
    }
}