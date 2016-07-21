using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace LT
{
    public class JobDriver_CleanFilth_NCP : JobDriver
    {
        private float cleaningWorkDone;

        //Progress bar
        private float totalCleaningWorkDone;
        private float totalCleaningWorkRequired;

        private Filth Filth => (Filth) CurJob.GetTarget(TargetIndex.A).Thing;

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
            this.FailOn(() => !Find.AreaCleaning[TargetThingA.Position]); // No filth at target position

            var reserve = Toils_Reserve.Reserve(TargetIndex.A);
            yield return reserve;

            var gotoThing = Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            yield return gotoThing;

            var clean = new Toil
            {
                initAction = () =>
                {
                    totalCleaningWorkRequired = Filth.def.filth.cleaningWorkToReduceThickness*Filth.thickness;
                },

                tickAction = () =>
                {
                    var filth = Filth;
                    if (filth == null)
                        return;

                    cleaningWorkDone++;
                    totalCleaningWorkDone++;
                    if (cleaningWorkDone <= filth.def.filth.cleaningWorkToReduceThickness)
                    {
                        return;
                    }
                    filth.ThinFilth();

                    //Filth thinned; reset counter
                    cleaningWorkDone = 0;
                    if (!filth.Destroyed)
                    {
                        return;
                    }

                    GetActor().records.Increment(RecordDefOf.MessesCleaned);
                    ReadyForNextToil();
                },
                defaultCompleteMode = ToilCompleteMode.Never,
            };
            clean.WithEffect("Clean", TargetIndex.A);
            clean.WithProgressBar(TargetIndex.A, GetProgress, true);
            clean.WithSustainer(SoundDefOf.Interact_CleanFilth);
            yield return clean;
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.LookValue(ref cleaningWorkDone, "cleaningWorkDone", 0f);
        }

        private float GetProgress()
        {
            return totalCleaningWorkDone/totalCleaningWorkRequired;
        }
    }
}
