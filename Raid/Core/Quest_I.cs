using Microsoft.Xna.Framework;

namespace Raid.Core
{
    public class Quest_I:Quest
    {
        public Quest_I()
        {
            base.Load();
            base.Quest_Selected = false;
            base.Quest_Active = false;
            base.Quest_Done = false;
            base.Quest_Select_Position = new Vector2(1139, 84);
            base.Quest_Select_Box = new Rectangle((int)base.Quest_Select_Position.X,(int)base.Quest_Select_Position.Y,48,48);
            base.Quest_Detail_string = "Defeat The Boss Enemy";
            base.Quest_Code = 1;
        }
        public override void Show_Detail()
        {
            Global.spriteBatch.DrawString(base.Quest_Detail_font, base.Quest_Detail_string, new Vector2(448,96), Color.Tomato);
        }
        
    }
}
