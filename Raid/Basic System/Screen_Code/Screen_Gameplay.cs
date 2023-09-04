﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Core;
using Raid.Enviroment;
using Raid.Item;
using Raid.MainCharacter;
using System;


namespace Raid.Screen_Code
{
    public class Screen_Gameplay:Screen
    {
        public Main_Character Main_Character = new Main_Character();
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
        public Screen_Gameplay() 
        { 
        }
        public override void load(Main_Character main_Character,Vector2 Deploy_Pos)
        {           
            base.load(main_Character,Deploy_Pos);
            this.Main_Character = main_Character;
            map = new Map();
            Max_Gate = 4;
            Max_Grace = 4;
            this.Time = new Time(15);
            Grace = new Grace[Max_Grace];
            extract_Gate = new Extract_gate[Max_Gate];
            //BG = Global.Content.Load<Texture2D>("Gameplay_test2");            
            Object_Load();
            Deploy(Deploy_Pos);
            Main_Character.Set_MainCharacterHitbox(new Rectangle((int)Main_Character.Get_MainCharacterPos().X,(int)Main_Character.Get_MainCharacterPos().Y,102,184));
            Camera = new Camera();           
            Main_Character.Set_state("Main_Char_idle_right");
            Main_Character.Set_ATK_state("None");
            Main_Character.Set_Char_Alive(true);
           Camera_Pos = Main_Character.Get_MainCharacterPos();
        }     
        public override void Update(GameTime gameTime)
        {
            Camera.CameraPos_Update(Camera_Pos);
            
            lootingsystem();
            Extractionsystem();
            if (Main_Character.Get_Char_Alive() == true)
            {
                Main_Character.Main_Character_Updatestate();
                Camera_Movement();
                //this.Time.Time_Count();
            }
            if (Main_Character.Get_Char_Alive() == false)
            {
                Main_Character.inventory.Grace_num = 0;
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
            Main_Character.Set_MainCharacterPos(new Vector2(0,0));            
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Main_Char_State ={0}", Main_Character.Get_state());
            Console.WriteLine("Main_Char_ATK_State ={0}", Main_Character.Get_ATK_state());
            Console.WriteLine(Main_Character.Key_ATK_ISPressed);         
            Console.WriteLine("Main_Char_Pos = {0}", Main_Character.Get_MainCharacterPos());
            Console.WriteLine("Grace_Pos = {0}", Grace[0].Get_GracePosition());
            Console.WriteLine("Grace num = {0}", Main_Character.inventory.Grace_num);
            Console.WriteLine("Weight ={0}/{1}", Main_Character.inventory.carry_weight, Main_Character.inventory.Max_weight);
            base.Debuging();
        }       
        ///////////////////////////////////////////////////////////////////////// Main-method /////////////////////////////////////////////////////       
        public void lootingsystem()
        {
            Main_Character.inventory.Cal_Weight(Grace[1].Get_Weight());

            int i = 0;
            for (int num = 0; num < 4; num++)
            {
                
                if (Main_Character.Get_MainCharacterBox().Intersects(Grace[i].Get_Grace_Hitbox()))
                {
                    Hit = true;                  
                    break;
                }
                else
                {
                    Hit = false;
                }
                i++;
            }
            
            if (Hit == true && Keyboard.GetState().IsKeyDown(Keys.E))
            {
                float x = Main_Character.inventory.carry_weight;
                if (x + Grace[i].Get_Weight() <= Main_Character.inventory.Max_weight)
                {
                    Grace[i].disapear();
                    Main_Character.inventory.Grace_num += 1;
                    Main_Character.inventory.Cal_Weight(this.Grace[i].Get_Weight());
                }
            }
        }
        private void Extractionsystem()
        {
            for(int i=0;i<4;i++)
            {
                if (Main_Character.Get_MainCharacterBox().Intersects(extract_Gate[i].Get_Box()) && Keyboard.GetState().IsKeyDown(Keys.E)&&Main_Character.Get_Char_Alive()==true)
                {
                    Extract = true;
                    break;
                }
                else
                {
                    Extract = false;
                }
            }
            if (this.Time.Get_Time_Count() <= 0)
            {
                Main_Character.Set_Char_Alive(false);
            }
              
        }       
        public void Deploy(Vector2 Deploy_Pos)
        {           
            Main_Character.Set_MainCharacterPos(Deploy_Pos);            
        }
        private void Draw_Form_Pos_inWorld()
        {
            //Global.spriteBatch.Draw(BG, Camera.Object_Vector(new Vector2(0, 0)), Color.White);
            Global.spriteBatch.Draw(map.Get_Map_Texture(5), Camera.Object_Vector(map.Get_Map_Pos(5)), Color.White);
            Global.spriteBatch.Draw(extract_Gate[0].Get_Texture(), Camera.Object_Vector(extract_Gate[0].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[1].Get_Texture(), Camera.Object_Vector(extract_Gate[1].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[2].Get_Texture(), Camera.Object_Vector(extract_Gate[2].Get_Position()), Color.White);
            Global.spriteBatch.Draw(extract_Gate[3].Get_Texture(), Camera.Object_Vector(extract_Gate[3].Get_Position()), Color.White);
            Global.spriteBatch.Draw(Grace[0].Get_Grace_Texture(), Camera.Object_Vector(Grace[0].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[1].Get_Grace_Texture(), Camera.Object_Vector(Grace[1].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[2].Get_Grace_Texture(), Camera.Object_Vector(Grace[2].Get_GracePosition()), Color.White);
            Global.spriteBatch.Draw(Grace[3].Get_Grace_Texture(), Camera.Object_Vector(Grace[3].Get_GracePosition()), Color.White);
            Main_Character.Animate(Camera.Object_Vector(Main_Character.Get_MainCharacterPos()));
        }
        private void Draw_UI()
        {
            Global.spriteBatch.DrawString(Time.GetSpriteFont(),"Time = "+this.Time.Get_Time_Count(), new Vector2(960, 0), Color.White);
        }
        private void Object_Load()
        {
            extract_Gate[0] = new Extract_gate(new Vector2(2469,6328));
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
            float Lenght_x = (Global.GraphicsDevice.PreferredBackBufferWidth/4)/2.5f;
            float Lenght_y = (Global.GraphicsDevice.PreferredBackBufferHeight/4)/2.5f;
            
            if (Main_Character.Get_state() == "Main_Char_Moving_Up")
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.X < Main_Character.Get_MainCharacterPos().X+24)
                {
                    Camera_Pos.X += Camera_acceleration_X * Camera_Time;  
                    if(Camera_Pos.X > Main_Character.Get_MainCharacterPos().X + 24)
                    {
                        Camera_Pos.X = Main_Character.Get_MainCharacterPos().X + 24;
                    }
                }
                else if (Camera_Pos.X > Main_Character.Get_MainCharacterPos().X+ 24)
                {
                    Camera_Pos.X -= Camera_acceleration_X * Camera_Time; 
                    if (Camera_Pos.X < Main_Character.Get_MainCharacterPos().X + 24)
                    {
                        Camera_Pos.X = Main_Character.Get_MainCharacterPos().X + 24;
                    }
                }               
                if(Camera_Pos.Y > Main_Character.Get_MainCharacterPos().Y + 48 -Lenght_y)
                {
                    Camera_Pos.Y -= Main_Character.Get_speed() + Camera_acceleration_Y * Camera_Time; 
                    if(Camera_Pos.Y < Main_Character.Get_MainCharacterPos().Y+ 48 - Lenght_y)
                    {
                        Camera_Pos.Y = Main_Character.Get_MainCharacterPos().Y+ 48 - Lenght_y;
                    }
                }               
            }
            if (Main_Character.Get_state() == "Main_Char_Moving_Down")
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.X < Main_Character.Get_MainCharacterPos().X + 24)
                {
                    Camera_Pos.X += Camera_acceleration_X * Camera_Time;
                    if (Camera_Pos.X > Main_Character.Get_MainCharacterPos().X + 24)
                    {
                        Camera_Pos.X = Main_Character.Get_MainCharacterPos().X + 24;
                    }
                }
                else if (Camera_Pos.X > Main_Character.Get_MainCharacterPos().X + 24)
                {
                    Camera_Pos.X -= Camera_acceleration_X * Camera_Time;
                    if (Camera_Pos.X < Main_Character.Get_MainCharacterPos().X + 24)
                    {
                        Camera_Pos.X = Main_Character.Get_MainCharacterPos().X + 24;
                    }
                }
                if (Camera_Pos.Y < Main_Character.Get_MainCharacterPos().Y+ 48 + Lenght_y)
                {
                    Camera_Pos.Y += Main_Character.Get_speed() + Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y > Main_Character.Get_MainCharacterPos().Y+ 48 + Lenght_y)
                    {
                        Camera_Pos.Y = Main_Character.Get_MainCharacterPos().Y+ 48 + Lenght_y;
                    }
                }

            }
            if ( Main_Character.Get_state() == "Main_Char_Moving_Left")
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.Y < Main_Character.Get_MainCharacterPos().Y + 48)
                {
                    Camera_Pos.Y += Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y > Main_Character.Get_MainCharacterPos().Y + 48)
                    {
                        Camera_Pos.Y = Main_Character.Get_MainCharacterPos().Y + 48;
                    }
                }
                else if (Camera_Pos.Y > Main_Character.Get_MainCharacterPos().Y + 48)
                {
                    Camera_Pos.Y -= Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y < Main_Character.Get_MainCharacterPos().Y + 48)
                    {
                        Camera_Pos.Y = Main_Character.Get_MainCharacterPos().Y + 48;
                    }
                }
                if (Camera_Pos.X > Main_Character.Get_MainCharacterPos().X + 24 - Lenght_x)
                {
                    Camera_Pos.X -= Main_Character.Get_speed() + Camera_acceleration_X * Camera_Time;
                    if (Camera_Pos.X < Main_Character.Get_MainCharacterPos().X + 24 - Lenght_x)
                    {
                        Camera_Pos.X = Main_Character.Get_MainCharacterPos().X + 24 - Lenght_x;
                    }
                }

            }
            if ( Main_Character.Get_state() == "Main_Char_Moving_Right")
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.Y < Main_Character.Get_MainCharacterPos().Y + 48)
                {
                    Camera_Pos.Y += Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y > Main_Character.Get_MainCharacterPos().Y + 48)
                    {
                        Camera_Pos.Y = Main_Character.Get_MainCharacterPos().Y + 48;
                    }
                }
                else if (Camera_Pos.Y > Main_Character.Get_MainCharacterPos().Y + 48)
                {
                    Camera_Pos.Y -= Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y < Main_Character.Get_MainCharacterPos().Y + 48)
                    {
                        Camera_Pos.Y = Main_Character.Get_MainCharacterPos().Y + 48;
                    }
                }
                if (Camera_Pos.X < Main_Character.Get_MainCharacterPos().X + 24 + Lenght_x)
                {
                    Camera_Pos.X += Main_Character.Get_speed() + Camera_acceleration_X * Camera_Time;
                    if (Camera_Pos.X > Main_Character.Get_MainCharacterPos().X + 24 + Lenght_x)
                    {
                        Camera_Pos.X = Main_Character.Get_MainCharacterPos().X + 24 + Lenght_x;
                    }
                }

            }
            if(Main_Character.Get_state() == "Main_Char_idle_Up"|| Main_Character.Get_state() == "Main_Char_idle_Down"|| Main_Character.Get_state() == "Main_Char_idle_left"|| Main_Character.Get_state() == "Main_Char_idle_right")
            {
                Camera_Time = 0;
            }
        }
    }
}
