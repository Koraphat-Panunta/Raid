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
        public int Grace_num;
        
        public Inventory(float weight) 
        {          
            this.Max_weight = weight;
        }
        public void Cal_Weight(float weight,int num) 
        {
            carry_weight += weight * num;
            Grace_num += num;
        }
        
    }
}
