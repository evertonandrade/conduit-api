using System.Text.RegularExpressions;

namespace Conduit.Api.Entities.Users;

public readonly record struct UserName
{
    private readonly string _value;

    private static readonly Regex UserNameRegex =
        new("^[a-z\\d](?:[a-z\\d]|-(?=[a-z\\d])){0,38}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private UserName(string value) => _value = value;

    public static implicit operator UserName(string value) => Parse(value);
    public static implicit operator string(UserName userName) => userName.ToString();

    public static UserName Parse(string value) =>
        TryParse(value, out var result)
            ? result
            : throw new ArgumentException($"{value} is not a valid username");

    private static bool TryParse(string value, out UserName result)
    {
        if (IsValid(value))
        {
            result = new(value);
            return true;
        }

        result = null!;
        return false;
    }

    private static bool IsValid(string value) => UserNameRegex.IsMatch(value);

    public override readonly string ToString() => _value;
}