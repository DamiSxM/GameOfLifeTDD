using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Board
    {
        public bool[,] grid;
        public int Width { get { return grid.GetLength(0); } }
        public int Height { get { return grid.GetLength(1); } }

        private bool IsPositionNegative(int x, int y) => x < 0 || y < 0;
        private bool IsPositionOversized(int x, int y) => x >= Width && y >= Height;
        private bool IsInvalidDimensions(int width, int height) => width <= 0 || height <= 0;

        public Board(int width, int height)
        {
            if (IsInvalidDimensions(width, height))
            {
                throw new ArgumentException("Impossible d'initialiser la grille à zéro ou inférieur.");
            }
            grid = new bool[width, height];
        }

        /// <summary>
        /// Itérateur sur toutes les cellules de la grille
        /// </summary>
        /// <returns>Tuple contenant la position</returns>
        internal IEnumerable<Tuple<int, int>> GetCells()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    yield return new Tuple<int, int>(x,y);
                }
            }
        }

        /// <summary>
        /// Retourne l'état de la cellule à cette position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        internal bool GetCellState(int x, int y)
        {
            return grid[x, y];
        }

        /// <summary>
        /// Calcul le nombre de cellules vivantes autour de la position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Nombre de cellules vivantes</returns>
        internal int GetCellNeighborsNumber(int x, int y)
        {
            var number = 0;

            // On va tester si la cellule existe,
            // si c'est le cas, on teste alors si elle est vivante
            // si c'est le cas, on ajoute un au nombre des voisins

            number += GetNeighbor(x, y, NEIGHBOR.TOP_LEFT) ? 1 : 0;
            number += GetNeighbor(x, y, NEIGHBOR.TOP_CENTER) ? 1 : 0;
            number += GetNeighbor(x, y, NEIGHBOR.TOP_RIGHT) ? 1 : 0;
            number += GetNeighbor(x, y, NEIGHBOR.MIDDLE_LEFT) ? 1 : 0;
            number += GetNeighbor(x, y, NEIGHBOR.MIDDLE_RIGHT) ? 1 : 0;
            number += GetNeighbor(x, y, NEIGHBOR.BOTTOM_LEFT) ? 1 : 0;
            number += GetNeighbor(x, y, NEIGHBOR.BOTTOM_CENTER) ? 1 : 0;
            number += GetNeighbor(x, y, NEIGHBOR.BOTTOM_RIGHT) ? 1 : 0;

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
        /// <param name="currentX"></param>
        /// <param name="currenty"></param>
        /// <param name="neighbor"></param>
        /// <returns></returns>
        private bool GetNeighbor(int currentX, int currenty, NEIGHBOR neighbor)
        {
            bool isNeighborExist = false;

            switch (neighbor)
            {
                case NEIGHBOR.TOP_LEFT:
                    isNeighborExist = currentX > 0 && currenty > 0;
                    return isNeighborExist && grid[currentX - 1, currenty - 1];

                case NEIGHBOR.TOP_CENTER:
                    isNeighborExist = currenty > 0;
                    return isNeighborExist && grid[currentX, currenty - 1];

                case NEIGHBOR.TOP_RIGHT:
                    isNeighborExist = currentX < Width - 1 && currenty > 0;
                    return isNeighborExist && grid[currentX + 1, currenty - 1];

                case NEIGHBOR.MIDDLE_LEFT:
                    isNeighborExist = currentX > 0;
                    return isNeighborExist && grid[currentX - 1, currenty];

                case NEIGHBOR.MIDDLE_RIGHT:
                    isNeighborExist = currentX < Width - 1;
                    return isNeighborExist && grid[currentX + 1, currenty];

                case NEIGHBOR.BOTTOM_LEFT:
                    isNeighborExist = currentX > 0 && currenty < Height - 1;
                    return isNeighborExist && grid[currentX - 1, currenty + 1];

                case NEIGHBOR.BOTTOM_CENTER:
                    isNeighborExist = currenty < Height - 1;
                    return isNeighborExist && grid[currentX, currenty + 1];

                case NEIGHBOR.BOTTOM_RIGHT:
                    isNeighborExist = currentX < Width - 1 && currenty < Height - 1;
                    return isNeighborExist && grid[currentX + 1, currenty + 1];
            }

            return isNeighborExist;
        }

        /// <summary>
        /// Active la cellule à cette position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal void ActivateCell(int x, int y)
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