using System;
using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class DefaultCreator
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
                    var currentCell = new Cell(x, y);
                    dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.Top | Dungeon.DungeonFlags.Bottom | Dungeon.DungeonFlags.Left | Dungeon.DungeonFlags.Right) );
                }
        }

        private void RemoveWalls(Dungeon dungeon, Room room)
        {
            for (int x = room.Left; x <= room.Right; x++)
                for (int y = room.Top; y <= room.Bottom; y++)
                {
                    var currentCell = new Cell(x, y);
                    dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.Unused | Dungeon.DungeonFlags.Path | Dungeon.DungeonFlags.Room));
                    dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.Room);

                    var rightCell = new Cell(x + 1, y);
                    if (rightCell.X <= room.Right)
                    {
                        dungeon.ConnectCells(currentCell, rightCell);
                        dungeon.ClearFlag(rightCell, (Dungeon.DungeonFlags.Unused | Dungeon.DungeonFlags.Path | Dungeon.DungeonFlags.Room));
                        dungeon.SetFlag(rightCell, Dungeon.DungeonFlags.Room);
                    }

                    var bottomCell = new Cell(x, y + 1);
                    if (bottomCell.Y <= room.Bottom)
                    {
                        dungeon.ConnectCells(currentCell, bottomCell);
                        dungeon.ClearFlag(bottomCell, (Dungeon.DungeonFlags.Unused | Dungeon.DungeonFlags.Path | Dungeon.DungeonFlags.Room));
                        dungeon.SetFlag(bottomCell, Dungeon.DungeonFlags.Room);
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
                CreateConnection(dungeon, room, connectionLocation);
            }
        }

        private void CreateConnection(Dungeon dungeon, Room room, Cell connectionLocation)
        {
            List<Cell> neighboursCells = new List<Cell>();

            if (!dungeon[connectionLocation.X, connectionLocation.Y].HasFlag(Dungeon.DungeonFlags.Top))
                neighboursCells.Add(new Cell(connectionLocation.X, connectionLocation.Y - 1));
            if (!dungeon[connectionLocation.X, connectionLocation.Y].HasFlag(Dungeon.DungeonFlags.Bottom))
                neighboursCells.Add(new Cell(connectionLocation.X, connectionLocation.Y + 1));
            if (!dungeon[connectionLocation.X, connectionLocation.Y].HasFlag(Dungeon.DungeonFlags.Left))
                neighboursCells.Add(new Cell(connectionLocation.X - 1, connectionLocation.Y));
            if (!dungeon[connectionLocation.X, connectionLocation.Y].HasFlag(Dungeon.DungeonFlags.Right))
                neighboursCells.Add(new Cell(connectionLocation.X + 1, connectionLocation.Y));
            if (neighboursCells.Count == 0) return;

            var index = _roomRandomizer.Next(0, neighboursCells.Count);
            var neighbourCellLocation = neighboursCells[index];

            dungeon.ConnectCells(connectionLocation, neighbourCellLocation);
            dungeon.ClearFlag(neighbourCellLocation, (Dungeon.DungeonFlags.Unused | Dungeon.DungeonFlags.Path | Dungeon.DungeonFlags.Room));
            dungeon.SetFlag(neighbourCellLocation, Dungeon.DungeonFlags.Unused);
        }

        private List<Cell> FindBorderCells(Dungeon dungeon, Room room)
        {
            var borderCell = new List<Cell>();

            for (int x = room.Left; x < room.Right; x++)
                if ((x > 0) && (x < dungeon.Width - 1))
                {
                    borderCell.Add(new Cell(x, room.Top));
                    borderCell.Add(new Cell(x, room.Bottom));
                }

            for (int y = room.Top; y < room.Bottom; y++)
                if ((y > 0) && (y < dungeon.Height - 1))
                {
                    borderCell.Add(new Cell(room.Left, y));
                    borderCell.Add(new Cell(room.Right, y));
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
            List<Room> createdRooms = new List<Room>();

            for (int densityCounter = 0; densityCounter < RoomDensity; densityCounter++)
            {
                var room = CreateRoom(dungeon);
                if (room == null) continue;
                if (room.ContainsStartFinish(dungeon)) continue;
                if (room.Overlaps(createdRooms, RoomDistance)) continue;

                createdRooms.Add(room);
                ResetWalls(dungeon, room);
                RemoveWalls(dungeon, room);
                CreateConnections(dungeon, room);
            }
        }

        #endregion
    }
}
