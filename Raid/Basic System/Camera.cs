using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Raid.MainCharacter;
using System;
using System.Collections.Generic;

namespace Raid
{
    public class Camera
        
    {
        public Vector2 Camera_Pos;
        private Random Random = new Random();
        private bool Camera_Shake = false;
        private float Camera_Shake_frame = 0;
        private bool Camera_Shake_End = true;
        //camera_finish
        public Camera(Vector2 Tracking_Object)
        {
            Camera_Pos = Tracking_Object;
           
        }
        public void Load()
        {
            
        }
        public  void CameraPos_Update(Vector2 Tracking_Object)
        {           
            Camera_Pos = Tracking_Object;
            
        }
        float Camera_Time = 0;
        private Vector2 Old_Vector; 
        public void Camera_Movement(Main_Char Main_Char)
        {
            float Camera_Velocity_Second = Main_Char.Get_speed() * 0.55f;
            float Camera_acceleration_X = 4.5f;
            float Camera_acceleration_Y = 3.5f;
            float Lenght_x = (Global.GraphicsDevice.PreferredBackBufferHeight / 4) / 2.5f;
            float Lenght_y = (Global.GraphicsDevice.PreferredBackBufferHeight / 4) / 2.5f;
            if (Main_Char.Curt_state == 5)
            {
                Camera_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if (Camera_Pos.X < Main_Char.Get_Pos().X)
                {
                    Camera_Pos.X += Camera_Velocity_Second + (Camera_acceleration_X * Camera_Time);
                    if (Camera_Pos.X > Main_Char.Get_Pos().X)
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X;
                    }
                }
                else if (Camera_Pos.X > Main_Char.Get_Pos().X)
                {
                    Camera_Pos.X -= Camera_Velocity_Second + (Camera_acceleration_X * Camera_Time);
                    if (Camera_Pos.X < Main_Char.Get_Pos().X)
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X;
                    }
                }
                if (Camera_Pos.Y > Main_Char.Get_Pos().Y - Lenght_y)
                {
                    Camera_Pos.Y -= Main_Char.Get_speed() + Camera_acceleration_Y * Camera_Time;
                    if (Camera_Pos.Y < Main_Char.Get_Pos().Y - Lenght_y)
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
                    Camera_Pos.X += Camera_Velocity_Second + (Camera_acceleration_X * Camera_Time);
                    if (Camera_Pos.X > Main_Char.Get_Pos().X)
                    {
                        Camera_Pos.X = Main_Char.Get_Pos().X;
                    }
                }
                else if (Camera_Pos.X > Main_Char.Get_Pos().X)
                {
                    Camera_Pos.X -= Camera_Velocity_Second + (Camera_acceleration_X * Camera_Time);
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
                    Camera_Pos.Y += Camera_Velocity_Second + (Camera_acceleration_Y * Camera_Time);
                    if (Camera_Pos.Y > Main_Char.Get_Pos().Y)
                    {
                        Camera_Pos.Y = Main_Char.Get_Pos().Y;
                    }
                }
                else if (Camera_Pos.Y > Main_Char.Get_Pos().Y)
                {
                    Camera_Pos.Y -= Camera_Velocity_Second + (Camera_acceleration_Y * Camera_Time);
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
                    Camera_Pos.Y += Camera_Velocity_Second + (Camera_acceleration_Y * Camera_Time);
                    if (Camera_Pos.Y > Main_Char.Get_Pos().Y)
                    {
                        Camera_Pos.Y = Main_Char.Get_Pos().Y;
                    }
                }
                else if (Camera_Pos.Y > Main_Char.Get_Pos().Y)
                {
                    Camera_Pos.Y -= Camera_Velocity_Second + (Camera_acceleration_Y * Camera_Time);
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
            
            if(Main_Char.ATK_state == 0)
            {
                Camera_Shake_End = true;
            }
            if(Camera_Shake == true)
            {
                Camera_Shake_frame += 1;
                int light_shake = 16;
                int normal_shake = 22;
                int Heavy_shake = 35;
                if (Camera_Shake_frame == 1)
                {
                    if (Main_Char.ATK_state == 1)
                    {
                        Camera_Pos.X += Random.Next(-light_shake, light_shake);
                        Camera_Pos.Y += Random.Next(-10,10);
                    }
                    if (Main_Char.ATK_state == 2)
                    {
                        Camera_Pos.X += Random.Next(-normal_shake,normal_shake);
                        Camera_Pos.Y += Random.Next(-10,10);
                    }
                    if (Main_Char.ATK_state == 4)
                    {
                        Camera_Pos.X += Random.Next(-Heavy_shake,Heavy_shake);
                        Camera_Pos.Y += Random.Next(-Heavy_shake, Heavy_shake);
                    }
                }
                if (Camera_Shake_frame == 3)
                {
                    if (Main_Char.ATK_state == 1)
                    {
                        Camera_Pos.X += Random.Next(-light_shake, light_shake);
                        Camera_Pos.Y += Random.Next(-10,10);
                    }
                    if (Main_Char.ATK_state == 2)
                    {
                        Camera_Pos.X += Random.Next(-normal_shake, normal_shake);
                        Camera_Pos.Y += Random.Next(-10, 10);
                    }
                    if (Main_Char.ATK_state == 4)
                    {
                        Camera_Pos.X += Random.Next(-Heavy_shake, Heavy_shake);
                        Camera_Pos.Y += Random.Next(-Heavy_shake, Heavy_shake);
                    }
                }
                if (Camera_Shake_frame > 4)
                {
                    Camera_Shake = false;
                    Camera_Shake_frame = 0;
                    Camera_Pos = Old_Vector;
                }
            }           
            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 2 || Main_Char.Curt_state == 3 || Main_Char.Curt_state == 4)
            {
                Camera_Time = 0;
            }
        }
        public void CameraShake()
        {
            if (Camera_Shake == false && Camera_Shake_End == true)
            {
                Old_Vector = Camera_Pos;
                Camera_Shake = true;
                Camera_Shake_End = false;
            }
        }
             
        public Vector2 Object_Vector(Vector2 Object)
        {
            return new Vector2(Object.X + (Global.GraphicsDevice.PreferredBackBufferWidth/2 - Camera_Pos.X), Object.Y + (Global.GraphicsDevice.PreferredBackBufferHeight/2 - Camera_Pos.Y)); 
        }
    }
}
