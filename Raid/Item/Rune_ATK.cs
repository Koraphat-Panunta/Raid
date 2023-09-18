using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_ATK:item
    {
        public static readonly int Damage_plus = 7;
        public static float Weight_static;
        public static float Value_static;

        public Rune_ATK() 
        {
            base.Weight = 10;
            base.Value = 15;           
            Weight_static = Weight;
            Value_static = Value;   
        }
       
    }
}
