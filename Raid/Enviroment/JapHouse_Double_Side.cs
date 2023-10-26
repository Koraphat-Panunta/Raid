using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Enviroment
{
    public class JapHouse_Double_Side:Buiding
    {
        public JapHouse_Double_Side(Vector2 vector) : base(vector)
        {
            base.texture = Global.Content.Load<Texture2D>("JapanHouse_Double_Side");
            base.Shadow = Global.Content.Load<Texture2D>("JapanHouse_Double_Side_Shadow");
            base.Vector2 = vector;
            base.Box_Colli = new Rectangle((int)vector.X+87,(int)vector.Y+522, 309, 216);
            base.Box_Trans = new Rectangle((int)vector.X+47,(int)vector.Y+27, 385, 642);

        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            Pos.X += 384;
            Pos.Y += 495;
            base.Draw_Shadow(Pos);
        }
    }
}
