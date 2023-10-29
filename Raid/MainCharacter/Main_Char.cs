using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Raid.Basic_System;
using Raid.Item;
using System.Collections.Generic;

namespace Raid.MainCharacter
{
    public class Main_Char:Dynamic_Obg
    {
        public Inventory inventory;
        private List<FrameEffect> frameEffects = new List<FrameEffect>();
        private Texture2D texture_ATK;
        public float HP;
        public float Armor;
        private float Max_Armor;
        private double Armor_regen_count =0;
        private bool Armor_is_regening = false;
        private AnimatedTexture ATK_animation_2;
        //public string Main_Char_curt_State;
        public int Curt_state;
        // Curt_state 
        // 0:none
        // 1:Main_Char_idle_Up
        // 2:Main_Char_idle_Down
        // 3:Main_Char_idle_left
        // 4:Main_Char_idle_right
        // 5:Main_Char_Moving_Up
        // 6:Main_Char_Moving_Down
        // 7:Main_Char_Moving_Left
        // 8:Main_Char_Moving_Right
        public int ATK_state;
        // ATK_state
        // 0:none
        // 1:Main_Char_Common_ATK
        // 2:Main_Char_Heavy_ATK
        // 3:Main_Char_Dodge
        // 4:Main_Char_Roll_ATK
        //public string Main_Char_ATK_State;       
        //Char_Moving_State
       

        public double Common_ATK;
        public double Heavy_ATK;
        public double Roll_ATK;
        public float Commom_ATK_Push = 3.5f;
        public float Heavy_ATK_Push = 4f;
        public float Roll_ATK_Push = 4.5f;

        public bool Alive;

        public double ATK_common_Range ;
        public double ATK_Heavy_Range ;
        public double ATK_Roll_Range ;

        bool ATK_ready;
        AnimatedTexture ATK_animation;
        Texture2D ATK_Texture2;
        bool KeyIspressed = false;
        float Moving_Speed;
        float Runing_Speed = 3.3f;
        float Dashing_Speed = 8f;
        float Runing_WhileATK_Speed = 0.3f;

        public int Hitsteak;
        public Main_Char() 
        {
            Load();
        }
        public override void Load()
        {
            inventory = new Inventory(50f);                        
            ATK_common_Range = (Global.Tile * 2);
            ATK_Heavy_Range = ATK_common_Range * 1.5f;
            ATK_Roll_Range = ATK_common_Range * 1.5f;
            base.texture = Global.Content.Load<Texture2D>("Main_Char_Move_ani");
            base.animation.Load(Global.Content, "Main_Char_Move_ani", 4,8,4);
            ATK_animation = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            ATK_animation.Load(Global.Content, "Main_Char_ATK_ani", 4,8, 7);
            Moving_Speed = Runing_Speed;
            texture_ATK = Global.Content.Load<Texture2D>("Main_Char_ATK_ani");
            ATK_animation_2 = new AnimatedTexture(Vector2.Zero, 0f, 1f, 0.5f);
            ATK_animation_2.Load(Global.Content, "RaiderHeavySpin",4,8,7);
            ATK_Texture2 = Global.Content.Load<Texture2D>("RaiderHeavySpin");
            base.Load();
        }
        public void Deploy(Vector2 Pos)
        {
            base.Vector2 = Pos;
            Curt_state = 1;
            ATK_state = 0;
            ATK_ready = true;
            Hitsteak = 0;
            Common_ATK = 10f + (inventory.Rune_ATK.Count * Rune_ATK.Damage_plus);
            Heavy_ATK = Common_ATK * 2.2f;
            Roll_ATK = Common_ATK * 2.9f;
            HP = 30 ;
            Max_Armor = (float)inventory.Rune_Armor.Count * Rune_Armor.HP_plus; 
            Armor = (float)inventory.Rune_Armor.Count * Rune_Armor.HP_plus;
            Alive = true;
            Armor_regen_count = 0;
            Armor_is_regening = true;
        }
        public override void Update()
        {
            if(Alive == true)
            {               
                Update_Input_Moving_state();
                Update_Input_ATK_state();
                Main_Character_Action();
                base.Box = new Rectangle((int)base.Vector2.X-30, (int)base.Vector2.Y-60,60,122);
                base.animation.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                if(Armor_is_regening == true && Armor<Max_Armor)
                {
                    Armor += 0.05f;
                    if (Armor > Max_Armor)
                    {
                        Armor = Max_Armor;
                    }
                }
                if(Armor_is_regening == false)
                {
                    Armor_regen_count += Global.gameTime.ElapsedGameTime.TotalSeconds;
                    if(Armor_regen_count >= 5)
                    {
                        Armor_is_regening = true;
                        Armor_regen_count = 0;
                    }
                }               
            }           
            if(HP <= 0)
            {
                if (inventory.Rune_Lives.Count > 0)
                {
                    HP = 30;
                    inventory.Rune_Lives.Remove(inventory.Rune_Lives[0]);
                }
                else
                {
                    Alive = false;
                }                
            }
            
            base.Update();
        }
        private void Update_Input_Moving_state()
        {
            if (ATK_state == 0 || ATK_state == 3)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) && KeyIspressed == false)
                {
                    Curt_state = 5;
                    KeyIspressed = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A) && KeyIspressed == false)
                {
                    Curt_state = 7;
                    KeyIspressed = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S) && KeyIspressed == false)
                {
                    Curt_state = 6;
                    KeyIspressed = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D) && KeyIspressed == false)
                {
                    Curt_state = 8;
                    KeyIspressed = true;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.W) && Curt_state == 5)
                {
                    Curt_state = 1;
                    KeyIspressed = false;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.A) && Curt_state == 7)
                {
                    Curt_state = 3;
                    KeyIspressed = false;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.S) && Curt_state == 6)
                {
                    Curt_state = 2;
                    KeyIspressed = false;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.D) && Curt_state == 8)
                {
                    Curt_state = 4;
                    KeyIspressed = false;
                }
            }
            else if(ATK_state == 1 || ATK_state == 2 || ATK_state == 4)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) )
                {
                    if (ATK_state == 4)
                    {
                        base.Vector2.Y -= Runing_Speed * 0.8f;
                    }
                    else 
                    {
                        base.Vector2.Y -= Runing_WhileATK_Speed;
                    }
                   
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A) )
                {
                    if (ATK_state == 4)
                    {
                        base.Vector2.X -= Runing_Speed * 0.8f;
                    }
                    else
                    {
                        base.Vector2.X -= Runing_WhileATK_Speed;
                    }
                  
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (ATK_state == 4)
                    {
                        base.Vector2.Y += Runing_Speed * 0.8f;
                    }
                    else
                    {
                        base.Vector2.Y += Runing_WhileATK_Speed;
                    }
                   
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    if (ATK_state == 4)
                    {
                        base.Vector2.X += Runing_Speed * 0.8f;
                    }
                    else
                    {
                        base.Vector2.X += Runing_WhileATK_Speed;
                    }
                   
                }
               
            }
        }
        private KeyboardState Old_Keys;
        public double Rate_of_attack = 0;
        public double Attack_duration = 0;
        private void Update_Input_ATK_state()
        {
            if(ATK_ready == false)
            {
                Rate_of_attack += 1;
                if(Rate_of_attack >= 38)
                {
                    Rate_of_attack = 0;
                    ATK_ready = true;  
                }
            }
            if (ATK_state == 1 || ATK_state == 2 || ATK_state == 4)
            {
                Attack_duration += 1;
                ATK_animation.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                ATK_animation_2.UpdateFrame((float)Global.gameTime.ElapsedGameTime.TotalSeconds);
                Moving_Speed = 0;
                if (Attack_duration >= 35) 
                {
                    ATK_state = 0;
                    Attack_duration = 0;
                    ATK_animation.Reset();
                    ATK_animation_2.Reset();
                    Moving_Speed = Runing_Speed;
                }              
            }
            if(ATK_state == 3)
            {
                Attack_duration += 1;
                Moving_Speed = Dashing_Speed;
                if(Attack_duration >= 20)
                {
                    ATK_state = 0;
                    Attack_duration = 0;
                    Moving_Speed = Runing_Speed;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.J) && Old_Keys.IsKeyUp(Keys.J) && ATK_ready == true)
            {
                ATK_animation.Reset();
                Attack_duration = 0;
                ATK_state = 1;
                ATK_ready = false;
                Audio.soundEffects[0].CreateInstance().Play();
                Audio.soundEffects[1].CreateInstance().Play();
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.K) && Old_Keys.IsKeyUp(Keys.J) && ATK_ready == true && Hitsteak>=2)
            {
                ATK_animation.Reset();
                Attack_duration = 0;
                ATK_state = 2;
                ATK_ready = false;
                Audio.soundEffects[0].CreateInstance().Play();
                Audio.soundEffects[1].CreateInstance().Play();
                Audio.soundEffects[5].CreateInstance().Play();
                Hitsteak = Hitsteak - 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.L) && Old_Keys.IsKeyUp(Keys.J) && ATK_ready == true && Hitsteak >=4)
            {
                ATK_animation.Reset();
                Attack_duration = 0;
                ATK_state = 4;
                ATK_ready = false;
                Hitsteak -= 4;
                Audio.soundEffects[0].CreateInstance().Play();
                Audio.soundEffects[1].CreateInstance().Play();
                Audio.soundEffects[5].CreateInstance().Play();
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Space)&& Old_Keys.IsKeyUp(Keys.Space) && ATK_state != 3 && Hitsteak >= 1 && (Curt_state == 5|| Curt_state == 6 || Curt_state == 7 || Curt_state == 8))
            {
                ATK_animation.Reset();
                Attack_duration = 0;
                ATK_state = 3;
                ATK_ready = false;
                Hitsteak -= 1;
                Audio.soundEffects[7].CreateInstance().Play();
            }            
            Old_Keys = Keyboard.GetState();
        }
        int Foot_step = 0;
        public void Main_Character_Action()
        {
            if (Curt_state == 5)
            {
                base.Vector2.Y -= Moving_Speed;
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    base.Vector2.X -= Moving_Speed;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    base.Vector2.X += Moving_Speed;
                }
            }
            else if (Curt_state == 6)
            {

                base.Vector2.Y += Moving_Speed;
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    base.Vector2.X -= Moving_Speed;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    base.Vector2.X += Moving_Speed;
                }
            }
            else if (Curt_state == 7)
            {

                base.Vector2.X -= Moving_Speed;
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    base.Vector2.Y -= Moving_Speed;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    base.Vector2.Y += Moving_Speed;
                }
            }
            else if (Curt_state == 8)
            {

                base.Vector2.X += Moving_Speed;
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    base.Vector2.Y -= Moving_Speed;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    base.Vector2.Y += Moving_Speed;
                }
            }
            if(Curt_state == 5|| Curt_state == 6 || Curt_state == 7 || Curt_state == 8 && ATK_state == 0)
            {
                Foot_step += 1;
                if(Foot_step == 28)
                {
                    Audio.soundEffects[6].CreateInstance().Play();
                    Foot_step = 0;
                }
            }
            if(Curt_state == 1 || Curt_state == 2 || Curt_state == 3 || Curt_state == 4)
            {
                
                Audio.soundEffects[6].CreateInstance().Stop();
            }
            
           
        }
        float Fading = 1;
       
       
        public void animate(Vector2 Position)
        {
            Vector2 Pos = new Vector2(Position.X - 192, Position.Y -192);
            if (frameEffects.Count > 0)
            {
                if (frameEffects[0].Trans_Time < 0)
                {
                    frameEffects.Remove(frameEffects[0]);
                }
            }
            if (Alive == true)
            {
                Fading = 1;                
                if (ATK_state == 0)
                {
                    if (Curt_state == 5)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 6);
                    }
                    if (Curt_state == 6)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 5);
                    }
                    if (Curt_state == 7)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 7);
                    }
                    if (Curt_state == 8)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 8);
                    }
                    if (Curt_state == 1)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 2);
                    }
                    if (Curt_state == 2)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 1);
                    }
                    if (Curt_state == 3)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 3);
                    }
                    if (Curt_state == 4)
                    {
                        base.animation.DrawFrame(Global.spriteBatch, Pos, 4);
                    }
                }
                if (ATK_state == 1)
                {
                    if (Curt_state == 1 || Curt_state == 5)
                    {
                        ATK_animation.DrawFrame(Global.spriteBatch, Pos, 6);
                    }
                    if (Curt_state == 2 || Curt_state == 6)
                    {
                        ATK_animation.DrawFrame(Global.spriteBatch, Pos, 5);
                    }
                    if (Curt_state == 3 || Curt_state == 7)
                    {
                        ATK_animation.DrawFrame(Global.spriteBatch, Pos, 7);
                    }
                    if (Curt_state == 4 || Curt_state == 8)
                    {
                        ATK_animation.DrawFrame(Global.spriteBatch, Pos, 8);
                    }
                }
                if (ATK_state == 2)
                {
                    if (Curt_state == 1 || Curt_state == 5)
                    {
                        ATK_animation_2.DrawFrame(Global.spriteBatch, Pos, 2);
                    }
                    if (Curt_state == 2 || Curt_state == 6)
                    {
                        ATK_animation_2.DrawFrame(Global.spriteBatch, Pos, 1);
                    }
                    if (Curt_state == 3 || Curt_state == 7)
                    {
                        ATK_animation_2.DrawFrame(Global.spriteBatch, Pos, 3);
                    }
                    if (Curt_state == 4 || Curt_state == 8)
                    {
                        ATK_animation_2.DrawFrame(Global.spriteBatch, Pos, 4);
                    }
                }               
                if (ATK_state == 4)
                {
                    float trans_time = 0.008f;
                    if (Curt_state == 1 || Curt_state == 5)
                    {
                        ATK_animation_2.DrawFrame(Global.spriteBatch, Pos, 6);
                        if(Attack_duration == 8*0)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 0, 384 * 6, 384, 384), base.Vector2,Color.DarkRed, trans_time));
                        }
                        if(Attack_duration == 9 * 2)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 1, 384 * 6, 384, 384), base.Vector2,Color.DarkRed, trans_time));
                        }
                        //if (Attack_duration == 8 * 2)
                        //{
                        //    frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(288 * 2, 288 * 9,288, 288), base.Vector2,Color.DarkRed));
                        //}
                        if (Attack_duration == 8 * 3)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 3, 384 * 6, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }

                    }
                    if (Curt_state == 2 || Curt_state == 6)
                    {
                        ATK_animation_2.DrawFrame(Global.spriteBatch, Pos, 5);
                        if (Attack_duration == 8 * 0)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 0, 384 * 5, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }
                        if (Attack_duration == 9 * 1)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 1, 384 * 5, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }
                        //if (Attack_duration == 8 * 2)
                        //{
                        //    frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(288 * 2, 288 * 8, 288, 288), base.Vector2, Color.DarkRed));
                        //}
                        if (Attack_duration == 8 * 3)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 3, 384 * 5, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }

                    }
                    if (Curt_state == 3 || Curt_state == 7)
                    {
                        ATK_animation_2.DrawFrame(Global.spriteBatch, Pos, 7);
                        if (Attack_duration == 8 * 0)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 0, 384 * 7, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }
                        if (Attack_duration == 9 * 1)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 1, 384 * 7, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }
                        //if (Attack_duration == 8 * 2)
                        //{
                        //    frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(288 * 2, 288 * 10, 288, 288), base.Vector2, Color.DarkRed));
                        //}
                        if (Attack_duration == 8 * 3)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 3, 384 * 7, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }
                    }
                    if (Curt_state == 4 || Curt_state == 8)
                    {
                        ATK_animation_2.DrawFrame(Global.spriteBatch, Pos, 8);
                        if (Attack_duration == 8 * 0)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 0, 384 * 8, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }
                        if (Attack_duration == 9 * 1)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 1, 384 * 8, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }
                        //if (Attack_duration == 8 * 2)
                        //{
                        //    frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(288 * 2, 288 * 11, 288, 288), base.Vector2, Color.DarkRed));
                        //}
                        if (Attack_duration == 8 * 3)
                        {
                            frameEffects.Add(new FrameEffect(ATK_Texture2, new Rectangle(384 * 3, 384 * 8, 384, 384), base.Vector2, Color.DarkRed, trans_time));
                        }
                    }
                }
                if (ATK_state == 3)
                {
                    float Trans_time = 0.005f;
                    if (Curt_state == 5)
                    {
                        ATK_animation.DrawFrame(Global.spriteBatch, Pos, 2);
                        if (Attack_duration == 8 * 0)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 0, 384 * 1, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 9 * 1)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 1, 384 * 1, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 8 * 2)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 2, 384 * 1, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 8 * 3)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 3, 384 * 1, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                    }
                    if (Curt_state == 6)
                    {
                        ATK_animation.DrawFrame(Global.spriteBatch, Pos, 1);
                        if (Attack_duration == 8 * 0)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 0, 384 * 0, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 9 * 1)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 1, 384 * 0, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 8 * 2)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 2, 384 * 0, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 8 * 3)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 3, 384 * 0, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                    }
                    if (Curt_state == 7)
                    {
                        ATK_animation.DrawFrame(Global.spriteBatch, Pos, 3);
                        if (Attack_duration == 8 * 0)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 0, 384 * 2, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 9 * 1)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 1, 384 * 2, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 8 * 2)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 2, 384 * 2, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 8 * 3)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 3, 384 * 2, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                    }
                    if (Curt_state == 8)
                    {
                        ATK_animation.DrawFrame(Global.spriteBatch, Pos, 4);
                        if (Attack_duration == 8 * 0)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 0, 384 * 3, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 9 * 1)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 1, 384 * 3, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 8 * 2)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 2, 384 * 3, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                        if (Attack_duration == 8 * 3)
                        {
                            frameEffects.Add(new FrameEffect(this.texture_ATK, new Rectangle(384 * 3, 384 * 3, 384, 384), base.Vector2, Color.LightBlue, Trans_time));
                        }
                    }
                }
            }
            if(Alive == false)
            {
                Fading -= (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                if(Curt_state == 1 || Curt_state == 5)
                {
                    Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0,1*384, 384, 384), Color.White * Fading);
                }
                if (Curt_state == 2 || Curt_state == 6)
                {
                    Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0,0* 384, 384, 384), Color.White * Fading);
                }
                if (Curt_state == 3 || Curt_state == 7)
                {
                    Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 1 * 384, 384, 384), Color.White * Fading);
                }
                if (Curt_state == 4 || Curt_state == 8)
                {
                    Global.spriteBatch.Draw(base.texture, Pos, new Rectangle(0, 2 * 384, 384, 384), Color.White * Fading);
                }

            }
        }
        
        
        public Vector2 Get_Pos()
        {
            return base.Vector2;
        }
        public Rectangle Get_Box()
        {
            return base.Box;
        }
        public void Set_Pos(Vector2 Pos)
        {
            base.Vector2 = Pos;
        }
        public float Get_speed()
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
            Armor_is_regening = false;
            Armor_regen_count = 0;
            if (Armor > 0)
            {
                Armor -= DMG;
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
            else if(Armor <= 0) 
            {
                HP -= DMG;
            }
        }
        public List<FrameEffect> Get_FrameEffect()
        {
            return frameEffects;
        }
    }
}
