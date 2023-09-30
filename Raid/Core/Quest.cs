using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Core
{
    public class Quest
    {
        public bool Quest_Selected;
        public bool Quest_Active;
        public bool Quest_Done;
        public bool Quest_Completed;
        public Rectangle Quest_Select_Box;
        public Texture2D Quest_Select_Texture;
        public Vector2 Quest_Select_Position;
        public SpriteFont Quest_Detail_font;
        public int Quest_Code;
        public string Quest_Detail_string;
        public Quest() 
        {
            Quest_Code = 0;
        }
        protected void Load()
        {
            Quest_Detail_font = Global.Content.Load<SpriteFont>("Quest_Detail");
            Quest_Select_Texture = Global.Content.Load<Texture2D>("Quest_icon");
        }
        public virtual void Show_Detail()
        {
            if (Quest_Done == false)
            {
                Global.spriteBatch.DrawString(Quest_Detail_font, Quest_Detail_string, new Vector2(448, 96), Color.DarkRed);
            }
            else if(Quest_Done == true)
            {
                Global.spriteBatch.DrawString(Quest_Detail_font, Quest_Detail_string, new Vector2(448, 96), Color.Yellow);
            }
        }

    }
}
