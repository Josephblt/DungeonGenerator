using System;
using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class DefaultCreator
    {
        #region Private Fields

        private Random _pathRandomizer;

        #endregion

        #region Private Methods

        private IEnumerable<Cell> FindAvailableCells(Dungeon dungeon, Cell currentCell)
        {
            if (currentCell.Y - 1 >= 0)
            {
                var nextCell = new Cell(currentCell.X, currentCell.Y - 1);
                if (dungeon[nextCell.X, nextCell.Y].HasFlag(Dungeon.DungeonFlags.Unused))
                    yield return nextCell;
            }

            if (currentCell.Y + 1 < dungeon.Height)
            {
                var nextCell = new Cell(currentCell.X, currentCell.Y + 1);
                if (dungeon[nextCell.X, nextCell.Y].HasFlag(Dungeon.DungeonFlags.Unused))
                    yield return nextCell;
            }

            if (currentCell.X - 1 >= 0)
            {
                var nextCell = new Cell(currentCell.X - 1, currentCell.Y);
                if (dungeon[nextCell.X, nextCell.Y].HasFlag(Dungeon.DungeonFlags.Unused))
                    yield return nextCell;
            }

            if (currentCell.X + 1 < dungeon.Width)
            {
                var nextCell = new Cell(currentCell.X + 1, currentCell.Y);
                if (dungeon[nextCell.X, nextCell.Y].HasFlag(Dungeon.DungeonFlags.Unused))
                    yield return nextCell;
            }
        }
        
        private Cell FindNextCell(Dungeon dungeon, Cell currentCell, Cell lastCell)
        {
            IEnumerable<Cell> availableCells = FindAvailableCells(dungeon, currentCell);
            List<Cell> availableCellsBuffer = new List<Cell>(availableCells);

            if (availableCellsBuffer.Count == 0)
                return null;

            bool corridor = _pathRandomizer.Next(0, 100) < CorridorBias;

            while (availableCellsBuffer.Count > 1)
            {
                Cell nextCell = availableCellsBuffer[_pathRandomizer.Next(0, availableCellsBuffer.Count)];

                if (lastCell == null)
                    return nextCell;

                if (corridor == IsCorridor(lastCell, nextCell))
                    return nextCell;
                else
                    availableCellsBuffer.Remove(nextCell);
            }

            return availableCellsBuffer[0];
        }

        private void OpenPath(Dungeon dungeon, Cell currentCell, Cell nextCell)
        {
            dungeon.ConnectCells(currentCell, nextCell);
            dungeon.ClearFlag(currentCell, (Dungeon.DungeonFlags.Unused | Dungeon.DungeonFlags.Path | Dungeon.DungeonFlags.Room));
            dungeon.SetFlag(currentCell, Dungeon.DungeonFlags.Path);
            dungeon.ClearFlag(nextCell, (Dungeon.DungeonFlags.Unused | Dungeon.DungeonFlags.Path | Dungeon.DungeonFlags.Room));
            dungeon.SetFlag(nextCell, Dungeon.DungeonFlags.Path);
        }

        private bool IsCorridor(Cell cellOne, Cell cellTwo)
        {
            return (cellOne.X == cellTwo.X) || (cellOne.Y == cellTwo.Y);
        }

        #endregion

        #region Protected Methods

        protected void InitializePathCreator()
        {
            _pathRandomizer = new Random(Seed);
        }

        protected void ProcessPath(Dungeon dungeon)
        {
            Cell currentCell = new Cell(0, 0);
            Cell nextCell = null;
            Cell lastCell = null;

            Queue<Cell> queue = new Queue<Cell>();
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
    }
}
