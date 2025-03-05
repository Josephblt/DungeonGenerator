using System;

namespace DungeonGenerator.Base
{
    public class Dungeon
    {
        #region Enum

        [Flags]
        public enum DungeonFlags
        {
            None = 0,

            Unused = 1,
            Path = 2,
            Room = 4,

            Left = 8,
            Top = 16,
            Right = 32,
            Bottom = 64,

            Start = 128,
            Finish = 256
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
                    return DungeonFlags.None;

                return _grid[x, y];
            }
        }
        public DungeonFlags this[Cell cellLocation]
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
                    SetFlag(x, y, DungeonFlags.Unused);
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

        public void SetFlag(Cell cellLocation, DungeonFlags cellFlag)
        {
            SetFlag(cellLocation.X, cellLocation.Y, cellFlag);
        }

        public void ClearFlag(Cell cellLocation, DungeonFlags cellFlag)
        {
            ClearFlag(cellLocation.X, cellLocation.Y, cellFlag);
        }

        public void ClearAllFlags(Cell cellLocation)
        {
            _grid[cellLocation.X, cellLocation.Y] = DungeonFlags.None;
        }

        public void ConnectCells(Cell firstCell, Cell secondCell)
        {
            var xDirection = firstCell.X - secondCell.X;
            var yDirection = firstCell.Y - secondCell.Y;

            if (xDirection == -1)
            {
                SetFlag(firstCell, DungeonFlags.Right);
                SetFlag(secondCell, DungeonFlags.Left);
            }
            if (xDirection == 1)
            {
                SetFlag(firstCell, DungeonFlags.Left);
                SetFlag(secondCell, DungeonFlags.Right);
            }

            if (yDirection == -1)
            {
                SetFlag(firstCell, DungeonFlags.Bottom);
                SetFlag(secondCell, DungeonFlags.Top);
            }
            if (yDirection == 1)
            {
                SetFlag(firstCell, DungeonFlags.Top);
                SetFlag(secondCell, DungeonFlags.Bottom);
            }
        }

        public void DisconnectCells(Cell firstCell, Cell secondCell)
        {
            var xDirection = firstCell.X - secondCell.X;
            var yDirection = firstCell.Y - secondCell.Y;

            if (xDirection == -1)
            {
                ClearFlag(firstCell, DungeonFlags.Right);
                ClearFlag(secondCell, DungeonFlags.Left);
            }
            if (xDirection == 1)
            {
                ClearFlag(firstCell, DungeonFlags.Left);
                ClearFlag(secondCell, DungeonFlags.Right);
            }

            if (yDirection == -1)
            {
                ClearFlag(firstCell, DungeonFlags.Bottom);
                ClearFlag(secondCell, DungeonFlags.Top);
            }
            if (yDirection == 1)
            {
                ClearFlag(firstCell, DungeonFlags.Top);
                ClearFlag(secondCell, DungeonFlags.Bottom);
            }
        }

        #endregion
    }
}
