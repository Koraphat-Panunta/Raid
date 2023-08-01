using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.MainCharacter
{
    public class Main_Character
    {
        Main_Character_Mechanic Character_Mechanic = new Main_Character_Mechanic(100, 6, 2);
        Main_Character_Animate Character_Animate = new Main_Character_Animate(Vector2.Zero, 0, 1f, 0.5f);
        //Char_idle_State
        bool Main_Char_idle_Up ;
        bool Main_Char_idle_Down ;
        bool Main_Char_idle_left;
        bool Main_Char_idle_right ;
        //Char_Moving_State
        bool Main_Char_Moving_Up ;
        bool Main_Char_Moving_Down ;
        bool Main_Char_Moving_Left ;
        bool Main_Char_Moving_Right ;
        //Char_CommonAtack_State
        bool Main_Char_Common_Attack_Up;
        bool Main_Char_Common_Attack_Down ;
        bool Main_Char_Common_Attack_Left ;
        bool Main_Char_Common_Attack_Right ;
        //Char_status
        bool Main_Char_Alive;
        public Main_Character()
        {

        }
        public void Main_Character_Update()
        {

        }
        public Vector2 Get_MainCharacterPos()
        {
            return Character_Mechanic.CharPos;
        }

    }
}
