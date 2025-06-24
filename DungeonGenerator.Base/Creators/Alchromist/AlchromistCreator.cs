using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Constructor

        private AlchromistCreator()
        {
            Seed = 12072017;
            Chamber = Chambers.GREEN;

            Size = 95;

            Tier1RoomSize = 35;
            Tier1MazeMargin = 2;
            Tier1MazeSize = 7;
            
            Tier2RoomSize = 25;
            Tier2MazeMargin = 2;
            Tier2MazeSize = 5;
            
            Tier3RoomSize = 15;
            Tier3MazeMargin = 2;
            Tier3MazeSize = 3;

            RoomQuantity = 10;
            RoomDistance = 5;
            RoomMinSize = 2;
            RoomMaxSize = 5;
            RoomConnections = 1;

            CorridorBias = 70;

            DeadEndQuantity = 20;
            DeadEndBias = 25;

            InitializeRoomCreator();
            InitializePathCreator();
            InitializeDeadEndCreator();
        }

        #endregion

        #region Private Fields

        private List<Room> createdRooms = new List<Room>();
        private CellLocation tier1MazeStart = null;
        private CellLocation tier2MazeStart = null;
        private CellLocation tier3MazeStart = null;

        #endregion

        #region Private Methods

        private CellLocation FindTopCell(CellLocation cellLocation)
        {
            if (cellLocation.Y - 1 >= 0)
                return new CellLocation(cellLocation.X, cellLocation.Y - 1);
            else
                return null;
        }

        private CellLocation FindBottomCell(CellLocation cellLocation)
        {
            if (cellLocation.Y + 1 < Size)
                return new CellLocation(cellLocation.X, cellLocation.Y + 1);
            else
                return null;
        }

        private CellLocation FindLeftCell(CellLocation cellLocation)
        {
            if (cellLocation.X - 1 >= 0)
                return new CellLocation(cellLocation.X - 1, cellLocation.Y);
            else
                return null;
        }

        private CellLocation FindRightCell(CellLocation cellLocation)
        {
            if (cellLocation.X + 1 < Size)
                return new CellLocation(cellLocation.X + 1, cellLocation.Y);
            else
                return null;
        }

        #endregion

        #region Public Methods

        public static Dungeon Create()
        {
            var creator = new AlchromistCreator();
            var dungeon = new Dungeon(creator.Size, creator.Size);

            creator.ProcessChamber(dungeon, creator.Chamber);
            creator.ProcessEntrance(dungeon);
            creator.ProcessTier1Room(dungeon);
            creator.ProcessTier2Room(dungeon);
            creator.ProcessTier3Room(dungeon);
            creator.ProcessRoom(dungeon);
            creator.ProcessPath(dungeon);
            creator.ProcessDeadEnd(dungeon);

            return dungeon;
        }

        #endregion
    }
}
