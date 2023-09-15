using Microsoft.Xna.Framework;
using Raid.MainCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Screen_Code
{
    public class Screen
    {       
        //public string Curt_Scene;
        
        
        public Screen() { }
        public virtual void load(Vector2 Pos)
        {            
            //Curt_Scene = Menu;                       
        }
        public virtual void Update(GameTime gameTime)
        {
            
        }
        public virtual void Draw(GameTime gameTime)
        {
        }
        
        public virtual void Unload()
        {
        }
        public virtual void Debuging()
        {
            
        }
        
    }
}
