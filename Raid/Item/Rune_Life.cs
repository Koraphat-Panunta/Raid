using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_Life:item
    {
        public static float Weight_static;
        public static float Value_static;
        public Rune_Life() 
        {
            base.Value = 100;
            base.Weight = 25;
            base.Value_OG = base.Value;
            Weight_static = Weight;
            Value_static = Value;
        }
    }
}
