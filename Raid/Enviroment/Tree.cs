using Microsoft.Xna.Framework;

namespace Raid.Enviroment
{
    public class Tree:Buiding
    {
        public Tree(Vector2 vector) : base(vector)
        {
            base.Box_Colli = new Rectangle((int)base.Vector2.X+116, (int)base.Vector2.Y+208,136,130);
            base.Box_Trans = new Rectangle((int)base.Vector2.X+12, (int)base.Vector2.Y+20,360,188);
        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            base.Draw_Shadow(Pos);
        }
    }
}
