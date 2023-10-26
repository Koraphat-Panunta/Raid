using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Enviroment
{
    public class JapHouse_Single_Front:Buiding
    {
        public JapHouse_Single_Front(Vector2 vector):base(vector) 
        {
            
        }
        public override void Draw_Shadow(Vector2 Pos)
        {
            base.Draw_Shadow(Pos);
        }
    }
}
