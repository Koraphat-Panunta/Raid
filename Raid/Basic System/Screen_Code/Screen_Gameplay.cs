using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public Texture2D BG;
        public Screen_Gameplay() 
        { 
        }
        public override void load()
        {           
            base.load();
            BG = Global.Content.Load<Texture2D>("Gameplay_Test");
            Main_Character.load();
        }
        public override void Update(GameTime gameTime)
        {
            Main_Character.Main_Character_Updatestate();           
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Global.spriteBatch.Draw(BG,new Vector2(0,0),Color.White);
            Main_Character.Animate();
            base.Draw(gameTime);
        }
     
        public override void Unload()
        {
            Main_Character.Main_Char_curt_State = null;
            Main_Character.Set_MainCharacterPos(new Vector2(0,0));
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Main_Char_State ={0}",Main_Character.Main_Char_curt_State);
            Console.WriteLine("Main_Char_Pos = {0}",Main_Character.Get_MainCharacterPos());
            base.Debuging();
        }
    }
}
