using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_ATK:item
    {
        public static readonly int Damage_plus = 5;
        public static float Weight_static;
        public static float Value_static;

        public Rune_ATK() 
        {
            base.Weight = 3;
            base.Value = 5;           
            Weight_static = Weight;
            Value_static = Value;   
        }
       
    }
}
