namespace DungeonGenerator.Base
{
    public class CellLocation
    {
        #region Constructor

        public CellLocation(int x, int y)
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
