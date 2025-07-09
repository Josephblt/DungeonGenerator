namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Private Methods

        private void CreateTier2Connection(Dungeon dungeon, Room room)
        {
            CellLocation connection_cell1 = null;
            CellLocation connection_cell2 = null;

            switch (Chamber)
            {
                case Chambers.CYAN:
                    connection_cell1 = new CellLocation(room.X + (Tier2RoomSize / 2), room.Y);
                    connection_cell2 = new CellLocation(room.X + (Tier2RoomSize / 2), room.Y - 1);
                    break;
                case Chambers.RED:
                    connection_cell1 = new CellLocation(room.X + (Tier2RoomSize / 2), room.Y + Tier2RoomSize - 1);
                    connection_cell2 = new CellLocation(room.X + (Tier2RoomSize / 2), room.Y + Tier2RoomSize);
                    break;
                case Chambers.MAGENTA:
                    connection_cell1 = new CellLocation(room.X + Tier2RoomSize - 1, room.Y + Tier2RoomSize - 1);
                    connection_cell2 = new CellLocation(room.X + Tier2RoomSize - 1, room.Y + Tier2RoomSize);
                    break;
                case Chambers.GREEN:
                    connection_cell1 = new CellLocation(room.X, room.Y);
                    connection_cell2 = new CellLocation(room.X, room.Y - 1);
                    break;
                case Chambers.YELLOW:
                    connection_cell1 = new CellLocation(room.X, room.Y + Tier2RoomSize - 1);
                    connection_cell2 = new CellLocation(room.X, room.Y + Tier2RoomSize);
                    break;
                case Chambers.BLUE:
                    connection_cell1 = new CellLocation(room.X + Tier2RoomSize - 1, room.Y);
                    connection_cell2 = new CellLocation(room.X + Tier2RoomSize - 1, room.Y - 1);
                    break;
            }

            dungeon.ConnectCells(connection_cell1, connection_cell2);
            dungeon.ClearFlag(connection_cell2, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
            dungeon.SetFlag(connection_cell1, Dungeon.DungeonFlags.START);
            dungeon.SetFlag(connection_cell2, Dungeon.DungeonFlags.UNUSED);
        }

        private Room CreateTier2Room(Dungeon dungeon)
        {
            var x = -1;
            var y = -1;            

            switch (Chamber)
            {
                case Chambers.CYAN:
                    x = (Size / 2) - (Tier2RoomSize / 2);
                    y = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier1RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    break;
                case Chambers.RED:
                    x = (Size / 2) - (Tier2RoomSize / 2);
                    y = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier3RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    break;
                case Chambers.MAGENTA:
                    x = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier3RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    y = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier3RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    break;
                case Chambers.GREEN:
                    x = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier1RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    y = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier1RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    break;
                case Chambers.YELLOW:
                    x = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier1RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    y = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier3RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    break;
                case Chambers.BLUE:
                    x = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier3RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    y = ((Size - Tier1RoomSize - Tier3RoomSize - (TiersOutterMargin * 2)) / 2) + (Tier1RoomSize + TiersOutterMargin) - (Tier2RoomSize / 2);
                    break;
            }

            return new Room(x, y, Tier2RoomSize, Tier2RoomSize, Room.RoomFlags.TIER2);
        }

        private bool IsInTier2MazeStrip(int x, int y, Room room)
        {
            bool inOuter = (
                x >= room.Left + TiersInnerMargin && x <= room.Right - TiersInnerMargin &&
                y >= room.Top + TiersInnerMargin && y <= room.Bottom - TiersInnerMargin
            );

            bool inInner = (
                x >= room.Left + TiersInnerMargin + Tier2MazeSize && x <= room.Right - TiersInnerMargin - Tier2MazeSize &&
                y >= room.Top + TiersInnerMargin + Tier2MazeSize && y <= room.Bottom - TiersInnerMargin - Tier2MazeSize
            );

            return inOuter && !inInner;
        }

        private void RemoveTier2Walls(Dungeon dungeon, Room room)
        {
            for (int x = room.Left; x <= room.Right; x++)
                for (int y = room.Top; y <= room.Bottom; y++)
                {
                    var currentCell = new CellLocation(x, y);
                    if (!IsInTier2MazeStrip(x, y, room))
                    {
                        dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
                        dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.ROOM);
                    }
                    else if (tier2MazeStart == null)
                    {
                        tier2MazeStart = currentCell;
                    }
                    dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.TIER2ROOM);

                    var rightCell = new CellLocation(x + 1, y);
                    if (rightCell.X <= room.Right)
                    {
                        if (!IsInTier2MazeStrip(x, y, room) && !IsInTier2MazeStrip(x + 1, y, room))
                        {
                            dungeon.SetFlag(rightCell, Dungeon.DungeonFlags.ROOM);
                            dungeon.ConnectCells(currentCell, rightCell);
                        }
                        else
                        {
                            if (IsInTier2MazeStrip(x, y, room) && !IsInTier2MazeStrip(x + 1, y, room) ||
                                !IsInTier2MazeStrip(x, y, room) && IsInTier2MazeStrip(x + 1, y, room))
                            {
                                if (y % 2 == 0)
                                    dungeon.ConnectCells(currentCell, rightCell);
                            }
                        }
                    }

                    var bottomCell = new CellLocation(x, y + 1);
                    if (bottomCell.Y <= room.Bottom)
                    {

                        if (!IsInTier2MazeStrip(x, y, room) && !IsInTier2MazeStrip(x, y + 1, room))
                        {
                            dungeon.SetFlag(bottomCell, Dungeon.DungeonFlags.ROOM);
                            dungeon.ConnectCells(currentCell, bottomCell);
                        }
                        else
                        {
                            if (IsInTier2MazeStrip(x, y, room) && !IsInTier2MazeStrip(x, y + 1, room) ||
                                !IsInTier2MazeStrip(x, y, room) && IsInTier2MazeStrip(x, y + 1, room))
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

        protected void ProcessTier2Room(Dungeon dungeon)
        {
            var tier2Room = CreateTier2Room(dungeon);
            createdRooms.Add(tier2Room);
            RemoveTier2Walls(dungeon, tier2Room);
            CreateTier2Connection(dungeon, tier2Room);
        }

        #endregion
    }
}