using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid
{
    public abstract class Dynamic_Obg:GameObg
    {
        protected AnimatedTexture animation = new AnimatedTexture(Vector2.Zero,0f,1f,0.5f);
        public Vector2 Last_Pos;
        public virtual void Load()
        {

        }
        public virtual void Update()
        {

        }
    }
}
