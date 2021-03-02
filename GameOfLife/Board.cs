using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Board
    {
        public bool[,] Grid { get; set; }
        public int Width { get { return Grid.GetLength(0); } }
        public int Height { get { return Grid.GetLength(1); } }

        private bool IsPositionNegative(Cell c) => c.X < 0 || c.Y < 0;
        private bool IsPositionOversized(Cell c) => c.X >= Width && c.Y >= Height;
        private bool IsInvalidDimensions(int width, int height) => width <= 0 || height <= 0;

        public Board(int width, int height)
        {
            if (IsInvalidDimensions(width, height))
            {
                throw new ArgumentException("Impossible d'initialiser la grille à zéro ou inférieur.");
            }
            Grid = new bool[width, height];
        }

        /// <summary>
        /// Itérateur sur toutes les cellules de la grille
        /// </summary>
        /// <returns>Tuple contenant la position</returns>
        internal IEnumerable<Cell> Cells
        {
            get
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        yield return new Cell(x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Retourne l'état de la cellule à cette position
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        internal bool IsAlive(Cell current)
        {
            return Grid[current.X, current.Y];
        }

        /// <summary>
        /// Calcul le nombre de cellules vivantes autour de la position
        /// </summary>
        /// <param name="current"></param>
        /// <returns>Nombre de cellules vivantes</returns>
        internal int GetNeighborsNumber(Cell current)
        {
            var number = 0;

            // On va tester si la cellule existe,
            // si c'est le cas, on teste alors si elle est vivante
            // si c'est le cas, on ajoute un au nombre des voisins

            number += GetNeighbor(current, NEIGHBOR.TOP_LEFT) ? 1 : 0;
            number += GetNeighbor(current, NEIGHBOR.TOP_CENTER) ? 1 : 0;
            number += GetNeighbor(current, NEIGHBOR.TOP_RIGHT) ? 1 : 0;
            number += GetNeighbor(current, NEIGHBOR.MIDDLE_LEFT) ? 1 : 0;
            number += GetNeighbor(current, NEIGHBOR.MIDDLE_RIGHT) ? 1 : 0;
            number += GetNeighbor(current, NEIGHBOR.BOTTOM_LEFT) ? 1 : 0;
            number += GetNeighbor(current, NEIGHBOR.BOTTOM_CENTER) ? 1 : 0;
            number += GetNeighbor(current, NEIGHBOR.BOTTOM_RIGHT) ? 1 : 0;

            return number;
        }

        private enum NEIGHBOR
        {
            TOP_LEFT,
            TOP_CENTER,
            TOP_RIGHT,
            MIDDLE_LEFT,
            MIDDLE_RIGHT,
            BOTTOM_LEFT,
            BOTTOM_CENTER,
            BOTTOM_RIGHT,
        }

        /// <summary>
        /// Retourne la valeur du voisin si elle existe
        /// sinon retourne false
        /// </summary>
        /// <param name="current"></param>
        /// <param name="neighbor"></param>
        /// <returns></returns>
        private bool GetNeighbor(Cell current, NEIGHBOR neighbor)
        {
            bool isNeighborExist = false;

            switch (neighbor)
            {
                case NEIGHBOR.TOP_LEFT:
                    isNeighborExist = current.X > 0 && current.Y > 0;
                    return isNeighborExist && Grid[current.X - 1, current.Y - 1];

                case NEIGHBOR.TOP_CENTER:
                    isNeighborExist = current.Y > 0;
                    return isNeighborExist && Grid[current.X, current.Y - 1];

                case NEIGHBOR.TOP_RIGHT:
                    isNeighborExist = current.X < Width - 1 && current.Y > 0;
                    return isNeighborExist && Grid[current.X + 1, current.Y - 1];

                case NEIGHBOR.MIDDLE_LEFT:
                    isNeighborExist = current.X > 0;
                    return isNeighborExist && Grid[current.X - 1, current.Y];

                case NEIGHBOR.MIDDLE_RIGHT:
                    isNeighborExist = current.X < Width - 1;
                    return isNeighborExist && Grid[current.X + 1, current.Y];

                case NEIGHBOR.BOTTOM_LEFT:
                    isNeighborExist = current.X > 0 && current.Y < Height - 1;
                    return isNeighborExist && Grid[current.X - 1, current.Y + 1];

                case NEIGHBOR.BOTTOM_CENTER:
                    isNeighborExist = current.Y < Height - 1;
                    return isNeighborExist && Grid[current.X, current.Y + 1];

                case NEIGHBOR.BOTTOM_RIGHT:
                    isNeighborExist = current.X < Width - 1 && current.Y < Height - 1;
                    return isNeighborExist && Grid[current.X + 1, current.Y + 1];
            }

            return isNeighborExist;
        }

        /// <summary>
        /// Active la cellule à cette position
        /// </summary>
        /// <param name="current"></param>
        internal void Activate(Cell current)
        {
            if (IsPositionNegative(current))
            {
                throw new ArgumentException("Impossible d'initialiser la cellule à zéro ou inférieur.");
            }

            if (IsPositionOversized(current))
            {
                throw new ArgumentException("Impossible d'initialiser la cellule hors de la grille.");
            }

            Grid[current.X, current.Y] = true;
        }
    }
}