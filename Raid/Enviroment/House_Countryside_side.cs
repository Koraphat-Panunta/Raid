using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Enviroment
{
    public class House_Countryside_side:Buiding
    {
        public House_Countryside_side(Vector2 vector):base(vector) 
        {
            base.texture = Global.Content.Load<Texture2D>("Common House Side");
            base.Shadow = Global.Content.Load<Texture2D>("Common House Side Shadow");
            base.Box_Trans = new Rectangle((int)base.Vector2.X + 66, (int)base.Vector2.Y + 35, 351, 607);
            base.Box_Colli = new Rectangle((int)base.Vector2.X + 87, (int)base.Vector2.Y + 180, 306, 512);
        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            Pos.X += 393;
            Pos.Y += 84;
            base.Draw_Shadow(Pos);
        }
    }
}
