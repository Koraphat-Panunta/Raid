using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Raid.Core
{
    public class Weight_UI:UI
    {
        private SpriteFont _font;
        
        public Weight_UI() 
        {
            base.Texture = Global.Content.Load<Texture2D>("WeightUI");
            _font = Global.Content.Load<SpriteFont>("Inventory");
        }
        public void Show_UI(float Weight,float max_Weight)
        {
            Global.spriteBatch.Draw(base.Texture, new Vector2(1108, 611), Color.White * 0.85f);
            Global.spriteBatch.DrawString(_font,""+Weight, new Vector2(1124,633), Color.White,0f,Vector2.Zero,1f,SpriteEffects.None,0.5f);
            Global.spriteBatch.DrawString(_font, "------------", new Vector2(1124, 644), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
            Global.spriteBatch.DrawString(_font, "" + max_Weight, new Vector2(1124, 658), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
        }
    }
}
