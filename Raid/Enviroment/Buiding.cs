using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Enviroment
{
    public abstract class Buiding:Stactic_Obg
    {        
        public Rectangle Box_Colli;
        public Rectangle Box_Trans;
        public bool Trans;
        public bool Trans_Check;
      

        public Buiding(Vector2 Pos) 
        {
            base.Vector2 = Pos;
            Trans = false;
            Trans_Check = false;
        }        
        public virtual void Show(Vector2 Pos)
        {
            if (Trans == false)
            {
                Global.spriteBatch.Draw(base.texture,Pos,Color.White);
            }
            if(Trans == true)
            {
                Global.spriteBatch.Draw(base.texture,Pos, Color.White*0.5f);
            }
        }
        public Vector2 Get_Pos()
        {
            return base.Vector2;
        }

    }
}
