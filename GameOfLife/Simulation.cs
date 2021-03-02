using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Simulation
    {
        private Board board;

        public int Time { get; private set; }
        public int Height { get { return board.Height; } }
        public int Width { get { return board.Width; } }

        /// <summary>
        /// Création de la surface de simulation
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Simulation(int width, int height)
        {
            board = new Board(width, height);
            Time = 0;
        }

        /// <summary>
        /// Itérateur sur les états de la simulation
        /// </summary>
        public IEnumerable<bool[,]> States
        {
            get
            {
                while (true)
                {
                    if (Time > 0)
                    {
                        ProcessNewState();
                    }

                    Time++;

                    yield return board.Grid;
                }
            }
        }

        /// <summary>
        /// Calcul le nouvel état de la simulation
        /// </summary>
        private void ProcessNewState()
        {
            var tmp = new bool[board.Width, board.Height];

            foreach (var cell in board.Cells)
            {
                tmp[cell.X, cell.Y] = ApplyRules(cell);
            }

            board.Grid = tmp;
        }

        /// <summary>
        /// Applique les règles de la simulation sur une cellule
        /// </summary>
        /// <param name="current">Cellule courante</param>
        /// <returns>Etat de la cellule</returns>
        private bool ApplyRules(Cell current)
        {
            var isAlive = board.IsAlive(current);
            var neighbors = board.GetNeighborsNumber(current);

            //Any live cell with fewer than two live neighbours dies, as if by loneliness.
            if (isAlive && neighbors < 2)
            {
                return false;
            }

            //Any live cell with more than three live neighbours dies, as if by overcrowding.
            if (isAlive && neighbors > 3)
            {
                return false;
            }

            //Any live cell with two or three live neighbours lives, unchanged, to the next generation.
            if (isAlive && neighbors == 2 || neighbors == 3)
            {
                return true;
            }

            //Any dead cell with exactly three live neighbours comes to life.
            if (!isAlive && neighbors == 3)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ajout d'une cellule vivante à cette position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Add(int x, int y)
        {
            board.Activate(new Cell(x,y));
        }
    }
}