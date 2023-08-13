using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public abstract class item
    {
        protected float Weight;
        protected float Value;
        protected Vector2 item_Pos;
        protected Rectangle item_Box;
        public item(Vector2 Pos) 
        {
            item_Pos = Pos;                     
        }
        protected virtual void SetWeight_Value()
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
        
    }
}
