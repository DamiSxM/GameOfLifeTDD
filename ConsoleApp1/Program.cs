using System;
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

            for (int i = 0; i < 100; i++)
            {
                var state = sim.GetState();

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
