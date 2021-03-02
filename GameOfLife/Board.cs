﻿using System;
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

        internal bool GetCellState(int x, int y)
        {
            return grid[x, y];
        }

        internal int GetCellNeighborsNumber(int x, int y)
        {
            var number = 0;

            return number;
        }

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