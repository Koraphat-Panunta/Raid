using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Enviroment
{
    public class JapHouse_Double_Front:Buiding
    {
        public JapHouse_Double_Front(Vector2 vector) : base(vector)
        {
            base.texture = Global.Content.Load<Texture2D>("JapanHouse_Douvle_Front");
            base.Shadow = Global.Content.Load<Texture2D>("JapanHouse_Double_Back&Front_Shadow");
            base.Vector2 = vector;
            base.Box_Colli = new Rectangle((int)vector.X + 90, (int)vector.Y + 408, 594, 153);
            base.Box_Trans = new Rectangle((int)vector.X + 48, (int)vector.Y + 21, 683, 492);
        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            Pos.X += 681;
            Pos.Y += 408;
            base.Draw_Shadow(Pos);
        }
    }
}
