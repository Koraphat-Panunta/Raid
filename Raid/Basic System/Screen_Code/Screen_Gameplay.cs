using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Core;
using Raid.Enemy;
using Raid.Enviroment;
using Raid.Item;
using Raid.MainCharacter;
using System;


namespace Raid.Screen_Code
{
    public class Screen_Gameplay:Screen
    {
        Random random = new Random();
        public Main_Char Main_Char;
        private EnemyClose[] enemyClose = new EnemyClose[7];
        Map map;
        Camera Camera;
        private int Max_Grace;
        private int Max_Gate;
        public Grace[] Grace;
        bool Hit =false;
        public Extract_gate[] extract_Gate;
        public bool Extract;       
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
            enemyClose[0] = new EnemyClose(new Vector2(2768, 5634));
            enemyClose[1] = new EnemyClose(new Vector2(2800, 5600));
            enemyClose[2] = new EnemyClose(new Vector2(3000, 6000));
            enemyClose[3] = new EnemyClose(new Vector2(2500, 5400));
            enemyClose[4] = new EnemyClose(new Vector2(random.Next(2500,3000),random.Next(5400,6000)));
            enemyClose[5] = new EnemyClose(new Vector2(random.Next(2500, 3000), random.Next(5400, 6000)));
            enemyClose[6] = new EnemyClose(new Vector2(random.Next(2500, 3000), random.Next(5400, 6000)));

            map = new Map();
            Max_Gate = 4;
            Max_Grace = 4;            
            Grace = new Grace[Max_Grace];
            extract_Gate = new Extract_gate[Max_Gate];
            //BG = Global.Content.Load<Texture2D>("Gameplay_test2");
            Main_Char.Deploy(Deploy_Pos);
            Object_Load();                        
            Camera = new Camera();            
           Camera_Pos = Main_Char.Get_Pos();
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count *Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
        }
        double Distance;
        public override void Update(GameTime gameTime)
        {
            Camera.CameraPos_Update(Camera_Pos);            
            if(Main_Char.Alive == true)
            {
                Time.Time_Count();
            }
            for (int i = 0; i < enemyClose.Length; i++)
            {                
                enemyClose[i].Update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));
                if (enemyClose[i].Enemy_is_Alert == true)
                {
                    if (enemyClose[i].stunt == false && enemyClose[i].immune == false && enemyClose[i].Unarmed == false)
                    {
                        if (enemyClose[i].Get_Pos().X < Main_Char.Get_Pos().X)
                        {
                            enemyClose[i].Set_Pos(new Vector2(enemyClose[i].Get_Pos().X + enemyClose[i].Moving_speed, enemyClose[i].Get_Pos().Y));
                            enemyClose[i].Enemy_state = enemyClose[i].Moving_right;
                        }
                        else if (enemyClose[i].Get_Pos().X-3 >= Main_Char.Get_Pos().X)
                        {
                            enemyClose[i].Set_Pos(new Vector2(enemyClose[i].Get_Pos().X - enemyClose[i].Moving_speed, enemyClose[i].Get_Pos().Y));
                            enemyClose[i].Enemy_state = enemyClose[i].Moving_left;
                        }
                        if (enemyClose[i].Get_Pos().Y < Main_Char.Get_Pos().Y)
                        {
                            enemyClose[i].Set_Pos(new Vector2(enemyClose[i].Get_Pos().X, enemyClose[i].Get_Pos().Y + enemyClose[i].Moving_speed));
                        }
                        else if (enemyClose[i].Get_Pos().Y > Main_Char.Get_Pos().Y)
                        {
                            enemyClose[i].Set_Pos(new Vector2(enemyClose[i].Get_Pos().X, enemyClose[i].Get_Pos().Y - enemyClose[i].Moving_speed));
                        }
                    }
                    if (enemyClose[i].Enemy_is_attack == true)
                    {
                        Main_Char.Get_Dmg(enemyClose[i].Enemt_ATK_DMG);
                        feedback_time_start = true;
                        break;
                    }
                    if (Main_Char.Main_Char_ATK_State == Main_Char.Main_Char_Common_ATK)
                    {
                        if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_Up || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Up)
                        {
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range+45 && enemyClose[i].Get_Pos().Y <= Main_Char.Get_Pos().Y && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;
                                Main_Char.Hitstreak_Plus();
                            }
                        }
                        if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_Down || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Down)
                        {
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyClose[i].Get_Pos().Y >= Main_Char.Get_Pos().Y && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;
                                Main_Char.Hitstreak_Plus();
                            }
                        }
                        if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_left || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Left)
                        {
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyClose[i].Get_Pos().X <= Main_Char.Get_Pos().X && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;
                                Main_Char.Hitstreak_Plus();
                            }
                        }
                        if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_right || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Right)
                        {
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 45 && enemyClose[i].Get_Pos().X >= Main_Char.Get_Pos().X && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;
                                Main_Char.Hitstreak_Plus();
                            }
                        }

                    }
                    if (Main_Char.Main_Char_ATK_State == Main_Char.Main_Char_Heavy_ATK)
                    {
                        if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_Up || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Up)
                        {
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyClose[i].Get_Pos().Y <= Main_Char.Get_Pos().Y && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;                                
                            }
                        }
                        if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_Down || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Down)
                        {
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyClose[i].Get_Pos().Y >= Main_Char.Get_Pos().Y && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;                                
                            }
                        }
                        if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_left || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Left)
                        {
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyClose[i].Get_Pos().X <= Main_Char.Get_Pos().X && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;                                
                            }
                        }
                        if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_right || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Right)
                        {
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyClose[i].Get_Pos().X >= Main_Char.Get_Pos().X && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;
                                
                            }
                        }
                    }
                    if (Main_Char.Main_Char_ATK_State == Main_Char.Main_Char_Roll_ATK)
                    {                       
                            if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 45 && enemyClose[i].immune == false)
                            {
                                enemyClose[i].Get_DMG(Main_Char.Roll_ATK);
                                enemyClose[i].stunt = true;
                                enemyClose[i].immune = true;
                                
                            }                      
                    }
                }
            }
                Extractionsystem();
                Main_Char.Update();
                Camera_Movement();
                //this.Time.Time_Count();                            
                base.Update(gameTime);
            
        }
        public override void Draw(GameTime gameTime)
        {
            Draw_Form_Pos_inWorld();
            Draw_UI();
            Global.spriteBatch.Draw(Pos,Camera.Object_Vector(Main_Char.Get_Pos()), new Rectangle(-3,-3, 6, 6), Color.White);
            Global.spriteBatch.Draw(Pos, Camera.Object_Vector(enemyClose[0].Get_Pos()), new Rectangle(-3,-3, 6, 6), Color.White);            
            
            base.Draw(gameTime);
        }    
        public override void Unload()
        {                               
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Enemy_Close Unarmed =" + enemyClose[0].Unarmed);
            Console.WriteLine("Enemy_Close immune =" + enemyClose[0].immune);
            Console.WriteLine("Enemy_Distance =" + enemyClose[0].Enemy_Distance);
            Console.WriteLine("HP ="+Main_Char.HP);
            Console.WriteLine("Enemy HP =" + enemyClose[0].HP);
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
            //Global.spriteBatch.Draw(BG, Camera.Object_Vector(new Vector2(0, 0)), Color.White);
            for(int i = 0; i < 13; i++)
            {
                Global.spriteBatch.Draw(map.Get_Map_Texture(i),Camera.Object_Vector(map.Get_Map_Pos(i)), Color.White);
            }
            Global.spriteBatch.Draw(extract_Gate[0].Get_Texture(), Camera.Object_Vector(extract_Gate[0].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[1].Get_Texture(), Camera.Object_Vector(extract_Gate[1].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[2].Get_Texture(), Camera.Object_Vector(extract_Gate[2].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[3].Get_Texture(), Camera.Object_Vector(extract_Gate[3].Get_Position()), Color.White);
            Global.spriteBatch.Draw(Grace[0].Get_Grace_Texture(), Camera.Object_Vector(Grace[0].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[1].Get_Grace_Texture(), Camera.Object_Vector(Grace[1].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[2].Get_Grace_Texture(), Camera.Object_Vector(Grace[2].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[3].Get_Grace_Texture(), Camera.Object_Vector(Grace[3].Get_GracePosition()), Color.White);
            for(int i = 0; i < enemyClose.Length; i++)
            {
                enemyClose[i].animate(Camera.Object_Vector(enemyClose[i].Get_Pos()));
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
                Global.spriteBatch.Draw(Blood_Feedback, Vector2.Zero, Color.White * 0.5f);
                if (feedback_time >= 0.5)
                {
                    feedback_time = 0;
                    feedback_time_start = false;
                }
            }
            
            Global.spriteBatch.DrawString(Time.GetSpriteFont(),"Time = "+this.Time.Get_Time_Count(), new Vector2(480, 0), Color.White);
            Global.spriteBatch.DrawString(Time.GetSpriteFont(), "HitSteak = " + Main_Char.Hitsteak, new Vector2(50, 500), Color.White);
            
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
            
            if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Up)
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
            if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Down)
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
            if (Main_Char.Main_Char_curt_State == "Main_Char_Moving_Left")
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
            if (Main_Char.Main_Char_curt_State == "Main_Char_Moving_Right")
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
            if(Main_Char.Main_Char_curt_State == "Main_Char_idle_Up"||Main_Char.Main_Char_curt_State == "Main_Char_idle_Down"|| Main_Char.Main_Char_curt_State == "Main_Char_idle_left"|| Main_Char.Main_Char_curt_State == "Main_Char_idle_right")
            {
                Camera_Time = 0;
            }
        }
    }
}
