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
        private Rectangle Grace_Hitbox;       
        public Grace(Vector2 Pos):base(Pos) 
        {
            Grace_Texture = Global.Content.Load<Texture2D>("Grace");
            base.Vector2 = Pos;
            base.Box = new Rectangle((int)base.Vector2.X, (int)base.Vector2.Y, 96, 96);
            base.Weight = 4;
            base.Value = 10;           
        }
        public Grace()
        {
            base.Weight = 4;
            base.Value = 10;
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
            return Grace_Texture;
        }
        public Rectangle Get_Grace_Hitbox()
        {
            return base.Box;
        }
       
       
    }
}
