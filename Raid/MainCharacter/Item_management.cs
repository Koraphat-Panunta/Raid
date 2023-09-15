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
        int max = 2;
        public List<Rune_ATK> Rune_ATK = new List<Rune_ATK>();
        public List<Rune_Armor> Rune_Armor = new List<Rune_Armor>();
        public List<Rune_Time> Rune_Times = new List<Rune_Time>();
        public List<Rune_Life> Rune_Lives = new List<Rune_Life>();
        public List<Grace> Graces = new List<Grace>();
        public Inventory(float weight)
        {
            for(int i = 0; i < max; i++)
            {
                Rune_Times.Add(new Rune_Time());
                
            }
            this.Max_weight = weight;           
        }
        public void Cal_Weight() 
        {
            carry_weight = (Rune_ATK.Count * Rune_ATK[0].Get_Weight() + (Rune_Armor.Count * Rune_Armor[0].Get_Weight()) + (Rune_Times.Count * Rune_Times[0].Get_Weight()) + (Rune_Lives.Count * Rune_Lives[0].Get_Weight()) + Graces.Count * Graces[0].Get_Weight());      
        }
        
    }
}
