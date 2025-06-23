using System;
using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Private Fields

        private Random _deadEndRandomizer;

        #endregion

        #region Private Methods

        private void ConnectDeadEnds(Dungeon dungeon, Queue<CellLocation> connectionQueue)
        {
            if (connectionQueue.Count == 0) return;
            while (connectionQueue.Count > 0)
            {
                var currentCell = connectionQueue.Dequeue();
                var connectionCell = FindConnectionPath(dungeon, currentCell);
                if (connectionCell == null) return;
                if (dungeon[connectionCell].HasFlag(Dungeon.DungeonFlags.START)) return;
                if (dungeon[connectionCell].HasFlag(Dungeon.DungeonFlags.FINISH)) return;

                dungeon.ConnectCells(currentCell, connectionCell);
                dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
                dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.PATH);
                dungeon.ClearFlag(connectionCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
                dungeon.SetFlag(connectionCell, Dungeon.DungeonFlags.PATH);
            }
        }

        private void FillDeadEnds(Dungeon dungeon, Queue<CellLocation> fillQueue)
        {
            if (fillQueue.Count == 0) return;
            while (fillQueue.Count > 0)
            {
                var currentCell = fillQueue.Dequeue();
                var fillCell = FindFillPath(dungeon, currentCell);

                if (fillCell == null) continue;

                dungeon.DisconnectCells(currentCell, fillCell);
                dungeon.ClearAllFlags(currentCell);

                if (dungeon[fillCell].HasFlag(Dungeon.DungeonFlags.START)) continue;
                if (dungeon[fillCell].HasFlag(Dungeon.DungeonFlags.FINISH)) continue;
                if (IsDeadEnd(dungeon[fillCell]))
                    fillQueue.Enqueue(fillCell);

            }
        }


        private CellLocation FindConnectionPath(Dungeon dungeon, CellLocation deadEndLocation)
        {
            var topPosition = FindTopCell(deadEndLocation);
            var bottomPosition = FindBottomCell(deadEndLocation);
            var leftPosition = FindLeftCell(deadEndLocation);
            var rightPosition = FindRightCell(deadEndLocation);

            List<CellLocation> availableConnections = new List<CellLocation>();

            if (IsTopConnectable(dungeon, deadEndLocation))
                availableConnections.Add(topPosition);
            if (IsBottomConnectable(dungeon, deadEndLocation))
                availableConnections.Add(bottomPosition);
            if (IsLeftConnectable(dungeon, deadEndLocation))
                availableConnections.Add(leftPosition);
            if (IsRightConnectable(dungeon, deadEndLocation))
                availableConnections.Add(rightPosition);

            if (availableConnections.Count == 0)
                return null;

            return availableConnections[_pathRandomizer.Next(0, availableConnections.Count)];
        }

        private CellLocation FindFillPath(Dungeon dungeon, CellLocation deadEndLocation)
        {
            var topCell = FindTopCell(deadEndLocation);
            var bottomCell = FindBottomCell(deadEndLocation);
            var leftCell = FindLeftCell(deadEndLocation);
            var rightCell = FindRightCell(deadEndLocation);

            List<CellLocation> paths = new List<CellLocation>();

            if ((topCell != null) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.TOP) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.PATH)) paths.Add(topCell);
            if ((bottomCell != null) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.BOTTOM) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.PATH)) paths.Add(bottomCell);
            if ((leftCell != null) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.LEFT) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.PATH)) paths.Add(leftCell);
            if ((rightCell != null) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.RIGHT) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.PATH)) paths.Add(rightCell);

            if (paths.Count == 0)
                return null;

            int index = _deadEndRandomizer.Next(0, paths.Count);

            return paths[index];
        }


        private bool IsDeadEnd(Dungeon.DungeonFlags cellFlags)
        {
            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.PATH)) return false;
            if (cellFlags.HasFlag(Dungeon.DungeonFlags.TIER1ROOM)) return false;
            if (cellFlags.HasFlag(Dungeon.DungeonFlags.TIER2ROOM)) return false;
            if (cellFlags.HasFlag(Dungeon.DungeonFlags.TIER3ROOM)) return false;

            int wallCount = 0;

            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.TOP)) wallCount++;
            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.BOTTOM)) wallCount++;
            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.LEFT)) wallCount++;
            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.RIGHT)) wallCount++;

            return wallCount == 3;
        }

        private bool IsTopConnectable(Dungeon dungeon, CellLocation deadEndLocation)
        {
            var top = new CellLocation(deadEndLocation.X, deadEndLocation.Y - 1);
            var left = new CellLocation(deadEndLocation.X - 1, deadEndLocation.Y);
            var right = new CellLocation(deadEndLocation.X + 1, deadEndLocation.Y);

            var currentCell = dungeon[deadEndLocation];
            var cellTop = dungeon[top];
            var cellLeft = dungeon[left];
            var cellRight = dungeon[right];

            if (currentCell.HasFlag(Dungeon.DungeonFlags.TOP))
                return false;

            if (cellTop == Dungeon.DungeonFlags.NONE)
                return false;

            if (!cellTop.HasFlag(Dungeon.DungeonFlags.PATH))
                return false;

            bool leftClear = false;
            bool rightClear = false;

            if (cellLeft == Dungeon.DungeonFlags.NONE ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.TOP) ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.RIGHT) ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.LEFT))
                leftClear = true;

            if (cellRight == Dungeon.DungeonFlags.NONE ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.TOP) ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.LEFT) ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.RIGHT))
                rightClear = true;

            return leftClear && rightClear;
        }

        private bool IsBottomConnectable(Dungeon dungeon, CellLocation deadEndLocation)
        {
            var bottom = new CellLocation(deadEndLocation.X, deadEndLocation.Y + 1);
            var left = new CellLocation(deadEndLocation.X - 1, deadEndLocation.Y);
            var right = new CellLocation(deadEndLocation.X + 1, deadEndLocation.Y);

            var currentCell = dungeon[deadEndLocation];
            var cellBottom = dungeon[bottom];
            var cellLeft = dungeon[left];
            var cellRight = dungeon[right];

            if (currentCell.HasFlag(Dungeon.DungeonFlags.BOTTOM))
                return false;

            if (cellBottom == Dungeon.DungeonFlags.NONE)
                return false;

            if (!cellBottom.HasFlag(Dungeon.DungeonFlags.PATH))
                return false;

            bool leftClear = false;
            bool rightClear = false;

            if (cellLeft == Dungeon.DungeonFlags.NONE ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.BOTTOM) ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.RIGHT) ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.LEFT))
                leftClear = true;

            if (cellRight == Dungeon.DungeonFlags.NONE ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.BOTTOM) ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.LEFT) ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.RIGHT))
                rightClear = true;

            return leftClear && rightClear;
        }

        private bool IsLeftConnectable(Dungeon dungeon, CellLocation deadEndLocation)
        {
            var left = new CellLocation(deadEndLocation.X - 1, deadEndLocation.Y);
            var top = new CellLocation(deadEndLocation.X, deadEndLocation.Y - 1);
            var bottom = new CellLocation(deadEndLocation.X, deadEndLocation.Y + 1);

            var currentCell = dungeon[deadEndLocation];
            var cellLeft = dungeon[left];
            var cellTop = dungeon[top];
            var cellBottom = dungeon[bottom];

            if (currentCell.HasFlag(Dungeon.DungeonFlags.LEFT))
                return false;

            if (cellLeft == Dungeon.DungeonFlags.NONE)
                return false;

            if (!cellLeft.HasFlag(Dungeon.DungeonFlags.PATH))
                return false;

            bool topClear = false;
            bool bottomClear = false;

            if (cellTop == Dungeon.DungeonFlags.NONE ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.LEFT) ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.BOTTOM) ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.TOP))
                topClear = true;

            if (cellBottom == Dungeon.DungeonFlags.NONE ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.TOP) ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.LEFT) ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.BOTTOM))
                bottomClear = true;

            return topClear && bottomClear;
        }

        private bool IsRightConnectable(Dungeon dungeon, CellLocation deadEndLocation)
        {
            var right = new CellLocation(deadEndLocation.X + 1, deadEndLocation.Y);
            var top = new CellLocation(deadEndLocation.X, deadEndLocation.Y - 1);
            var bottom = new CellLocation(deadEndLocation.X, deadEndLocation.Y + 1);

            var currentCell = dungeon[deadEndLocation];
            var cellRight = dungeon[right];
            var cellTop = dungeon[top];
            var cellBottom = dungeon[bottom];

            if (currentCell.HasFlag(Dungeon.DungeonFlags.RIGHT))
                return false;

            if (cellRight == Dungeon.DungeonFlags.NONE)
                return false;

            if (!cellRight.HasFlag(Dungeon.DungeonFlags.PATH))
                return false;

            bool topClear = false;
            bool bottomClear = false;

            if (cellTop == Dungeon.DungeonFlags.NONE ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.RIGHT) ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.BOTTOM) ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.TOP))
                topClear = true;

            if (cellBottom == Dungeon.DungeonFlags.NONE ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.TOP) ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.RIGHT) ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.BOTTOM))
                bottomClear = true;

            return topClear && bottomClear;
        }

        void Shuffle<CellLocation>(List<CellLocation> list)
        {
            Random rng = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        private void InitializeDeadEndCreator()
        {
            _deadEndRandomizer = new Random(Seed);
        }

        private void ProcessDeadEnd(Dungeon dungeon)
        {
            List<CellLocation> deadEndList = new List<CellLocation>();

            for (int x = 0; x < dungeon.Width; x++)
                for (int y = 0; y < dungeon.Height; y++)
                    if (IsDeadEnd(dungeon[x, y]))
                    {
                        deadEndList.Add(new CellLocation(x, y));
                    }

            Shuffle(deadEndList);

            Queue<CellLocation> connectionQueue = new Queue<CellLocation>();
            Queue<CellLocation> fillQueue = new Queue<CellLocation>();
            for (int i = 0; i < deadEndList.Count; i++)
            {
                if (i < DeadEndQuantity)
                {
                    dungeon.SetFlag(deadEndList[i], Dungeon.DungeonFlags.DEADEND);
                }
                else
                { 
                    if (_deadEndRandomizer.Next(0, 100) < DeadEndBias)
                        connectionQueue.Enqueue(deadEndList[i]);
                    else
                        fillQueue.Enqueue(deadEndList[i]);
                }
            }

            ConnectDeadEnds(dungeon, connectionQueue);
            FillDeadEnds(dungeon, fillQueue);
        }

        #endregion
    }
}
