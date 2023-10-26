using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Enviroment
{
    public class Tree_Group:Stactic_Obg
    {
        public Tree_Group(Vector2 Pos,string name) 
        {
            base.Vector2 = Pos;
            base.texture = Global.Content.Load<Texture2D>(name);
        }
        public void Draw(Vector2 vector)
        {
            Global.spriteBatch.Draw(base.texture,vector,Color.White);
        }
        public Vector2 Get_Pos() { return base.Vector2; }

    }
}
