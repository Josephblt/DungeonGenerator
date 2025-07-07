namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Enumerators

        public enum Chambers
        {
            CYAN = 0,
            RED = 1,
            MAGENTA = 2,
            GREEN = 4,
            YELLOW = 8,
            BLUE = 16
        }

        #endregion

        #region Attributes and Properties

        public int Seed { get; set; }

        public Chambers Chamber { get; set; }

        public int Size
        {
            get
            {
                return (TiersOutterMargin * 4) +
                       (Tier1CenterSize) + (2 * Tier1MazeSize) + (2 * TiersInnerMargin) +
                       (Tier2CenterSize) + (2 * Tier2MazeSize) + (2 * TiersInnerMargin) +
                       (Tier3CenterSize) + (2 * Tier3MazeSize) + (2 * TiersInnerMargin);
            }
        }
        
        public int TiersOutterMargin { get; set; }
        public int TiersInnerMargin { get; set; }

        public int Tier1CenterSize { get; set; }
        public int Tier1MazeSize { get; set; }
        public int Tier1RoomSize
        { 
            get 
            {
                return Tier1CenterSize + (2 * Tier1MazeSize) + (2 * TiersInnerMargin);
            }
        }
        
        public int Tier2CenterSize { get; set; }
        public int Tier2MazeSize { get; set; }
        public int Tier2RoomSize
        {
            get
            {
                return Tier2CenterSize + (2 * Tier2MazeSize) + (2 * TiersInnerMargin);
            }
        }


        public int Tier3CenterSize { get; set; }
        public int Tier3MazeSize { get; set; }
        public int Tier3RoomSize
        {
            get
            {
                return Tier3CenterSize + (2 * Tier3MazeSize) + (2 * TiersInnerMargin);
            }
        }

        public int RoomQuantity { get; set; }
        public int RoomDistance { get; set; }
        public int RoomMinSize { get; set; }
        public int RoomMaxSize { get; set; }
        public int RoomConnections { get; set; }

        public int CorridorBias { get; set; }

        public int DeadEndBias { get; set; }
        public int DeadEndQuantity { get; set; }

        #endregion
    }
}
