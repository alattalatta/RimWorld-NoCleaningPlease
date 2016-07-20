using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace LT
{
    internal class WorkGiver_CleanFilth_NCP : WorkGiver_Scanner
    {
        private const int MinTicksSinceThickened = 600;

        public override PathEndMode PathEndMode => PathEndMode.OnCell;

        public override ThingRequest PotentialWorkThingRequest => ThingRequest.ForGroup(ThingRequestGroup.Filth);

        //public override int LocalRegionsToScanFirst => 8;

        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
        {
            return ListerFilthInCleaningArea.FilthWithin;
        }

        public override bool HasJobOnThing(Pawn pawn, Thing t)
        {
            if (pawn.Faction != Faction.OfPlayer)
            {
                return false;
            }
            var filth = t as RimWorld.Filth;
            if (filth == null)
            {
                return false;
            }
            return Find.AreaCleaning[filth.Position] &&
                   pawn.CanReserveAndReach(t, PathEndMode.ClosestTouch, pawn.NormalMaxDanger()) &&
                   filth.TicksSinceThickened >= MinTicksSinceThickened;
        }

        public override Job JobOnThing(Pawn pawn, Thing t)
        {
            return new Job(JobDefOf.Clean, t);
        }
    }
}
