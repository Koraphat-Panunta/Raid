﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Core
{
    public class Prepare_Page
    {
        public Texture2D BG;
        public Texture2D Map;
        public Texture2D Deploy_select;
        public Texture2D Deploy_Button;
        private Vector2 Deploy_Button_pos;
        private Vector2 Map_Pos;
        private Vector2[] Deploy_select_pos;
        private Rectangle[] Deploy_select_Box;
        private Rectangle Deploy_Button_Box;
        public Prepare_Page()
        {
            Deploy_select_pos = new Vector2[4];
            Deploy_select_Box = new Rectangle[4];
            
            BG = Global.Content.Load<Texture2D>("GraphicUIV2");
            Map = Global.Content.Load<Texture2D>("Map");
            Deploy_select = Global.Content.Load<Texture2D>("Deploy_Point");
            Deploy_Button = Global.Content.Load<Texture2D>("Deploy_button");
            
            Set_ALL();
        }
        private void Set_ALL()
        {
            Map_Pos = new Vector2(615,65);
            Deploy_select_pos[0] = new Vector2(704,280);
            Deploy_select_pos[1] = new Vector2(823, 224);
            Deploy_select_pos[2] = new Vector2(696, 208);
            Deploy_select_pos[3] = new Vector2(1803,520);
            Deploy_Button_pos = new Vector2(812, 443);
            Deploy_Button_Box = new Rectangle((int)Deploy_Button_pos.X,(int)Deploy_Button_pos.Y,90,36);
            for (int i = 0;i<=Deploy_select_Box.Length-1;i++) 
            {
                Deploy_select_Box[i] = new Rectangle((int)Deploy_select_pos[i].X,(int)Deploy_select_pos[i].Y, 16, 16);
            }
        }
        public Vector2 Get_Map_Pos()
        {
            return Map_Pos;
        }
        public Vector2 Get_Deploy_Pos(int i)
        {
            return Deploy_select_pos[i];
        }
        public Vector2 Get_Deploy_select_pos(int i)
        {
            switch (i)
            {
                case 0: return new Vector2(2469,6328);
                    break;
                case 1: return new Vector2(5782, 4538);
                    break;
                case 2: return new Vector2(2227, 4115);
                    break;
                case 3: return new Vector2(1600 * 2,800*2);
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
