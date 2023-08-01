using Microsoft.Xna.Framework;
using Raid.MainCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Screen_Code
{
    public class Screen_Gameplay:Screen
    {      
        public Screen_Gameplay() 
        { 
        }
        public override void load()
        {           
            base.load();
        }
        public override void Update(GameTime gameTime)
        {
            Main_Character.Main_Character_Updatestate();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Global.Graphics.Clear(Color.BurlyWood);
            base.Draw(gameTime);
        }
     
        public override void Unload()
        {
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Main_Char_State ={0}",Main_Character.Main_Char_curt_State);
            base.Debuging();
        }
    }
}
