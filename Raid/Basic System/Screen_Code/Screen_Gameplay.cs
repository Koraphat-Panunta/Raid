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
        
        public Main_Char Main_Char;
        private EnemyClose enemyClose;
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
        public Screen_Gameplay() 
        { 
        }
        public override void load(Vector2 Deploy_Pos)
        {           
            base.load(Deploy_Pos);
            Main_Char = new Main_Char();               
            enemyClose = new EnemyClose(new Vector2(2768, 5634));
            map = new Map();
            Max_Gate = 4;
            Max_Grace = 4;
            this.Time = new Time(15);
            Grace = new Grace[Max_Grace];
            extract_Gate = new Extract_gate[Max_Gate];
            //BG = Global.Content.Load<Texture2D>("Gameplay_test2");
            Main_Char.Deploy(Deploy_Pos);
            Object_Load();                        
            Camera = new Camera();            
           Camera_Pos = Main_Char.Get_Pos();
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");

        }
        double Distance;
        public override void Update(GameTime gameTime)
        {
            Camera.CameraPos_Update(Camera_Pos); ;
            enemyClose.Update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));
            if (enemyClose.Enemy_is_Alert == true)
            {
                if (enemyClose.stunt == false && enemyClose.immune == false && enemyClose.Unarmed == false)
                {
                    if (enemyClose.Get_Pos().X < Main_Char.Get_Pos().X)
                    {
                        enemyClose.Set_Pos(new Vector2(enemyClose.Get_Pos().X + 1, enemyClose.Get_Pos().Y));
                    }
                    else if (enemyClose.Get_Pos().X > Main_Char.Get_Pos().X)
                    {
                        enemyClose.Set_Pos(new Vector2(enemyClose.Get_Pos().X - 1, enemyClose.Get_Pos().Y));
                    }
                    if (enemyClose.Get_Pos().Y < Main_Char.Get_Pos().Y)
                    {
                        enemyClose.Set_Pos(new Vector2(enemyClose.Get_Pos().X, enemyClose.Get_Pos().Y + 1));
                    }
                    else if (enemyClose.Get_Pos().Y > Main_Char.Get_Pos().Y)
                    {
                        enemyClose.Set_Pos(new Vector2(enemyClose.Get_Pos().X, enemyClose.Get_Pos().Y - 1));
                    }
                }
                if (enemyClose.Enemy_is_attack == true)
                {
                    Main_Char.Get_Dmg(1);
                }
                if (Main_Char.Main_Char_ATK_State == Main_Char.Main_Char_Common_ATK)
                {
                    if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_Up || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Up)
                    {
                        if (enemyClose.Enemy_Distance + 36 <= Main_Char.ATK_common_Range && enemyClose.Get_Pos().Y <= Main_Char.Get_Pos().Y && enemyClose.immune == false)
                        {
                            enemyClose.Get_DMG(Main_Char.Common_ATK);
                            enemyClose.stunt = true;
                            enemyClose.immune = true;
                            Main_Char.Hitstreak_Plus();
                        }
                    }
                    if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_Down || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Down)
                    {
                        if (enemyClose.Enemy_Distance + 36 <= Main_Char.ATK_common_Range && enemyClose.Get_Pos().Y >= Main_Char.Get_Pos().Y && enemyClose.immune == false)
                        {
                            enemyClose.Get_DMG(Main_Char.Common_ATK);
                            enemyClose.stunt = true;
                            enemyClose.immune = true;
                            Main_Char.Hitstreak_Plus();
                        }
                    }
                    if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_left || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Left)
                    {
                        if (enemyClose.Enemy_Distance + 36 <= Main_Char.ATK_common_Range && enemyClose.Get_Pos().X <= Main_Char.Get_Pos().X && enemyClose.immune == false)
                        {
                            enemyClose.Get_DMG(Main_Char.Common_ATK);
                            enemyClose.stunt = true;
                            enemyClose.immune = true;
                            Main_Char.Hitstreak_Plus();
                        }
                    }
                    if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_right || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Right)
                    {
                        if (enemyClose.Enemy_Distance + 36 <= Main_Char.ATK_common_Range && enemyClose.Get_Pos().X >= Main_Char.Get_Pos().X && enemyClose.immune == false)
                        {
                            enemyClose.Get_DMG(Main_Char.Common_ATK);
                            enemyClose.stunt = true;
                            enemyClose.immune = true;
                            Main_Char.Hitstreak_Plus();
                        }
                    }

                }
                if (Main_Char.Main_Char_ATK_State == Main_Char.Main_Char_Heavy_ATK)
                {
                    if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_Up || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Up)
                    {
                        if (enemyClose.Enemy_Distance  <= Main_Char.ATK_Heavy_Range && enemyClose.Get_Pos().Y <= Main_Char.Get_Pos().Y && enemyClose.immune == false)
                        {
                            enemyClose.Get_DMG(Main_Char.Heavy_ATK);
                            enemyClose.stunt = true;
                            enemyClose.immune = true;
                            Main_Char.Hitstreak_Plus();
                        }
                    }
                    if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_Down || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Down)
                    {
                        if (enemyClose.Enemy_Distance  <= Main_Char.ATK_Heavy_Range && enemyClose.Get_Pos().Y >= Main_Char.Get_Pos().Y && enemyClose.immune == false)
                        {
                            enemyClose.Get_DMG(Main_Char.Heavy_ATK);
                            enemyClose.stunt = true;
                            enemyClose.immune = true;
                            Main_Char.Hitstreak_Plus();
                        }
                    }
                    if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_left || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Left)
                    {
                        if (enemyClose.Enemy_Distance  <= Main_Char.ATK_Heavy_Range && enemyClose.Get_Pos().X <= Main_Char.Get_Pos().X && enemyClose.immune == false)
                        {
                            enemyClose.Get_DMG(Main_Char.Heavy_ATK);
                            enemyClose.stunt = true;
                            enemyClose.immune = true;
                            Main_Char.Hitstreak_Plus();
                        }
                    }
                    if (Main_Char.Main_Char_curt_State == Main_Char.Main_Char_idle_right || Main_Char.Main_Char_curt_State == Main_Char.Main_Char_Moving_Right)
                    {
                        if (enemyClose.Enemy_Distance  <= Main_Char.ATK_Heavy_Range && enemyClose.Get_Pos().X >= Main_Char.Get_Pos().X && enemyClose.immune == false)
                        {
                            enemyClose.Get_DMG(Main_Char.Heavy_ATK);
                            enemyClose.stunt = true;
                            enemyClose.immune = true;
                            Main_Char.Hitstreak_Plus();
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
            Global.spriteBatch.Draw(Pos, Camera.Object_Vector(Camera_Pos), new Rectangle(-3,-3, 6, 6), Color.White);
            Global.spriteBatch.Draw(Pos, Camera.Object_Vector(enemyClose.Get_Pos()), new Rectangle(-3, -3, 6, 6), Color.White);
            base.Draw(gameTime);
        }    
        public override void Unload()
        {                               
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Enemy_Close Unarmed =" + enemyClose.Unarmed);
            Console.WriteLine("Enemy_Close immune =" + enemyClose.immune);
            Console.WriteLine("Enemy_Distance =" + enemyClose.Enemy_Distance);
            Console.WriteLine("HP ="+Main_Char.HP);
            Console.WriteLine("Enemy HP =" + enemyClose.HP);
            Console.WriteLine("Hitstreak count =" + Main_Char.Hitsteak);
            base.Debuging();
        }       
        ///////////////////////////////////////////////////////////////////////// Main-method /////////////////////////////////////////////////////       
        //public void lootingsystem()
        //{
        //    Main_Character.inventory.Cal_Weight(Grace[1].Get_Weight());

        //    int i = 0;
        //    for (int num = 0; num < 4; num++)
        //    {
                
        //        if (Main_Character.Get_MainCharacterBox().Intersects(Grace[i].Get_Grace_Hitbox()))
        //        {
        //            Hit = true;                  
        //            break;
        //        }
        //        else
        //        {
        //            Hit = false;
        //        }
        //        i++;
        //    }
            
        //    if (Hit == true && Keyboard.GetState().IsKeyDown(Keys.E))
        //    {
        //        float x = Main_Character.inventory.carry_weight;
        //        if (x + Grace[i].Get_Weight() <= Main_Character.inventory.Max_weight)
        //        {
        //            Grace[i].disapear();
        //            Main_Character.inventory.Grace_num += 1;
        //            Main_Character.inventory.Cal_Weight(this.Grace[i].Get_Weight());
        //        }
        //    }
        //}
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
            enemyClose.animate(Camera.Object_Vector(enemyClose.Get_Pos()));
            Main_Char.animate(Camera.Object_Vector(Main_Char.Get_Pos()));

            
        }
        private void Draw_UI()
        {
            Global.spriteBatch.DrawString(Time.GetSpriteFont(),"Time = "+this.Time.Get_Time_Count(), new Vector2(960, 0), Color.White);
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
