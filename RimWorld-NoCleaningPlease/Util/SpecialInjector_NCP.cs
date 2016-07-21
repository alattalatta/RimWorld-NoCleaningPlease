using System.Reflection;
using CommunityCoreLibrary;
using Verse;

namespace LT
{
    public class SpecialInjector_NCP : SpecialInjector
    {
        public override bool Inject()
        {
            // Detours; ripped from CCL code

            #region ListerFilth

            var RW_ListerFilth_RebuildAll = typeof(RimWorld.ListerFilthInHomeArea)
                .GetMethod("RebuildAll", BindingFlags.Static | BindingFlags.Public);
            var LT_ListerFilth_RebuildAll = typeof(LT.ListerFilthInCleaningArea)
                .GetMethod("RebuildAll", BindingFlags.Static | BindingFlags.Public);
            if (!Detours.
                TryDetourFromTo(RW_ListerFilth_RebuildAll, LT_ListerFilth_RebuildAll))
            {
                return false;
            }

            var RW_ListerFilth_Notify_FilthSpawned = typeof(RimWorld.ListerFilthInHomeArea)
                .GetMethod("Notify_FilthSpawned", BindingFlags.Static | BindingFlags.Public);
            var LT_ListerFilth_Notify_FilthSpawned = typeof(LT.ListerFilthInCleaningArea)
                .GetMethod("Notify_FilthSpawned", BindingFlags.Static | BindingFlags.Public);
            if (!Detours.
                TryDetourFromTo(RW_ListerFilth_Notify_FilthSpawned, LT_ListerFilth_Notify_FilthSpawned))
            {
                return false;
            }

            var RW_ListerFilth_Notify_FilthDespawned = typeof(RimWorld.ListerFilthInHomeArea)
                .GetMethod("Notify_FilthDespawned", BindingFlags.Static | BindingFlags.Public);
            var LT_ListerFilth_Notify_FilthDespawnedd = typeof(LT.ListerFilthInCleaningArea)
                .GetMethod("Notify_FilthDespawned", BindingFlags.Static | BindingFlags.Public);
            if (!Detours.
                TryDetourFromTo(RW_ListerFilth_Notify_FilthDespawned, LT_ListerFilth_Notify_FilthDespawnedd))
            {
                return false;
            }

            var RW_ListerFilth_Notify_HomeAreaChanged = typeof(RimWorld.ListerFilthInHomeArea)
                .GetMethod("Notify_HomeAreaChanged", BindingFlags.Static | BindingFlags.Public);
            var LT_ListerFilth_Notify_HomeAreaChanged = typeof(LT.ListerFilthInCleaningArea)
                .GetMethod("Notify_HomeAreaChanged", BindingFlags.Static | BindingFlags.Public);
            if (!Detours.
                TryDetourFromTo(RW_ListerFilth_Notify_HomeAreaChanged, LT_ListerFilth_Notify_HomeAreaChanged))
            {
                return false;
            }

            #endregion
            
            return true;
        }
    }
}
