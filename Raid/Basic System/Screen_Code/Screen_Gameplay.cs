using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Raid.Basic_System;
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
        int enemyclosemax = 0;
        int enemyRangemax = 0;
        int enemyBossmax = 0;
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
    
        Texture2D Pos;
        Texture2D Blood_Feedback;       
        public Quest Quest;
        private HP_BAR HP_BAR;
        private Hitstrak_Bar Hitstreak_bar;
        private Weight_UI Weight_UI;
        private Buiding[] Buidings = new Buiding[1];
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
            Camera = new Camera(Main_Char.Get_Pos());                       
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count *Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
            HP_BAR = new HP_BAR();
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
            extract_Gate[0] = new Extract_gate(new Vector2(4573, 9479));
            extract_Gate[1] = new Extract_gate(new Vector2(4618, 6774));
            extract_Gate[2] = new Extract_gate(new Vector2(9317, 6618));
            Main_Char.Deploy(Deploy_Pos);
            Camera = new Camera(Main_Char.Get_Pos());
            Camera.Load();
            MediaPlayer.Play(Audio.Wind_ambient);
            MediaPlayer.IsRepeating = true;
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count * Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
            this.Quest = quest;
            HP_BAR = new HP_BAR();
            Hitstreak_bar = new Hitstrak_Bar();
            Weight_UI = new Weight_UI();
            Buidings[0] = new House_Contryside_font(new Vector2(2688, 5897));
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
            Camera = new Camera(Main_Char.Get_Pos());
            
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count * Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");

        }
        float SceneEnd_time = 0;
        public override void Update(GameTime gameTime)
        {
            foreach(var buiding in Buidings)
            {
                buiding.Layer = 3;
                buiding.Trans = false;
            }           
            Main_Char.Update();
            Collision();
            Main_Char.Last_Pos = Main_Char.Get_Pos();
            Camera.Camera_Movement(Main_Char);            
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

                    //ENEMY Trans building vheck
                    for (int n = 0; n < Buidings.Length; n++)
                    {
                        if (Buidings[n].Layer == 3)
                        {
                            if (enemyClose[n].Box.Intersects(Buidings[n].Box_Trans))
                            {
                                Buidings[n].Layer = 2;
                                Buidings[n].Trans = true;
                            }
                            else
                            {
                                Buidings[n].Layer = 3;
                            }
                        }
                    }
                    enemyClose[i].Last_Pos = enemyClose[i].Get_Pos();
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
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 90 && enemyClose[i].Get_Pos().Y <= Main_Char.Get_Pos().Y+96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Commom_ATK_Push,Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 90 && enemyClose[i].Get_Pos().Y >= Main_Char.Get_Pos().Y- 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 90 && enemyClose[i].Get_Pos().X <= Main_Char.Get_Pos().X+ 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        enemyClose[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                        Camera.CameraShake();
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 90 && enemyClose[i].Get_Pos().X >= Main_Char.Get_Pos().X- 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        Camera.CameraShake(); 
                                        enemyClose[i].Get_Push(Main_Char.Commom_ATK_Push,Main_Char.Get_Pos());
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
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 90 && enemyClose[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;

                                    }
                                }
                                if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 90 && enemyClose[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 90 && enemyClose[i].Get_Pos().X <= Main_Char.Get_Pos().X + 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 90 && enemyClose[i].Get_Pos().X >= Main_Char.Get_Pos().X - 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        enemyClose[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                        Camera.CameraShake();
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                            }
                            if (Main_Char.ATK_state == 4)
                            {
                                if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 90 && enemyClose[i].immune == false)
                                {
                                    enemyClose[i].Get_DMG(Main_Char.Roll_ATK);
                                    enemyClose[i].Get_Push(Main_Char.Roll_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
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
                    enemyRanges[i].Update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));
                    enemyRanges[i].Last_Pos = enemyRanges[i].Get_Pos();

                    //ENEMY Trans building vheck
                    for (int n = 0; n < Buidings.Length; n++)
                    {
                        if (Buidings[n].Layer == 3)
                        {
                            if (enemyRanges[i].Box.Intersects(Buidings[n].Box_Trans))
                            {
                                Buidings[n].Layer = 2;
                                Buidings[n].Trans = true;
                            }
                            else
                            {
                                Buidings[n].Layer = 3;
                            }
                        }
                    }
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
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 35 && enemyRanges[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 35 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 35 && enemyRanges[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 35 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 35 && enemyRanges[i].Get_Pos().X <= Main_Char.Get_Pos().X + 35 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 35 && enemyRanges[i].Get_Pos().X >= Main_Char.Get_Pos().X - 35 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
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
                                    enemyRanges[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
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
                                    enemyRanges[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
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
                                    enemyRanges[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
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
                                    enemyRanges[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;
                                }
                            }
                        }
                        if (Main_Char.ATK_state == 4)
                        {
                            if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 48 && enemyRanges[i].immune == false)
                            {
                                enemyRanges[i].Get_DMG(Main_Char.Roll_ATK);
                                enemyRanges[i].Get_Push(Main_Char.Roll_ATK_Push, Main_Char.Get_Pos());
                                Camera.CameraShake();
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
                    enemyBosses[i].Last_Pos = enemyBosses[i].Get_Pos();
                    //ENEMY Trans building vheck
                    for (int n = 0; n < Buidings.Length; n++)
                    {
                        if (Buidings[n].Layer == 3)
                        {
                            if (enemyBosses[i].Box.Intersects(Buidings[n].Box_Trans))
                            {
                                Buidings[n].Layer = 2;
                                Buidings[n].Trans = true;
                            }
                            else
                            {
                                Buidings[n].Layer = 3;
                            }
                        }
                    }
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
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 164 && enemyBosses[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 164 && enemyBosses[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 164 && enemyBosses[i].Get_Pos().X <= Main_Char.Get_Pos().X + 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 164 && enemyBosses[i].Get_Pos().X >= Main_Char.Get_Pos().X - 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
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
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 164 && enemyBosses[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;

                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 164 && enemyBosses[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 164 && enemyBosses[i].Get_Pos().X <= Main_Char.Get_Pos().X + 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 164 && enemyBosses[i].Get_Pos().X >= Main_Char.Get_Pos().X - 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                        }
                        if (Main_Char.ATK_state == 4)
                        {
                            if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 164 && enemyBosses[i].immune == false)
                            {
                                enemyBosses[i].Get_DMG(Main_Char.Roll_ATK);
                                enemyBosses[i].Get_Push(Main_Char.Roll_ATK_Push, Main_Char.Get_Pos());
                                Camera.CameraShake();
                                enemyBosses[i].stunt = true;
                                enemyBosses[i].immune = true;
                                break;
                            }
                        }
                    }

                }
                //Player check trans building
                for (int i = 0; i < Buidings.Length; i++)
                {
                    if (Main_Char.Box.Intersects(Buidings[i].Box_Trans) == false)
                    {
                        Buidings[i].Layer = 3;
                    }
                    if (Main_Char.Box.Intersects(Buidings[i].Box_Trans))
                    {
                        Buidings[i].Layer = 1;
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
            base.Draw(gameTime);
        }
            
        public override void Unload()
        {                               
            base.Unload();
        }
        public override void Debuging()
        {
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
            //MAP
            for (int i = 0; i < map.num_zone; i++)
            {
                if (Main_Char.Get_Pos().Y > map.Get_Map_Pos(i).Y - 1400 && Main_Char.Get_Pos().Y < map.Get_Map_Pos(i).Y + map.Get_Map_Texture(i).Height + 1400 && Main_Char.Get_Pos().X > map.Get_Map_Pos(i).X - 1400 && Main_Char.Get_Pos().X < map.Get_Map_Pos(i).X + map.Get_Map_Texture(i).Width + 1400)
                {
                    Global.spriteBatch.Draw(map.Get_Map_Texture(i), Camera.Object_Vector(map.Get_Map_Pos(i)), Color.White);
                    
                }
            }
            //EXTRACT GATE
            Global.spriteBatch.Draw(extract_Gate[0].Get_Texture(), Camera.Object_Vector(extract_Gate[0].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[1].Get_Texture(), Camera.Object_Vector(extract_Gate[1].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[2].Get_Texture(), Camera.Object_Vector(extract_Gate[2].Get_Position()), Color.White);

            //BUILDING LAYER 3
            foreach(var buidling in Buidings)
            {
                if (buidling.Layer ==3)
                {
                    buidling.Show(Camera.Object_Vector(buidling.Get_Pos()));
                }
            }

            //TREES LAYER2
            foreach (var buidling in Buidings)
            {
                if (buidling.Layer == 2)
                {
                    buidling.Show(Camera.Object_Vector(buidling.Get_Pos()));
                }
            }
            //GRACE
            for (int i = 0; i < graces.Count; i++)
            {
                Global.spriteBatch.Draw(graces[i].Get_Grace_Texture(), Camera.Object_Vector(graces[i].Get_GracePosition()), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.5f);
            }

            //ENEMY
            for (int i = 0; i < enemyClose.Count; i++)
            {
                enemyClose[i].animate(Camera.Object_Vector(enemyClose[i].Get_Pos()));
                
            }            
            for(int i = 0;i<enemyBosses.Count;i++)
            {
                enemyBosses[i].animate(Camera.Object_Vector(enemyBosses[i].Get_Pos()));
            }
            for (int i = 0; i < enemyRanges.Count; i++)
            {
                enemyRanges[i].animate(Camera.Object_Vector(enemyRanges[i].Get_Pos()));
                if (enemyRanges[i].fire_ball.Count > 0)
                {
                    enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1].animate(Camera.Object_Vector(enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1].Return_Pos()));

                }
            }
            for(int i = 0; i < Main_Char.Get_FrameEffect().Count; i++)
            {
                Main_Char.Get_FrameEffect()[i].Animate(Camera.Object_Vector(Main_Char.Get_FrameEffect()[i].Get_Vector()));
            }

            //BUILDING LAYER 2

            //PLAYER
            Main_Char.animate(Camera.Object_Vector(Main_Char.Get_Pos()));

            //MAP SHADOW
            for (int i = 0; i < map.num_zone; i++)
            {
                if (Main_Char.Get_Pos().Y > map.Get_Map_Pos(i).Y - 1400 && Main_Char.Get_Pos().Y < map.Get_Map_Pos(i).Y + map.Get_Map_Texture(i).Height + 1400 && Main_Char.Get_Pos().X > map.Get_Map_Pos(i).X - 1400 && Main_Char.Get_Pos().X < map.Get_Map_Pos(i).X + map.Get_Map_Texture(i).Width + 1400)
                {
                    Global.spriteBatch.Draw(map.Get_Map_Shadow(i), Camera.Object_Vector(map.Get_Map_Pos(i)), Color.White);

                }
            }
            //TREES LAYER1

            //BUILDING LAYER 1
            foreach (var buidling in Buidings)
            {
                if (buidling.Layer == 1)
                {
                    buidling.Show(Camera.Object_Vector(buidling.Get_Pos()));
                }
            }





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
            Time.animate();           
            if(Quest.Quest_Code != 0)
            {
                if (Quest.Quest_Done == false)
                {
                    Global.spriteBatch.DrawString(Quest.Quest_Detail_font, Quest.Quest_Detail_string, new Vector2(862,48), Color.WhiteSmoke,0f,Vector2.Zero,1.5f,SpriteEffects.None,0.5f);
                }
                else if(Quest.Quest_Done == true) 
                {
                    Global.spriteBatch.DrawString(Quest.Quest_Detail_font, Quest.Quest_Detail_string, new Vector2(862,48), Color.WhiteSmoke * 0.4f,0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.5f);
                }
            }
            
                Global.spriteBatch.Draw(HP_BAR.HP_Bar, HP_BAR.HP_pos, null, Color.White, 0f, Vector2.Zero, new Vector2((float)Main_Char.HP / 30,1), SpriteEffects.None, 0.5f);                                      
                Global.spriteBatch.Draw(HP_BAR.Armmor_Bar, HP_BAR.Armmor_Pos, null, Color.LightBlue, 0f, Vector2.Zero, new Vector2(Main_Char.Armor /(Main_Char.inventory.Rune_Armor.Count*Rune_Armor.HP_plus), 1), SpriteEffects.None, 0.5f);
            
            Global.spriteBatch.Draw(HP_BAR.Texture, HP_BAR.Vector2, Color.White);
            
            int life = Main_Char.inventory.Rune_Lives.Count;
            
            Global.spriteBatch.DrawString(HP_BAR.Font,"ATK:"+(int)Main_Char.Common_ATK+"  AR:"+(int)Main_Char.Armor+"  Life:"+life,new Vector2(99,80),Color.Black);
            Hitstreak_bar.Hitstrak_Bar_Show(Main_Char.Hitsteak);
            Weight_UI.Show_UI(Main_Char.inventory.carry_weight,Main_Char.inventory.Max_weight);
        }
        public void Reset()
        {
            MediaPlayer.Stop();
             SceneEnd_time = 0;
            enemyClose.Clear();
            enemyRanges.Clear();
            enemyBosses.Clear();
            graces.Clear();
        }              
        private void Collision()
        {
            foreach (var buiding in Buidings)
            {
                if (Main_Char.Box.Intersects(buiding.Box_Colli))
                {
                    if (Main_Char.Get_Box().Top < buiding.Box_Colli.Bottom && Main_Char.Get_Box().Top > buiding.Box_Colli.Bottom - 7)
                    {
                        Main_Char.Set_Pos(new Vector2(Main_Char.Get_Pos().X, buiding.Box_Colli.Bottom + Global.Tile));
                    }
                    if (Main_Char.Get_Box().Bottom > buiding.Box_Colli.Top && Main_Char.Get_Box().Bottom < buiding.Box_Colli.Top + 7)
                    {
                        Main_Char.Set_Pos(new Vector2(Main_Char.Get_Pos().X, buiding.Box_Colli.Top - Global.Tile));
                    }
                    if (Main_Char.Get_Box().Right > buiding.Box_Colli.Left && Main_Char.Get_Box().Right < buiding.Box_Colli.Left + 7)
                    {
                        Main_Char.Set_Pos(new Vector2(buiding.Box_Colli.Left - Global.Tile / 2, Main_Char.Get_Pos().Y));
                    }
                    if (Main_Char.Get_Box().Left < buiding.Box_Colli.Right && Main_Char.Get_Box().Left > buiding.Box_Colli.Right - 7)
                    {
                        Main_Char.Set_Pos(new Vector2(buiding.Box_Colli.Right + Global.Tile / 2, Main_Char.Get_Pos().Y));
                    }
                }
            }
            
        }
    }
}
