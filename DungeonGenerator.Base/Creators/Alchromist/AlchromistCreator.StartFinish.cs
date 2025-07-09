namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Protected Methods

        protected void ProcessEntrance(Dungeon dungeon)
        {
            CellLocation startCellLocation = null;
            switch (Chamber)
            {
                case Chambers.CYAN:
                    startCellLocation = new CellLocation(dungeon.Width / 2, 0);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.TOP);
                    break;
                case Chambers.RED:
                    startCellLocation = new CellLocation(dungeon.Width / 2, dungeon.Height - 1);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.BOTTOM);
                    break;
                case Chambers.MAGENTA:
                    startCellLocation = new CellLocation(dungeon.Width - 1, dungeon.Height - 1);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.BOTTOM);
                    break;
                case Chambers.GREEN:
                    startCellLocation = new CellLocation(0, 0);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.TOP);
                    break;
                case Chambers.YELLOW:
                    startCellLocation = new CellLocation(0, dungeon.Height - 1);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.BOTTOM);
                    break;
                case Chambers.BLUE:
                    startCellLocation = new CellLocation(dungeon.Width - 1, 0);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.TOP);
                    break;
            }

            dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.START);
        }

        #endregion
    }
}
