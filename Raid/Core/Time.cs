

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raid.Core
{
    public class Time
    {
        private int TimeCount;
        private float update;
        private SpriteFont Time_font = Global.Content.Load<SpriteFont>("Time");
        private AnimatedTexture Animated = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
        private Texture2D TimeUI = Global.Content.Load<Texture2D>("Time_Icon");
        public Time(int time) 
        {
            update = 0;
            TimeCount = time;
            Animated.Load(Global.Content, "Time_Icon", 2, 1, 1);
        }       
        public void Time_Count()
        {
            update += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
            if(update > 1)
            {
                TimeCount -= 1;
                update = 0;
            }
            Animated.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
        }
        public void animate()
        {
            //Global.spriteBatch.Draw(TimeUI, new Vector2(528+424, 64),new Rectangle(0,0,64,64), Color.White * 0.89f);
            Animated.DrawFrame(Global.spriteBatch, new Vector2(528 + 424, 64));
            Global.spriteBatch.DrawString(Time_font, ":" + TimeCount, new Vector2(576+424,64), Color.DarkBlue*0.89f);
            Global.spriteBatch.DrawString(Time_font, "Sec", new Vector2(635 + 424,88), Color.DarkBlue * 0.89f,0f,Vector2.Zero,0.4f,SpriteEffects.None,0.5f);
        }
        public void Set_Time() { }
        public int Get_Time_Count() { return TimeCount; }
        public SpriteFont GetSpriteFont() { return Time_font; }
    }
}
