using LifeSim.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSim.Core
{
    public static class Renderer
    {
        public static void RenderWorld(World world)
        {
            Console.SetCursorPosition(0, 0);

            var plants = world.All.OfType<Plant>().Count();
            var herbs = world.All.OfType<Herbivore>().Count();
            var preds = world.All.OfType<Predator>().Count();

            Console.ResetColor();
            Console.WriteLine($"Tick: {world.Tick,-8}  Plants: {plants,-5}  Herbivores: {herbs,-5}  Predators: {preds,-5}   [Space/P] pause, [Q/Esc] quit");

            var snapshot = world.GridSnapshot();
            for (var y = 0; y < world.Height; y++)
            {
                for (var x = 0; x < world.Width; x++)
                {
                    if (snapshot.TryGetValue(new Point2(x, y), out var organism))
                    {
                        ApplyColorFor(organism);
                        Console.Write(GetGlyphFor(organism));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        } 

        // Color and Glyphs Renderer
        public static void ApplyColorFor(Organism org)
        {
            Console.ForegroundColor = org switch
            {
                Plant => ConsoleColor.Green,
                Herbivore => ConsoleColor.Yellow,
                Predator => ConsoleColor.Red,
                Animal => ConsoleColor.White
            };
        }

        public static char GetGlyphFor(Organism org)
        {
            return org switch
            {
                Plant => '♣',
                Herbivore => 'h',
                Predator => 'W'
            };


        }
    }

}
