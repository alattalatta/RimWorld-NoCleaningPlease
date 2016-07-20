using System;
using System.Linq;
using CommunityCoreLibrary;
using Verse;

namespace LT
{
    public class SpecialInjector_NCP : SpecialInjector
    {
        public override bool Inject()
        {
            //Class changer
            var defs = DefDatabase<ThingDef>.AllDefs;
            try
            {
                foreach (
                    var current in
                        defs.Where(current => current.thingClass == typeof(RimWorld.Filth)))
                {
                    current.thingClass = typeof(Filth);
                }
            }
            catch (Exception e)
            {
                Log.Error("LT-NC: Met error while injecting.\n" + e);
                return false;
            }
            return true;
        }
    }
}
