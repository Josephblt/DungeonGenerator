namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Private Methods

        private void CreateTier3Connection(Dungeon dungeon, Room room)
        {
            CellLocation connection_cell1 = null;
            CellLocation connection_cell2 = null;

            switch (Chamber)
            {
                case Chambers.CYAN:
                    connection_cell1 = new CellLocation(room.X + (Tier3RoomSize / 2), room.Y);
                    connection_cell2 = new CellLocation(room.X + (Tier3RoomSize / 2), room.Y - 1);
                    break;
                case Chambers.RED:
                    connection_cell1 = new CellLocation(room.X + (Tier3RoomSize / 2), room.Y + Tier3RoomSize - 1);
                    connection_cell2 = new CellLocation(room.X + (Tier3RoomSize / 2), room.Y + Tier3RoomSize);
                    break;
                case Chambers.MAGENTA:
                    connection_cell1 = new CellLocation(room.X + Tier3RoomSize - 1, room.Y + Tier3RoomSize - 1);
                    connection_cell2 = new CellLocation(room.X + Tier3RoomSize - 1, room.Y + Tier3RoomSize);
                    break;
                case Chambers.GREEN:
                    connection_cell1 = new CellLocation(room.X, room.Y);
                    connection_cell2 = new CellLocation(room.X, room.Y - 1);
                    break;
                case Chambers.YELLOW:
                    connection_cell1 = new CellLocation(room.X, room.Y + Tier3RoomSize - 1);
                    connection_cell2 = new CellLocation(room.X, room.Y + Tier3RoomSize);
                    break;
                case Chambers.BLUE:
                    connection_cell1 = new CellLocation(room.X + Tier3RoomSize - 1, room.Y);
                    connection_cell2 = new CellLocation(room.X + Tier3RoomSize - 1, room.Y - 1);
                    break;
            }

            dungeon.ConnectCells(connection_cell1, connection_cell2);
            dungeon.ClearFlag(connection_cell2, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
            dungeon.SetFlag(connection_cell1, Dungeon.DungeonFlags.START);
            dungeon.SetFlag(connection_cell2, Dungeon.DungeonFlags.UNUSED);
        }

        private Room CreateTier3Room(Dungeon dungeon)
        {
            var x = -1;
            var y = -1;

            switch (Chamber)
            {
                case Chambers.CYAN:
                    x = (Size / 2) - (Tier3RoomSize / 2);
                    y = Size - Tier3RoomSize - TiersOutterMargin;
                    break;
                case Chambers.RED:
                    x = (Size / 2) - (Tier3RoomSize / 2);
                    y = TiersOutterMargin;
                    break;
                case Chambers.MAGENTA:
                    x = TiersOutterMargin;
                    y = TiersOutterMargin;
                    break;
                case Chambers.GREEN:
                    x = Size - Tier3RoomSize - TiersOutterMargin;
                    y = Size - Tier3RoomSize - TiersOutterMargin;
                    break;
                case Chambers.YELLOW:
                    x = Size - Tier3RoomSize - TiersOutterMargin;
                    y = TiersOutterMargin;
                    break;
                case Chambers.BLUE:
                    x = TiersOutterMargin;
                    y = Size - Tier3RoomSize - TiersOutterMargin;
                    break;
            }

            return new Room(x, y, Tier3RoomSize, Tier3RoomSize, Room.RoomFlags.TIER3);
        }

        private bool IsInTier3MazeStrip(int x, int y, Room room)
        {
            bool inOuter = (
                x >= room.Left + TiersInnerMargin && x <= room.Right - TiersInnerMargin &&
                y >= room.Top + TiersInnerMargin && y <= room.Bottom - TiersInnerMargin
            );

            bool inInner = (
                x >= room.Left + TiersInnerMargin + Tier3MazeSize && x <= room.Right - TiersInnerMargin - Tier3MazeSize &&
                y >= room.Top + TiersInnerMargin + Tier3MazeSize && y <= room.Bottom - TiersInnerMargin - Tier3MazeSize
            );

            return inOuter && !inInner;
        }

        private void RemoveTier3Walls(Dungeon dungeon, Room room)
        {
            for (int x = room.Left; x <= room.Right; x++)
                for (int y = room.Top; y <= room.Bottom; y++)
                {
                    var currentCell = new CellLocation(x, y);
                    if (!IsInTier3MazeStrip(x, y, room))
                    {
                        dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
                        dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.ROOM);
                    }
                    else if (tier3MazeStart == null)
                    {
                        tier3MazeStart = currentCell;
                    }
                    dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.TIER3ROOM);

                    var rightCell = new CellLocation(x + 1, y);
                    if (rightCell.X <= room.Right)
                    {
                        if (!IsInTier3MazeStrip(x, y, room) && !IsInTier3MazeStrip(x + 1, y, room))
                        {
                            dungeon.SetFlag(rightCell, Dungeon.DungeonFlags.ROOM);
                            dungeon.ConnectCells(currentCell, rightCell);
                        }
                        else
                        {
                            if (IsInTier3MazeStrip(x, y, room) && !IsInTier3MazeStrip(x + 1, y, room) ||
                                !IsInTier3MazeStrip(x, y, room) && IsInTier3MazeStrip(x + 1, y, room))
                            {
                                if (y % 2 == 0)
                                    dungeon.ConnectCells(currentCell, rightCell);
                            }
                        }
                    }

                    var bottomCell = new CellLocation(x, y + 1);
                    if (bottomCell.Y <= room.Bottom)
                    {

                        if (!IsInTier3MazeStrip(x, y, room) && !IsInTier3MazeStrip(x, y + 1, room))
                        {
                            dungeon.SetFlag(bottomCell, Dungeon.DungeonFlags.ROOM);
                            dungeon.ConnectCells(currentCell, bottomCell);
                        }
                        else
                        {
                            if (IsInTier3MazeStrip(x, y, room) && !IsInTier3MazeStrip(x, y + 1, room) ||
                                !IsInTier3MazeStrip(x, y, room) && IsInTier3MazeStrip(x, y + 1, room))
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

        protected void ProcessTier3Room(Dungeon dungeon)
        {
            var tier3Room = CreateTier3Room(dungeon);
            createdRooms.Add(tier3Room);
            RemoveTier3Walls(dungeon, tier3Room);
            CreateTier3Connection(dungeon, tier3Room);
        }

        #endregion
    }
}