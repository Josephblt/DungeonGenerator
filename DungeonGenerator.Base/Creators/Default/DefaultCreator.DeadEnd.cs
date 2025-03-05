using System;
using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class DefaultCreator
    {
        #region Private Fields

        private Random _deadEndRandomizer;

        #endregion

        #region Private Methods
        
        private void ConnectDeadEnds(Dungeon dungeon, Queue<Cell> connectionQueue)
        {
            if (connectionQueue.Count == 0) return;
            while (connectionQueue.Count > 0)
            {
                var currentCell = connectionQueue.Dequeue();
                var connectionCell = FindConnectionPath(dungeon, currentCell);
                if (connectionCell == null) return;
                if (dungeon[connectionCell].HasFlag(Dungeon.DungeonFlags.Start)) return;
                if (dungeon[connectionCell].HasFlag(Dungeon.DungeonFlags.Finish)) return;

                dungeon.ConnectCells(currentCell, connectionCell);
                dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.Unused | Dungeon.DungeonFlags.Path | Dungeon.DungeonFlags.Room));
                dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.Path);
                dungeon.ClearFlag(connectionCell, (Dungeon.DungeonFlags.Unused | Dungeon.DungeonFlags.Path | Dungeon.DungeonFlags.Room));
                dungeon.SetFlag(connectionCell, Dungeon.DungeonFlags.Path);
            }
        }

        private void FillDeadEnds(Dungeon dungeon, Queue<Cell> fillQueue)
        {
            if (fillQueue.Count == 0) return;
            while (fillQueue.Count > 0)
            {
                var currentCell = fillQueue.Dequeue();
                var fillCell = FindFillPath(dungeon, currentCell);

                if (fillCell == null) continue;

                dungeon.DisconnectCells(currentCell, fillCell);
                dungeon.ClearAllFlags(currentCell);

                if (dungeon[fillCell].HasFlag(Dungeon.DungeonFlags.Start)) continue;
                if (dungeon[fillCell].HasFlag(Dungeon.DungeonFlags.Finish)) continue;
                if (IsDeadEnd(dungeon[fillCell]))
                    fillQueue.Enqueue(fillCell);

            }
        }


        private Cell FindConnectionPath(Dungeon dungeon, Cell deadEndLocation)
        {
            var topPosition = FindTopCell(deadEndLocation);
            var bottomPosition = FindBottomCell(deadEndLocation);
            var leftPosition = FindLeftCell(deadEndLocation);
            var rightPosition = FindRightCell(deadEndLocation);

            List<Cell> availableConnections = new List<Cell>();

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

        private Cell FindFillPath(Dungeon dungeon, Cell deadEndLocation)
        {
            var topCell = FindTopCell(deadEndLocation);
            var bottomCell = FindBottomCell(deadEndLocation);
            var leftCell = FindLeftCell(deadEndLocation);
            var rightCell = FindRightCell(deadEndLocation);

            List<Cell> paths = new List<Cell>();

            if ((topCell != null) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.Top) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.Path)) paths.Add(topCell);
            if ((bottomCell != null)  && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.Bottom) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.Path)) paths.Add(bottomCell);
            if ((leftCell != null)  && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.Left) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.Path)) paths.Add(leftCell);
            if ((rightCell != null)  && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.Right) && dungeon[deadEndLocation].HasFlag(Dungeon.DungeonFlags.Path)) paths.Add(rightCell);

            if (paths.Count == 0)
                return null;

            int index = _deadEndRandomizer.Next(0, paths.Count);

            return paths[index];
        }


        private bool IsDeadEnd(Dungeon.DungeonFlags cellFlags)
        {
            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.Path)) return false;

            int wallCount = 0;

            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.Top)) wallCount++;
            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.Bottom)) wallCount++;
            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.Left)) wallCount++;
            if (!cellFlags.HasFlag(Dungeon.DungeonFlags.Right)) wallCount++;

            return wallCount == 3;
        }

        private bool IsTopConnectable(Dungeon dungeon, Cell deadEndLocation)
        {
            var top = new Cell(deadEndLocation.X, deadEndLocation.Y - 1);
            var left = new Cell(deadEndLocation.X - 1, deadEndLocation.Y);
            var right = new Cell(deadEndLocation.X + 1, deadEndLocation.Y);

            var currentCell = dungeon[deadEndLocation];
            var cellTop = dungeon[top];
            var cellLeft = dungeon[left];
            var cellRight = dungeon[right];

            if (currentCell.HasFlag(Dungeon.DungeonFlags.Top))
                return false;

            if (cellTop == Dungeon.DungeonFlags.None)
                return false;

            if (!cellTop.HasFlag(Dungeon.DungeonFlags.Path))
                return false;

            bool leftClear = false;
            bool rightClear = false;

            if (cellLeft == Dungeon.DungeonFlags.None ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.Top) ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.Right) ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.Left))
                leftClear = true;

            if (cellRight == Dungeon.DungeonFlags.None ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.Top) ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.Left) ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.Right))
                rightClear = true;

            return leftClear && rightClear;
        }

        private bool IsBottomConnectable(Dungeon dungeon, Cell deadEndLocation)
        {
            var bottom = new Cell(deadEndLocation.X, deadEndLocation.Y + 1);
            var left = new Cell(deadEndLocation.X - 1, deadEndLocation.Y);
            var right = new Cell(deadEndLocation.X + 1, deadEndLocation.Y);

            var currentCell = dungeon[deadEndLocation];
            var cellBottom = dungeon[bottom];
            var cellLeft = dungeon[left];
            var cellRight = dungeon[right];

            if (currentCell.HasFlag(Dungeon.DungeonFlags.Bottom))
                return false;

            if (cellBottom == Dungeon.DungeonFlags.None)
                return false;

            if (!cellBottom.HasFlag(Dungeon.DungeonFlags.Path))
                return false;

            bool leftClear = false;
            bool rightClear = false;

            if (cellLeft == Dungeon.DungeonFlags.None ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.Bottom) ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.Right) ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.Left))
                leftClear = true;

            if (cellRight == Dungeon.DungeonFlags.None ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.Bottom) ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.Left) ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.Right))
                rightClear = true;

            return leftClear && rightClear;
        }

        private bool IsLeftConnectable(Dungeon dungeon, Cell deadEndLocation)
        {
            var left = new Cell(deadEndLocation.X - 1, deadEndLocation.Y);
            var top = new Cell(deadEndLocation.X, deadEndLocation.Y - 1);
            var bottom = new Cell(deadEndLocation.X, deadEndLocation.Y + 1);

            var currentCell = dungeon[deadEndLocation];
            var cellLeft = dungeon[left];
            var cellTop = dungeon[top];
            var cellBottom = dungeon[bottom];

            if (currentCell.HasFlag(Dungeon.DungeonFlags.Left))
                return false;

            if (cellLeft == Dungeon.DungeonFlags.None)
                return false;

            if (!cellLeft.HasFlag(Dungeon.DungeonFlags.Path))
                return false;

            bool topClear = false;
            bool bottomClear = false;

            if (cellTop == Dungeon.DungeonFlags.None ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.Left) ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.Bottom) ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.Top))
                topClear = true;

            if (cellBottom == Dungeon.DungeonFlags.None ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.Top) ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.Left) ||
                !cellLeft.HasFlag(Dungeon.DungeonFlags.Bottom))
                bottomClear = true;

            return topClear && bottomClear;
        }

        private bool IsRightConnectable(Dungeon dungeon, Cell deadEndLocation)
        {
            var right = new Cell(deadEndLocation.X + 1, deadEndLocation.Y);
            var top = new Cell(deadEndLocation.X, deadEndLocation.Y - 1);
            var bottom = new Cell(deadEndLocation.X, deadEndLocation.Y + 1);

            var currentCell = dungeon[deadEndLocation];
            var cellRight = dungeon[right];
            var cellTop = dungeon[top];
            var cellBottom = dungeon[bottom];

            if (currentCell.HasFlag(Dungeon.DungeonFlags.Right))
                return false;

            if (cellRight == Dungeon.DungeonFlags.None)
                return false;

            if (!cellRight.HasFlag(Dungeon.DungeonFlags.Path))
                return false;

            bool topClear = false;
            bool bottomClear = false;

            if (cellTop == Dungeon.DungeonFlags.None ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.Right) ||
                !cellTop.HasFlag(Dungeon.DungeonFlags.Bottom) ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.Top))
                topClear = true;

            if (cellBottom == Dungeon.DungeonFlags.None ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.Top) ||
                !cellBottom.HasFlag(Dungeon.DungeonFlags.Right) ||
                !cellRight.HasFlag(Dungeon.DungeonFlags.Bottom))
                bottomClear = true;

            return topClear && bottomClear;
        }


        private void InitializeDeadEndCreator()
        {
            _deadEndRandomizer = new Random(Seed);
        }

        private void ProcessDeadEnd(Dungeon dungeon)
        {
            Queue<Cell> connectionQueue = new Queue<Cell>();
            Queue<Cell> fillQueue = new Queue<Cell>();

            for (int x = 0; x < dungeon.Width; x++)
                for (int y = 0; y < dungeon.Height; y++)
                    if (IsDeadEnd(dungeon[x, y]))
                    {
                        if (_deadEndRandomizer.Next(0, 100) < DeadEndBias)
                            connectionQueue.Enqueue(new Cell(x, y));
                        else
                            fillQueue.Enqueue(new Cell(x, y));
                    }

            ConnectDeadEnds(dungeon, connectionQueue);
            FillDeadEnds(dungeon, fillQueue);
        }

        #endregion
    }
}
