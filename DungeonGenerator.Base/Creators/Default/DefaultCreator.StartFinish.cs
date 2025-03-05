using System;
using System.Collections.Generic;

namespace DungeonGenerator.Base.Creators
{
    public partial class DefaultCreator
    {
        #region Private Fields

        private Random _startFinishRandomizer;

        #endregion

        #region Private Methods

        private void DefineStart(Dungeon dungeon, int direction)
        {
            Cell startCellLocation = null;
            switch (direction)
            {
                case 0:
                    startCellLocation = new Cell(_startFinishRandomizer.Next(0, dungeon.Width), 0);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.Top);
                    break;
                case 1:
                    startCellLocation = new Cell(_startFinishRandomizer.Next(0, dungeon.Width), dungeon.Height - 1);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.Bottom);
                    break;
                case 2:
                    startCellLocation = new Cell(0, _startFinishRandomizer.Next(0, dungeon.Height));
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.Left);
                    break;
                case 3:
                    startCellLocation = new Cell(dungeon.Width - 1, _startFinishRandomizer.Next(0, dungeon.Height));
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.Right);
                    break;
            }

            dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.Start);
        }

        private void DefineFinish(Dungeon dungeon, int direction)
        {
            Cell finishCellLocation = null;
            switch (direction)
            {
                case 0:
                    finishCellLocation = new Cell(_startFinishRandomizer.Next(0, dungeon.Width), 0);
                    dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.Top);
                    break;
                case 1:
                    finishCellLocation = new Cell(_startFinishRandomizer.Next(0, dungeon.Width), dungeon.Height - 1);
                    dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.Bottom);
                    break;
                case 2:
                    finishCellLocation = new Cell(0, _startFinishRandomizer.Next(0, dungeon.Height));
                    dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.Left);
                    break;
                case 3:
                    finishCellLocation = new Cell(dungeon.Width - 1, _startFinishRandomizer.Next(0, dungeon.Height));
                    dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.Right);
                    break;
            }

            dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.Finish);
        }

        #endregion

        #region Protected Methods

        protected void InitializeStartFinishCreator()
        {
            _startFinishRandomizer = new Random(Seed);
        }

        protected void ProcessStartFinish(Dungeon dungeon)
        {
            List<int> directions = new List<int>{ 0, 1, 2, 3 };

            if (CreateStart)
            {
                var startIndex = _startFinishRandomizer.Next(0, directions.Count);
                DefineStart(dungeon, directions[startIndex]);
                directions.RemoveAt(startIndex);
            }
            else
            {
                if (Start != null)
                    dungeon.SetFlag(Start, Dungeon.DungeonFlags.Start);
            }

            if (CreateFinish)
            {
                var finishIndex = _startFinishRandomizer.Next(0, directions.Count);
                DefineFinish(dungeon, directions[finishIndex]);
            }
            else
            {
                if (Finish != null)
                    dungeon.SetFlag(Finish, Dungeon.DungeonFlags.Finish);
            }
        }

        #endregion
    }
}
