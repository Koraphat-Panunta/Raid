using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Enviroment
{
    public class JapHouse_Single_Side:Buiding
    {
        public JapHouse_Single_Side(Vector2 vector) : base(vector)
        {
            base.texture = Global.Content.Load<Texture2D>("JapanHouse Single Side");
            base.Shadow = Global.Content.Load<Texture2D>("JapanHouse_single_Side_Shadow");
            base.Vector2 = vector;
            base.Box_Trans = new Rectangle((int)vector.X+48, (int)vector.Y, 384, 777);
            base.Box_Colli = new Rectangle((int)vector.X+87,(int)vector.Y+256, 306, 591);
        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            Pos.X += 381;
            Pos.Y += 225;
            base.Draw_Shadow(Pos);
        }
    }
}
