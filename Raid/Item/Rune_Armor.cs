using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_Armor:item
    {
        public const int HP_plus = 5;
        public Rune_Armor() 
        {
            base.Value = 5;
            base.Weight = 5;
        }
    }
}
