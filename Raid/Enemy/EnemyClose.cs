using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Raid.Basic_System;
using Raid.MainCharacter;
using System;


namespace Raid.Enemy
{
    public class EnemyClose:Enemy
    {

        Random num = new Random();                     
        public readonly float Moving_speed = 2.3f;         
        private AnimatedTexture animated_left;
        private AnimatedTexture animated_right;       
        private Texture2D animated;
        
        public EnemyClose(Vector2 Spawn_Pos) 
        {
            Load(Spawn_Pos);                    
        }
        private void Load(Vector2 Pos)
        {
            base.texture = Global.Content.Load<Texture2D>("enemy_Close_Left_attacked");
            animated = Global.Content.Load<Texture2D>("enemy_Close_Left");
            animated_left = new AnimatedTexture(Vector2.Zero,0f,1f,0.5f);
            animated_right = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            animated_left.Load(Global.Content, "enemy_Close_Left",4,3,4);
            animated_right.Load(Global.Content, "enemy_Close_Right", 4, 3,4);
            base.HP = num.Next(160,260);
            base.Alive = true;
            base.Enemy_ATK_Range = Global.Tile*1.5f;
            base.Enemy_state = 1;
            base.Enemy_Detection_Range = Global.Tile * 10;
            
            Render_Range = Global.GraphicsDevice.PreferredBackBufferWidth;
            Enemy_is_Alert = false;
            Enemy_is_attack = false;
            base.Enemt_ATK_DMG = num.Next(4,8);
            base.Vector2 = Pos;
            base.Load();
        }
        
        public override void Update(Vector2 Player_Pos)
        {            
            Enemy_Distance = (float)Math.Sqrt(Math.Pow(Player_Pos.X - (base.Vector2.X), 2) + Math.Pow(Player_Pos.Y - (base.Vector2.Y), 2));
            Push();
            if (Enemy_Distance <= Render_Range)
            {            
                if (base.HP <= 0)
                {
                fading -= (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if(fading <= 0)
                    {
                    base.Alive =false;
                    }
                }
                if (base.Alive == true && base.HP > 0)
                {
                    base.Box = new Rectangle((int)base.Vector2.X-120, (int)base.Vector2.Y-120,240,240);
                    if (Enemy_is_Alert == true)
                    {
                        if (stunt == false && Unarmed == false)
                        {
                            if (Get_Pos().X < Player_Pos.X)
                            {
                                Set_Pos(new Vector2(Get_Pos().X + Moving_speed, Get_Pos().Y));
                                Enemy_state = 8;
                            }
                            else if (Get_Pos().X - 3 >= Player_Pos.X)
                            {
                                Set_Pos(new Vector2(Get_Pos().X - Moving_speed, Get_Pos().Y));
                                Enemy_state = 7;
                            }
                            if (Get_Pos().Y < Player_Pos.Y)
                            {
                                Set_Pos(new Vector2(Get_Pos().X, Get_Pos().Y + Moving_speed));
                            }
                            else if (Get_Pos().Y > Player_Pos.Y)
                            {
                                Set_Pos(new Vector2(Get_Pos().X, Get_Pos().Y - Moving_speed));
                            }
                        }
                    }
                    
                }
                    
                if (base.Unarmed == true)                    
                {
                    Enemy_is_attack = false;
                    base.Unarmed_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if(base.Unarmed_time > 2.5)
                    {
                        base.Unarmed = false;
                        base.Unarmed_time = 0;
                    } 
                }
                if(base.stunt == true)
                {
                    base.stunt_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;                                    
                    if (stunt_time > 0.3f)
                    {
                        base.stunt_time = 0;
                        base.stunt = false;
                        effect_time = 0;
                    }
                }
                if(base.immune == true) 
                {
                    base.immune_time += 1;
                    if(base.immune_time >= 36)
                    {
                        base.immune = false;
                        base.immune_time = 0;
                    }
                }
                if(base.stunt == false && base.Unarmed==false)
                {
                   
                    if (Enemy_Distance < Enemy_Detection_Range)
                    {
                        Enemy_is_Alert = true;
                    }
                    else if(Enemy_Distance >= Enemy_Detection_Range)
                    {
                        Enemy_is_Alert = false;
                    }
                    if (Enemy_Distance < Enemy_ATK_Range)
                    {
                        Enemy_is_attack = true;
                        base.Unarmed = true;
                    }
                }
               
                
            }
            base.Update(Player_Pos);
        }
        float fading = 1;
        float effect_time = 0;
        public void animate(Vector2 Pos)
        {
            if (Enemy_Distance <= Render_Range)
            {
                Pos.X -= 160;
                Pos.Y -= 160;
                animated_left.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                animated_right.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                if (base.Alive == true && base.HP > 0)
                {
                    if (base.stunt == false)
                    {
                        if (base.Enemy_state == 1)
                        {
                            if (base.Unarmed == true && base.Unarmed_time < 0.3f)
                            {
                                animated_left.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                                animated_left.DrawFrame(Global.spriteBatch, Pos, 2);
                            }
                            else if (Unarmed == false || base.Unarmed_time >= 0.3f)
                            {
                                animated_left.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                                animated_left.DrawFrame(Global.spriteBatch, Pos, 3);
                            }
                        }
                        if (base.Enemy_state == 2)
                        {
                            if (base.Unarmed == true && base.Unarmed_time < 0.3f)
                            {
                                animated_right.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                                animated_right.DrawFrame(Global.spriteBatch, Pos, 2);
                            }
                            else if (Unarmed == false || base.Unarmed_time >= 0.3f)
                            {
                                animated_right.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                                animated_right.DrawFrame(Global.spriteBatch, Pos, 3);
                            }
                        }
                        if (base.Enemy_state == 7)
                        {

                            if (base.Unarmed == true && base.Unarmed_time < 0.3f)
                            {
                                animated_left.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                                animated_left.DrawFrame(Global.spriteBatch, Pos, 2);
                            }
                            else if (Unarmed == false || base.Unarmed_time >= 0.3f)
                            {
                                animated_left.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                                animated_left.DrawFrame(Global.spriteBatch, Pos, 1);
                            }
                        }
                        if (base.Enemy_state == 8)
                        {

                            if (base.Unarmed == true && base.Unarmed_time < 0.3f)
                            {
                                animated_right.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                                animated_right.DrawFrame(Global.spriteBatch, Pos, 2);
                            }
                            else if (Unarmed == false || base.Unarmed_time >= 0.3f)
                            {
                                animated_right.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                                animated_right.DrawFrame(Global.spriteBatch, Pos, 1);
                            }

                        }

                    }
                    else if (base.stunt == true)
                    {
                        effect_time += 1;
                        if (effect_time == 1|| effect_time == 2 || effect_time == 3 || effect_time == 4 || effect_time == 7 || effect_time == 8 || effect_time == 9)
                        {
                            if (base.Enemy_state == 8)
                            {
                                Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 320, 320), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.5f);
                            }
                            if (base.Enemy_state == 7)
                            {
                                Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 320, 320), Color.White);
                            }
                        }
                        else
                        {
                            if (base.Enemy_state == 8)
                            {
                                Global.spriteBatch.Draw(animated, Pos, new Rectangle(0, 0, 320, 320), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.5f);
                            }
                            if (base.Enemy_state == 7)
                            {
                                Global.spriteBatch.Draw(animated, Pos, new Rectangle(0, 0, 320, 320), Color.White);
                            }
                        }
                        
                    }
                }
                else if (base.HP <= 0)
                {

                    if (base.Enemy_state == 8)
                    {
                        Global.spriteBatch.Draw(animated, Pos, new Rectangle(0, 0, 320, 320), Color.Red * fading,0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.5f);
                    }
                    if (base.Enemy_state == 7)
                    {
                        Global.spriteBatch.Draw(animated, Pos, new Rectangle(0, 0, 320, 320), Color.Red * fading);
                    }
                    if (fading > 0)
                    {
                        fading -= (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    }
                }

            }  
            base.animate();
        }
        Vector2 Pos;
        float v = 0;
        float a = -6;
        float U = 0;
        public override void Get_Push(float U, Vector2 Pos)
        {
            this.U = U;
            this.Pos = Pos;
            Audio.soundEffects[2].CreateInstance().Play();
        }
        public void Push()
        {
            Push_Time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
            v = (U + (a * Push_Time));
            if (v < 0)
            {
                v = 0;
                U = 0;
                Push_Time = 0;
            }
            if (Pos.X >= base.Vector2.X)
            {                
                base.Vector2.X -= v * (float)Math.Cos(Math.Atan((Pos.Y - base.Vector2.Y) / (Pos.X - base.Vector2.X)));
                base.Vector2.Y -= v * (float)Math.Sin(Math.Atan((Pos.Y - base.Vector2.Y) / (Pos.X - base.Vector2.X)));
            }
            else if (Pos.X < base.Vector2.X)
            {              
                base.Vector2.X -= -v * (float)Math.Cos(Math.Atan((Pos.Y - base.Vector2.Y) / (Pos.X - base.Vector2.X)));
                base.Vector2.Y -= -v * (float)Math.Sin(Math.Atan((Pos.Y - base.Vector2.Y) / (Pos.X - base.Vector2.X)));
            }
            
        }
        public double get_stunt()
        {
            return base.stunt_time;
        }


    }
}
