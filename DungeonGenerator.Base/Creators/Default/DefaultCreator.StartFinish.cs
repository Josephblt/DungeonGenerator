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
            CellLocation startCellLocation = null;
            switch (direction)
            {
                case 0:
                    startCellLocation = new CellLocation(_startFinishRandomizer.Next(0, dungeon.Width), 0);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.TOP);
                    break;
                case 1:
                    startCellLocation = new CellLocation(_startFinishRandomizer.Next(0, dungeon.Width), dungeon.Height - 1);
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.BOTTOM);
                    break;
                case 2:
                    startCellLocation = new CellLocation(0, _startFinishRandomizer.Next(0, dungeon.Height));
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.LEFT);
                    break;
                case 3:
                    startCellLocation = new CellLocation(dungeon.Width - 1, _startFinishRandomizer.Next(0, dungeon.Height));
                    dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.RIGHT);
                    break;
            }

            dungeon.SetFlag(startCellLocation, Dungeon.DungeonFlags.START);
        }

        private void DefineFinish(Dungeon dungeon, int direction)
        {
            CellLocation finishCellLocation = null;
            switch (direction)
            {
                case 0:
                    finishCellLocation = new CellLocation(_startFinishRandomizer.Next(0, dungeon.Width), 0);
                    dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.TOP);
                    break;
                case 1:
                    finishCellLocation = new CellLocation(_startFinishRandomizer.Next(0, dungeon.Width), dungeon.Height - 1);
                    dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.BOTTOM);
                    break;
                case 2:
                    finishCellLocation = new CellLocation(0, _startFinishRandomizer.Next(0, dungeon.Height));
                    dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.LEFT);
                    break;
                case 3:
                    finishCellLocation = new CellLocation(dungeon.Width - 1, _startFinishRandomizer.Next(0, dungeon.Height));
                    dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.RIGHT);
                    break;
            }

            dungeon.SetFlag(finishCellLocation, Dungeon.DungeonFlags.FINISH);
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
                    dungeon.SetFlag(Start, Dungeon.DungeonFlags.START);
            }

            if (CreateFinish)
            {
                var finishIndex = _startFinishRandomizer.Next(0, directions.Count);
                DefineFinish(dungeon, directions[finishIndex]);
            }
            else
            {
                if (Finish != null)
                    dungeon.SetFlag(Finish, Dungeon.DungeonFlags.FINISH);
            }
        }

        #endregion
    }
}
