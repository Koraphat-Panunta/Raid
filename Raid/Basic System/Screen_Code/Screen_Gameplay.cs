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
        Main_Character Player;
        public Screen_Gameplay() 
        { 
        }
        public override void load()
        {
            Player = new Main_Character();
            base.load();
        }
        public override void Update(GameTime gameTime)
        {
            Camera.CameraPos_Update(Player.Get_MainCharacterPos());
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            
            base.Draw(gameTime);
        }
        public override void Unload()
        {
            base.Unload();
        }
    }
}
