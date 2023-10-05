using Microsoft.Xna.Framework;
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
            base.texture = Global.Content.Load<Texture2D>("House_font");
            base.Box_Trans = new Rectangle((int)base.Vector2.X+37,(int)base.Vector2.Y,288,88);
            base.Box_Colli = new Rectangle((int)base.Vector2.X + 39, (int)base.Vector2.Y + 88, 278, 136);
        }
    }
}
