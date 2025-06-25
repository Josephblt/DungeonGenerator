using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Constructor

        public AlchromistCreator()
        {
            Seed = 0;
            Chamber = Chambers.RED;

            TiersOutterMargin = 11;
            TiersInnerMargin = 3;

            Tier1CenterSize = 9;
            Tier1MazeSize = 7;
            
            Tier2CenterSize = 7;
            Tier2MazeSize = 5;
            
            Tier3CenterSize = 5;
            Tier3MazeSize = 3;

            RoomQuantity = 10;
            RoomDistance = 5;
            RoomMinSize = 2;
            RoomMaxSize = 7;
            RoomConnections = 2;

            CorridorBias = 70;

            DeadEndQuantity = 20;
            DeadEndBias = 10;
        }

        #endregion

        #region Attributes and Properties

        public string Stats
        {
            get
            {
                return $"Chamber Color: {Chamber} \n" +
                       $"Seed: {Seed} \n" +
                       $"Size: {Size} \n" +
                       "\n" +
                       $"Tiers Inner Margin: {TiersInnerMargin} \n" +
                       $"Tiers Outter Margin: {TiersOutterMargin} \n" +
                       "\n" +
                       $"Tier 1 Room Size: {Tier1RoomSize} \n" +
                       $"Tier 1 Room Center Size: {Tier1CenterSize} \n" +
                       $"Tier 1 Maze Size: {Tier1MazeSize} \n" +
                       "\n" +
                       $"Tier 2 Room Size: {Tier2RoomSize} \n" +
                       $"Tier 2 Room Center Size: {Tier2CenterSize} \n" +
                       $"Tier 2 Maze Size: {Tier2MazeSize} \n" +
                       "\n" +
                       $"Tier 3 Room Size: {Tier3RoomSize} \n" +
                       $"Tier 3 Room Center Size: {Tier3CenterSize} \n" +
                       $"Tier 3 Maze Size: {Tier3MazeSize} \n" +
                       "\n" +
                       $"Room Quantity: {RoomQuantity} \n" +
                       $"Real Room Quantity: {RoomQuantity} \n" +
                       $"Room Distance: {RoomDistance} \n" +
                       $"Room Min Size: {RoomMinSize} \n" +
                       $"Room Max Size: {RoomMaxSize} \n" +
                       $"Room Connections: {RoomConnections} \n" +
                       "\n" +
                       $"Corridor Bias: {CorridorBias} \n" +
                       "\n" +
                       $"Dead End Quantity: {DeadEndQuantity} \n" +
                       $"Dead End Bias: {DeadEndBias}";
            }
        }

        #endregion

        #region Private Fields

        private List<Room> createdRooms = new List<Room>();
        private CellLocation tier1MazeStart = null;
        private CellLocation tier2MazeStart = null;
        private CellLocation tier3MazeStart = null;

        #endregion

        #region Private Methods

        private void InitializeCreator()
        {
            createdRooms = new List<Room>();
            tier1MazeStart = null;
            tier2MazeStart = null;
            tier3MazeStart = null;
        }

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

        public Dungeon Create()
        {
            InitializeCreator();

            var dungeon = new Dungeon(Size, Size);

            ProcessChamber(dungeon, Chamber);
            ProcessEntrance(dungeon);
            ProcessTier1Room(dungeon);
            ProcessTier2Room(dungeon);
            ProcessTier3Room(dungeon);
            ProcessRooms(dungeon);
            ProcessPaths(dungeon);
            ProcessDeadEnds(dungeon);

            return dungeon;
        }

        #endregion
    }
}
