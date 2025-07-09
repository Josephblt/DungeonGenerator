namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Private Methods

        private void CreateTier1Connection(Dungeon dungeon, Room room)
        {
            CellLocation connection_cell1 = null;
            CellLocation connection_cell2 = null;

            switch (Chamber)
            {
                case Chambers.CYAN:
                    connection_cell1 = new CellLocation(room.X + (Tier1RoomSize / 2), room.Y);
                    connection_cell2 = new CellLocation(room.X + (Tier1RoomSize / 2), room.Y - 1);
                    break;
                case Chambers.RED:
                    connection_cell1 = new CellLocation(room.X + (Tier1RoomSize / 2), room.Y + Tier1RoomSize - 1);
                    connection_cell2 = new CellLocation(room.X + (Tier1RoomSize / 2), room.Y + Tier1RoomSize);
                    break;
                case Chambers.MAGENTA:
                    connection_cell1 = new CellLocation(Size - TiersOutterMargin - 1, room.Y + Tier1RoomSize - 1);
                    connection_cell2 = new CellLocation(Size - TiersOutterMargin - 1, room.Y + Tier1RoomSize);
                    break;
                case Chambers.GREEN:
                    connection_cell1 = new CellLocation(room.X, room.Y);
                    connection_cell2 = new CellLocation(room.X, room.Y - 1);
                    break;
                case Chambers.YELLOW:
                    connection_cell1 = new CellLocation(room.X, room.Y + Tier1RoomSize - 1);
                    connection_cell2 = new CellLocation(room.X, room.Y + Tier1RoomSize);
                    break;
                case Chambers.BLUE:
                    connection_cell1 = new CellLocation(Size - TiersOutterMargin - 1, room.Y);
                    connection_cell2 = new CellLocation(Size - TiersOutterMargin - 1, room.Y - 1);
                    break;
            }

            dungeon.ConnectCells(connection_cell1, connection_cell2);
            dungeon.ClearFlag(connection_cell2, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
            dungeon.SetFlag(connection_cell1, Dungeon.DungeonFlags.START);
            dungeon.SetFlag(connection_cell2, Dungeon.DungeonFlags.UNUSED);
        }

        private Room CreateTier1Room(Dungeon dungeon)
        {
            var x = -1;
            var y = -1;            

            switch (Chamber)
            {
                case Chambers.CYAN:
                    x = (Size / 2) - (Tier1RoomSize / 2);
                    y = TiersOutterMargin;
                    break;
                case Chambers.RED:
                    x = (Size / 2) - (Tier1RoomSize / 2);
                    y = Size - Tier1RoomSize - TiersOutterMargin;
                    break;
                case Chambers.MAGENTA:
                    x = Size - Tier1RoomSize - TiersOutterMargin;
                    y = Size - Tier1RoomSize - TiersOutterMargin;
                    break;
                case Chambers.GREEN:
                    x = TiersOutterMargin;
                    y = TiersOutterMargin;
                    break;
                case Chambers.YELLOW:
                    x = TiersOutterMargin;
                    y = Size - Tier1RoomSize - TiersOutterMargin;
                    break;
                case Chambers.BLUE:
                    x = Size - Tier1RoomSize - TiersOutterMargin;
                    y = TiersOutterMargin;
                    break;
            }

            return new Room(x, y, Tier1RoomSize, Tier1RoomSize, Room.RoomFlags.TIER1);
        }

        private bool IsInTier1MazeStrip(int x, int y, Room room)
        {
            bool inOuter = (
                x >= room.Left + TiersInnerMargin && x <= room.Right - TiersInnerMargin &&
                y >= room.Top + TiersInnerMargin && y <= room.Bottom - TiersInnerMargin
            );

            bool inInner = (
                x >= room.Left + TiersInnerMargin + Tier1MazeSize && x <= room.Right - TiersInnerMargin - Tier1MazeSize &&
                y >= room.Top + TiersInnerMargin + Tier1MazeSize && y <= room.Bottom - TiersInnerMargin - Tier1MazeSize
            );

            return inOuter && !inInner;
        }

        private void RemoveTier1Walls(Dungeon dungeon, Room room)
        {
            for (int x = room.Left; x <= room.Right; x++)
                for (int y = room.Top; y <= room.Bottom; y++)
                {
                    var currentCell = new CellLocation(x, y);

                    if (!IsInTier1MazeStrip(x, y, room))
                    {
                        dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
                        dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.ROOM);
                    }
                    else if (tier1MazeStart == null)
                    {
                        tier1MazeStart = currentCell;
                    }
                    dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.TIER1ROOM);

                    var rightCell = new CellLocation(x + 1, y);
                    if (rightCell.X <= room.Right)
                    {
                        if (!IsInTier1MazeStrip(x, y, room) && !IsInTier1MazeStrip(x + 1, y, room))
                        {
                            dungeon.SetFlag(rightCell, Dungeon.DungeonFlags.ROOM);
                            dungeon.ConnectCells(currentCell, rightCell);
                        }
                        else
                        {
                            if (IsInTier1MazeStrip(x, y, room) && !IsInTier1MazeStrip(x + 1, y, room) ||
                                !IsInTier1MazeStrip(x, y, room) && IsInTier1MazeStrip(x + 1, y, room))
                            {
                                if (y % 2 == 0)
                                    dungeon.ConnectCells(currentCell, rightCell);
                            }
                        }
                    }

                    var bottomCell = new CellLocation(x, y + 1);
                    if (bottomCell.Y <= room.Bottom)
                    {
                        
                        if (!IsInTier1MazeStrip(x, y, room) && !IsInTier1MazeStrip(x, y + 1, room))
                        {
                            dungeon.SetFlag(bottomCell, Dungeon.DungeonFlags.ROOM);
                            dungeon.ConnectCells(currentCell, bottomCell);
                        }
                        else
                        {
                            if (IsInTier1MazeStrip(x, y, room) && !IsInTier1MazeStrip(x, y + 1, room) ||
                                !IsInTier1MazeStrip(x, y, room) && IsInTier1MazeStrip(x, y + 1, room))
                            {
                                if (x % 2 == 0)
                                    dungeon.ConnectCells(currentCell, bottomCell);
                            }
                        }
                    }
                }
        }

        #endregion

        #region Protected Methods

        protected void ProcessTier1Room(Dungeon dungeon)
        {
            var tier1Room = CreateTier1Room(dungeon);
            createdRooms.Add(tier1Room);
            RemoveTier1Walls(dungeon, tier1Room);
            CreateTier1Connection(dungeon, tier1Room);
        }

        #endregion
    }
}