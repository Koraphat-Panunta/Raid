using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Screen_Code
{
    public class Screen_Inventory_and_Mission : Screen

    {
        public Texture2D BG;
        public Screen_Inventory_and_Mission() { }
        public override void load()
        {
            BG = Global.Content.Load<Texture2D>("InventoryPage_Test");
            base.load();
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
