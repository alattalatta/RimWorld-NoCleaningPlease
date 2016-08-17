using RimWorld;
using UnityEngine;
using Verse;

namespace LT
{
    public class Area_Cleaning : Area
    {
        public override string Label
        {
            get
            {
                return ResourceBank_NCP.AreaCleanLabel;
            }
        }

        public override Color Color
        {
            get
            {
                return new Color(0.3f, 0.9f, 0.9f);
            }
        }

        public override int ListPriority
        {
            get
            {
                return 10001;
            }
        }

        public override bool AssignableAsAllowed(AllowedAreaMode mode)
        {
            //May only assign humans to cleaning zone
            return mode == AllowedAreaMode.Humanlike;
        }

        public override string GetUniqueLoadID()
        {
            return "Area_Cleaning";
        }
    }
}
