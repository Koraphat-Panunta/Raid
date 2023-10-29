using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace Raid.Enemy
{
     public class Enemy:Dynamic_Obg
    {
        public double HP;       
        public int Enemy_state;
        public bool Alive;
        public bool immune;
        public bool stunt;
        public bool Unarmed;
        protected double stunt_time;
        protected double Unarmed_time;
        protected float immune_time;
        public float Enemy_ATK_Range;
        public float Enemy_Detection_Range;
        public int Enemt_ATK_DMG;
        public float Enemy_Distance;
        protected float Render_Range;
        protected float fading = 1;
        public bool Enemy_is_Alert;
        public bool Enemy_is_attack;
        public float Moving_speed;
        float a = -1.25f;
        public float v = 0;


        public Enemy()
        {

        }
        public virtual void Load() { }
        public virtual void Update(Vector2 vector) 
        {
           

        }
        public virtual void animate()
        {

        }
        public Vector2 Get_Pos()
        {
            return base.Vector2;
        }
        public Texture2D GetTexture()
        {
            return base.texture;
        }
        public Rectangle GetBox()
        {
            return base.Box;
        }
        public int GetState()
        {
            return Enemy_state;
        }
        public void Set_Pos(Vector2 Pos)
        {
            base.Vector2 = Pos;
        }
        public void Get_DMG(double DMG)
        {
            HP -= DMG;
        }
        protected float Push_Time = 0;
        public bool Pushing = false;
        protected bool Push_Ready = true;
        Vector2 Push_Pos;
        public virtual void Get_Push(float U,Vector2 Pos)
        {  
           
        }
        public Rectangle Get_Box()
        {
            return Box;
        }
    }
}
