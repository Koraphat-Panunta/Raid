
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.MainCharacter;
using System;

namespace Raid.Screen_Code
{
    public class Screen_Inventory_and_Mission : Screen

    {
        public Texture2D BG;
        public Main_Character main_Character;
        public bool Deployed;
        public Screen_Inventory_and_Mission() 
        {
        }
        public override void load(Main_Character main_Character)
        {
            this.main_Character = main_Character;
            BG = Global.Content.Load<Texture2D>("InventoryPage_Test");
            this.Deployed = false;
            
            base.load(main_Character);
        }
        public override void Update(GameTime gameTime)
        {
            //Main_Character.inventory.Cal_Weight();
            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                this.Deployed = true;
            }
            else
            {
                this.Deployed = false;
            }            
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Global.spriteBatch.Draw(BG, new Vector2(0, 0), Color.White);           
            base.Draw(gameTime);
        }
        public override void Unload()
        {
            base.Unload();
        }
        public override void Debuging()
        {
            Console.WriteLine("Grace Num = {0}", main_Character.inventory.Grace.Num);
            Console.WriteLine("Inventory weigth ={0}/{1}", main_Character.inventory.carry_weight, main_Character.inventory.Max_weight);
            base.Debuging();
        }      
        public Vector2 Deploy_Pos(Vector2 Deploy_mainchar_pos)
        {
            return Deploy_mainchar_pos;
        }
    }
}
