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
        public static float Weight_static;
        public static float Value_static;
        public Grace(Vector2 Pos):base(Pos) 
        {
            base.texture = Global.Content.Load<Texture2D>("Grace");
            base.Vector2 = Pos;
            base.Box = new Rectangle((int)base.Vector2.X, (int)base.Vector2.Y, 48, 48);
            base.Weight = 1f;
            base.Value = 10;  
            Weight_static = Weight;
            Value_static = Value;
        }
        public Grace()
        {
            base.Weight = 0.5f;            
        }
        public override float Get_Weight()
        {
            return base.Weight;
        }
        public override float Get_Value()
        {
            return base.Get_Value();
        }
        public Vector2 Get_GracePosition()
        {
            return base.Vector2;
        }
        public Texture2D Get_Grace_Texture()
        {
            return base.texture;
        }
        public Rectangle Get_Grace_Hitbox()
        {
            return base.Box;
        }
       
       
    }
}
