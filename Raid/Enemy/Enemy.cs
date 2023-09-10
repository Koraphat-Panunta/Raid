using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel.Design;

namespace Raid.Enemy
{
    abstract public class Enemy:Dynamic_Obg
    {
        public double HP;       
        public string Enemy_state;
        protected bool Alive;
        public bool immune;
        public bool stunt;
        public bool Unarmed;
        protected double stunt_time;
        protected double Unarmed_time;
        protected float immune_time;
        public float Enemy_ATK_Range;
        public float Enemy_Detection_Range;
        public int Enemt_ATK_DMG;
        bool Enemy_Alive;

        public Enemy()
        {

        }
        public virtual void Load() { }
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
        public string GetState()
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
    }
}
