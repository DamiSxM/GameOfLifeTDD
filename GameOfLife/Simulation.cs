using System;
using System.Linq;

namespace GameOfLife
{
    public class Simulation
    {
        private bool initialSate = true;
        public Board board;

        public Simulation(int width, int height)
        {
            board = new Board(width, height);
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

            return board.grid;
        }

        private void ProcessNewState()
        {
            var tmp = new bool[board.Width, board.Height];

            foreach ((int x, int y) in board.GetCells())
            {
                tmp[x, y] = ApplyRules(x, y);
            }

            board.grid = tmp;
        }

        private bool ApplyRules(int x, int y)
        {
            var currentCell = board.GetCellState(x,y);
            var neighborsCells = board.GetCellNeighborsNumber(x, y);

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

        public void Add(int x, int y)
        {
            board.ActivateCell(x, y);
        }
    }
}