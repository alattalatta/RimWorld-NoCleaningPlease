using Verse;

namespace LT
{
    // TODO: Get rid of these
    // Here to not break any saves

    public class MapComponent_NCP : MapComponent
    {
        bool done = false;
        public override void MapComponentUpdate()
        {
            if (done)
            {
                return;
            }

            var allFilth = Verse.Find.ListerThings.ThingsInGroup(ThingRequestGroup.Filth);

            for (var i = 0; i < allFilth.Count; i++)
            {
                if (allFilth[i].GetType() == typeof(RimWorld.Filth))
                {
                    continue;
                }
                allFilth[i] = allFilth[i] as RimWorld.Filth;
            }

            done = true;
        }
    }

    public class Filth : RimWorld.Filth
    {
    }
}
