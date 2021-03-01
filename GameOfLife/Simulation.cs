using System;

namespace GameOfLife
{
    public class Simulation
    {
        bool[,] actualState;

        private bool IsZeroOrBelow(int value) => value <= 0;

        public Simulation(int width, int height)
        {
            if (IsZeroOrBelow(width) || IsZeroOrBelow(height))
            {
                throw new ArgumentException("Impossible d'initialiser la grille à zéro ou inférieur.");
            }

            actualState = new bool[width, height];
        }

        public bool[,] GetState()
        {
            return actualState;
        }

        public void Add(int x, int y)
        {
            if (IsZeroOrBelow(x) || IsZeroOrBelow(y))
            {
                throw new ArgumentException("Impossible d'initialiser la cellule à zéro ou inférieur.");
            }

            if (x >= actualState.GetLength(0) && y >= actualState.GetLength(1))
            {
                throw new ArgumentException("Impossible d'initialiser la cellule hors de la grille.");
            }

            actualState[x, y] = true;
        }
    }
}
