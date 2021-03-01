using System;

namespace GameOfLife
{
    public class Simulation
    {
        public Simulation(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Impossible d'initialiser la grille  à zéro.");
            }

        }
    }
}
