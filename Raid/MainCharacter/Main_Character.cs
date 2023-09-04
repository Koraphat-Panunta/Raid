
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
        private Main_Character_Mechanic Character_Mechanic = new Main_Character_Mechanic(100, 6, 3);
        private Main_Character_Animate Character_Animate = new Main_Character_Animate(Vector2.Zero, 0, 1f,1f);
        public Inventory inventory = new Inventory(50f);
        bool KeyIspressed = false;
        public bool Key_ATK_ISPressed = false;
        private string Main_Char_curt_State;//Char_currentstate
        private string Main_Char_ATK_State;
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
        //Char_HeavyAttack_State
        private string Main_Char_Heavy_Attack_Up = "Main_Char_Heavy_Attack_Up";
        private string Main_Char_Heavy_Attack_Down = "Main_Char_Heavy_Attack_Down";
        private string Main_Char_Heavy_Attack_Left = "Main_Char_Heavy_Attack_Left";
        private string Main_Char_Heavy_Attack_Right = "Main_Char_Heavy_Attack_Right";
        //Char_Dodge_State
        private string Main_Char_Dodge_Up = "Main_Char_Dodge_Up";
        private string Main_Char_Dodge_Down = "Main_Char_Dodge_Down";
        private string Main_Char_Dodge_Left = "Main_Char_Dodge_Left";
        private string Main_Char_Dodge_Right = "Main_Char_Dodge_Right";
        //Char_RollAttack_State
        private string Main_Char_Roll_Attack = "Main_Char_Roll_Attack";
        //CHar_None_State
        private string Main_Char_None_Attack = "None";
        
        //Char_status
        private bool Main_Char_Alive;
        public Main_Character()
        {
            Main_Char_curt_State = Main_Char_idle_right;
        }
        public KeyboardState Last_Key;
        public void Main_Character_Updatestate()
        {          
                Update_Input_Moving_state();
                Update_Input_Special_Abillity_state();                      
            //Check ATK state
            Character_Mechanic.Main_Character_Action(Main_Char_curt_State,Main_Char_ATK_State);
            if (Character_Mechanic.Get_HP() <= 0f)
            {
                Main_Char_Alive = false;
            }
        }
        
        private void Update_Input_Moving_state()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && KeyIspressed == false)
            {
                Main_Char_curt_State = Main_Char_Moving_Up;
                KeyIspressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && KeyIspressed == false)
            {
                Main_Char_curt_State = Main_Char_Moving_Left;
                KeyIspressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && KeyIspressed == false)
            {
                Main_Char_curt_State = Main_Char_Moving_Down;
                KeyIspressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && KeyIspressed == false)
            {
                Main_Char_curt_State = Main_Char_Moving_Right;
                KeyIspressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W) && Main_Char_curt_State == Main_Char_Moving_Up)
            {
                Main_Char_curt_State = Main_Char_idle_Up;
                KeyIspressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.A) && Main_Char_curt_State == Main_Char_Moving_Left)
            {
                Main_Char_curt_State = Main_Char_idle_left;
                KeyIspressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.S) && Main_Char_curt_State == Main_Char_Moving_Down)
            {
                Main_Char_curt_State = Main_Char_idle_Down;
                KeyIspressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.D) && Main_Char_curt_State == Main_Char_Moving_Right)
            {
                Main_Char_curt_State = Main_Char_idle_right;
                KeyIspressed = false;
            }           
        }
       
        private void Update_Input_Special_Abillity_state()
        {            
            //Common_ATK
            if (Keyboard.GetState().IsKeyDown(Keys.J) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_Up || Main_Char_curt_State == Main_Char_Moving_Up))
            {
                Main_Char_ATK_State = Main_Char_Common_Attack_Up;                
                Key_ATK_ISPressed = true;                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.J) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_Down || Main_Char_curt_State == Main_Char_Moving_Down))
            {
                Main_Char_ATK_State = Main_Char_Common_Attack_Down;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.J) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_left || Main_Char_curt_State == Main_Char_Moving_Left))
            {
                Main_Char_ATK_State = Main_Char_Common_Attack_Left;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.J) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_right || Main_Char_curt_State == Main_Char_Moving_Right))
            {
                Main_Char_ATK_State = Main_Char_Common_Attack_Right;
                Key_ATK_ISPressed = true;
            }
            ////////////////
            if (Keyboard.GetState().IsKeyUp(Keys.J) && Key_ATK_ISPressed == true && (Main_Char_ATK_State == Main_Char_Common_Attack_Up || Main_Char_ATK_State == Main_Char_Common_Attack_Down || Main_Char_ATK_State == Main_Char_Common_Attack_Left || Main_Char_ATK_State == Main_Char_Common_Attack_Right)||Main_Char_ATK_State == Main_Char_None_Attack)
            {
                Main_Char_ATK_State = Main_Char_None_Attack;
                Key_ATK_ISPressed = false;
            }


            //Heavy_ATK
            if (Keyboard.GetState().IsKeyDown(Keys.K) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_Up || Main_Char_curt_State == Main_Char_Moving_Up))
            {
                Main_Char_ATK_State = Main_Char_Heavy_Attack_Up;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.K) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_Down || Main_Char_curt_State == Main_Char_Moving_Down))
            {
                Main_Char_ATK_State = Main_Char_Heavy_Attack_Down;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.K) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_left || Main_Char_curt_State == Main_Char_Moving_Left))
            {
                Main_Char_ATK_State = Main_Char_Heavy_Attack_Left;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.K) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_right || Main_Char_curt_State == Main_Char_Moving_Right))
            {
                Main_Char_ATK_State = Main_Char_Heavy_Attack_Right;
                Key_ATK_ISPressed = true;
            }
            ///////////////
            if (Keyboard.GetState().IsKeyUp(Keys.K) && Key_ATK_ISPressed == true && (Main_Char_ATK_State == Main_Char_Heavy_Attack_Up || Main_Char_ATK_State == Main_Char_Heavy_Attack_Down || Main_Char_ATK_State == Main_Char_Heavy_Attack_Left || Main_Char_ATK_State == Main_Char_Heavy_Attack_Right))
            {
                Main_Char_ATK_State = Main_Char_None_Attack;
                Key_ATK_ISPressed = false;
            }
            //Dodge
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_Up || Main_Char_curt_State == Main_Char_Moving_Up))
            {
                Main_Char_ATK_State = Main_Char_Dodge_Up;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_Down || Main_Char_curt_State == Main_Char_Moving_Down))
            {
                Main_Char_ATK_State = Main_Char_Dodge_Down;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_left || Main_Char_curt_State == Main_Char_Moving_Left))
            {
                Main_Char_ATK_State = Main_Char_Dodge_Left;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Key_ATK_ISPressed == false && (Main_Char_curt_State == Main_Char_idle_right || Main_Char_curt_State == Main_Char_Moving_Right))
            {
                Main_Char_ATK_State = Main_Char_Dodge_Right;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space) && Key_ATK_ISPressed == true && (Main_Char_ATK_State == Main_Char_Dodge_Up || Main_Char_ATK_State == Main_Char_Dodge_Down || Main_Char_ATK_State == Main_Char_Dodge_Left || Main_Char_ATK_State == Main_Char_Dodge_Right))
            {
                Main_Char_ATK_State = Main_Char_None_Attack;
                Key_ATK_ISPressed = false;
            }
            //Roll_ATK
            if (Keyboard.GetState().IsKeyDown(Keys.L) && Key_ATK_ISPressed == false)
            {
                Main_Char_ATK_State = Main_Char_Roll_Attack;
                Key_ATK_ISPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.L) && Key_ATK_ISPressed == true && (Main_Char_ATK_State == Main_Char_Roll_Attack))
            {
                Main_Char_ATK_State = Main_Char_None_Attack;
                Key_ATK_ISPressed = false;
            }
            Main_Char_ATK_State = Main_Char_None_Attack;
        }
        public void Deploy_Pos(Vector2 Deploy_Pos)
        {
            Character_Mechanic.CharPos = Deploy_Pos;
        }
        
        
        public void Set_MainCharacterPos(Vector2 CharPos)
        {
            Character_Mechanic.CharPos = CharPos;           
        }
        public void Set_MainCharacterHitbox(Rectangle Char_Box)
        {
            Character_Mechanic.Set_Char_Box(Char_Box);  
        }
        public Vector2 Get_MainCharacterPos()
        {
            return Character_Mechanic.CharPos;
        }
        public Rectangle Get_MainCharacterBox()
        {
            return Character_Mechanic.Get_CharBox();
        }
        public void Animate(Vector2 CharPos)
        {
            if(Main_Char_Alive == true)
            {
                Character_Animate.Animate(CharPos, Main_Char_curt_State);
            }
            else if(Main_Char_Alive == false) 
            {
                
            }
        }
        public void Set_state(string state)
        {
            Main_Char_curt_State = state;
        }
        public void Set_Char_Alive(bool status)
        {
            Main_Char_Alive = status;
        }
        public bool Get_Char_Alive()
        {
            return Main_Char_Alive;
        }
        public string Get_state() 
        {
            return Main_Char_curt_State;
        }
        public void Set_ATK_state(string state)
        {
            Main_Char_ATK_State = state;
        }
        public string Get_ATK_state()
        {
            return Main_Char_ATK_State;
        }
        public float Get_speed()
        {
            return Character_Mechanic.Get_MovingSpeed();
        }
        
        public Main_Character_Animate Get_Char_Animate()
        {
            return Character_Animate;
        }
        public void Hitstreak_Plus()
        {
            if (Character_Mechanic.Get_Hitstreak() <= 6)
            {
                Character_Mechanic.Set_Hitstreak(Character_Mechanic.Get_Hitstreak() + 1);
            }           
        }
        public void Reset_Hitstreak()
        {
            Character_Mechanic.Set_Hitstreak(0);
        }


    }
}
