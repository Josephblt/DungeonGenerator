using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Private Methods
        
        private void ProcessChamber(Dungeon dungeon, Chambers chamber)
        {
            for (int x = 0; x < dungeon.Width; x++)
                for (int y = 0; y < dungeon.Height; y++)
                    switch (chamber)
                    {
                        case Chambers.CYAN:
                            dungeon.SetFlag(new CellLocation(x, y), Dungeon.DungeonFlags.CYAN);
                            break;
                        case Chambers.RED:
                            dungeon.SetFlag(new CellLocation(x, y), Dungeon.DungeonFlags.RED);
                            break;
                        case Chambers.MAGENTA:
                            dungeon.SetFlag(new CellLocation(x, y), Dungeon.DungeonFlags.MAGENTA);
                            break;
                        case Chambers.GREEN:
                            dungeon.SetFlag(new CellLocation(x, y), Dungeon.DungeonFlags.GREEN);
                            break;
                        case Chambers.YELLOW:
                            dungeon.SetFlag(new CellLocation(x, y), Dungeon.DungeonFlags.YELLOW);
                            break;
                        case Chambers.BLUE:
                            dungeon.SetFlag(new CellLocation(x, y), Dungeon.DungeonFlags.BLUE);
                            break;
                    }
        }

        #endregion
    }
}
