using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Raid.Enemy
{
    public class EnemyClose:Enemy
    {

        Random num = new Random();
        public bool Enemy_is_Alert;        
        public string idle_left = "idle_left";
        public string idle_right = "idle_right";
        public string Moving_left = "Moving_left";
        public string Moving_right = "Moving_right";
        public readonly int Moving_speed = 1; 
        public bool Enemy_is_attack;
        private AnimatedTexture animated_left;
        private AnimatedTexture animated_right;       
        private Texture2D animated;
        public EnemyClose(Vector2 Spawn_Pos) 
        {
            Load(Spawn_Pos);                    
        }
        private void Load(Vector2 Pos)
        {
            base.texture = Global.Content.Load<Texture2D>("enemy_Close_Right");
            animated = Global.Content.Load<Texture2D>("enemy_Close_Left");
            animated_left = new AnimatedTexture(Vector2.Zero,0f,1f,0.5f);
            animated_right = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            animated_left.Load(Global.Content, "enemy_Close_Left",4,3,4);
            animated_right.Load(Global.Content, "enemy_Close_Right", 4, 3,4);
            base.HP = num.Next(60,80);
            base.Alive = true;
            base.Enemy_ATK_Range = Global.Tile*1.5f;
            base.Enemy_state = idle_left;
            base.Enemy_Detection_Range = Global.Tile * 5;
            Enemy_is_Alert = false;
            Enemy_is_attack = false;
            base.Enemt_ATK_DMG = num.Next(4,8);
            base.Vector2 = Pos;
            base.Load();
        }
        public float Enemy_Distance;
        public void Update(Vector2 Player_Pos)
        {
            Enemy_Distance = (float)Math.Sqrt(Math.Pow(Player_Pos.X - (base.Vector2.X), 2) + Math.Pow(Player_Pos.Y - (base.Vector2.Y), 2));
            if (base.HP <= 0)
            {
                base.Alive = false;
            }
            if (base.Alive == true)
            {
                if (base.Unarmed == true)
                {
                    Enemy_is_attack = false;
                    base.Unarmed_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if(base.Unarmed_time > 3)
                    {
                        base.Unarmed = false;
                        base.Unarmed_time = 0;
                    } 
                }
                if(base.stunt == true)
                {
                    base.stunt_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;                                    
                    if (stunt_time > 0.5)
                    {
                        base.stunt_time = 0;
                        base.stunt = false;
                    }
                }
                if(base.immune == true) 
                {
                    base.immune_time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if(base.immune_time >= 0.5)
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
                    if (Enemy_Distance < Enemy_ATK_Range)
                    {
                        Enemy_is_attack = true;
                        base.Unarmed = true;
                    }
                }                             
            }
            
            else
            {

            }            
            base.Update();
        }
        float fading = 1;
        public void animate(Vector2 Pos)
        {
            Pos.X -= 80;
            Pos.Y -= 80;
            animated_left.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
            animated_right.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
            if (base.Alive == true)
            {
                if (base.stunt == false)
                {
                    if (base.Enemy_state == idle_left)
                    {                      
                        if (base.Unarmed == true && base.Unarmed_time < 0.3f)
                        {                           
                            animated_left.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                            animated_left.DrawFrame(Global.spriteBatch, Pos, 2);
                        }
                        else if(Unarmed == false || base.Unarmed_time >= 0.3f)
                        {
                            animated_left.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                            animated_left.DrawFrame(Global.spriteBatch, Pos, 3);
                        }
                    }
                    if (base.Enemy_state == idle_right)
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
                    if (base.Enemy_state == Moving_left)
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
                    if (base.Enemy_state == Moving_right)
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
                    if(base.Enemy_state == Moving_right)
                    {
                        Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 160, 160), Color.Red);
                    }
                    if(base.Enemy_state == Moving_left)
                    {
                        Global.spriteBatch.Draw(animated, Pos, new Rectangle(0, 0, 160, 160), Color.Red);
                    }
                }
            }
            else if(base.Alive == false)
            {
                
                if (base.Enemy_state == Moving_right)
                {
                    Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 160, 160), Color.White*fading);
                }
                if (base.Enemy_state == Moving_left)
                {
                    Global.spriteBatch.Draw(animated, Pos, new Rectangle(0, 0, 160, 160), Color.White*fading);
                }
                if(fading > 0)
                {
                    fading -= (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            
            
            base.animate();
        }
        public double get_stunt()
        {
            return base.stunt_time;
        }


    }
}
