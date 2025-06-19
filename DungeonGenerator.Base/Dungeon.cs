using System;

namespace DungeonGenerator.Base
{
    public class Dungeon
    {
        #region Enum

        [Flags]
        public enum DungeonFlags
        {
            NONE = 0,

            UNUSED = 1,
            PATH = 2,
            ROOM = 4,

            LEFT = 8,
            TOP = 16,
            RIGHT = 32,
            BOTTOM = 64,

            START = 128,
            FINISH = 256,
            DEADEND = 512,

            TIER1ROOM = 1024,
            TIER2ROOM = 2048,
            TIER3ROOM = 4096,

            RED = 8192,
            CYAN = 16384,
            GREEN = 32768,
            MAGENTA = 65536,
            BLUE = 131072,
            YELLOW = 262144
        }

        #endregion

        #region Constructor

        public Dungeon(int width, int height)
        {
            Width = width;
            Height = height;

            Initialize();
        }

        #endregion

        #region Attributes and Properties

        public int Width { get; }
        public int Height { get; }

        public DungeonFlags this[int x, int y]
        {
            get
            {
                if ((x < 0) || (x >= Width) || (y < 0) || (y >= Height))
                    return DungeonFlags.NONE;

                return _grid[x, y];
            }
        }
        public DungeonFlags this[CellLocation cellLocation]
        {
            get
            {
                return this[cellLocation.X, cellLocation.Y];
            }
        }

        #endregion

        #region Private Fields

        private DungeonFlags[,] _grid;

        #endregion

        #region Private Methods

        private void Initialize()
        {
            _grid = new DungeonFlags[Width, Height];
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    SetFlag(x, y, DungeonFlags.UNUSED);
        }

        private void SetFlag(int x, int y, DungeonFlags cellFlag)
        {
            if ((x >= Width) || (y >= Height) || (x < 0) || (y < 0))
                return;

            _grid[x, y] |= cellFlag;
        }

        private void ClearFlag(int x, int y, DungeonFlags cellFlag)
        {
            if ((x >= Width) || (y >= Height) || (x < 0) || (y < 0))
                return;

            _grid[x, y] &= ~cellFlag;
        }

        #endregion

        #region Public Methods

        public void SetFlag(CellLocation cellLocation, DungeonFlags cellFlag)
        {
            SetFlag(cellLocation.X, cellLocation.Y, cellFlag);
        }

        public void ClearFlag(CellLocation cellLocation, DungeonFlags cellFlag)
        {
            ClearFlag(cellLocation.X, cellLocation.Y, cellFlag);
        }

        public void ClearAllFlags(CellLocation cellLocation)
        {
            _grid[cellLocation.X, cellLocation.Y] = DungeonFlags.NONE;
        }

        public void ConnectCells(CellLocation firstCell, CellLocation secondCell)
        {
            var xDirection = firstCell.X - secondCell.X;
            var yDirection = firstCell.Y - secondCell.Y;

            if (xDirection == -1)
            {
                SetFlag(firstCell, DungeonFlags.RIGHT);
                SetFlag(secondCell, DungeonFlags.LEFT);
            }
            if (xDirection == 1)
            {
                SetFlag(firstCell, DungeonFlags.LEFT);
                SetFlag(secondCell, DungeonFlags.RIGHT);
            }

            if (yDirection == -1)
            {
                SetFlag(firstCell, DungeonFlags.BOTTOM);
                SetFlag(secondCell, DungeonFlags.TOP);
            }
            if (yDirection == 1)
            {
                SetFlag(firstCell, DungeonFlags.TOP);
                SetFlag(secondCell, DungeonFlags.BOTTOM);
            }
        }

        public void DisconnectCells(CellLocation firstCell, CellLocation secondCell)
        {
            var xDirection = firstCell.X - secondCell.X;
            var yDirection = firstCell.Y - secondCell.Y;

            if (xDirection == -1)
            {
                ClearFlag(firstCell, DungeonFlags.RIGHT);
                ClearFlag(secondCell, DungeonFlags.LEFT);
            }
            if (xDirection == 1)
            {
                ClearFlag(firstCell, DungeonFlags.LEFT);
                ClearFlag(secondCell, DungeonFlags.RIGHT);
            }

            if (yDirection == -1)
            {
                ClearFlag(firstCell, DungeonFlags.BOTTOM);
                ClearFlag(secondCell, DungeonFlags.TOP);
            }
            if (yDirection == 1)
            {
                ClearFlag(firstCell, DungeonFlags.TOP);
                ClearFlag(secondCell, DungeonFlags.BOTTOM);
            }
        }

        #endregion
    }
}