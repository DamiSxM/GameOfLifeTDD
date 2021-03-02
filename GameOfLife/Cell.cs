namespace GameOfLife
{
    internal class Cell
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}