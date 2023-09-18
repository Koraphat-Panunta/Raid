using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_Armor:item
    {
        static public readonly int HP_plus = 15;
        public static float Weight_static;
        public static float Value_static;
        public Rune_Armor() 
        {
            base.Value = 15;
            base.Weight = 5;
            Weight_static = Weight;
            Value_static = Value;
            
        }
    }
}
