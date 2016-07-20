using System;
using RimWorld;
using Verse;

namespace LT
{
    public abstract class Designator_AreaCleaning : Designator
    {
        private DesignateMode mode;

        public override int DraggableDimensions
        {
            get
            {
                return 2;
            }
        }

        public override bool DragDrawMeasurements
        {
            get
            {
                return true;
            }
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            if(!c.InBounds())
            {
                return false;
            }

            var exist = Find.AreaCleaning[c];
            if(mode == DesignateMode.Add)
            {
                return !exist;
            }
            return exist;
        }

        public override void DesignateSingleCell(IntVec3 c)
        {
            if(mode == DesignateMode.Add)
            {
                Find.AreaCleaning.Set(c);
            } else
            {
                Find.AreaCleaning.Clear(c);
            }
        }

        public override void SelectedUpdate()
        {
            GenUI.RenderMouseoverBracket();
            Find.AreaCleaning.MarkForDraw();
        }

        public Designator_AreaCleaning(DesignateMode mode)
        {
            this.mode = mode;
            soundDragSustain = SoundDefOf.DesignateDragStandard;
            soundDragChanged = SoundDefOf.DesignateDragStandardChanged;
            useMouseIcon = true;
            hotKey = KeyBindingDefOf.Misc7;
        }
        
    }
}
