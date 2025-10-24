using Auth.Domain.Abstractions;

namespace Auth.Domain.Users;

public sealed class User : Entity
{
    public Email Email { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private User() : base() { } // para ORM futuramente

    private User(Email email, PasswordHash passwordHash, Role role) : base()
    {
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        CreatedAt = DateTime.UtcNow;
    }

    public static User Create(Email email, PasswordHash passwordHash, Role role = Role.User)
        => new(email, passwordHash, role);

    public void ChangePassword(PasswordHash newHash)
    {
        PasswordHash = newHash;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeRole(Role role)
    {
        Role = role;
        UpdatedAt = DateTime.UtcNow;
    }
}
