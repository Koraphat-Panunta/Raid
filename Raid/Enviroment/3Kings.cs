using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Enviroment
{
    public class _3Kings:Buiding
    {
        public _3Kings(Vector2 vector):base(vector) 
        {
            base.texture = Global.Content.Load<Texture2D>("3King");
            base.Shadow = Global.Content.Load<Texture2D>("Emty");
            base.Vector2 = vector;
            base.Box_Colli = new Rectangle((int)vector.X, (int)vector.Y+278, 704,230);
            base.Box_Trans = new Rectangle((int)vector.X, (int)vector.Y,704, 278);

        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            
            base.Draw_Shadow(Pos);
        }
    }
}
