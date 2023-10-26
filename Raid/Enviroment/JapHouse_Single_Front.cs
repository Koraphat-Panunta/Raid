using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Enviroment
{
    public class JapHouse_Single_Front:Buiding
    {
        public JapHouse_Single_Front(Vector2 vector):base(vector) 
        {
            base.texture = Global.Content.Load<Texture2D>("JapanHouse_single_Front");
            base.Shadow = Global.Content.Load<Texture2D>("JapanHouse_single_Back&Front_Shadow");
            base.Vector2 = vector;
            base.Box_Trans = new Rectangle((int)vector.X, (int)vector.Y + 126, 672, 291);
            base.Box_Colli = new Rectangle((int)vector.X + 36, (int)vector.Y + 315, 594, 155);
        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            Pos.X += 624;
            Pos.Y += 315;
            base.Draw_Shadow(Pos);
        }
    }
}
