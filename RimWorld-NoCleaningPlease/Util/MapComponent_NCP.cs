using Verse;

namespace LT
{
    public class MapComponent_NCP : MapComponent
    {
        private bool done;

        public override void MapComponentUpdate()
        {
            if (done)
            {
                return;
            }

            var areas = Verse.Find.AreaManager.AllAreas;
            if (!areas.Exists(s => s.GetType() == typeof(Area_Cleaning)))
            {
                //There is no cleaning area; add one
                areas.Add(new Area_Cleaning());
            }
            ListerFilthInCleaningArea.RebuildAll();
            Log.Message("LT-NCP: Initialized NoCleaningPlease.");
            done = true;
        }
    }
}
