using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Raid.Core
{
    public class HP_BAR:UI
    {
        public Texture2D HP_Bar;
        public Vector2 HP_pos;
        public Texture2D Armmor_Bar;
        public Vector2 Armmor_Pos;
        public SpriteFont Font = Global.Content.Load<SpriteFont>("HP_font");
        public HP_BAR() 
        {
            base.Texture = Global.Content.Load<Texture2D>("HP bar");
            base.Vector2 = new Vector2 (64,64);
            HP_Bar = Global.Content.Load<Texture2D>("HP");
            HP_pos = new Vector2(190, 98);
            Armmor_Bar = Global.Content.Load<Texture2D>("ARMMOR");
            Armmor_Pos = new Vector2(382,98);
            
        }
    }
}
