﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Enviroment
{
    public class House_Contryside_font:Buiding
    {
        public House_Contryside_font(Vector2 vector):base(vector) 
        {
            base.texture = Global.Content.Load<Texture2D>("Common House Front");
            base.Shadow = Global.Content.Load<Texture2D>("Common House Back&Front Shadow");
            base.Box_Trans = new Rectangle((int)base.Vector2.X+78,(int)base.Vector2.Y+6, 555, 426);
            base.Box_Colli = new Rectangle((int)base.Vector2.X + 141, (int)base.Vector2.Y + 318, 426, 192);
        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            Pos.X += 567;
            Pos.Y += 270;
            base.Draw_Shadow(Pos);
        }
    }
}
