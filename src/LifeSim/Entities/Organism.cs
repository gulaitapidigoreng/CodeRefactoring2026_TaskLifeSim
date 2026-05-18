using LifeSim.Core;
using System;

namespace LifeSim.Entities;

public abstract class Organism
{
    protected Organism(World world, Point2 pos, Gender? gender = null)
    {
        World = world;
        Pos = world.Wrap(pos);
        Gender = gender ?? PickGender();
    }

    public World World { get; }
    public Point2 Pos { get; set; }
    public bool IsAlive { get; set; } = true;
    public int Age { get; private set; }
    public virtual ConsoleColor? Color => null;

    public void ApplyColor()
    {
        if (Color.HasValue)
        {
            Console.ForegroundColor = Color.Value;
        }
    }

    public Gender Gender { get; }
    public virtual void Tick() => Age++;
    private static Gender PickGender() => RandomUtils.Chance(0.5) ? Gender.Female : Gender.Male;
}