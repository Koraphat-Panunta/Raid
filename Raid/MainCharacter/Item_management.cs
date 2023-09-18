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
        public Rune_ATK weight_Rune_ATK = new Rune_ATK();
        public Grace weight_Grace = new Grace();
        public Rune_Armor weight_Rune_Armor = new Rune_Armor();
        public Rune_Time weight_Rune_Time = new Rune_Time();
        public Rune_Life weight_Rune_Life = new Rune_Life();
        int max = 2;
        public List<Rune_ATK> Rune_ATK = new List<Rune_ATK>();
        public List<Rune_Armor> Rune_Armor = new List<Rune_Armor>();
        public List<Rune_Time> Rune_Times = new List<Rune_Time>();
        public List<Rune_Life> Rune_Lives = new List<Rune_Life>();
        public List<Grace> Graces = new List<Grace>();
        public Inventory(float weight)
        {            
            this.Max_weight = weight;           
        }
        public void Cal_Weight() 
        {
           
            carry_weight = (Rune_ATK.Count *weight_Rune_ATK.Get_Weight() + (Rune_Armor.Count * weight_Rune_Armor.Get_Weight()) + (Rune_Times.Count * weight_Rune_Time.Get_Weight()) + (Rune_Lives.Count * weight_Rune_Life.Get_Weight()) + Graces.Count * weight_Grace.Get_Weight());      
        }
        public void upgrade_inventory()
        {
            this.Max_weight += 10;
        }
        public void add_grace() 
        { 
            Graces.Add(new Grace());
        }
        public void add_rune_time()
        {
            Rune_Times.Add(new Rune_Time());
        }
        public void add_rune_ATK()
        {
            Rune_ATK.Add(new Rune_ATK());
        }
        public void add_rune_Armor()
        {
            Rune_Armor.Add(new Rune_Armor());
        }
        public void add_rune_Life()
        {
            Rune_Lives.Add(new Rune_Life());
        }
        public void Clear_All()
        {
            Rune_ATK.Clear();
            Rune_Times.Clear();
            Rune_Armor.Clear();
            Graces.Clear();
        }
        public float return_maxweight()
        {
            return Max_weight;
        }
        
    }
}
