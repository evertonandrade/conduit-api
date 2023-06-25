using System.Text.RegularExpressions;

namespace Conduit.Api.Entities.Users;

public readonly record struct Email
{
    private readonly string _value;

    private static readonly Regex EmailRegex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

    private Email(string value) => _value = value;

    public static implicit operator Email(string value) => Parse(value);
    public static implicit operator string(Email email) => email.ToString();

    public static Email Parse(string value) =>
        TryParse(value, out var result)
            ? result
            : throw new ArgumentException($"{value} is not a valid email address");

    private static bool TryParse(string value, out Email result)
    {
        if (IsValid(value))
        {
            result = new(value);
            return true;
        }

        result = null!;
        return false;
    }

    private static bool IsValid(string value) => EmailRegex.IsMatch(value);

    public override readonly string ToString() => _value;
}
