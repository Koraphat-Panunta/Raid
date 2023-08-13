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
            base.item_Pos = Pos;
            base.item_Box = new Rectangle((int)item_Pos.X, (int)item_Pos.Y, 96, 96);
            SetWeight_Value();
        }
        protected override void SetWeight_Value()
        {
            base.Weight = 4;
            base.Value = 10;
            base.SetWeight_Value();
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
            return base.item_Pos;
        }
        public Texture2D Get_Grace_Texture()
        {
            return Grace_Texture;
        }
        public Rectangle Get_Grace_Hitbox()
        {
            return base.item_Box;
        }
        public void Set_Grace_Hitbox(Rectangle Box)
        {
            item_Box = Box;
        }
        public void Set_Grace_Position(Vector2 Pos)
        {
            base.item_Pos = Pos;
        }
        public override void disapear()
        {
            base.item_Pos = new Vector2(100000,100000);
            base.item_Box = new Rectangle((int)base.item_Pos.X,(int)base.item_Pos.X,96,96);
        }
    }
}
