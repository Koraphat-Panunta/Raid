using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Basic_System
{
    public class FrameEffect
    {
        Texture2D texture;
        Rectangle Rectangle;
        Vector2 Pos;
        Vector2 Draw_Pos;
        Color Color;
        public float Time = 0;
       
        public float Trans_Time;
        public FrameEffect(Texture2D texture,Rectangle rectangle,Vector2 Pos,Color color,float time) 
        { 
            this.texture = texture;
            this.Rectangle = rectangle;
            this.Pos = new Vector2(Pos.X-192,Pos.Y-192);            
            Trans_Time = 0.6f;
            this.Color = color;
            this.Time = time;
      
        }
       
        public void Animate(Vector2 Pos)
        {
            
            Global.spriteBatch.Draw(this.texture,Pos, this.Rectangle, this.Color * Trans_Time);
            Trans_Time -= Time;
        }
        public Vector2 Get_Vector() 
        {
            return this.Pos;
        }

    }
}
