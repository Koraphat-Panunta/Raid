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
        int enemyclosemax = 5;
        int enemyRangemax = 1;
        Random random = new Random();
        public Main_Char Main_Char;
        List<EnemyClose> enemyClose = new List<EnemyClose>();
        List<EnemyRange> enemyRanges = new List<EnemyRange>();
        Map map;
        Camera Camera;       
        public Grace[] Grace;
        bool Hit =false;
        public Extract_gate[] extract_Gate;
        public bool Extract_success;
        public bool Extract_fail;
        private Time Time;
        private Vector2 Camera_Pos;
        Texture2D Pos;
        Texture2D Blood_Feedback;
        public Screen_Gameplay() 
        { 
        }
        public override void load(Vector2 Deploy_Pos)
        {           
            base.load(Deploy_Pos);
            Main_Char = new Main_Char();
            for(int i = 0; i < enemyclosemax; i++)
            {
                enemyClose.Add(new EnemyClose(new Vector2(random.Next(2400,3000),random.Next(5000,6000))));                
            }
            for (int i = 0; i < enemyRangemax; i++)
            {           
                enemyRanges.Add(new EnemyRange(new Vector2(random.Next(2400, 3000), random.Next(5000, 6000))));
            }
            Extract_fail = false;
            Extract_success = false;
            map = new Map();                     
            Grace = new Grace[4];
            extract_Gate = new Extract_gate[4];            
            Main_Char.Deploy(Deploy_Pos);
            Object_Load();                        
            Camera = new Camera();            
           Camera_Pos = Main_Char.Get_Pos();
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count *Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
        }
        double Distance;
        float SceneEnd_time = 0;
        public override void Update(GameTime gameTime)
        {
            Main_Char.Update();
            Camera.CameraPos_Update(Camera_Pos);
            Camera_Movement();
            if (Main_Char.Alive == true)
            {
                Time.Time_Count();
                for (int i = 0; i < enemyClose.Count; i++)
                {
                    if (enemyClose[i].Alive == false)
                    {
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

                if (Time.Get_Time_Count() <= 0)
                {
                    Main_Char.Alive = false;
                }
            }
            if(Main_Char.Alive == false)
            {
                SceneEnd_time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if(SceneEnd_time >= 4)
                {
                    Extract_fail = true;
                }
            }
            Extractionsystem();               
               
                base.Update(gameTime);            
        }
        public override void Draw(GameTime gameTime)
        {
            Draw_Form_Pos_inWorld();
            Draw_UI();
            Global.spriteBatch.Draw(Pos,Camera.Object_Vector(Main_Char.Get_Pos()), new Rectangle(-3,-3, 6, 6), Color.White);                   
            
            base.Draw(gameTime);
        }    
        public override void Unload()
        {                               
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Enemy_number = " + enemyClose.Count);
            Console.WriteLine("HP ="+Main_Char.HP);            
            Console.WriteLine("Hitstreak count =" + Main_Char.Hitsteak);
            Console.WriteLine("Feedback_time ="+feedback_time);
           
            base.Debuging();
        }
        ///////////////////////////////////////////////////////////////////////// Main-method /////////////////////////////////////////////////////       
        public void lootingsystem()
        {
            Main_Char.inventory.Cal_Weight();
            int i = 0;
            //foreach(Stactic_Obg Obg in GameObg)
            //{

            //}
        }
        private void Extractionsystem()
        {
           
              
        }       
       
        private void Draw_Form_Pos_inWorld()
        {
            for (int i = 0; i < 13; i++)
            {
                if (Main_Char.Get_Pos().Y > map.Get_Map_Pos(i).Y - 400 && Main_Char.Get_Pos().Y < map.Get_Map_Pos(i).Y + map.Get_Map_Texture(i).Height + 400 && Main_Char.Get_Pos().X > map.Get_Map_Pos(i).X - 400 && Main_Char.Get_Pos().X < map.Get_Map_Pos(i).X + map.Get_Map_Texture(i).Width + 400)
                {
                    Global.spriteBatch.Draw(map.Get_Map_Texture(i), Camera.Object_Vector(map.Get_Map_Pos(i)), Color.White);
                    
                }
            }
            Global.spriteBatch.Draw(extract_Gate[0].Get_Texture(), Camera.Object_Vector(extract_Gate[0].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[1].Get_Texture(), Camera.Object_Vector(extract_Gate[1].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[2].Get_Texture(), Camera.Object_Vector(extract_Gate[2].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[3].Get_Texture(), Camera.Object_Vector(extract_Gate[3].Get_Position()), Color.White);
            Global.spriteBatch.Draw(Grace[0].Get_Grace_Texture(), Camera.Object_Vector(Grace[0].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[1].Get_Grace_Texture(), Camera.Object_Vector(Grace[1].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[2].Get_Grace_Texture(), Camera.Object_Vector(Grace[2].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[3].Get_Grace_Texture(), Camera.Object_Vector(Grace[3].Get_GracePosition()), Color.White);
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
                    //Global.spriteBatch.Draw(Pos,Camera.Object_Vector( enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1].Return_Pos()),new Rectangle(0,0,25,25), Color.White);
                }
            }
            //Global.spriteBatch.Draw(Pos,Camera.Object_Vector(new Vector2(Main_Char.Get_Pos().X-24, Main_Char.Get_Pos().Y - 48)),new Rectangle(0,0,48,96),Color.White);
            //Global.spriteBatch.Draw();
            Main_Char.animate(Camera.Object_Vector(Main_Char.Get_Pos()));


        }
        double feedback_time = 0;
        bool feedback_time_start = false;
        private void Draw_UI()
        {
            
            if(feedback_time_start == true)
            {
                feedback_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;                
                Global.spriteBatch.Draw(Blood_Feedback, Vector2.Zero, Color.White * 0.5f);
                if (feedback_time >= 0.5)
                {
                    feedback_time = 0;
                    feedback_time_start = false;
                }
            }
            
            Global.spriteBatch.DrawString(Time.GetSpriteFont(),"Time = "+this.Time.Get_Time_Count(), new Vector2(480, 0), Color.White);
            Global.spriteBatch.DrawString(Time.GetSpriteFont(), "HitSteak = " + Main_Char.Hitsteak, new Vector2(50, 500), Color.White);
            Global.spriteBatch.DrawString(Time.GetSpriteFont(), "HP:" + Main_Char.HP, new Vector2(50,0), Color.Black);
            
        }
        private void Object_Load()
        {
            extract_Gate[0] = new Extract_gate(new Vector2(-225, 63));
            extract_Gate[1] = new Extract_gate(new Vector2(1450 * 2, 30));
            extract_Gate[2] = new Extract_gate(new Vector2(30, 750 * 2));
            extract_Gate[3] = new Extract_gate(new Vector2(1450 * 2, 750 * 2));
            this.Grace[0] = new Grace(new Vector2(729, 428));
            this.Grace[1] = new Grace(new Vector2(1219 * 2, 449));
            this.Grace[2] = new Grace(new Vector2(673, 678 * 2));
            this.Grace[3] = new Grace(new Vector2(1110 * 2, 673 * 2));
            
        }

        private float Camera_Time = 0;
        private float camera_speed_X = 9;
        private float camera_speed_Y = 7;
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
