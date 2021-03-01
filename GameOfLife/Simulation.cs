using System;

namespace GameOfLife
{
    public class Simulation
    {
        bool[,] actualState;

        public Simulation(int width, int height)
        {
            bool oneDimensionIsZero = width <= 0 || height <= 0;
            if (oneDimensionIsZero)
            {
                throw new ArgumentException("Impossible d'initialiser la grille  à zéro.");
            }

            actualState = new bool[width, height];
        }

        public bool[,] GetState()
        {
            return actualState;
        }
    }
}
