using Raid.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.MainCharacter
{
    public class Inventory
    {
        public float Max_weight;
        public float carry_weight;
        public float carry_value;
        public Grace Grace;
        public Inventory(float weight) 
        {
            Grace = new Grace("Grace",4,10);
            this.Max_weight = weight;
        }
        public void Cal_Weight() 
        {          
            carry_weight = Grace.Get_Weight() * Grace.Num;
        }
        
    }
}
