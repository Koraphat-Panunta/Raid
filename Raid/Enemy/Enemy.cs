using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Enemy
{
    abstract public class Enemy
    {
        protected int HP;
        protected Texture2D Enemy_Texture;
        protected AnimatedTexture Enemy_animation;
        protected Rectangle Enemy_Box;
        protected Vector2 Enemy_Position;
        protected string Enemy_state;
        protected bool Alive;
        protected bool immune;
        protected bool stunt;

        bool Enemy_Alive;

        public Enemy()
        {

        }      
        public Vector2 Get_Pos()
        {
            return Enemy_Position;
        }
        public Texture2D GetTexture()
        {
            return Enemy_Texture;
        }
        public Rectangle GetBox()
        {
            return Enemy_Box;
        }
        public string GetState()
        {
            return Enemy_state;
        }
    }
}
