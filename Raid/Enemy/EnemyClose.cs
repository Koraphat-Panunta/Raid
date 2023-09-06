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
        private float Enemy_ATK_Range;
        public EnemyClose() 
        {
            base.Enemy_Texture = Global.Content.Load<Texture2D>("");
            base.Enemy_animation = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            //base.Enemy_animation.Load(Global.Content,"");
            base.HP = num.Next(50,90);
            base.Alive = true;
            Enemy_is_Alert = false;

        }
        public void Enemy_Update()
        {
            if (base.Alive == true)
            {

            }
            else
            {

            }
        }
        
        
    }
}
