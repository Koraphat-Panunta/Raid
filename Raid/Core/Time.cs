

namespace Raid.Core
{
    public class Time
    {
        private int TimeCount;
        private float update;
        public Time(int time) 
        {
            update = 0;
            TimeCount = time;
        }       
        public void Time_Count()
        {
            update += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
            if(update > 1)
            {
                TimeCount -= 1;
                update = 0;
            }
        }
        public int Get_Time_Count() { return TimeCount; }
    }
}
