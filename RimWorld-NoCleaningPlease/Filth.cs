using Verse;

namespace LT
{
    public class Filth : RimWorld.Filth
    {
        public override void SpawnSetup()
        {
            base.SpawnSetup();
            if(!Spawned)
            {
                //If already removed while in base.SpawnSetup
                return;
            }
            if (Current.ProgramState == ProgramState.MapPlaying)
            {
                ListerFilthInCleaningArea.Notify_FilthSpawned(this);
            }
        }

        public override void DeSpawn()
        {
            base.DeSpawn();
            if (Current.ProgramState == ProgramState.MapPlaying)
            {
                ListerFilthInCleaningArea.Notify_FilthDespawned(this);
            }
        }
    }
}
