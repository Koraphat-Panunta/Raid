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
        public Main_Character()
        {

        }
        public Vector2 Get_MainCharacterPos()
        {
            return Character_Mechanic.CharPos;
        }

    }
}
