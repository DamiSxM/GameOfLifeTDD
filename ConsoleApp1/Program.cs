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

            //Act
            sim.Add(0, 2);
            sim.Add(1, 2);
            sim.Add(2, 2);
            sim.Add(2, 1);
            sim.Add(1, 0);

            foreach (var state in sim.States)
            {
                for (int y = 0; y < sim.board.Height; y++)
                {
                    string toto = "";
                    for (int x = 0; x < sim.board.Width; x++)
                    {
                        if (state[x, y])
                        {
                            toto += "■ ";
                        }
                        else
                        {
                            toto += "  ";
                        }
                    }
                    Console.WriteLine(toto);
                }
                Thread.Sleep(250);
                Console.Clear();
            }
        }
    }
}
