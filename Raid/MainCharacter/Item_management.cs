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
        private Rune_ATK rune_atk = new Rune_ATK();
        public List<Rune_ATK> Rune_ATK = new List<Rune_ATK>();
        public List<Grace> Graces = new List<Grace>();
        public Inventory(float weight)
        {
            this.Max_weight = weight;
            
        }
        public void Cal_Weight() 
        {
            carry_weight = Rune_ATK.Count * Rune_ATK[0].Get_Weight() + Graces.Count*Graces[0].Get_Weight(); ;          
        }
        
    }
}
