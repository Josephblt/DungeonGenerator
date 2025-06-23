namespace DungeonGenerator.Base.Creators
{
    public partial class DefaultCreator
    {
        #region Attributes and Properties

        public int Seed { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool CreateStart { get; set; }
        public bool CreateFinish { get; set; }
        public CellLocation Start { get; set; }
        public CellLocation Finish { get; set; }

        public int RoomDensity { get; set; }
        public int RoomDistance { get; set; }
        public int RoomMinSize { get; set; }
        public int RoomMaxSize { get; set; }
        public int RoomConnections { get; set; }

        public int CorridorBias { get; set; }

        public int DeadEndBias { get; set; }

        #endregion
    }
}
