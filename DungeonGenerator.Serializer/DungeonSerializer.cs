using DungeonGenerator.Base;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DungeonGenerator.Serializer
{
    public static class DungeonSerializer
    {
        public static string Serialize(Dungeon dungeon)
        {
            var data = ToData(dungeon);
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public static Dungeon Deserialize(string json)
        {
            var data = JsonConvert.DeserializeObject<DungeonData>(json);
            return FromData(data);
        }

        public static void SaveToFile(Dungeon dungeon, string filePath, bool overwrite = false)
        {
            if (File.Exists(filePath) && !overwrite)
            {
                Console.WriteLine($"File '{filePath}' already exists. Set overwrite=true to replace it.");
                return;
            }

            string json = Serialize(dungeon);
            File.WriteAllText(filePath, json);

        }

        private static DungeonData ToData(Dungeon dungeon)
        {
            int[] flat = new int[dungeon.Width * dungeon.Height];

            for (int x = 0; x < dungeon.Width; x++)
                for (int y = 0; y < dungeon.Height; y++)
                    flat[x + y * dungeon.Width] = (int)dungeon[x, y];

            return new DungeonData
            {
                Width = dungeon.Width,
                Height = dungeon.Height,
                Grid = flat
            };
        }

        private static Dungeon FromData(DungeonData data)
        {
            var dungeon = new Dungeon(data.Width, data.Height);

            for (int x = 0; x < data.Width; x++)
                for (int y = 0; y < data.Height; y++)
                    dungeon.SetFlag(new CellLocation(x, y), (Dungeon.DungeonFlags)data.Grid[x + y * data.Width]);

            return dungeon;
        }
    }
}
