using System.Collections.ObjectModel;

namespace DungeonGenerator.Base.Creators
{
    public partial class DefaultCreator
    {
        #region Constructor

        private DefaultCreator()
        {
            Seed = 0;
            Width = 100;
            Height = 100;
            CreateStart = true;
            CreateFinish = true;
            RoomDensity = 100;
            RoomDistance = 5;
            RoomMinSize = 2;
            RoomMaxSize = 4;
            RoomConnections = 1;
            CorridorBias = 75;
            DeadEndBias = 25;

            InitializeRoomCreator();
            InitializePathCreator();
            InitializeDeadEndCreator();
            InitializeStartFinishCreator();
        }

        #endregion

        #region Private Methods

        private Cell FindTopCell(Cell cellLocation)
        {
            if (cellLocation.Y - 1 >= 0)
                return new Cell(cellLocation.X, cellLocation.Y - 1);
            else
                return null;
        }

        private Cell FindBottomCell(Cell cellLocation)
        {
            if (cellLocation.Y + 1 < Height)
                return new Cell(cellLocation.X, cellLocation.Y + 1);
            else
                return null;
        }

        private Cell FindLeftCell(Cell cellLocation)
        {
            if (cellLocation.X - 1 >= 0)
                return new Cell(cellLocation.X - 1, cellLocation.Y);
            else
                return null;
        }

        private Cell FindRightCell(Cell cellLocation)
        {
            if (cellLocation.X + 1 < Width)
                return new Cell(cellLocation.X + 1, cellLocation.Y);
            else
                return null;
        }

        #endregion

        #region Public Methods

        public static Dungeon Create()
        {
            var creator = new DefaultCreator();
            var dungeon = new Dungeon(creator.Width, creator.Height);
            
            creator.ProcessStartFinish(dungeon);
            creator.ProcessRoom(dungeon);
            creator.ProcessPath(dungeon);
            creator.ProcessDeadEnd(dungeon);

            return dungeon;
        }

        #endregion
    }
}
