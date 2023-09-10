using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace Raid.MainCharacter
{
    public class Main_Char:Dynamic_Obg
    {
        public float HP;
        public string Main_Char_curt_State;
        public string Main_Char_ATK_State;
        public string Main_Char_idle_Up = "Main_Char_idle_Up";
        public string Main_Char_idle_Down = "Main_Char_idle_Down";
        public string Main_Char_idle_left = "Main_Char_idle_left";
        public string Main_Char_idle_right = "Main_Char_idle_right";
        //Char_Moving_State
        public string Main_Char_Moving_Up = "Main_Char_Moving_Up";
        public string Main_Char_Moving_Down = "Main_Char_Moving_Down";
        public string Main_Char_Moving_Left = "Main_Char_Moving_Left";
        public string Main_Char_Moving_Right = "Main_Char_Moving_Right";
        public string Main_Char_Common_ATK = "Main_Char_Common_ATK";
        public string Main_Char_Heavy_ATK = "Main_Char_Heavy_ATK";
        public string Main_Char_Roll_ATK = "Main_Char_Roll_ATK";
        public string Main_Char_Dodge = "Main_Char_Dodge";
        public string Main_Char_None = "None";

        public double Common_ATK;
        public double Heavy_ATK;
        public double Roll_ATK;

        public double ATK_common_Range ;
        public double ATK_Heavy_Range ;
        public double ATK_Roll_Range ;

        bool ATK_ready;
        AnimatedTexture ATK_animation;

        bool KeyIspressed = false;
        int Moving_Speed = 3;

        public int Hitsteak;
        public Main_Char() 
        {
            Load();
        }
        public override void Load()
        {
            ATK_common_Range = (Global.Tile * 2)+36;
            ATK_Heavy_Range = ATK_common_Range * 1.5f;
            ATK_Roll_Range = ATK_common_Range * 1.5f;
            
            base.animation.Load(Global.Content, "RaiderSpriteSheetWIP Move",4,8,8);
            ATK_animation = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            ATK_animation.Load(Global.Content, "RaiderSpriteSheetWIP", 4, 12, 8);
            Main_Char_curt_State = Main_Char_idle_Up;
            Main_Char_ATK_State = Main_Char_None;
            ATK_ready = true;
            Hitsteak = 0;
            HP = 60;
            Common_ATK = 10;
            Heavy_ATK = Common_ATK*1.5f;
            Roll_ATK = Common_ATK * 3;
            base.Load();
        }
        public void Deploy(Vector2 Pos)
        {
            base.Vector2 = Pos; 
            //base.Vector2 = new Vector2(base.Vector2.X + 144, base.Vector2.Y + 144/2);
            
        }
        public override void Update()
        {
            
            base.animation.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
            Update_Input_Moving_state();
            Update_Input_ATK_state();
            Main_Character_Action();
            base.Box = new Rectangle((int)base.Vector2.X + 120,(int)base.Vector2.Y + 96, 48, 96);
            base.Update();
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
        private KeyboardState Old_Keys;
        public double Rate_of_attack = 0;
        public double Attack_duration = 0;
        private void Update_Input_ATK_state()
        {
            if(ATK_ready == false)
            {
                Rate_of_attack += Global.gameTime.ElapsedGameTime.TotalSeconds;
                if(Rate_of_attack >= 0.5)
                {
                    Rate_of_attack = 0;
                    ATK_ready = true;  
                }
            }
            if (Main_Char_ATK_State == Main_Char_Common_ATK || Main_Char_ATK_State == Main_Char_Heavy_ATK || Main_Char_ATK_State == Main_Char_Roll_ATK)
            {
                Attack_duration += Global.gameTime.ElapsedGameTime.TotalSeconds;
                ATK_animation.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                Moving_Speed = 1;
                if (Attack_duration >= 0.5)
                {
                    Main_Char_ATK_State = Main_Char_None;
                    Attack_duration = 0;
                    ATK_animation.Reset();
                    Moving_Speed = 3;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.J) && Old_Keys.IsKeyUp(Keys.J) && ATK_ready == true)
            {
                Main_Char_ATK_State = Main_Char_Common_ATK;
                ATK_ready = false;
               
            }
            if (Keyboard.GetState().IsKeyDown(Keys.K) && Old_Keys.IsKeyUp(Keys.J) && ATK_ready == true && Hitsteak>=3)
            {
                Main_Char_ATK_State = Main_Char_Heavy_ATK;
                ATK_ready = false;

                Hitsteak = Hitsteak - 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.L) && Old_Keys.IsKeyUp(Keys.J) && ATK_ready == true && Hitsteak >=5)
            {
                Main_Char_ATK_State = Main_Char_Roll_ATK;
                ATK_ready = false;

                Hitsteak -= 5;
            }
           
            Old_Keys = Keyboard.GetState();
        }
        
        public void Main_Character_Action()
        {
            if (Main_Char_curt_State == "Main_Char_Moving_Up")
            {
                base.Vector2.Y -= Moving_Speed;
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    base.Vector2.X -= Moving_Speed;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    base.Vector2.X += Moving_Speed;
                }
            }
            if (Main_Char_curt_State == "Main_Char_Moving_Down")
            {
                base.Vector2.Y += Moving_Speed;
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    base.Vector2.X -= Moving_Speed;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    base.Vector2.X += Moving_Speed;
                }
            }
            if (Main_Char_curt_State == "Main_Char_Moving_Left")
            {
                base.Vector2.X -= Moving_Speed;
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    base.Vector2.Y -= Moving_Speed;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    base.Vector2.Y += Moving_Speed;
                }
            }
            if (Main_Char_curt_State == "Main_Char_Moving_Right")
            {
                base.Vector2.X += Moving_Speed;
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    base.Vector2.Y -= Moving_Speed;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    base.Vector2.Y += Moving_Speed;
                }
            }          
        }
        public void animate(Vector2 Position)
        {
            Vector2 Pos = new Vector2(Position.X - 144, Position.Y -144);
            if (Main_Char_ATK_State == Main_Char_None)
            {
                if (Main_Char_curt_State == "Main_Char_Moving_Up")
                {
                    base.animation.DrawFrame(Global.spriteBatch, Pos, 6);
                }
                if (Main_Char_curt_State == "Main_Char_Moving_Down")
                {
                    base.animation.DrawFrame(Global.spriteBatch, Pos, 5);
                }
                if (Main_Char_curt_State == "Main_Char_Moving_Left")
                {
                    base.animation.DrawFrame(Global.spriteBatch, Pos, 7);
                }
                if (Main_Char_curt_State == "Main_Char_Moving_Right")
                {
                    base.animation.DrawFrame(Global.spriteBatch, Pos, 8);
                }
                if (Main_Char_curt_State == "Main_Char_idle_Up")
                {
                    base.animation.DrawFrame(Global.spriteBatch, Pos, 2);
                }
                if (Main_Char_curt_State == "Main_Char_idle_Down")
                {
                    base.animation.DrawFrame(Global.spriteBatch, Pos, 1);
                }
                if (Main_Char_curt_State == "Main_Char_idle_left")
                {
                    base.animation.DrawFrame(Global.spriteBatch, Pos, 3);
                }
                if (Main_Char_curt_State == "Main_Char_idle_right")
                {
                    base.animation.DrawFrame(Global.spriteBatch, Pos, 4);
                }
            }
            if(Main_Char_ATK_State == Main_Char_Common_ATK)
            {
                if(Main_Char_curt_State == Main_Char_idle_Up||Main_Char_curt_State == Main_Char_Moving_Up)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 2);
                }
                if (Main_Char_curt_State == Main_Char_idle_Down || Main_Char_curt_State == Main_Char_Moving_Down)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 1);
                }
                if (Main_Char_curt_State == Main_Char_idle_left || Main_Char_curt_State == Main_Char_Moving_Left)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 3);
                }
                if (Main_Char_curt_State == Main_Char_idle_right || Main_Char_curt_State == Main_Char_Moving_Right)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 4);
                }
            }
            if (Main_Char_ATK_State == Main_Char_Heavy_ATK)
            {
                if (Main_Char_curt_State == Main_Char_idle_Up || Main_Char_curt_State == Main_Char_Moving_Up)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 6);
                }
                if (Main_Char_curt_State == Main_Char_idle_Down || Main_Char_curt_State == Main_Char_Moving_Down)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 5);
                }
                if (Main_Char_curt_State == Main_Char_idle_left || Main_Char_curt_State == Main_Char_Moving_Left)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 7);
                }
                if (Main_Char_curt_State == Main_Char_idle_right || Main_Char_curt_State == Main_Char_Moving_Right)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 8);
                }
            }
            if (Main_Char_ATK_State == Main_Char_Roll_ATK)
            {
                if (Main_Char_curt_State == Main_Char_idle_Up || Main_Char_curt_State == Main_Char_Moving_Up)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 10);
                }
                if (Main_Char_curt_State == Main_Char_idle_Down || Main_Char_curt_State == Main_Char_Moving_Down)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 9);
                }
                if (Main_Char_curt_State == Main_Char_idle_left || Main_Char_curt_State == Main_Char_Moving_Left)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 11);
                }
                if (Main_Char_curt_State == Main_Char_idle_right || Main_Char_curt_State == Main_Char_Moving_Right)
                {
                    ATK_animation.DrawFrame(Global.spriteBatch, Pos, 12);
                }
            }
        }
        public Vector2 Get_Pos()
        {
            return base.Vector2;
        }
        public int Get_speed()
        {
            return Moving_Speed;
        }
        public void Hitstreak_Plus()
        {
            if(Hitsteak < 6)
            {
                Hitsteak++;
            }           
        }
        public void Get_Dmg(int DMG)
        {
            HP -= DMG;
        }
    }
}
