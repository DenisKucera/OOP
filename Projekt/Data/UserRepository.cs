using Projekt.Domain;

namespace Projekt.Data;

public class UserRepository : IUserRepository
{
    private readonly TaskDbContext _context;

    public UserRepository(TaskDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? GetById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }
    public void Delete(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}