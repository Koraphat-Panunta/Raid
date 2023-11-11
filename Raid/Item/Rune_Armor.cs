using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_Armor:item
    {
        static public readonly int HP_plus = 5;
        public static float Weight_static;
        public static float Value_static;
        public Rune_Armor() 
        {
            base.Value = 5;
            base.Weight = 5;
            base.Value_OG = base.Value;
            Weight_static = Weight;
            Value_static = Value;
            
        }
    }
}
