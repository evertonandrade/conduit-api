namespace Conduit.Utils.Functional;

public readonly struct Unit : IEquatable<Unit>
{
    public static readonly Unit Value = new();

    public override bool Equals(object? obj)
    {
        return obj is Unit;
    }

    public bool Equals(Unit other)
    {
        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString()
    {
        return "()";
    }

    public static bool operator ==(Unit left, Unit right)
    {
        return true;
    }

    public static bool operator !=(Unit left, Unit right)
    {
        return false;
    }
}
