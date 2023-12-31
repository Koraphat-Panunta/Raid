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
        public Texture2D Rune_ATK_Texture;
        public Texture2D Rune_Armor_Texture;
        public Texture2D Rune_Time_Texture;
        public Texture2D Rune_Life_Texture;
        public Texture2D SellButton_Texture;
        public Texture2D InputItem_Texture;
        public Texture2D StoreItem_Texture;
        public Texture2D BuyItem_Texture;
        public Texture2D Upgrade_Inventory_Texture;
        public Vector2 Rune_ATK_Pos;
        public Vector2 Rune_Armor_Pos;
        public Vector2 Rune_Time_Pos;
        public Vector2 Rune_Life_Pos;        
        public Vector2[] SellButton_Pos = new Vector2[4];
        public Vector2[] InputItem_Pos = new Vector2[4];
        public Vector2[] StoreItem_Pos = new Vector2[4];
        public Vector2[] BuyItem_Pos = new Vector2[4];
        public Rectangle Rune_ATK_Box;
        public Rectangle Rune_Armor_Box;
        public Rectangle Rune_Time_Box;
        public Rectangle Rune_Life_Box;
        public Rectangle[] SellButton_Box = new Rectangle[4];
        public Rectangle[] InputItem_Box = new Rectangle[4];
        public Rectangle[] StoreItem_Box = new Rectangle[4];
        public Rectangle[] BuyItem_Box = new Rectangle[4];
        public Rectangle Upgrade_Inventory_Box;
        private Vector2 Deploy_Button_pos;
        private Vector2 Map_Pos;
        private Vector2[] Deploy_select_pos;
        private Rectangle[] Deploy_select_Box;
        private Rectangle Deploy_Button_Box;
        public Prepare_Page()
        {
            Deploy_select_pos = new Vector2[4];
            Deploy_select_Box = new Rectangle[4];
            
            BG = Global.Content.Load<Texture2D>("GraphicUI");
            Map = Global.Content.Load<Texture2D>("Map");
            Deploy_select = Global.Content.Load<Texture2D>("Deploy_Point");
            Deploy_Button = Global.Content.Load<Texture2D>("Deploy_button");

            Rune_ATK_Texture = Global.Content.Load<Texture2D>("SpriteRuneATK01_ver2");
            Rune_Armor_Texture = Global.Content.Load<Texture2D>("SpriteRuneARMOR01_ver2");
            Rune_Time_Texture = Global.Content.Load<Texture2D>("SpriteRuneTIME01_ver2");
            Rune_Life_Texture = Global.Content.Load<Texture2D>("SpriteRuneLIFE01_ver2");

            SellButton_Texture = Global.Content.Load<Texture2D>("Sell-item");
            InputItem_Texture = Global.Content.Load<Texture2D>("Input-item");
            StoreItem_Texture = Global.Content.Load<Texture2D>("store-item");
            BuyItem_Texture = Global.Content.Load<Texture2D>("store-item");
            Upgrade_Inventory_Texture = Global.Content.Load<Texture2D>("Upgrade_inventory");

            Upgrade_Inventory_Box = new Rectangle(639,636,128,64);
            Rune_ATK_Pos = new Vector2(120, 704);
            Rune_Armor_Pos = new Vector2(120,775);
            Rune_Time_Pos = new Vector2(120, 846);
            Rune_Life_Pos = new Vector2(120,917);

            for(int i = 0; i < 4; i++)
            {
                InputItem_Pos[i] = new Vector2(56, 704+(71*i));                
                StoreItem_Pos[i] = new Vector2(391,704+(71*i));
                SellButton_Pos[i] = new Vector2(455,704+(71*i));
                BuyItem_Pos[i] = new Vector2(590, 704 + (71*i));

                InputItem_Box[i] = new Rectangle((int)InputItem_Pos[i].X, (int)InputItem_Pos[i].Y,64,64);
                StoreItem_Box[i] = new Rectangle((int)StoreItem_Pos[i].X, (int)StoreItem_Pos[i].Y,64,64);
                SellButton_Box[i] = new Rectangle((int)SellButton_Pos[i].X, (int)SellButton_Pos[i].Y,64,64);
                BuyItem_Box[i] = new Rectangle((int)BuyItem_Pos[i].X, (int)BuyItem_Pos[i].Y,64, 64);
            }                                 
            Set_ALL();
        }
        private void Set_ALL()
        {
            Map_Pos = new Vector2(1167, 101);
            Deploy_select_pos[0] = new Vector2(1398,545);
            Deploy_select_pos[1] = new Vector2(1641, 430);
            Deploy_select_pos[2] = new Vector2(1389, 398);
            Deploy_select_pos[3] = new Vector2(1803,520);
            Deploy_Button_pos = new Vector2(1624, 880);
            Deploy_Button_Box = new Rectangle((int)Deploy_Button_pos.X,(int)Deploy_Button_pos.Y,192,96);
            for (int i = 0;i<=Deploy_select_Box.Length-1;i++) 
            {
                Deploy_select_Box[i] = new Rectangle((int)Deploy_select_pos[i].X,(int)Deploy_select_pos[i].Y,64,64);
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
                case 0: return new Vector2(4573+(Global.Tile*2),9479 + (Global.Tile * 2));
                    break;
                case 1: return new Vector2(9317+(Global.Tile * 2),6618 + (Global.Tile * 2));
                    break;
                case 2: return new Vector2(4618 + (Global.Tile * 2),6774 + (Global.Tile * 2));
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
