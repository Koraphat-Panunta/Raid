using Raid.MainCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public abstract class Rune
    {
        protected float Weight;
        protected float Value;
        protected Rune() { }
        protected virtual void Set_Weight(float Weight)
        {
            this.Weight = Weight;
        }
        protected virtual void Set_Value(float Value) 
        {
            this.Value = Value;
        }
        //public virtual Main_Character Effect(Main_Character character) 
        //{ 
        //    return character;
        //}
        public virtual float Get_Weight()
        {
            return Weight;
        } 
        public virtual float GetValue() 
        {
            return Value;
        }
    }
}
