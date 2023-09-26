using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Core;
using Raid.Enemy;
using Raid.Enviroment;
using Raid.Item;
using Raid.MainCharacter;
using System;
using System.Collections.Generic;

namespace Raid.Screen_Code
{
    public class Screen_Gameplay:Screen
    {
        int enemyclosemax = 25;
        int enemyRangemax = 6;
        int enemyBossmax = 1;
        Random random = new Random();
        public Main_Char Main_Char;
        List<EnemyClose> enemyClose = new List<EnemyClose>();
        List<EnemyRange> enemyRanges = new List<EnemyRange>();
        List<EnemyBoss> enemyBosses = new List<EnemyBoss>();
        Map map;
        Camera Camera;       
        public List<Grace> graces = new List<Grace>();  
        bool Hit =false;
        public Extract_gate[] extract_Gate;
        public bool Extract_success;
        public bool Extract_fail;
        private Time Time;
        private Vector2 Camera_Pos;
        Texture2D Pos;
        Texture2D Blood_Feedback;
        public Quest Quest;
        public Screen_Gameplay() 
        { 
        }
        public override void load(Vector2 Deploy_Pos)
        {                      
            Main_Char = new Main_Char();
            for(int i = 0; i < enemyclosemax; i++)
            {
                enemyClose.Add(new EnemyClose(new Vector2(random.Next(2400,3000),random.Next(5000,6000))));                
            }
            for (int i = 0; i < enemyRangemax; i++)
            {           
                enemyRanges.Add(new EnemyRange(new Vector2(random.Next(2400, 3000), random.Next(5000, 6000))));
            }
            for(int i = 0; i < enemyBossmax; i++)
            {
                enemyBosses.Add(new EnemyBoss(new Vector2(random.Next(2400, 3000), random.Next(5000,6000))));
            }
            Extract_fail = false;
            Extract_success = false;
            map = new Map();                                 
            extract_Gate = new Extract_gate[3];
            extract_Gate[0] = new Extract_gate(new Vector2(2238,6153));
            extract_Gate[1] = new Extract_gate(new Vector2(5547,4563));
            extract_Gate[2] = new Extract_gate(new Vector2(2001,4145));
            Main_Char.Deploy(Deploy_Pos);                                   
            Camera = new Camera();            
            Camera_Pos = Main_Char.Get_Pos();
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count *Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
        }
        public void load(Vector2 Deploy_Pos,Inventory inventory,Quest quest)
        {
            Main_Char = new Main_Char();
            Main_Char.inventory = inventory;
            for (int i = 0; i < enemyclosemax; i++)
            {
                enemyClose.Add(new EnemyClose(new Vector2(random.Next(2400, 3000), random.Next(5000, 6000))));
            }
            for (int i = 0; i < enemyRangemax; i++)
            {
                enemyRanges.Add(new EnemyRange(new Vector2(random.Next(2400, 3000), random.Next(5000, 6000))));
            }
            for (int i = 0; i < enemyBossmax; i++)
            {
                enemyBosses.Add(new EnemyBoss(new Vector2(random.Next(2400, 3000), random.Next(5000, 6000))));
            }
            Extract_fail = false;
            Extract_success = false;
            map = new Map();
            extract_Gate = new Extract_gate[3];
            extract_Gate[0] = new Extract_gate(new Vector2(2238, 6153));
            extract_Gate[1] = new Extract_gate(new Vector2(5547, 4563));
            extract_Gate[2] = new Extract_gate(new Vector2(2001, 4145));
            Main_Char.Deploy(Deploy_Pos);
            Camera = new Camera();
            Camera_Pos = Main_Char.Get_Pos();
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count * Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
            this.Quest = quest;            
        }
        public void load(Vector2 Deploy_Pos, Inventory inventory)
        {

            Main_Char = new Main_Char();
            Main_Char.inventory = inventory;
            for (int i = 0; i < enemyclosemax; i++)
            {
                enemyClose.Add(new EnemyClose(new Vector2(random.Next(2400, 3000), random.Next(5000, 6000))));
            }
            for (int i = 0; i < enemyRangemax; i++)
            {
                enemyRanges.Add(new EnemyRange(new Vector2(random.Next(2400, 3000), random.Next(5000, 6000))));
            }
            for (int i = 0; i < enemyBossmax; i++)
            {
                enemyBosses.Add(new EnemyBoss(new Vector2(random.Next(2400, 3000), random.Next(5000, 6000))));
            }
            Extract_fail = false;
            Extract_success = false;
            map = new Map();
            extract_Gate = new Extract_gate[3];
            extract_Gate[0] = new Extract_gate(new Vector2(2238, 6153));
            extract_Gate[1] = new Extract_gate(new Vector2(5547, 4563));
            extract_Gate[2] = new Extract_gate(new Vector2(2001, 4145));
            Main_Char.Deploy(Deploy_Pos);
            Camera = new Camera();
            Camera_Pos = Main_Char.Get_Pos();
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count * Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
            
        }        
        float SceneEnd_time = 0;
        public override void Update(GameTime gameTime)
        {
            Main_Char.Update();
            Camera.CameraPos_Update(Camera_Pos);
            Camera_Movement();            
            if (Main_Char.Alive == true)
            {
                Extractionsystem();
                lootingsystem();
                Time.Time_Count();
                for (int i = 0; i < enemyClose.Count; i++)
                {
                    if (enemyClose[i].Alive == false)
                    {
                        graces.Add(new Grace(enemyClose[i].Get_Pos()));
                        enemyClose.Remove(enemyClose[i]);
                        break;
                    }
                    enemyClose[i].Update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));                   
                        if (enemyClose[i].Enemy_is_attack == true)
                        {
                            if (Main_Char.ATK_state != 3)
                            {
                                Main_Char.Get_Dmg(enemyClose[i].Enemt_ATK_DMG);
                                feedback_time_start = true;
                                break;
                            }
                        }
                        if (enemyClose[i].immune == false)
                        {
                            if (Main_Char.ATK_state == 1)
                            {
                                if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyClose[i].Get_Pos().Y <= Main_Char.Get_Pos().Y+48 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyClose[i].Get_Pos().Y >= Main_Char.Get_Pos().Y- 48 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyClose[i].Get_Pos().X <= Main_Char.Get_Pos().X+ 48 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyClose[i].Get_Pos().X >= Main_Char.Get_Pos().X- 48 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus(); 
                                        break;
                                    }
                                }

                            }
                            if (Main_Char.ATK_state == 2)
                            {
                                if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyClose[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 48 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;

                                    }
                                }
                                if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyClose[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 48 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyClose[i].Get_Pos().X <= Main_Char.Get_Pos().X + 48 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyClose[i].Get_Pos().X >= Main_Char.Get_Pos().X - 48 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                            }
                            if (Main_Char.ATK_state == 4)
                            {
                                if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 45 && enemyClose[i].immune == false)
                                {
                                    enemyClose[i].Get_DMG(Main_Char.Roll_ATK);
                                    enemyClose[i].stunt = true;
                                    enemyClose[i].immune = true;
                                    break;
                                }
                            }
                        }
                   
                    }
                for (int i = 0; i < enemyRanges.Count; i++)
                {
                    if (enemyRanges[i].Alive == false)
                    {
                        graces.Add(new Grace(enemyRanges[i].Get_Pos()));
                        enemyRanges.Remove(enemyRanges[i]);
                        break;
                    }
                    enemyRanges[i].update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));
                    if (enemyRanges[i].fire_ball.Count > 0)
                    {
                        if (enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count-1].Return_box().Intersects(Main_Char.Get_Box()))
                        {
                            if (Main_Char.ATK_state != 3)
                            {
                                Main_Char.Get_Dmg(enemyRanges[i].Enemt_ATK_DMG);
                                feedback_time_start = true;
                                enemyRanges[i].fire_ball.Remove(enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1]);
                                break;
                            }
                        }
                    }
                    if (enemyRanges[i].immune == false)
                    {
                        if (Main_Char.ATK_state == 1)
                        {
                            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyRanges[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyRanges[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyRanges[i].Get_Pos().X <= Main_Char.Get_Pos().X + 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyRanges[i].Get_Pos().X >= Main_Char.Get_Pos().X - 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }

                        }
                        if (Main_Char.ATK_state == 2)
                        {
                            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyRanges[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;

                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyRanges[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyRanges[i].Get_Pos().X <= Main_Char.Get_Pos().X + 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyRanges[i].Get_Pos().X >= Main_Char.Get_Pos().X - 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;
                                }
                            }
                        }
                        if (Main_Char.ATK_state == 4)
                        {
                            if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 45 && enemyRanges[i].immune == false)
                            {
                                enemyRanges[i].Get_DMG(Main_Char.Roll_ATK);
                                enemyRanges[i].stunt = true;
                                enemyRanges[i].immune = true;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < enemyBosses.Count; i++)
                {
                    if (enemyBosses[i].Alive == false)
                    {
                        graces.Add(new Grace(enemyBosses[i].Get_Pos()));
                        enemyBosses.Remove(enemyBosses[i]);
                        if(Quest.Quest_Code == 1)
                        {
                            Quest.Quest_Done = true;
                        }
                        break;
                    }
                    enemyBosses[i].Update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));
                    if (enemyBosses[i].Enemy_is_attack == true)
                    {
                        if (Main_Char.ATK_state != 3)
                        {
                            Main_Char.Get_Dmg(enemyBosses[i].Enemt_ATK_DMG);
                            feedback_time_start = true;
                            break;
                        }
                    }
                    if (enemyBosses[i].immune == false)
                    {
                        if (Main_Char.ATK_state == 1)
                        {
                            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 * 1.2f && enemyBosses[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 48 * 1.2f && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 * 1.2f && enemyBosses[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 48 * 1.2f && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 * 1.2f && enemyBosses[i].Get_Pos().X <= Main_Char.Get_Pos().X + 48 * 1.2f && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 * 1.2f && enemyBosses[i].Get_Pos().X >= Main_Char.Get_Pos().X - 48 * 1.2f && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }

                        }
                        if (Main_Char.ATK_state == 2)
                        {
                            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 * 1.2f && enemyBosses[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 48 * 1.2f && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;

                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 * 1.2f && enemyBosses[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 48 * 1.2f && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 * 1.2f && enemyBosses[i].Get_Pos().X <= Main_Char.Get_Pos().X + 48 * 1.2f && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 * 1.2f && enemyBosses[i].Get_Pos().X >= Main_Char.Get_Pos().X - 48 * 1.2f && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                        }
                        if (Main_Char.ATK_state == 4)
                        {
                            if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 45*1.2f && enemyBosses[i].immune == false)
                            {
                                enemyBosses[i].Get_DMG(Main_Char.Roll_ATK);
                                enemyBosses[i].stunt = true;
                                enemyBosses[i].immune = true;
                                break;
                            }
                        }
                    }

                }
                if (Time.Get_Time_Count() <= 0)
                {
                    Main_Char.Alive = false;
                }
            }
            if(Main_Char.Alive == false)
            {
                SceneEnd_time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                Quest.Quest_Done = false;
                if(SceneEnd_time >= 4)
                {
                    Extract_fail = true;
                    Main_Char.inventory.Graces.Clear();
                    Main_Char.inventory.Rune_Armor.Clear();
                    Main_Char.inventory.Rune_ATK.Clear();
                    Main_Char.inventory.Rune_Lives.Clear();
                    Main_Char.inventory.Rune_Times.Clear();
                }
            }            
                base.Update(gameTime);            
        }
        public override void Draw(GameTime gameTime)
        {
            Draw_Form_Pos_inWorld();
            Draw_UI();
            Global.spriteBatch.Draw(Pos,Camera.Object_Vector(Main_Char.Get_Pos()), new Rectangle(-3,-3, 6, 6), Color.White);
            if (enemyBosses.Count > 0)
            {
                for(int i = 0; i < enemyBosses.Count; i++)
                {
                    Global.spriteBatch.Draw(Pos, Camera.Object_Vector(enemyBosses[i].Get_Pos()), new Rectangle(-3, -3, 6, 6), Color.White);
                }
            }
            base.Draw(gameTime);
        }    
        public override void Unload()
        {                               
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Enemy_number = " + enemyClose.Count);
            Console.WriteLine("grace num ="+Main_Char.inventory.Graces.Count);                       
            Console.WriteLine("Intersect = {0}",Main_Char.Get_Box().Intersects(extract_Gate[0].Get_Box()));
            Console.WriteLine("Intersect = {0}", Main_Char.Get_Box().Intersects(extract_Gate[1].Get_Box()));
            Console.WriteLine("Intersect = {0}", Main_Char.Get_Box().Intersects(extract_Gate[2].Get_Box()));
            Console.WriteLine("Key E = {0}",Keyboard.GetState().IsKeyDown(Keys.E));
            base.Debuging();
        }
        ///////////////////////////////////////////////////////////////////////// Main-method /////////////////////////////////////////////////////       
        public void lootingsystem()
        {
            Main_Char.inventory.Cal_Weight();
            for (int i = 0; i < graces.Count;i++)
            {
                if (graces[i].Get_Grace_Hitbox().Intersects(Main_Char.Get_Box()) && Keyboard.GetState().IsKeyDown(Keys.E) && Main_Char.inventory.carry_weight + Main_Char.inventory.weight_Grace.Get_Weight() <= Main_Char.inventory.Max_weight) 
                {
                    graces.Remove(graces[i]);
                    Main_Char.inventory.add_grace();
                    break;
                }
            }

        }
        private void Extractionsystem()
        {
            for (int i = 0; i < extract_Gate.Length; i++)
            {
                if (extract_Gate[i].Get_Box().Intersects(Main_Char.Get_Box()) && Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    Extract_success = true;
                    if (Quest.Quest_Code != 0)
                    {
                        if (Quest.Quest_Done == true)
                        {
                            Quest.Quest_Completed = true;
                        }
                    }
                    break;
                }
            }
        }       
       
        private void Draw_Form_Pos_inWorld()
        {
            for (int i = 0; i < 13; i++)
            {
                if (Main_Char.Get_Pos().Y > map.Get_Map_Pos(i).Y - 700 && Main_Char.Get_Pos().Y < map.Get_Map_Pos(i).Y + map.Get_Map_Texture(i).Height + 700 && Main_Char.Get_Pos().X > map.Get_Map_Pos(i).X - 700 && Main_Char.Get_Pos().X < map.Get_Map_Pos(i).X + map.Get_Map_Texture(i).Width + 700)
                {
                    Global.spriteBatch.Draw(map.Get_Map_Texture(i), Camera.Object_Vector(map.Get_Map_Pos(i)), Color.White);
                    
                }
            }
            Global.spriteBatch.Draw(extract_Gate[0].Get_Texture(), Camera.Object_Vector(extract_Gate[0].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[1].Get_Texture(), Camera.Object_Vector(extract_Gate[1].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[2].Get_Texture(), Camera.Object_Vector(extract_Gate[2].Get_Position()), Color.White);
            
            for (int i = 0; i < enemyClose.Count; i++)
            {
                enemyClose[i].animate(Camera.Object_Vector(enemyClose[i].Get_Pos()));
                
            }
            for(int i = 0;i< enemyRanges.Count; i++)
            {
                enemyRanges[i].animate(Camera.Object_Vector(enemyRanges[i].Get_Pos()));
                if (enemyRanges[i].fire_ball.Count > 0)
                {
                    enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1].animate(Camera.Object_Vector(enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1].Return_Pos()));
                    
                }
            }
            for(int i = 0;i<enemyBosses.Count;i++)
            {
                enemyBosses[i].animate(Camera.Object_Vector(enemyBosses[i].Get_Pos()));
            }
          
            for(int i = 0; i < graces.Count; i++)
            {
                    Global.spriteBatch.Draw(graces[i].Get_Grace_Texture(),Camera.Object_Vector( graces[i].Get_GracePosition()),null, Color.White,0f,Vector2.Zero,0.5f,SpriteEffects.None,0.5f);
            }            
            Main_Char.animate(Camera.Object_Vector(Main_Char.Get_Pos()));


        }
        double feedback_time = 0;
        bool feedback_time_start = false;
        private void Draw_UI()
        {
            
            if(feedback_time_start == true)
            {
                feedback_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;                
                Global.spriteBatch.Draw(Blood_Feedback, Vector2.Zero,null, Color.White*0.7f,0f,Vector2.Zero,1.35f,SpriteEffects.None,0.5f);
                if (feedback_time >= 0.5)
                {
                    feedback_time = 0;
                    feedback_time_start = false;
                }
            }
            
            Global.spriteBatch.DrawString(Time.GetSpriteFont(),"Time = "+this.Time.Get_Time_Count(), new Vector2(480, 0), Color.White);
            Global.spriteBatch.DrawString(Time.GetSpriteFont(), "HitSteak = " + Main_Char.Hitsteak, new Vector2(550, 500), Color.DarkRed);
            Global.spriteBatch.DrawString(Time.GetSpriteFont(), "HP:" + Main_Char.HP, new Vector2(50,0), Color.Black);
            Global.spriteBatch.DrawString(Time.GetSpriteFont(),"Wt :" +(float)Main_Char.inventory.carry_weight+" / "+Main_Char.inventory.Max_weight, new Vector2(910,680), Color.White);
            if(Quest.Quest_Code != 0)
            {
                Global.spriteBatch.DrawString(Quest.Quest_Detail_font, Quest.Quest_Detail_string, new Vector2(1000, 0), Color.White);
            }
        }
        public void Reset()
        {
             SceneEnd_time = 0;

            enemyClose.Clear();
            enemyRanges.Clear();
            enemyBosses.Clear();
            graces.Clear();
        }
        private float Camera_Time = 0;        
        private void Camera_Movement()
        {
            float Camera_acceleration_X = 6.0f;
            float Camera_acceleration_Y = 3.75f;
            float Lenght_x = (Global.GraphicsDevice.PreferredBackBufferHeight/4)/2.5f;
            float Lenght_y = (Global.GraphicsDevice.PreferredBackBufferHeight/4)/2.5f;
            
            if (Main_Char.Curt_state == 5)
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.X < Main_Char.Get_Pos().X)
                {
                    Camera_Pos.X += Camera_acceleration_X * Camera_Time;  
                    if(Camera_Pos.X > Main_Char.Get_Pos().X )
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X;
                    }
                }
                else if (Camera_Pos.X > Main_Char.Get_Pos().X)
                {
                    Camera_Pos.X -= Camera_acceleration_X * Camera_Time; 
                    if (Camera_Pos.X < Main_Char.Get_Pos().X)
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X;
                    }
                }               
                if(Camera_Pos.Y > Main_Char.Get_Pos().Y- Lenght_y)
                {
                    Camera_Pos.Y -= Main_Char.Get_speed() + Camera_acceleration_Y * Camera_Time; 
                    if(Camera_Pos.Y < Main_Char.Get_Pos().Y - Lenght_y)
                    {
                        Camera_Pos.Y = Main_Char.Get_Pos().Y - Lenght_y;
                    }
                }               
            }
            if (Main_Char.Curt_state == 6)
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.X < Main_Char.Get_Pos().X)
                {
                    Camera_Pos.X += Camera_acceleration_X * Camera_Time;
                    if (Camera_Pos.X > Main_Char.Get_Pos().X)
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X;
                    }
                }
                else if (Camera_Pos.X > Main_Char.Get_Pos().X)
                {
                    Camera_Pos.X -= Camera_acceleration_X * Camera_Time;
                    if (Camera_Pos.X < Main_Char.Get_Pos().X)
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X;
                    }
                }
                if (Camera_Pos.Y < Main_Char.Get_Pos().Y + Lenght_y)
                {
                    Camera_Pos.Y += Main_Char.Get_speed() + Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y > Main_Char.Get_Pos().Y + Lenght_y)
                    {
                        Camera_Pos.Y = Main_Char.Get_Pos().Y + Lenght_y;
                    }
                }

            }
            if (Main_Char.Curt_state == 7)
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.Y < Main_Char.Get_Pos().Y)
                {
                    Camera_Pos.Y += Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y > Main_Char.Get_Pos().Y)
                    {
                        Camera_Pos.Y = Main_Char.Get_Pos().Y;
                    }
                }
                else if (Camera_Pos.Y > Main_Char.Get_Pos().Y)
                {
                    Camera_Pos.Y -= Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y < Main_Char.Get_Pos().Y)
                    {
                        Camera_Pos.Y = Main_Char.Get_Pos().Y;
                    }
                }
                if (Camera_Pos.X > Main_Char.Get_Pos().X - Lenght_x)
                {
                    Camera_Pos.X -= Main_Char.Get_speed() + Camera_acceleration_X * Camera_Time;
                    if (Camera_Pos.X < Main_Char.Get_Pos().X - Lenght_x)
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X - Lenght_x;
                    }
                }

            }
            if (Main_Char.Curt_state == 8)
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.Y < Main_Char.Get_Pos().Y)
                {
                    Camera_Pos.Y += Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y > Main_Char.Get_Pos().Y)
                    {
                        Camera_Pos.Y = Main_Char.Get_Pos().Y;
                    }
                }
                else if (Camera_Pos.Y > Main_Char.Get_Pos().Y)
                {
                    Camera_Pos.Y -= Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y < Main_Char.Get_Pos().Y)
                    {
                        Camera_Pos.Y = Main_Char.Get_Pos().Y;
                    }
                }
                if (Camera_Pos.X < Main_Char.Get_Pos().X + Lenght_x)
                {
                    Camera_Pos.X += Main_Char.Get_speed() + Camera_acceleration_X * Camera_Time;
                    if (Camera_Pos.X > Main_Char.Get_Pos().X + Lenght_x)
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X + Lenght_x;
                    }
                }

            }
            if(Main_Char.Curt_state == 1||Main_Char.Curt_state == 2|| Main_Char.Curt_state == 3|| Main_Char.Curt_state == 4)
            {
                Camera_Time = 0;
            }
        }
    }
}
