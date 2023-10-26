using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Enviroment
{
    public class Tree_Red : Tree
    {
        public Tree_Red(Vector2 vector) : base(vector)
        {
            base.texture = Global.Content.Load<Texture2D>("Tree Red");
            base.Shadow = Global.Content.Load<Texture2D>("Trees Shadow");
        }
    }
}
