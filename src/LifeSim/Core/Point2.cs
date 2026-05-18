namespace LifeSim.Core;

public readonly record struct Point2(int X, int Y)
{
    public override string ToString() => $"({X},{Y})";
}