using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Enemy
{
    public class EnemyBoss:Enemy
    {
        
        AnimatedTexture animated_left;
        AnimatedTexture animated_right;
        Texture2D animated;
        Random num = new Random();
        public EnemyBoss(Vector2 Spawn) 
        {
            Load(Spawn);
        }
        private void Load(Vector2 Pos)
        {
            base.texture = Global.Content.Load<Texture2D>("boss-sheet_96_Right");
            animated = Global.Content.Load<Texture2D>("enemy_boss_sheet_96_Left_2");
            animated_left = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            animated_right = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            animated_left.Load(Global.Content, "enemy_boss_sheet_96_Left_2", 4, 3, 4);
            animated_right.Load(Global.Content, "boss-sheet_96_Right", 4, 3, 4);
            base.HP = num.Next(450,500);
            base.Alive = true;
            base.Enemy_ATK_Range = Global.Tile * 1.5f;
            base.Enemy_state = 1;
            base.Enemy_Detection_Range = Global.Tile * 8.5f;
            Render_Range = Global.Tile * 14;
            Enemy_is_Alert = false;
            Enemy_is_attack = false;
            base.Enemt_ATK_DMG = 14;
            base.Vector2 = Pos;
            base.Moving_speed = 0.5f;
            base.Load();
        }

        public void Update(Vector2 Player_Pos)
        {
            Enemy_Distance = (float)Math.Sqrt(Math.Pow(Player_Pos.X - (base.Vector2.X), 2) + Math.Pow(Player_Pos.Y - (base.Vector2.Y), 2));
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
                    if (base.Unarmed_time > 2.5)
                    {
                        base.Unarmed = false;
                        base.Unarmed_time = 0;
                    }
                }
                if (base.stunt == true)
                {
                    base.stunt_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if (stunt_time > 0.1f)
                    {
                        base.stunt_time = 0;
                        base.stunt = false;
                    }
                }
                if (base.immune == true)
                {
                    base.immune_time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if (base.immune_time >= 0.49f)
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
                        Enemy_is_attack = true;
                        base.Unarmed = true;
                    }
                }
            }
            base.Update();
        }
        float fading = 1;
        public void animate(Vector2 Pos)
        {
            if (Enemy_Distance <= Render_Range)
            {
                Pos.X -= 96;
                Pos.Y -= 102;
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
                        if (base.Enemy_state == 8)
                        {
                            Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 192, 192), Color.Red);
                        }
                        if (base.Enemy_state == 7)
                        {
                            Global.spriteBatch.Draw(animated, Pos, new Rectangle(0, 0, 192, 192), Color.Red);
                        }
                    }
                }
                else if (base.HP <= 0)
                {

                    if (base.Enemy_state == 8)
                    {
                        Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 160, 160), Color.Red * fading);
                    }
                    if (base.Enemy_state == 7)
                    {
                        Global.spriteBatch.Draw(animated, Pos, new Rectangle(0, 0, 160, 160), Color.Red * fading);
                    }
                    if (fading > 0)
                    {
                        fading -= (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                    }
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
