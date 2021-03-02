using System;
using System.Linq;

namespace GameOfLife
{
    public class Simulation
    {
        private bool initialSate = true;
        private bool[,] grid;

        private bool IsInvalidDimensions(int width, int height) => width <= 0 || height <= 0;

        public Simulation(int width, int height)
        {
            if (IsInvalidDimensions(width, height))
            {
                throw new ArgumentException("Impossible d'initialiser la grille à zéro ou inférieur.");
            }

            grid = new bool[width, height];
        }

        public bool[,] GetState()
        {
            if (initialSate)
            {
                initialSate = false;
            }
            else
            {
                ProcessNewState();
            }

            return grid;
        }

        public int Width { get { return grid.GetLength(0); } }

        public int Height { get { return grid.GetLength(1); } }

        private void ProcessNewState()
        {
            var tmp = new bool[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tmp[x, y] = GetFuturCellState(x, y);
                }
            }

            grid = tmp;
        }

        private bool GetFuturCellState(int x, int y)
        {
            var currentCell = grid[x, y];
            var neighborsCells = GetNeighborCellsNumber(x, y);

            //Any live cell with fewer than two live neighbours dies, as if by loneliness.
            if (currentCell && neighborsCells < 2)
            {
                return false;
            }

            //Any live cell with more than three live neighbours dies, as if by overcrowding.
            if (currentCell && neighborsCells > 3)
            {
                return false;
            }

            //Any live cell with two or three live neighbours lives, unchanged, to the next generation.
            if (currentCell && neighborsCells == 2 || neighborsCells == 3)
            {
                return true;
            }

            //Any dead cell with exactly three live neighbours comes to life.
            if (!currentCell && neighborsCells == 3)
            {
                return true;
            }

            return false;
        }

        private int GetNeighborCellsNumber(int x, int y)
        {
            var number = 0;            var isTopLeftExist = x > 0 && y > 0;            number += isTopLeftExist && grid[x - 1, y - 1] ? 1 : 0;            var isTopCenterExist = y > 0;            number += isTopCenterExist && grid[x, y - 1] ? 1 : 0;            var isTopRightExist = x < Width - 1 && y > 0;            number += isTopRightExist && grid[x + 1, y - 1] ? 1 : 0;            var isMiddleLeftExist = x > 0;            number += isMiddleLeftExist && grid[x - 1, y] ? 1 : 0;            var isMiddleRightExist = x < Width - 1;            number += isMiddleRightExist && grid[x + 1, y] ? 1 : 0;            var isBottomLeftExist = x > 0 && y < Height - 1;            number += isBottomLeftExist && grid[x - 1, y + 1] ? 1 : 0;            var isBottomCenterExist = y < Height - 1;            number += isBottomCenterExist && grid[x, y + 1] ? 1 : 0;            var isBottomRightExist = x < Width - 1 && y < Height - 1;            number += isBottomRightExist && grid[x + 1, y + 1] ? 1 : 0;

            return number;
        }
        private bool IsPositionNegative(int x, int y) => x < 0 || y < 0;

        private bool IsPositionOversized(int x, int y) => x >= Width && y >= Height;

        public void Add(int x, int y)
        {
            if (IsPositionNegative(x, y))
            {
                throw new ArgumentException("Impossible d'initialiser la cellule à zéro ou inférieur.");
            }

            if (IsPositionOversized(x, y))
            {
                throw new ArgumentException("Impossible d'initialiser la cellule hors de la grille.");
            }

            grid[x, y] = true;
        }
    }
}
