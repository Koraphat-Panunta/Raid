using Microsoft.Xna.Framework;
using System;

namespace Raid.Enemy
{
    public class Weapon_range:Dynamic_Obg
    {        
        private float Velocity = 3f;
        private float velocity_x;
        private float velocity_y;
        public Weapon_range() 
        {
            base.animation = new AnimatedTexture(Vector2.Zero,0f,1f,0.5f);
            base.animation.Load(Global.Content, "enemy_range_weapon",4,1,3);
        }
        public void update()
        {
            base.Vector2.X += velocity_x;
            base.Vector2.Y += velocity_y;
            base.Box = new Rectangle((int)base.Vector2.X, (int)base.Vector2.Y,20,20);
            
        }
        public void animate(Vector2 Pos)
        {
            base.animation.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
            Pos.X -= 50;
            Pos.Y -= 50;
            base.animation.DrawFrame(Global.spriteBatch,Pos);
        }
        public void Shoot(Vector2 Enemy_Pos,Vector2 Player_Pos)
        {
            base.Vector2 = Enemy_Pos;
            if (Player_Pos.X >= base.Vector2.X)
            {
                velocity_x = Velocity *(float)Math.Cos(Math.Atan((Player_Pos.Y - base.Vector2.Y) / (Player_Pos.X - base.Vector2.X)));
                velocity_y = Velocity * (float)Math.Sin(Math.Atan((Player_Pos.Y - base.Vector2.Y) / (Player_Pos.X - base.Vector2.X)));
            }
            else if (Player_Pos.X < base.Vector2.X)
            {
                velocity_x = -Velocity * (float)Math.Cos(Math.Atan((Player_Pos.Y - base.Vector2.Y) / (Player_Pos.X - base.Vector2.X)));
                velocity_y = -Velocity * (float)Math.Sin(Math.Atan((Player_Pos.Y - base.Vector2.Y) / (Player_Pos.X - base.Vector2.X)));
            }           
        }
        public AnimatedTexture Get_animation()
        {
            return base.animation;
        }
        public Rectangle Return_box()
        {
            return base.Box;
        }
        public Vector2 Return_Pos() 
        {
            return base.Vector2;
        }
    }
}
