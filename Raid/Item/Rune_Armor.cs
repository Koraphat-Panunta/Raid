using Raid.MainCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Rune_Armor:Rune
    {
        public Rune_Armor() { }
        protected override void Set_Value(float Value)
        {
            base.Set_Value(Value);
        }
        protected override void Set_Weight(float Weight)
        {
            base.Set_Weight(Weight);
        }
        //public override Main_Character Effect(Main_Character character)
        //{
        //    return base.Effect(character);
        //}
        public override float GetValue()
        {
            return base.GetValue();
        }
        public override float Get_Weight()
        {
            return base.Get_Weight();
        }
    }
}
