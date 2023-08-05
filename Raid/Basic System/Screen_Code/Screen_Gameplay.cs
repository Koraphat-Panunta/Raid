using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        public Texture2D BG;
        Camera Camera;
        bool Hit =false;
        public Screen_Gameplay() 
        { 
        }
        public override void load()
        {           
            base.load();
            BG = Global.Content.Load<Texture2D>("Gameplay_Test");
            Main_Character.Set_MainCharacterPos(new Vector2(960,540));
            Main_Character.Set_MainCharacterHitbox(new Rectangle((int)Main_Character.Get_MainCharacterPos().X,(int)Main_Character.Get_MainCharacterPos().Y,32,64));
            Camera = new Camera();
            Camera.track_Object(Main_Character.Get_MainCharacterPos());
        }
        public override void Update(GameTime gameTime)
        {
            Camera.CameraPos_Update(Main_Character.Get_MainCharacterPos());
            Main_Character.Main_Character_Updatestate();
            if(Main_Character.Get_MainCharacterBox().Intersects(Main_Character.inventory.Grace.Get_Grace_Hitbox())) 
            {
                Hit = true;
                if(Hit == true && Keyboard.GetState().IsKeyDown(Keys.E)) 
                {                   
                    Main_Character.inventory.Grace.Num += 1;
                    Main_Character.inventory.Grace.disapear(0);
                }
            }
            else
            {
                Hit=false;
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {            
            Global.spriteBatch.Draw(BG,Camera.Object_Vector(new Vector2(0,0)),Color.White);            
            Main_Character.Animate(Camera.Object_Vector(Main_Character.Get_MainCharacterPos()));
            Global.spriteBatch.Draw(Main_Character.inventory.Grace.Get_Grace_Texture(), Camera.Object_Vector(Main_Character.inventory.Grace.Grace_Position[0]),Color.White);           
            base.Draw(gameTime);
        }
     
        public override void Unload()
        {
            Main_Character.Main_Char_curt_State = null;
            Main_Character.Set_MainCharacterPos(new Vector2(0,0));
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Main_Char_State ={0}",Main_Character.Main_Char_curt_State);
            Console.WriteLine("Main_Char_Pos = {0}",Main_Character.Get_MainCharacterPos());
            Console.WriteLine("Grace_Pos = {0}", Main_Character.inventory.Grace.Grace_Position[0]);
            Console.WriteLine("Hit = {0}", Hit);
            Console.WriteLine("Grace num = {0}",Main_Character.inventory.Grace.Num);
            
            base.Debuging();
        }
    }
}
