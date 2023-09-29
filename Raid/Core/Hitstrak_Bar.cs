using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Core
{
    public class Hitstrak_Bar:UI
    {
        private Texture2D Body;
        private Texture2D Dash;
        private Texture2D Heavy_ATK;
        private Texture2D Roll_ATK;
        private Texture2D Guage;
        public Hitstrak_Bar() 
        {
            Body = Global.Content.Load<Texture2D>("Hitstreakbar");
            Dash = Global.Content.Load<Texture2D>("Dash_icon");
            Heavy_ATK = Global.Content.Load<Texture2D>("Heavy_ATK");
            Roll_ATK = Global.Content.Load<Texture2D>("Roll_ATK");
            Guage = Global.Content.Load<Texture2D>("Hitstreak_gauge");
        }
        public void Hitstrak_Bar_Show(int Hit_Count)
        {
            if (Hit_Count == 0)
            {
                Global.spriteBatch.Draw(Body, new Vector2(48, 192), Color.White*0.2f);
            }
            
            if (Hit_Count >= 2) 
            {
                Global.spriteBatch.Draw(Guage, new Vector2(108, 337), null, Color.White, 0f, Vector2.Zero, new Vector2(1, 4), SpriteEffects.None, 0.5f);
                Global.spriteBatch.Draw(Heavy_ATK, new Vector2(49, 337), Color.White);
                if (Hit_Count >= 3)
                {
                    Global.spriteBatch.Draw(Guage, new Vector2(108, 289), null, Color.White, 0f, Vector2.Zero, new Vector2(1, 2), SpriteEffects.None, 0.5f);
                }
            }            
            if (Hit_Count >= 4) 
            {
                Global.spriteBatch.Draw(Guage, new Vector2(108,241), null, Color.White, 0f, Vector2.Zero, new Vector2(1, 2), SpriteEffects.None, 0.5f);
                Global.spriteBatch.Draw(Roll_ATK, new Vector2(49, 241), Color.White);
                if (Hit_Count >= 5)
                {
                    Global.spriteBatch.Draw(Guage, new Vector2(49, 217), null, Color.White, 0f, Vector2.Zero, new Vector2(6.36f, 1), SpriteEffects.None, 0.5f);
                }
                if (Hit_Count >= 6)
                {
                    Global.spriteBatch.Draw(Guage, new Vector2(49, 193), null, Color.White, 0f, Vector2.Zero, new Vector2(6.36f, 1), SpriteEffects.None, 0.5f);                    
                }
            }            
            if (Hit_Count >= 1)
            {                
                Global.spriteBatch.Draw(Guage, new Vector2(108, 433), null, Color.White, 0f, Vector2.Zero, new Vector2(1, 4), SpriteEffects.None, 0.5f);
                Global.spriteBatch.Draw(Dash, new Vector2(49, 433), Color.White);
                Global.spriteBatch.Draw(Body, new Vector2(48, 192), Color.White*0.89f);
            }

        }
    }
}
