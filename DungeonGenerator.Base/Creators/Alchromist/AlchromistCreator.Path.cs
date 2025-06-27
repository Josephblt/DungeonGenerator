using System;
using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class AlchromistCreator
    {
        #region Private Fields

        private Random _pathRandomizer;

        #endregion

        #region Private Methods

        private IEnumerable<CellLocation> FindAvailableCells(Dungeon dungeon, CellLocation currentCell)
        {
            if (currentCell.Y - 1 >= 0)
            {
                var nextCell = new CellLocation(currentCell.X, currentCell.Y - 1);
                if (dungeon[nextCell.X, nextCell.Y].HasFlag(Dungeon.DungeonFlags.UNUSED))
                    yield return nextCell;
            }

            if (currentCell.Y + 1 < dungeon.Height)
            {
                var nextCell = new CellLocation(currentCell.X, currentCell.Y + 1);
                if (dungeon[nextCell.X, nextCell.Y].HasFlag(Dungeon.DungeonFlags.UNUSED))
                    yield return nextCell;
            }

            if (currentCell.X - 1 >= 0)
            {
                var nextCell = new CellLocation(currentCell.X - 1, currentCell.Y);
                if (dungeon[nextCell.X, nextCell.Y].HasFlag(Dungeon.DungeonFlags.UNUSED))
                    yield return nextCell;
            }

            if (currentCell.X + 1 < dungeon.Width)
            {
                var nextCell = new CellLocation(currentCell.X + 1, currentCell.Y);
                if (dungeon[nextCell.X, nextCell.Y].HasFlag(Dungeon.DungeonFlags.UNUSED))
                    yield return nextCell;
            }
        }

        private CellLocation FindNextCell(Dungeon dungeon, CellLocation currentCell, CellLocation lastCell)
        {
            IEnumerable<CellLocation> availableCells = FindAvailableCells(dungeon, currentCell);
            List<CellLocation> availableCellsBuffer = new List<CellLocation>(availableCells);

            if (availableCellsBuffer.Count == 0)
                return null;

            bool corridor = _pathRandomizer.Next(0, 100) < CorridorBias;

            while (availableCellsBuffer.Count > 1)
            {
                CellLocation nextCell = availableCellsBuffer[_pathRandomizer.Next(0, availableCellsBuffer.Count)];

                if (lastCell == null)
                    return nextCell;

                if (corridor == IsCorridor(lastCell, nextCell))
                    return nextCell;
                else
                    availableCellsBuffer.Remove(nextCell);
            }

            return availableCellsBuffer[0];
        }

        private void OpenPath(Dungeon dungeon, CellLocation currentCell, CellLocation nextCell)
        {
            dungeon.ConnectCells(currentCell, nextCell);
            dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
            dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.PATH);
            dungeon.ClearFlag(nextCell, (Dungeon.DungeonFlags.UNUSED | Dungeon.DungeonFlags.PATH | Dungeon.DungeonFlags.ROOM));
            dungeon.SetFlag(nextCell, Dungeon.DungeonFlags.PATH);
        }

        private bool IsCorridor(CellLocation cellOne, CellLocation cellTwo)
        {
            return (cellOne.X == cellTwo.X) || (cellOne.Y == cellTwo.Y);
        }

        private void CreateChamberPath(Dungeon dungeon)
        {
            CellLocation currentCell = new CellLocation(0, 0);
            CellLocation nextCell = null;
            CellLocation lastCell = null;
            _pathRandomizer = new Random(Seed + (int)Chamber);

            Queue<CellLocation> queue = new Queue<CellLocation>();
            queue.Enqueue(currentCell);

            while (queue.Count > 0)
            {
                nextCell = FindNextCell(dungeon, currentCell, lastCell);
                if (nextCell != null)
                {
                    OpenPath(dungeon, currentCell, nextCell);
                    queue.Enqueue(nextCell);
                    lastCell = currentCell;
                    currentCell = nextCell;
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        lastCell = null;
                        currentCell = queue.Dequeue();
                    }
                }
            }
        }

        private void CreateTier1Path(Dungeon dungeon)
        {
            CellLocation currentCell = tier1MazeStart;
            CellLocation nextCell = null;
            CellLocation lastCell = null;
            _pathRandomizer = new Random(Seed + (int)Chamber);

            Queue<CellLocation> queue = new Queue<CellLocation>();
            queue.Enqueue(currentCell);

            while (queue.Count > 0)
            {
                nextCell = FindNextCell(dungeon, currentCell, lastCell);
                if (nextCell != null)
                {
                    OpenPath(dungeon, currentCell, nextCell);
                    queue.Enqueue(nextCell);
                    lastCell = currentCell;
                    currentCell = nextCell;
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        lastCell = null;
                        currentCell = queue.Dequeue();
                    }
                }
            }
        }

        private void CreateTier2Path(Dungeon dungeon)
        {
            CellLocation currentCell = tier2MazeStart;
            CellLocation nextCell = null;
            CellLocation lastCell = null;
            _pathRandomizer = new Random(Seed + (int)Chamber);

            Queue<CellLocation> queue = new Queue<CellLocation>();
            queue.Enqueue(currentCell);

            while (queue.Count > 0)
            {
                nextCell = FindNextCell(dungeon, currentCell, lastCell);
                if (nextCell != null)
                {
                    OpenPath(dungeon, currentCell, nextCell);
                    queue.Enqueue(nextCell);
                    lastCell = currentCell;
                    currentCell = nextCell;
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        lastCell = null;
                        currentCell = queue.Dequeue();
                    }
                }
            }
        }

        private void CreateTier3Path(Dungeon dungeon)
        {
            CellLocation currentCell = tier3MazeStart;
            CellLocation nextCell = null;
            CellLocation lastCell = null;
            _pathRandomizer = new Random(Seed + (int)Chamber);

            Queue<CellLocation> queue = new Queue<CellLocation>();
            queue.Enqueue(currentCell);

            while (queue.Count > 0)
            {
                nextCell = FindNextCell(dungeon, currentCell, lastCell);
                if (nextCell != null)
                {
                    OpenPath(dungeon, currentCell, nextCell);
                    queue.Enqueue(nextCell);
                    lastCell = currentCell;
                    currentCell = nextCell;
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        lastCell = null;
                        currentCell = queue.Dequeue();
                    }
                }
            }
        }

        #endregion

        #region Protected Methods

        protected void ProcessPaths(Dungeon dungeon)
        {
            CreateChamberPath(dungeon);
            CreateTier1Path(dungeon);
            CreateTier2Path(dungeon);
            CreateTier3Path(dungeon);
        }

        #endregion
    }
}
