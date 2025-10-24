namespace Auth.Domain.Users;

public sealed class PasswordHash : IEquatable<PasswordHash>
{
    public string Value { get; }

    private PasswordHash(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Password hash is required.", nameof(value));

        Value = value;
    }

    public static PasswordHash From(string hash) => new(hash);

    public override string ToString() => Value;
    public bool Equals(PasswordHash? other) => other is not null && Value == other.Value;
    public override bool Equals(object? obj) => obj is PasswordHash p && Equals(p);
    public override int GetHashCode() => Value.GetHashCode();
}
