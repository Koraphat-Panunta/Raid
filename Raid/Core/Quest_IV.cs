using Microsoft.Xna.Framework;
namespace Raid.Core
{
    public class Quest_IV:Quest
    {
        public Quest_IV()
        {
            base.Load();
            base.Quest_Selected = false;
            base.Quest_Active = false;
            base.Quest_Done = false;
            base.Quest_Select_Position = new Vector2(1380, 170);
            base.Quest_Select_Box = new Rectangle((int)base.Quest_Select_Position.X, (int)base.Quest_Select_Position.Y, 48, 96);
            base.Quest_Detail_string = "Defeat The Boss Enemy\n\nLocation:Nothern West Village\n\nReward75$";
            base.Quest_Code = 4;
        }
        public override void Show_Detail()
        {
            Global.spriteBatch.DrawString(base.Quest_Detail_font, base.Quest_Detail_string, new Vector2(672, 96), Color.DarkRed);
        }
    }
}
