using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Raid.Basic_System;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Raid.Enemy
{

    public class EnemyRange : Enemy
    {
        public List<Weapon_range> fire_ball = new List<Weapon_range>();
        private Random random = new Random();
        private AnimatedTexture animation;
        private Texture2D texture;
        private readonly float Moving_speed = 1f;
        private float attact_duration = 0;
        public EnemyRange(Vector2 Spawn_Pos)
        {
            base.animation = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            this.animation = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            base.animation.Load(Global.Content, "enemy_range_left", 4, 1, 4);
            this.animation.Load(Global.Content, "enemy_range_Right", 4, 1, 4);
            base.texture = Global.Content.Load<Texture2D>("enemy_range_Right");
            this.texture = Global.Content.Load<Texture2D>("enemy_range_left");
            base.Vector2 = Spawn_Pos;
            base.HP = random.Next(35,50);
            base.Alive = true;
            base.Enemt_ATK_DMG = random.Next(4,6);
            base.Enemy_Detection_Range = Global.Tile * 8;
            base.Enemy_ATK_Range = Global.Tile * 7.5f;
            base.Enemy_state = 7;
            base.Render_Range = Global.Tile * 17;
            base.Enemy_is_Alert = false;
            base.Enemy_is_attack = false;            
            //1:left
            //2:right            
            base.texture = Global.Content.Load<Texture2D>("enemy_range_left");
        }
        public override void Update(Vector2 Player_Pos)
        {
            base.Enemy_Distance = (float)Math.Sqrt(Math.Pow(Player_Pos.X - (base.Vector2.X), 2) + Math.Pow(Player_Pos.Y - (base.Vector2.Y), 2));
            Push();
            if (fire_ball.Count > 0)
            {
                attact_duration += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                fire_ball[fire_ball.Count - 1].update();
                if(attact_duration >= 5)
                {
                    fire_ball.RemoveAt(fire_ball.Count - 1);
                    attact_duration = 0;
                }
            }
            if(fire_ball.Count <= 0)
            {
                attact_duration = 0;
            }
            if (Enemy_Distance <= Render_Range)
            {
                if (base.HP <= 0)
                {
                    fading -= (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if (fading <= 0)
                    {
                        base.Alive = false;
                    }
                }
                if (base.Alive == true && base.HP > 0)
                {

                    if (Enemy_is_Alert == true && stunt == false && immune == false)
                    {
                       
                            if (Enemy_Distance >= Enemy_ATK_Range)
                            {
                                if (base.Vector2.X < Player_Pos.X)
                                {
                                    base.Vector2.X += Moving_speed;
                                    Enemy_state = 8;
                                }
                                else if (base.Vector2.X - 3 >= Player_Pos.X)
                                {
                                    base.Vector2.X -= Moving_speed;
                                    Enemy_state = 7;
                                }
                                if (base.Vector2.Y < Player_Pos.Y)
                                {
                                    base.Vector2.Y += Moving_speed;
                                }
                                else if (base.Vector2.Y > Player_Pos.Y)
                                {
                                    base.Vector2.Y -= Moving_speed;
                                }
                            }
                            else if (Enemy_Distance < Global.Tile*4.5)
                            {
                                if (base.Vector2.X < Player_Pos.X)
                                {
                                    base.Vector2.X -= Moving_speed*0.75f;
                                    Enemy_state = 8;
                                }
                                else if (base.Vector2.X - 3 >= Player_Pos.X)
                                {
                                    base.Vector2.X += Moving_speed * 0.75f;
                                    Enemy_state = 7;
                                }
                                if (base.Vector2.Y < Player_Pos.Y)
                                {
                                    base.Vector2.Y -= Moving_speed * 0.75f;
                                }
                                else if (base.Vector2.Y > Player_Pos.Y)
                                {
                                    base.Vector2.Y += Moving_speed * 0.75f;
                                }
                            }                                                 
                    }                   
                }

                if (base.Unarmed == true)
                {
                    Enemy_is_attack = false;
                    base.Unarmed_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;                    
                    if (base.Unarmed_time > 5)
                    {                       
                        base.Unarmed = false;
                        base.Unarmed_time = 0;
                    }
                }
                if (base.stunt == true)
                {
                    base.stunt_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if (stunt_time > 0.3)
                    {
                        base.stunt_time = 0;
                        base.stunt = false;
                    }
                }
                if (base.immune == true)
                {
                    base.immune_time += 1;
                    if (base.immune_time >= 36)
                    {
                        base.immune = false;
                        base.immune_time = 0;
                    }
                }
                if (base.stunt == false && base.Unarmed == false)
                {

                    if (Enemy_Distance < Enemy_Detection_Range)
                    {
                        Enemy_is_Alert = true;
                    }
                    else if (Enemy_Distance >= Enemy_Detection_Range)
                    {
                        Enemy_is_Alert = false;
                    }
                    if (Enemy_Distance < Enemy_ATK_Range)
                    {
                        fire_ball.Add(new Weapon_range());
                        fire_ball[fire_ball.Count-1].Shoot(base.Vector2,Player_Pos);
                        Enemy_is_attack = true;
                        base.Unarmed = true;
                    }
                }
            }
            if (base.Alive == true)
            {
                base.Box = new Rectangle((int)base.Vector2.X, (int)base.Vector2.Y, 128, 129);
            }
            base.Update(Player_Pos);
            
        }
        public void animate(Vector2 Pos)
        {
            if (Enemy_Distance <= Render_Range)
            {
                Pos.X -= 80;
                Pos.Y -= 80;
                base.animation.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                this.animation.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                if (base.Alive == true && base.HP > 0)
                {
                    if (base.stunt == false)
                    {
                        if (base.Enemy_state == 7)
                        {
                            base.animation.DrawFrame(Global.spriteBatch,Pos,1);
                        }
                        if (base.Enemy_state == 8)
                        {
                            this.animation.DrawFrame(Global.spriteBatch,Pos,1);
                        }                       
                    }
                    else if (base.stunt == true)
                    {
                        if (base.Enemy_state == 8)
                        {
                            Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 128, 128), Color.Red);
                        }
                        if (base.Enemy_state == 7)
                        {
                            Global.spriteBatch.Draw(this.texture, Pos, new Rectangle(0, 0, 128, 128), Color.Red);
                        }
                    }                    
                }
                else if (base.HP <= 0)
                {

                    if (base.Enemy_state == 8)
                    {
                        Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 128, 128), Color.Red * fading);
                    }
                    if (base.Enemy_state == 7)
                    {
                        Global.spriteBatch.Draw(this.texture, Pos, new Rectangle(0, 0, 128, 128), Color.Red * fading);
                    }
                    if (fading > 0)
                    {
                        fading -= (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    }
                }

            }
        }
        float v = 0;
        float a = -6;
        float U = 0;
        Vector2 Pos;
        public override void Get_Push(float U, Vector2 Pos)
        {
            this.U = 0.5f;
            this.Pos = Pos;
            Audio.soundEffects[3].CreateInstance().Play();
        }
        private void Push()
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
        public Rectangle get_weaponBox()
        {
            return fire_ball[fire_ball.Count - 1].Return_box();
        }
        public Vector2 Get_Weapon_Pos()
        {
            return fire_ball[fire_ball.Count-1].Return_Pos();
        }
    }
}
