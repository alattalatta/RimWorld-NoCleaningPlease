using RimWorld;
using Verse;

using UnityEngine;

namespace LT
{
    public class Designator_AreaCleaningExpand : Designator_AreaCleaning
    {
        public Designator_AreaCleaningExpand() : base(DesignateMode.Add)
        {
            defaultLabel = ResourceBank_NCP.AreaCleaningExpand;
            defaultDesc = ResourceBank_NCP.AreaCleaningExpandDesc;
            icon = ContentFinder<Texture2D>.Get("UI/Commands/AreaCleaning", true);
            soundDragSustain = SoundDefOf.DesignateDragAreaAdd;
            soundSucceeded = SoundDefOf.DesignateAreaAdd;
        }
    }
}
