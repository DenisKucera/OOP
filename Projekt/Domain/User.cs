namespace Projekt.Domain;
public class User : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get; private set; }

    public User(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }
}
