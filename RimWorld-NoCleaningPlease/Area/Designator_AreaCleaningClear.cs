using RimWorld;
using Verse;

using UnityEngine;

namespace LT
{
    public class Designator_AreaCleaningClear : Designator_AreaCleaning
    {
        public Designator_AreaCleaningClear() : base(DesignateMode.Remove)
        {
            defaultLabel     = ResourceBank_NCP.AreaCleaningClear;
            defaultDesc      = ResourceBank_NCP.AreaCleaningClearDesc;
            icon             = ContentFinder<Texture2D>.Get("UI/Commands/AreaCleaningDelete", true);
            soundDragSustain = SoundDefOf.DesignateDragAreaDelete;
            soundSucceeded   = SoundDefOf.DesignateAreaDelete;
        }
    }
}
