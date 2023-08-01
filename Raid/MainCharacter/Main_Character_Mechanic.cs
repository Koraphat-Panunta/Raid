using Microsoft.Xna.Framework;

namespace Raid.MainCharacter
{
    public class Main_Character_Mechanic
    {
        public Vector2 CharPos;
        public int HP;
        public int Hitstreak;
        private int Moving_Speed;

        public Main_Character_Mechanic(int HP,int Hitsteak,int Speed) 
        {
            this.HP = HP;
            this.Hitstreak = Hitsteak;
            this.Moving_Speed = Speed;
        }
        public void Main_Character_Action(string Character_State)
        {
            if(Character_State == "MovingUp")
            {
                CharPos.Y -= Moving_Speed;
            }
        }
        public void Upgrade_HP(int HP) 
        {
            this.HP += HP;
        }
    }
}
