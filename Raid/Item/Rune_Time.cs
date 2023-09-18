using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_Time:item
    {
        static public readonly int time_plus = 20;
        public static float Weight_static;
        public static float Value_static;
        public Rune_Time() 
        {
            base.Value = 5;
            base.Weight = 5.75f;
            Weight_static = Weight;
            Value_static = Value;
        }
    }
}
