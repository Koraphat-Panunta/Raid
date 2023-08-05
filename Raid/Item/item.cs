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
        public item(string name,float weight,float value) 
        {
            Global.Content.Load<Texture2D>(name);
            this.Weight = weight;
            this.Value = value;
        }
        protected virtual void SetWeight_Value(float weight,float value)
        {
            this.Weight = weight;
            this.Value = value; 
        }
        public virtual float Get_Weight()
        {
            return this.Weight;
        } 
        public virtual float Get_Value() 
        { 
            return this.Value;
        }
        public virtual void disapear(int i)
        {
            
        }
        
    }
}
