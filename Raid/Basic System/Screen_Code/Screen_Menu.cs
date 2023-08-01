using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Screen_Code
{
    public class Screen_Menu:Screen
    {              
        public Screen_Menu() { }
        public override void load()           
        {
            
            base.load();
        }
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Global.Graphics.Clear(Color.Black);
            base.Draw(gameTime);
        }
        public override void Unload()
        {            
            base.Unload();
        }
        public override void Debuging()
        {
            base.Debuging();
        }

    }
}
