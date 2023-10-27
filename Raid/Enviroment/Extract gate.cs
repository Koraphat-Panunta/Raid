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
        private Rectangle Gate_Box;
        Texture2D Gate_Texture;
        private Vector2 Gate_Position = Vector2.Zero;
        public bool Extract_gate_enable;
        public Extract_gate(Vector2 Deploy_Pos)
        {
            Gate_Texture = Global.Content.Load<Texture2D>("Extraction");
            Gate_Position = Deploy_Pos;
            Gate_Box = new Rectangle((int)Gate_Position.X, (int)Gate_Position.Y,170,170);
            Extract_gate_enable = true;
        }
        public Rectangle Get_Box()
        {
            return Gate_Box;
        }
        public Texture2D Get_Texture()
        {
            return Gate_Texture;
        }
        public Vector2 Get_Position()
        {
            return Gate_Position;
        }
    }
}
