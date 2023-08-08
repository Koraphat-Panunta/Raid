using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Core
{
    public class Prepare_Page
    {
        public Texture2D BG;
        public Texture2D Deploy_select;
        public Texture2D Deploy_Button;
        private Vector2 Deploy_Button_pos;
        private Vector2[] Deploy_select_pos;
        private Rectangle[] Deploy_select_Box;
        private Rectangle Deploy_Button_Box;
        public Prepare_Page(int i,string Deploy_Texture,string BG_Texture,string Deploy_button)
        {
            Deploy_select_pos = new Vector2[i];
            Deploy_select_Box = new Rectangle[i];
            
            BG = Global.Content.Load<Texture2D>(BG_Texture);
            Deploy_select = Global.Content.Load<Texture2D>(Deploy_Texture);
            Deploy_Button = Global.Content.Load<Texture2D>(Deploy_button);
            Set_ALL();
        }
        private void Set_ALL()
        {
            Deploy_select_pos[0] = new Vector2(1023,342);
            Deploy_select_pos[1] = new Vector2(1392,129);
            Deploy_select_pos[2] = new Vector2(1788,365);
            Deploy_select_pos[3] = new Vector2(1402,660);
            Deploy_Button_pos = new Vector2(1089,862);
            Deploy_Button_Box = new Rectangle((int)Deploy_Button_pos.X,(int)Deploy_Button_pos.Y,90,36);
            for (int i = 0;i<=Deploy_select_Box.Length-1;i++) 
            {
                Deploy_select_Box[i] = new Rectangle((int)Deploy_select_pos[i].X,(int)Deploy_select_pos[i].Y, 60, 60);
            }
        }
        public Vector2 Get_Deploy_Pos(int i)
        {
            return Deploy_select_pos[i];
        }
        public Vector2 Get_Deploy_select_pos(int i)
        {
            switch (i)
            {
                case 0: return new Vector2(0,0);
                    break;
                case 1: return new Vector2(1920,0);
                    break;
                case 2: return new Vector2(0,1080);
                    break;
                case 3: return new Vector2(1920,1080);
                    break;
                    default: return new Vector2(0,0);
            }
        }
        public Rectangle Get_Deploy_select_Box(int i) 
        {
            return Deploy_select_Box[i];
        }
        public Vector2 Get_Deploy_Button_pos()
        {
            return Deploy_Button_pos;
        }
        public Rectangle Get_Deploy_Button_Box()
        {
            return Deploy_Button_Box;
        }

    }
}
