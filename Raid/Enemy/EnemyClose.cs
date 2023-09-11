using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Enemy_is_attack;
        public EnemyClose(Vector2 Spawn_Pos) 
        {
            Load(Spawn_Pos);                    
        }
        private void Load(Vector2 Pos)
        {
            base.texture = Global.Content.Load<Texture2D>("sprite-golem");
            base.animation = new AnimatedTexture(Vector2.Zero, 0f, 1.5f, 0.5f);
            base.animation.Load(Global.Content,"sprite-golem", 4, 2, 3);
            base.HP = num.Next(60,80);
            base.Alive = true;
            base.Enemy_ATK_Range = Global.Tile*0.5f;
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
                    if(stunt_time > 0.5)
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
        public void animate(Vector2 Pos)
        {
            Pos.X -= 24;
            Pos.Y -= 36;
            base.animation.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
            if(base.Alive == true)
            {
                if (base.stunt == false)
                {

                    if (base.Enemy_state == idle_left)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 1);
                    }
                    if (base.Enemy_state == idle_right)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 1);
                    }
                    if (base.Enemy_state == Moving_left)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 1);
                    }
                    if (base.Enemy_state == idle_right)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 1);
                    }
                    if (Enemy_is_attack == true)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 2);
                    }
                }
                else if(base.stunt == true)
                {
                    Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0, 48, 48), Color.Violet * 1f, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.5f);
                }
            }
            else if(base.Alive == false)
            {
                Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 0,48,48),Color.Red*1.8f,0f,Vector2.Zero,1.5f,SpriteEffects.None,0.5f);
            }
            
            
            base.animate();
        }
        public double get_stunt()
        {
            return base.stunt_time;
        }


    }
}
