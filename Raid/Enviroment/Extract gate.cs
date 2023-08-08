using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Enviroment
{
    public class Extract_gate
    {
        private Rectangle[] Gate_Box = new Rectangle[5];
        Texture2D Gate_Texture;
        private Vector2[] Gate_Position = new Vector2[5];
        public Extract_gate()
        {
            Gate_Texture = Global.Content.Load<Texture2D>("Extraction");
            Gate_Position[0] = new Vector2 (460,540);
            Gate_Box[0] = new Rectangle((int)Gate_Position[0].X, (int)Gate_Position[0].Y, 672, 624);
        }
        public Rectangle Get_Box()
        {
            return Gate_Box[0];
        }
        public Texture2D Get_Texture()
        {
            return Gate_Texture;
        }
        public Vector2 Get_Position()
        {
            return Gate_Position[0];
        }
    }
}
