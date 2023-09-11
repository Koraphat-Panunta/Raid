using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_ATK:item
    {
        public static readonly int Damage_plus = 4;
        
        public Rune_ATK() 
        {
            base.Weight = 5;
            base.Value = 6;           
        }
       
    }
}
