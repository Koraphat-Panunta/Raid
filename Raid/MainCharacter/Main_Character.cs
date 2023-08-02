﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.MainCharacter
{
    public class Main_Character
    {
        private Main_Character_Mechanic Character_Mechanic = new Main_Character_Mechanic(100, 6, 2);
        private Main_Character_Animate Character_Animate = new Main_Character_Animate(Vector2.Zero, 0, 1f, 0.5f);
        public string Main_Char_curt_State;//Char_currentstate
        //Char_idle_State
        private string Main_Char_idle_Up = "Main_Char_idle_Up" ;
        private string Main_Char_idle_Down = "Main_Char_idle_Down";
        private string Main_Char_idle_left = "Main_Char_idle_left";
        private string Main_Char_idle_right = "Main_Char_idle_right";
        //Char_Moving_State
        private string Main_Char_Moving_Up = "Main_Char_Moving_Up";
        private string Main_Char_Moving_Down = "Main_Char_Moving_Down";
        private string Main_Char_Moving_Left = "Main_Char_Moving_Left";
        private string Main_Char_Moving_Right = "Main_Char_Moving_Right";
        //Char_CommonAtack_State
        private string Main_Char_Common_Attack_Up = "Main_Char_Common_Attack_Up";
        private string Main_Char_Common_Attack_Down = "Main_Char_Common_Attack_Down";
        private string Main_Char_Common_Attack_Left = "Main_Char_Common_Attack_Left";
        private string Main_Char_Common_Attack_Right = "Main_Char_Common_Attack_Right";
        //Char_status
        private string Main_Char_Alive;
        public Main_Character()
        {
            Main_Char_curt_State = Main_Char_idle_right;
        }
        public void load()
        {           
        }
        public void Main_Character_Updatestate()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Main_Char_curt_State = Main_Char_Moving_Up;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Main_Char_curt_State = Main_Char_Moving_Left;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Main_Char_curt_State = Main_Char_Moving_Down;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Main_Char_curt_State = Main_Char_Moving_Right;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W)&&Main_Char_curt_State == Main_Char_Moving_Up)
            {
                Main_Char_curt_State = Main_Char_idle_Up;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.A)&&Main_Char_curt_State == Main_Char_Moving_Left)
            {
                Main_Char_curt_State = Main_Char_idle_left;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.S) && Main_Char_curt_State == Main_Char_Moving_Down)
            {
                Main_Char_curt_State = Main_Char_idle_Down;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.D) && Main_Char_curt_State == Main_Char_Moving_Right)
            {
                Main_Char_curt_State = Main_Char_idle_right;
            }
            Character_Mechanic.Main_Character_Action(Main_Char_curt_State);

        }
        public void Deploy_Pos(Vector2 Deploy_Pos)
        {
            Character_Mechanic.CharPos = Deploy_Pos;
        }
        
        public void Set_MainCharacterPos(Vector2 CharPos)
        {
            Character_Mechanic.CharPos = CharPos;
        }
        public Vector2 Get_MainCharacterPos()
        {
            return Character_Mechanic.CharPos;
        }
        public void Animate()
        {
            Character_Animate.Animate(Get_MainCharacterPos(),Main_Char_curt_State);
        }

    }
}
