
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Core;
using Raid.Item;
using Raid.MainCharacter;
using System;
using System.Collections.Generic;

namespace Raid.Screen_Code
{
    public class Screen_Inventory_and_Mission : Screen

    {
        public Quest quest = new Quest();
        List<Quest> quest_selection = new List<Quest>();
        public Quest_I Quest_I;
        public Quest_II Quest_II;
        private Texture2D grace_texture;
        private SpriteFont font;
        public Prepare_Page map;
        public Inventory inventory = new Inventory(80f);
        private Inventory stash = new Inventory(8000f);
        private Texture2D Face_Icon;
        private Texture2D ATK_icon_menu;
        private Texture2D Armor_icon_menu;
        private Texture2D Time_icon_menu;
        private Texture2D Life_icon_menu;
        private int Invectory_Upgrade_Cost = 35;
       
        public Texture2D Deploy_select;
        public Rectangle mouse;
        public Vector2 Deploy_Pos;
        public bool Deploy_selected;
        public bool Deploy_Confirm;
        
        public Screen_Inventory_and_Mission()
        {
        }
        public override void load( Vector2 Pos)
        {
            map = new Prepare_Page();
            Deploy_Pos = Vector2.Zero;
            this.Deploy_selected = false;
            this.Deploy_Confirm = false;
            base.load(Pos);
            font = Global.Content.Load<SpriteFont>("Inventory");
            grace_texture = Global.Content.Load<Texture2D>("Grace");
            Face_Icon = Global.Content.Load<Texture2D>("Face_icon");
            ATK_icon_menu = Global.Content.Load<Texture2D>("ATK icon Menu");
            Armor_icon_menu = Global.Content.Load<Texture2D>("Armor icon menu");
            Time_icon_menu =  Global.Content.Load<Texture2D>("Time icon menu");
            Life_icon_menu = Global.Content.Load<Texture2D>("Life icon menu");
            for(int i = 0; i < 3; i++)
            {
                inventory.add_rune_ATK();
            }
            for (int i = 0; i < 4; i++)
            {
                inventory.add_rune_Armor();
            }
            for (int i = 0; i < 2; i++)
            {
                inventory.add_rune_time();
            }
            for (int i = 0; i < 100; i++)
            {
                stash.add_grace();
            }
            
            quest_selection.Add(new Quest_I());
            quest_selection.Add(new Quest_II());
            quest_selection.Add(new Quest_III());
            
        }
        public void load(Inventory inventory,Quest quest)
        {
            Deploy_Pos = Vector2.Zero;
            map = new Prepare_Page();
            this.Deploy_selected = false;
            this.Deploy_Confirm = false;
            grace_texture = Global.Content.Load<Texture2D>("Grace");
            font = Global.Content.Load<SpriteFont>("Inventory");
            this.inventory = inventory;
            for(int i = 0; i < this.inventory.Graces.Count; i++)
            {
                stash.add_grace();
            }
            this.inventory.Graces.Clear();
            this.quest = quest;
            if(this.quest.Quest_Completed == true)
            {
                if (quest.Quest_Code == 1)
                {
                    for (int i = 0; i < 75; i++)
                    {
                        stash.add_grace();
                    }
                }
                if (quest.Quest_Code == 2)
                {
                    for (int i = 0; i < 75; i++)
                    {
                        stash.add_grace();
                    }
                }
                if (quest.Quest_Code == 3)
                {
                    for (int i = 0; i < 75; i++)
                    {
                        stash.add_grace();
                    }
                }

            }
            this.quest = new Quest();
        }
        KeyboardState Oldkey;
        public override void Update(GameTime gameTime)
        {
            mouse = new Rectangle((int)Mouse.GetState().Position.X, (int)Mouse.GetState().Position.Y, 3, 3);
            Item_management();
            Deploy_check();
            Mission_Select();
            if (Keyboard.GetState().IsKeyDown(Keys.F1) && Oldkey.IsKeyUp(Keys.F1))
            {
                Restart();
            }
            base.Update(gameTime);
            Oldkey = Keyboard.GetState();
        }
        public override void Draw(GameTime gameTime)
        {

            Global.spriteBatch.Draw(map.BG,Vector2.Zero,Color.White);
            Global.spriteBatch.Draw(map.Map, map.Get_Map_Pos(), Color.White);
            Global.spriteBatch.Draw(Face_Icon, new Vector2(111,107), Color.White);
            Global.spriteBatch.Draw(ATK_icon_menu, new Vector2(50, 505), Color.White);
            Global.spriteBatch.Draw(Armor_icon_menu, new Vector2(184, 510), Color.White);
            Global.spriteBatch.Draw(Time_icon_menu, new Vector2(309, 510), Color.White);
            Global.spriteBatch.Draw(Life_icon_menu, new Vector2(445, 508), Color.White);
            for (int i = 0; i < 3; i++)
            {
                if (Deploy_Pos == map.Get_Deploy_select_pos(i))
                {
                    Global.spriteBatch.Draw(map.Deploy_select, map.Get_Deploy_Pos(i), Color.Yellow) ;
                }
                else
                {
                    Global.spriteBatch.Draw(map.Deploy_select, map.Get_Deploy_Pos(i), Color.White);
                }
            }
            if (mouse.Intersects(map.Get_Deploy_Button_Box()))
            {
                Global.spriteBatch.Draw(map.Deploy_Button, map.Get_Deploy_Button_pos(), Color.White*0.72f);
            }
            else 
            {
                Global.spriteBatch.Draw(map.Deploy_Button, map.Get_Deploy_Button_pos(), Color.White);
            }
            Global.spriteBatch.Draw(map.Rune_ATK_Texture, map.Rune_ATK_Pos, Color.White);
            Global.spriteBatch.Draw(map.Rune_Armor_Texture, map.Rune_Armor_Pos, Color.White);
            Global.spriteBatch.Draw(map.Rune_Time_Texture, map.Rune_Time_Pos, Color.White);
            Global.spriteBatch.Draw(map.Rune_Life_Texture, map.Rune_Life_Pos, Color.White);
            //
            Global.spriteBatch.Draw(map.Rune_ATK_Texture, new Vector2(654,704), Color.White);
            Global.spriteBatch.Draw(map.Rune_Armor_Texture, new Vector2(654,775), Color.White);
            Global.spriteBatch.Draw(map.Rune_Time_Texture, new Vector2(654,846), Color.White);
            Global.spriteBatch.Draw(map.Rune_Life_Texture, new Vector2(654,917), Color.White);
            for (int i = 0; i < 4; i++)
            {
                if (mouse.Intersects(map.InputItem_Box[i]))
                {
                    Global.spriteBatch.Draw(map.InputItem_Texture, map.InputItem_Pos[i], Color.SkyBlue*0.5f);
                }
                else
                {
                    Global.spriteBatch.Draw(map.InputItem_Texture, map.InputItem_Pos[i], Color.White);
                }
                if (mouse.Intersects(map.StoreItem_Box[i]))
                {
                    Global.spriteBatch.Draw(map.StoreItem_Texture, map.StoreItem_Pos[i], Color.SkyBlue * 0.5f);
                }
                else
                {
                    Global.spriteBatch.Draw(map.StoreItem_Texture, map.StoreItem_Pos[i], Color.White);
                }
                if (mouse.Intersects(map.SellButton_Box[i]))
                {
                    Global.spriteBatch.Draw(map.SellButton_Texture, map.SellButton_Pos[i], Color.SkyBlue*0.5f);
                }
                else
                {
                    Global.spriteBatch.Draw(map.SellButton_Texture, map.SellButton_Pos[i], Color.White);
                }
                if (mouse.Intersects(map.BuyItem_Box[i]))
                {
                    Global.spriteBatch.Draw(map.BuyItem_Texture, map.BuyItem_Pos[i], Color.SkyBlue * 0.5f);
                }
                else
                {
                    Global.spriteBatch.Draw(map.BuyItem_Texture, map.BuyItem_Pos[i], Color.White);
                }
            }
            if (mouse.Intersects(map.Upgrade_Inventory_Box))
            {
                Global.spriteBatch.Draw(map.Upgrade_Inventory_Texture, new Vector2(639, 636), Color.SkyBlue * 0.5f);
            }
            else
            {
                Global.spriteBatch.Draw(map.Upgrade_Inventory_Texture, new Vector2(639, 636), Color.White);
            }
            foreach(var Quest in quest_selection)
            {
                if (mouse.Intersects(Quest.Quest_Select_Box) && Quest.Quest_Done == false || Quest.Quest_Selected == true)
                {
                    Global.spriteBatch.Draw(Quest.Quest_Select_Texture, Quest.Quest_Select_Position, Color.White);
                }
                else if (Quest.Quest_Completed == true)
                {
                    Global.spriteBatch.Draw(Quest.Quest_Select_Texture, Quest.Quest_Select_Position, Color.Black * 0.6f);
                }
                else
                {
                    Global.spriteBatch.Draw(Quest.Quest_Select_Texture, Quest.Quest_Select_Position, Color.White * 0.6f);
                }
                if (quest == Quest)
                {
                    quest.Show_Detail();
                }
            }
           
            
            Global.spriteBatch.Draw(grace_texture, new Vector2(832, 636),null, Color.White,0f,Vector2.Zero,0.5f,SpriteEffects.None,0.5f);
            Global.spriteBatch.DrawString(font," : "+stash.Graces.Count+"  $", new Vector2(896, 644 ), Color.White);
            Global.spriteBatch.DrawString(font,""+ inventory.Rune_ATK.Count + " / " + stash.Rune_ATK.Count, new Vector2(192, 709+10), Color.White);
            Global.spriteBatch.DrawString(font,""+ inventory.Rune_Armor.Count + " / " + stash.Rune_Armor.Count, new Vector2(192, 782 + 10), Color.White);
            Global.spriteBatch.DrawString(font,"" + inventory.Rune_Times.Count + " / " + stash.Rune_Times.Count, new Vector2(192, 854 + 10), Color.White);
            Global.spriteBatch.DrawString(font,"" + inventory.Rune_Lives.Count + " / " + stash.Rune_Lives.Count, new Vector2(192, 927 + 10), Color.White);
            Global.spriteBatch.DrawString(font,"" + inventory.carry_weight + " / " + inventory.Max_weight+" Wt",new Vector2(416, 640),Color.White);
            Global.spriteBatch.DrawString(font, "Wt", new Vector2(282, 634),Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.weight_Rune_ATK.Get_Weight(), new Vector2(282, 709 + 10), Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.weight_Rune_Armor.Get_Weight() , new Vector2(282, 782 + 10), Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.weight_Rune_Time.Get_Weight() , new Vector2(282, 854 + 10), Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.weight_Rune_Life.Get_Weight() , new Vector2(282, 927 + 10), Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.weight_Rune_ATK.Get_Value() + " $", new Vector2(731, 709 + 10), Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.weight_Rune_Armor.Get_Value() + " $", new Vector2(731, 782 + 10), Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.weight_Rune_Time.Get_Value() + " $", new Vector2(731, 854 + 10), Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.weight_Rune_Life.Get_Value() + " $", new Vector2(731, 927 + 10), Color.White);
            Global.spriteBatch.DrawString(font, "" + Invectory_Upgrade_Cost + " $", new Vector2(774, 640), Color.White);
            Global.spriteBatch.DrawString(font, "" + (8.5f + (inventory.Rune_ATK.Count * Rune_ATK.Damage_plus)), new Vector2(96,516), Color.White);
            Global.spriteBatch.DrawString(font, "" +  (inventory.Rune_Armor.Count * Rune_Armor.HP_plus), new Vector2(244, 516), Color.White);
            Global.spriteBatch.DrawString(font, "" +(200+ (inventory.Rune_Times.Count * Rune_Time.time_plus)), new Vector2(373, 516), Color.White);
            Global.spriteBatch.DrawString(font, "" + inventory.Rune_Lives.Count, new Vector2(502, 516), Color.White);
                                  
            base.Draw(gameTime);
        }
        public override void Unload()
        {

            map = null;
            base.Unload();
        }
        public override void Debuging()
        {

            //Console.WriteLine("Deploy_Selected = {0}", Deploy_selected);
            //Console.WriteLine("Deploy_Confirm = {0}",Deploy_Confirm);
            //Console.WriteLine("Mouse = ({0},{1})",mouse.X,mouse.Y);
            Console.WriteLine("Deploye select[0] = ({0},{1})", map.Get_Deploy_select_Box(0).X, map.Get_Deploy_select_Box(0).Y);
            /* Console.WriteLine("Deploy_Pos = {0}", Deploy_Pos)*/
            ;
            //Console.WriteLine("Stash Grace num = " + Stash.Grace_num);
            base.Debuging();
        }
        
        public void Deploy_check()
        {
            for (int i = 0; i < 4; i++)
            {
                if (mouse.Intersects(map.Get_Deploy_select_Box(i)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Deploy_Pos = map.Get_Deploy_select_pos(i);
                    Deploy_selected = true;                   
                }
                if (Deploy_selected == true && mouse.Intersects(map.Get_Deploy_Button_Box()) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Deploy_Confirm = true;
                    this.quest.Quest_Selected = false;
                }
            }
        }
        MouseState Oldmouse;
        private void Item_management()
        {
            inventory.Cal_Weight();
            if (stash.Graces.Count >= Invectory_Upgrade_Cost)
            {
                if (mouse.Intersects(map.Upgrade_Inventory_Box) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released)
                {
                    inventory.Max_weight += 20;
                    for(int i = 0; i < Invectory_Upgrade_Cost; i++)
                    {
                        stash.Graces.Remove(stash.Graces[0]);
                    }
                }
            }
            //Input item
            if (stash.Rune_ATK.Count > 0)
            {
                if (mouse.Intersects(map.InputItem_Box[0]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released 
                    && inventory.carry_weight+inventory.weight_Rune_ATK.Get_Weight()<=inventory.Max_weight)
                {
                    inventory.add_rune_ATK();
                    stash.Rune_ATK.Remove(stash.Rune_ATK[0]);
                }
            }
            if (inventory.Rune_ATK.Count > 0)
            {
                if (mouse.Intersects(map.SellButton_Box[0]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released)
                {
                    for (int i = 0; i < (int)inventory.weight_Rune_ATK.Get_Value() / 2; i++)
                    {
                        stash.add_grace();
                    }
                    inventory.Rune_ATK.Remove(inventory.Rune_ATK[0]);
                }
            }
            if (stash.Rune_Armor.Count > 0)
            {
                if (mouse.Intersects(map.InputItem_Box[1]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released
                     && inventory.carry_weight + inventory.weight_Rune_Armor.Get_Weight() <= inventory.Max_weight)
                {
                    inventory.add_rune_Armor();
                    stash.Rune_Armor.Remove(stash.Rune_Armor[0]);
                }               
            }
            if (inventory.Rune_Armor.Count > 0)
            {
                if (mouse.Intersects(map.SellButton_Box[1]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released)
                {
                    for (int i = 0; i < (int)inventory.weight_Rune_Armor.Get_Value() / 2; i++)
                    {
                        stash.add_grace();
                    }
                    inventory.Rune_Armor.Remove(inventory.Rune_Armor[0]);
                }
            }
            if (stash.Rune_Lives.Count > 0)
            {
                if (mouse.Intersects(map.InputItem_Box[3]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released
                     && inventory.carry_weight + inventory.weight_Rune_Life.Get_Weight() <= inventory.Max_weight)
                {
                    inventory.add_rune_Life();
                    stash.Rune_Lives.Remove(stash.Rune_Lives[0]);
                }
            }
            if (inventory.Rune_Lives.Count > 0)
            {
                if (mouse.Intersects(map.SellButton_Box[3]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released)
                {
                    for (int i = 0; i < (int)inventory.weight_Rune_Life.Get_Value() / 2; i++)
                    {
                        stash.add_grace();
                    }
                    inventory.Rune_Lives.Remove(inventory.Rune_Lives[0]);
                }
            }
            if (stash.Rune_Times.Count > 0)
            {
                if (mouse.Intersects(map.InputItem_Box[2]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released
                     && inventory.carry_weight + inventory.weight_Rune_Time.Get_Weight() <= inventory.Max_weight)
                {
                    inventory.add_rune_time();
                    stash.Rune_Times.Remove(stash.Rune_Times[0]);
                }
            }
            if (inventory.Rune_Times.Count > 0)
            {
                if (mouse.Intersects(map.SellButton_Box[2]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released)
                {
                    for (int i = 0; i < (int)inventory.weight_Rune_Time.Get_Value() / 2; i++)
                    {
                        stash.add_grace();
                    }
                    inventory.Rune_Times.Remove(inventory.Rune_Times[0]);
                }
            }
            //Store itemn
            if (inventory.Rune_ATK.Count > 0)
            {
                if (mouse.Intersects(map.StoreItem_Box[0])&& Mouse.GetState().LeftButton == ButtonState.Pressed&&Oldmouse.LeftButton == ButtonState.Released)
                {
                    stash.add_rune_ATK();
                    inventory.Rune_ATK.Remove(inventory.Rune_ATK[0]);
                }
            }
            if (inventory.Rune_Armor.Count > 0)
            {
                if (mouse.Intersects(map.StoreItem_Box[1]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released)
                {
                    stash.add_rune_Armor();
                    inventory.Rune_Armor.Remove(inventory.Rune_Armor[0]);
                }
            }
            if (inventory.Rune_Lives.Count > 0)
            {
                if (mouse.Intersects(map.StoreItem_Box[3]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released)
                {
                    stash.add_rune_Life();
                    inventory.Rune_Lives.Remove(inventory.Rune_Lives[0]);
                }
            }
            if (inventory.Rune_Times.Count > 0)
            {
                if (mouse.Intersects(map.StoreItem_Box[2]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released)
                {
                    stash.add_rune_time();
                    inventory.Rune_Times.Remove(inventory.Rune_Times[0]);
                }
            }
            //Buy Item
            if (stash.Graces.Count >= inventory.weight_Rune_ATK.Get_Value())
            {
                if (mouse.Intersects(map.BuyItem_Box[0]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released&&stash.Graces.Count>=inventory.weight_Rune_ATK.Get_Value())
                {
                    stash.add_rune_ATK();
                    for(int i = 0; i < inventory.weight_Rune_ATK.Get_Value(); i++)
                    {
                        stash.Graces.Remove(stash.Graces[0]);
                    }
                    inventory.weight_Rune_ATK.Set_Value(8);
                }
            }
            if (stash.Graces.Count >= inventory.weight_Rune_Armor.Get_Value())
            {
                if (mouse.Intersects(map.BuyItem_Box[1]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released && stash.Graces.Count >= inventory.weight_Rune_Armor.Get_Value())
                {
                    stash.add_rune_Armor();
                    for (int i = 0; i < inventory.weight_Rune_Armor.Get_Value(); i++)
                    {
                        stash.Graces.Remove(stash.Graces[0]);
                    }
                    inventory.weight_Rune_Armor.Set_Value(5);
                }
            }
            if (stash.Graces.Count >= inventory.weight_Rune_Life.Get_Value())
            {
                if (mouse.Intersects(map.BuyItem_Box[3]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released && stash.Graces.Count >= inventory.weight_Rune_Life.Get_Value())
                {
                    stash.add_rune_Life();
                    for (int i = 0; i < inventory.weight_Rune_Life.Get_Value(); i++)
                    {
                        stash.Graces.Remove(stash.Graces[0]);
                    }
                    
                }
            }
            if (stash.Graces.Count >= inventory.weight_Rune_Time.Get_Value())
            {
                if (mouse.Intersects(map.BuyItem_Box[2]) && Mouse.GetState().LeftButton == ButtonState.Pressed && Oldmouse.LeftButton == ButtonState.Released && stash.Graces.Count >= inventory.weight_Rune_Time.Get_Value())
                {
                    stash.add_rune_time();
                    for (int i = 0; i < inventory.weight_Rune_Time.Get_Value(); i++)
                    {
                        stash.Graces.Remove(stash.Graces[0]);
                    }
                    inventory.weight_Rune_Time.Set_Value(5);
                }
            }
            Oldmouse = Mouse.GetState();
        }
        private void Mission_Select()
        {
            foreach(var Quest in quest_selection)
            {
                if (mouse.Intersects(Quest.Quest_Select_Box) && Mouse.GetState().LeftButton == ButtonState.Pressed && Quest.Quest_Completed == false)
                {
                    quest.Quest_Selected = false;
                    quest = Quest;
                    quest.Quest_Selected = true;
                }
            }
           
        }
        public void Reset()
        {

        }
        private void Restart()
        {
            inventory.Clear_All();
            stash.Clear_All();
            quest_selection.Clear();
            for (int i = 0; i < 3; i++)
            {
                inventory.add_rune_ATK();
            }
            for (int i = 0; i < 4; i++)
            {
                inventory.add_rune_Armor();
            }
            for (int i = 0; i < 2; i++)
            {
                inventory.add_rune_time();
            }
            for (int i = 0; i < 100; i++)
            {
                stash.add_grace();
            }
            inventory.weight_Rune_Armor.Reset_Value();
            inventory.weight_Rune_ATK.Reset_Value();
            inventory.weight_Rune_Life.Reset_Value();
            inventory.weight_Rune_Time.Reset_Value();
            quest_selection.Add(new Quest_I());
            quest_selection.Add(new Quest_II());
            quest_selection.Add(new Quest_III());
        }
    }
}
