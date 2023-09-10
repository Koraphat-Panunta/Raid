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
        public int Rune_Time_num;
        public int Rune_ATK_num;
        public int Rune_Arrmor_num;
        public int Rune_life_num;      
        public Inventory(float weight,int num)
        {
            this.Max_weight = weight;
            this.Grace_num = num;
        }
        public void Cal_Weight(float weight) 
        {
            carry_weight = weight * Grace_num;            
        }
        
    }
}
