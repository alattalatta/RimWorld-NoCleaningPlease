using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace LT
{
    public static class ListerFilthInCleaningArea
    {
        public static List<Thing> FilthInCleaningArea => ListerFilthInHomeArea.FilthInHomeArea;

        public static void RebuildAll()
        {
            if (Find.AreaCleaning == null)
            {
                //Add a Area_Cleaning if none exists
                //Can't be inside of a MapComp? I think this method is being called sooner; too lazy to test
                Verse.Find.AreaManager.AllAreas.Add(new Area_Cleaning());
            }

            FilthInCleaningArea.Clear();
            foreach (var current in Verse.Find.Map.AllCells)
            {
                Notify_HomeAreaChanged(current);
            }
        }

        public static void Notify_FilthSpawned(RimWorld.Filth f)
        {
            if (Find.AreaCleaning[f.Position])
            {
                FilthInCleaningArea.Add(f);
            }
        }

        public static void Notify_FilthDespawned(RimWorld.Filth f)
        {
            for (var i = 0; i < FilthInCleaningArea.Count; i++)
            {
                if (FilthInCleaningArea[i] != f)
                {
                    continue;
                }

                FilthInCleaningArea.RemoveAt(i);
                return;
            }
        }

        public static void Notify_HomeAreaChanged(IntVec3 c)
        {
            //Expanded
            if (Find.AreaCleaning[c])
            {
                var thingList =
                    c.GetThingList()
                     .Where(s => s.def.thingClass == typeof(RimWorld.Filth));

                FilthInCleaningArea.AddRange(thingList);
            }

            //Removed
            else
            {
                FilthInCleaningArea.RemoveAll(s => s.Position == c);
            }
        }
    }
}
