namespace DungeonGenerator.Base
{
    public class Cell
    {
        #region Constructor

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Attributes and Properties

        public int X { get; private set; }
        public int Y { get; private set; }

        #endregion
    }
}
