using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Item
{
    public class Grace : item
    {
        private Texture2D Grace_Texture;
        private Rectangle[] Grace_Hitbox = new Rectangle[5];
        public Vector2[] Grace_Position = new Vector2[5];        
        public Grace(string name,float weight,float value):base(name,weight,value) 
        {
            Grace_Texture = Global.Content.Load<Texture2D>(name);
            base.Weight = weight;
            base.Value = value;
            Grace_Position[0] = new Vector2(700,700);
            Grace_Hitbox[0] = new Rectangle((int)Grace_Position[0].X,(int)Grace_Position[0].Y,96,96);
        }
        protected override void SetWeight_Value(float weight, float value)
        {
            base.SetWeight_Value(weight, value);
        }
        public override float Get_Weight()
        {
            return base.Get_Weight();
        }
        public override float Get_Value()
        {
            return base.Get_Value();
        }
        public Texture2D Get_Grace_Texture()
        {
            return Grace_Texture;
        }
        public Rectangle Get_Grace_Hitbox()
        {
            return this.Grace_Hitbox[0];
        }
        public void Set_Grace_Hitbox(Rectangle Box,int i)
        {
            Grace_Hitbox[i] = Box;
        }
        public override void disapear(int i)
        {
            Grace_Position[i] = new Vector2(100000,100000);
            Grace_Hitbox[i] = new Rectangle((int)Grace_Position[i].X,(int)Grace_Position[i].X, 2, 2);
        }
    }
}
