using Microsoft.Xna.Framework;

namespace Raid.MainCharacter
{
    public class Main_Character_Mechanic
    {
        public Vector2 CharPos;
        private Rectangle Char_Hitbox;
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
            Update_Regtangle();
        }
        public void Upgrade_HP(float HP) 
        {
            this.HP += HP;
        }
        public void Set_Char_Box(Rectangle Charbox)
        {
            Char_Hitbox = Charbox;
        }
        private void Update_Regtangle()
        {
            Char_Hitbox = new Rectangle((int)CharPos.X,(int)CharPos.Y,Char_Hitbox.Width,Char_Hitbox.Height);
        }
        public Rectangle Get_CharBox()
        {
            return Char_Hitbox;
        }
    }
}
