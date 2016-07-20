using System.Collections.Generic;
using System.Linq;
using Verse;

namespace LT
{
    public static class ListerFilthInCleaningArea
    {
        public static List<Thing> FilthWithin { get; } = new List<Thing>();

        public static void RebuildAll()
        {
            FilthWithin.Clear();
            foreach (var current in Verse.Find.Map.AllCells)
            {
                Notify_CleaningAreaChanged(current);
            }
        }

        public static void Notify_FilthSpawned(Filth f)
        {
            if (Find.AreaCleaning[f.Position])
            {
                FilthWithin.Add(f);
            }
        }

        public static void Notify_FilthDespawned(Filth f)
        {
            for (var i = 0; i < FilthWithin.Count; i++)
            {
                if (FilthWithin[i] != f)
                {
                    continue;
                }

                FilthWithin.RemoveAt(i);
                return;
            }
        }

        public static void Notify_CleaningAreaChanged(IntVec3 c)
        {
            //Expanded
            if (Find.AreaCleaning[c])
            {
                var thingList =
                    c.GetThingList()
                     .Where(s => s.def.thingClass == typeof(Filth)); //|| s.def.thingClass == typeof(RimWorld.Filth));
                /*
                foreach (var current in thingList)
                {
                    FilthWithin.Add(current);
                }
                */
                FilthWithin.AddRange(thingList);
            }

            //Removed
            else
            {
                /**
                 * http://stackoverflow.com/questions/17233976
                 */
                FilthWithin.RemoveAll(s => s.Position == c);

                /*
                for (var j = FilthWithin.Count - 1; j >= 0; j--)
                {
                    if (FilthWithin[j].Position == c)
                    {
                        FilthWithin.RemoveAt(j);
                    }
                }
                */
            }
        }
    }
}
