using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_Time:item
    {
        public const int time_plus = 20;
        public Rune_Time() 
        {
            base.Value = 10;
            base.Weight = 10;
        }
    }
}
