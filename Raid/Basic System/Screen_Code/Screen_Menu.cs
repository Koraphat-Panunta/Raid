using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Raid.MainCharacter;
using Raid.Screen_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Content
{
    public class Screen_Menu : Screen
    {
        public Texture2D BG;
        public Screen_Menu() { }
        public override void load(Main_Character main_Character)
        {
            BG = Global.Content.Load<Texture2D>("Title_Test");
            base.load(main_Character);
        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Global.spriteBatch.Draw(BG, new Vector2(0, 0), Color.White);
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
