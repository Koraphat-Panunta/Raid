using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public abstract class item:Stactic_Obg
    {
        protected float Weight;
        protected float Value;
        
        public item(Vector2 Pos) 
        {
            base.Vector2 = Pos;                     
        }
        public item()
        {

        }
         public virtual float Get_Weight()
        {
            return this.Weight;
        } 
        public virtual float Get_Value() 
        { 
            return this.Value;
        }
        public virtual void disapear()
        {
            
        }
        public virtual void Set_Value(float Price_Up)
        {
            this.Value += Price_Up;
        }
        
    }
}
