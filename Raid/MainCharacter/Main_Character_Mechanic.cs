using Microsoft.Xna.Framework;

namespace Raid.MainCharacter
{
    public class Main_Character_Mechanic
    {
        public Vector2 CharPos;
        private float HP;
        public int Hitstreak;
        private int Moving_Speed;

        public Main_Character_Mechanic(float HP,int Hitsteak,int Speed) 
        {
            this.HP = HP;
            this.Hitstreak = Hitsteak;
            this.Moving_Speed = Speed;
        }
        public void Main_Character_Action(string Character_State)
        {
            if(Character_State == "Main_Char_Moving_Up")
            {
                CharPos.Y -= Moving_Speed;
            }
            if(Character_State == "Main_Char_Moving_Down")
            {
                CharPos.Y += Moving_Speed;
            }
            if(Character_State == "Main_Char_Moving_Left")
            {
                CharPos.X -= Moving_Speed;
            }
            if(Character_State == "Main_Char_Moving_Right")
            {
                CharPos.X += Moving_Speed;
            }
        }
        public void Upgrade_HP(float HP) 
        {
            this.HP += HP;
        }
    }
}
