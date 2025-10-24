using System.Text.RegularExpressions;

namespace Auth.Domain.Users;

public sealed class Email : IEquatable<Email>
{
    private static readonly Regex Pattern = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public string Value { get; }

    private Email(string value) => Value = value;

    public static Email Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Email is required.", nameof(input));

        var normalized = input.Trim().ToLowerInvariant();
        if (!Pattern.IsMatch(normalized))
            throw new ArgumentException("Invalid email format.", nameof(input));

        return new Email(normalized);
    }

    public override string ToString() => Value;
    public bool Equals(Email? other) => other is not null && Value == other.Value;
    public override bool Equals(object? obj) => obj is Email e && Equals(e);
    public override int GetHashCode() => Value.GetHashCode();
}
