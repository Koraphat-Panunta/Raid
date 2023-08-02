using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.MainCharacter
{
    public class Main_Character_Animate:AnimatedTexture
    {
        AnimatedTexture Char_animate;        
        public Main_Character_Animate(Vector2 Origin,float Rotation,float Scale,float Depth):base(Origin, Rotation, Scale, Depth)
        {
            Char_animate = new AnimatedTexture(Origin, Rotation, Scale, Depth);
            load();
        }
        protected void load()
        {
            Char_animate.Load(Global.Content, "Char_Test", 4, 4, 8);
        }
        public void Animate(Vector2 Char_Pos, string Char_state)
        {
            Char_animate.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
            if (Char_state == "Main_Char_Moving_Up")
            {
                Char_animate.DrawFrame(Global.spriteBatch, Char_Pos, 4);
            }
            if (Char_state == "Main_Char_Moving_Down")
            {
                Char_animate.DrawFrame(Global.spriteBatch, Char_Pos, 1);
            }
            if (Char_state == "Main_Char_Moving_Left")
            {
                Char_animate.DrawFrame(Global.spriteBatch, Char_Pos, 2);
            }
            if (Char_state == "Main_Char_Moving_Right")
            {
                Char_animate.DrawFrame(Global.spriteBatch, Char_Pos, 3);
            }
            if (Char_state == "Main_Char_idle_Up")
            {
                Char_animate.DrawFrame(Global.spriteBatch, 1, Char_Pos, 4);
            }
            if (Char_state == "Main_Char_idle_Down")
            {
                Char_animate.DrawFrame(Global.spriteBatch, 1, Char_Pos, 1);
            }
            if (Char_state == "Main_Char_idle_left")
            {
                Char_animate.DrawFrame(Global.spriteBatch,1, Char_Pos, 2);
            }
            if (Char_state == "Main_Char_idle_right")
            {
                Char_animate.DrawFrame(Global.spriteBatch, 1, Char_Pos, 3);
            }
            
        }
    }
}
