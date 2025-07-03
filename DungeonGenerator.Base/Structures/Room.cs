using System;
using System.Collections.Generic;
using static DungeonGenerator.Base.Dungeon;

namespace DungeonGenerator.Base
{
    public class Room
    {
        #region Enum

        [Flags]
        public enum RoomFlags
        {
            NONE = 0,
            TIER1 = 1,
            TIER2 = 2,
            TIER3 = 4,
        }

        #endregion

        #region Constructor

        public Room(int x, int y, int width, int height, RoomFlags roomFlag = RoomFlags.NONE)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            RoomFlag = roomFlag;
        }

        #endregion

        #region Attributes and Properties

        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public RoomFlags RoomFlag { get; set; } = RoomFlags.NONE;

        public int Top { get { return Y; } }
        public int Bottom { get { return Y + Height - 1; } }
        public int Left { get { return X; } }
        public int Right { get { return X + Width - 1; } }

        #endregion

        #region Private Methods

        private int DistanceTo(Room room)
        {
            if ((Top >= room.Top && Top <= room.Bottom) &&
                (Left >= room.Left && Left <= room.Right))
                return -1;
            if ((Top >= room.Top && Top <= room.Bottom) &&
                (Right >= room.Left && Right <= room.Right))
                return -1;
            if ((Bottom >= room.Top && Bottom <= room.Bottom) &&
                (Left >= room.Left && Left <= room.Right))
                return -1;
            if ((Bottom >= room.Top && Bottom <= room.Bottom) &&
                (Right >= room.Left && Right <= room.Right))
                return -1;

            if ((room.Top >= Top && room.Top <= Bottom) &&
                (room.Left >= Left && room.Left <= Right))
                return -1;
            if ((room.Top >= Top && room.Top <= Bottom) &&
                (room.Right >= Left && room.Right <= Right))
                return -1;
            if ((room.Bottom >= Top && room.Bottom <= Bottom) &&
                (room.Left >= Left && room.Left <= Right))
                return -1;
            if ((room.Bottom >= Top && room.Bottom <= Bottom) &&
                (room.Right >= Left && room.Right <= Right))
                return -1;

            int xDistance;
            if (X < room.X)
                xDistance = room.Left - Right;
            else
                xDistance = Left - room.Right;

            int yDistance;
            if (Y < room.Y)
                yDistance = room.Top - Bottom;
            else
                yDistance = Top - room.Bottom;

            return Math.Max(xDistance, yDistance);
        }

        #endregion

        #region Public Methods

        public bool ContainsStartFinish(Dungeon dungeon)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (dungeon[x, y].HasFlag(Dungeon.DungeonFlags.START) || dungeon[x, y].HasFlag(Dungeon.DungeonFlags.FINISH))
                        return true;
            return false;
        }

        public bool Overlaps(IEnumerable<Room> rooms, int roomDistance)
        {
            foreach (var createdRoom in rooms)
                if (DistanceTo(createdRoom) <= roomDistance)
                    return true;

            return false;
        }

        #endregion
    }
}
