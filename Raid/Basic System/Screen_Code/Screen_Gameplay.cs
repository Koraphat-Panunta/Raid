using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Enviroment;
using Raid.Item;
using Raid.MainCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Screen_Code
{
    public class Screen_Gameplay:Screen
    {
        public Main_Character Main_Character = new Main_Character();
        public Texture2D BG;
        Camera Camera;
        bool Hit =false;       
        public Extract_gate extract_Gate = new Extract_gate();
        public Vector2 Deploy_pos;
        
        public Screen_Gameplay() 
        { 
        }
        public override void load(Main_Character main_Character,Vector2 Deploy_Pos)
        {           
            base.load(main_Character,Deploy_Pos);           
            this.Main_Character = main_Character;
            BG = Global.Content.Load<Texture2D>("Gameplay");
            Deploy(Deploy_Pos);
            Main_Character.Set_MainCharacterHitbox(new Rectangle((int)Main_Character.Get_MainCharacterPos().X,(int)Main_Character.Get_MainCharacterPos().Y,62,1));
            Camera = new Camera();
            main_Character.inventory.Grace.Set_Grace_Position(new Vector2(300, 700), 0);
            Camera.track_Object(Main_Character.Get_MainCharacterPos(),Deploy_Pos);           
            Main_Character.inventory.Grace.Set_Grace_Hitbox(new Rectangle((int)Main_Character.inventory.Grace.Get_GracePosition(0).X, (int)Main_Character.inventory.Grace.Get_GracePosition(0).Y, 96, 96), 0);
            Main_Character.Set_state("Main_Char_idle_right");
           
        }
        public override void Update(GameTime gameTime)
        {
            Camera.CameraPos_Update(Main_Character.Get_MainCharacterPos());
            Main_Character.Main_Character_Updatestate();
            lootingsystem();
            Extractionsystem();
            Main_Character.inventory.Cal_Weight();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {            
            Global.spriteBatch.Draw(BG,Camera.Object_Vector(new Vector2(0,0)),Color.White);                    
            Global.spriteBatch.Draw(Main_Character.inventory.Grace.Get_Grace_Texture(), Camera.Object_Vector(Main_Character.inventory.Grace.Get_GracePosition(0)),Color.White); 
            Global.spriteBatch.Draw(extract_Gate.Get_Texture(),Camera.Object_Vector(extract_Gate.Get_Position()),Color.White);
            Main_Character.Animate(Camera.Object_Vector(Main_Character.Get_MainCharacterPos()));
            base.Draw(gameTime);
        }
     
        public override void Unload()
        {
            Main_Character.Main_Char_curt_State = null;
            Main_Character.Set_MainCharacterPos(new Vector2(0,0));
            Deploy_pos = new Vector2(0,0);
            base.Unload();
        }
        public void lootingsystem()
        {
            if (Main_Character.Get_MainCharacterBox().Intersects(Main_Character.inventory.Grace.Get_Grace_Hitbox()))
            {
                Hit = true;
                if (Hit == true && Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    float x = Main_Character.inventory.carry_weight;
                    if (x + Main_Character.inventory.Grace.Get_Weight() * 10 <= Main_Character.inventory.Max_weight)
                    {
                    Main_Character.inventory.Grace_num += 10;
                    Main_Character.inventory.Grace.disapear(0); 
                    }                                 
                }
            }
            else
            {
                Hit = false;
            }
        }
        private void Extractionsystem()
        {
            if (Main_Character.Get_MainCharacterBox().Intersects(extract_Gate.Get_Box())&&Keyboard.GetState().IsKeyDown(Keys.E))
            {
                Extract = true;
            }
            else
            {
                Extract = false;
            }           
        }
        public void transter_Inventory(Inventory invt)
        {            
                Main_Character.inventory = invt;                     
        }
        public void Deploy(Vector2 Deploy_Pos)
        {           
            Main_Character.Set_MainCharacterPos(Deploy_Pos);
            Deploy_pos = Deploy_Pos ;
        }
       
        public override void Debuging()
        {
            Console.WriteLine("Main_Char_State ={0}",Main_Character.Main_Char_curt_State);
            Console.WriteLine("Main_Char_Pos = {0}",Main_Character.Get_MainCharacterPos());
            Console.WriteLine("Grace_Pos = {0}", Main_Character.inventory.Grace.Get_GracePosition(0));           
            Console.WriteLine("Grace num = {0}",Main_Character.inventory.Grace_num);
            Console.WriteLine(Camera.Object_Vector(Main_Character.Get_MainCharacterPos()));
            Console.WriteLine(Camera.Object_Vector(Main_Character.inventory.Grace.Get_GracePosition(0)));
            Console.WriteLine("Weight ={0}/{1}",Main_Character.inventory.carry_weight,Main_Character.inventory.Max_weight);                      
            base.Debuging();
        }
    }
}
