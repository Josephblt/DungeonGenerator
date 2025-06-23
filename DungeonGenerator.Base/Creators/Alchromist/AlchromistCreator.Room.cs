using System;
using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Private Fields

        private Random _roomRandomizer;

        #endregion

        #region Private Methods

        private Room CreateRoom(Dungeon dungeon)
        {
            var width = _roomRandomizer.Next(RoomMinSize, RoomMaxSize + 1);
            var height = _roomRandomizer.Next(RoomMinSize, RoomMaxSize + 1);

            var xMaxRange = dungeon.Width - width - RoomDistance;
            var yMaxRange = dungeon.Height - height - RoomDistance;

            if (xMaxRange < RoomDistance) return null;
            if (yMaxRange < RoomDistance) return null;

            var x = _roomRandomizer.Next(RoomDistance, dungeon.Width - width - RoomDistance);
            var y = _roomRandomizer.Next(RoomDistance, dungeon.Height - height - RoomDistance);

            var room = new Room(x, y, width, height);
            return room;
        }

        private void ResetWalls(Dungeon dungeon, Room room)
        {
            for (int x = room.Left; x <= room.Right; x++)
                for (int y = room.Top; y <= room.Bottom; y++)
                {
                    var currentCell = new CellLocation(x, y);
                    dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.TOP | Dungeon.DungeonFlags.BOTTOM | Dungeon.DungeonFlags.LEFT | Dungeon.DungeonFlags.RIGHT));
                }
        }

        private void RemoveWalls(Dungeon dungeon, Room room)
        {
            for (int x = room.Left; x <= room.Right; x++)
                for (int y = room.Top; y <= room.Bottom; y++)
                {
                    var currentCell = new CellLocation(x, y);
                    dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
                    dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.ROOM);

                    var rightCell = new CellLocation(x + 1, y);
                    if (rightCell.X <= room.Right)
                    {
                        dungeon.ConnectCells(currentCell, rightCell);
                        dungeon.ClearFlag(rightCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
                        dungeon.SetFlag(rightCell, Dungeon.DungeonFlags.ROOM);
                    }

                    var bottomCell = new CellLocation(x, y + 1);
                    if (bottomCell.Y <= room.Bottom)
                    {
                        dungeon.ConnectCells(currentCell, bottomCell);
                        dungeon.ClearFlag(bottomCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
                        dungeon.SetFlag(bottomCell, Dungeon.DungeonFlags.ROOM);
                    }
                }
        }

        private void CreateConnections(Dungeon dungeon, Room room)
        {
            var availableBorderCells = FindBorderCells(dungeon, room);

            for (int connectionsCounter = 0; connectionsCounter < RoomConnections; connectionsCounter++)
            {
                var index = _roomRandomizer.Next(0, availableBorderCells.Count);
                var connectionLocation = availableBorderCells[index];
                availableBorderCells.Remove(connectionLocation);
                CreateConnection(dungeon, connectionLocation);
            }
        }

        private void CreateConnection(Dungeon dungeon, CellLocation connectionLocation)
        {
            List<CellLocation> neighboursCells = new List<CellLocation>();

            if (!dungeon[connectionLocation.X, connectionLocation.Y].HasFlag(Dungeon.DungeonFlags.TOP))
                neighboursCells.Add(new CellLocation(connectionLocation.X, connectionLocation.Y - 1));
            if (!dungeon[connectionLocation.X, connectionLocation.Y].HasFlag(Dungeon.DungeonFlags.BOTTOM))
                neighboursCells.Add(new CellLocation(connectionLocation.X, connectionLocation.Y + 1));
            if (!dungeon[connectionLocation.X, connectionLocation.Y].HasFlag(Dungeon.DungeonFlags.LEFT))
                neighboursCells.Add(new CellLocation(connectionLocation.X - 1, connectionLocation.Y));
            if (!dungeon[connectionLocation.X, connectionLocation.Y].HasFlag(Dungeon.DungeonFlags.RIGHT))
                neighboursCells.Add(new CellLocation(connectionLocation.X + 1, connectionLocation.Y));
            if (neighboursCells.Count == 0) return;

            var index = _roomRandomizer.Next(0, neighboursCells.Count);
            var neighbourCellLocation = neighboursCells[index];

            dungeon.ConnectCells(connectionLocation, neighbourCellLocation);
            dungeon.ClearFlag(neighbourCellLocation, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
            dungeon.SetFlag(neighbourCellLocation, Dungeon.DungeonFlags.UNUSED);
        }

        private List<CellLocation> FindBorderCells(Dungeon dungeon, Room room)
        {
            var borderCell = new List<CellLocation>();

            for (int x = room.Left; x < room.Right; x++)
                if ((x > 0) && (x < dungeon.Width - 1))
                {
                    borderCell.Add(new CellLocation(x, room.Top));
                    borderCell.Add(new CellLocation(x, room.Bottom));
                }

            for (int y = room.Top; y < room.Bottom; y++)
                if ((y > 0) && (y < dungeon.Height - 1))
                {
                    borderCell.Add(new CellLocation(room.Left, y));
                    borderCell.Add(new CellLocation(room.Right, y));
                }

            return borderCell;
        }

        #endregion

        #region Protected Methods

        protected void InitializeRoomCreator()
        {
            _roomRandomizer = new Random(Seed);
        }

        protected void ProcessRoom(Dungeon dungeon)
        {
            for (int roomCounter = 0; roomCounter < RoomQuantity; roomCounter++)
            {
                var room = CreateRoom(dungeon);
                if (room.Overlaps(createdRooms, RoomDistance))
                {
                    roomCounter--;
                    continue;
                }

                createdRooms.Add(room);
                ResetWalls(dungeon, room);
                RemoveWalls(dungeon, room);
                CreateConnections(dungeon, room);
            }
        }

        #endregion
    }
}