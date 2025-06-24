namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Enumerators
        protected enum Chambers
        {
            CYAN,
            RED,
            MAGENTA,
            GREEN,
            YELLOW,
            BLUE
        }

        #endregion

        #region Attributes and Properties

        protected int Seed { get; set; }

        protected Chambers Chamber { get; set; }

        protected int Size { get; set; }

        protected CellLocation Start { get; set; }

        protected int Tier1RoomSize { get; set; }
        protected int Tier1MazeMargin { get; set; }
        protected int Tier1MazeSize { get; set; }
        protected int Tier2RoomSize { get; set; }
        protected int Tier2MazeMargin { get; set; }
        protected int Tier2MazeSize { get; set; }
        protected int Tier3RoomSize { get; set; }
        protected int Tier3MazeMargin { get; set; }
        protected int Tier3MazeSize { get; set; }


        protected int RoomQuantity { get; set; }
        protected int RoomDistance { get; set; }
        protected int RoomMinSize { get; set; }
        protected int RoomMaxSize { get; set; }
        protected int RoomConnections { get; set; }

        protected int CorridorBias { get; set; }

        protected int DeadEndQuantity { get; set; }
        protected int DeadEndBias { get; set; }

        #endregion
    }
}
