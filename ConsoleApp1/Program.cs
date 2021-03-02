using System;
using System.Linq;
using System.Threading;
using GameOfLife;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sim = new Simulation(20, 20);

            // - o -
            // - - o
            // o o o
            sim.Add(0, 2);
            sim.Add(1, 2);
            sim.Add(2, 2);
            sim.Add(2, 1);
            sim.Add(1, 0);

            foreach (var state in sim.States)
            {
                Console.WriteLine("Temps: " + sim.Time);

                for (int y = 0; y < sim.Height; y++)
                {
                    string line = "";
                    for (int x = 0; x < sim.Width; x++)
                    {
                        line += (state[x, y])
                            ? "■ "
                            : "  ";
                    }
                    Console.WriteLine(line);
                }
                Thread.Sleep(250);
                Console.Clear();
            }
        }
    }
}
