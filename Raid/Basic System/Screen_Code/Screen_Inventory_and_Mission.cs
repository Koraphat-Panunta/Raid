
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Core;
using Raid.MainCharacter;
using System;

namespace Raid.Screen_Code
{
    public class Screen_Inventory_and_Mission : Screen

    {
        public Prepare_Page Invt;
        private Inventory Stash = new Inventory(1000f, 60);

        public Texture2D Deploy_select;
        public Rectangle mouse;
        public Vector2 Deploy_Pos;
        public bool Deploy_selected;
        public bool Deploy_Confirm;
        public Screen_Inventory_and_Mission()
        {
        }
        public override void load( Vector2 Pos)
        {

            Invt = new Prepare_Page();
            Deploy_Pos = Vector2.Zero;
            this.Deploy_selected = false;
            this.Deploy_Confirm = false;
            base.load(Pos);
        }
        public void load()
        {
            Deploy_Pos = Vector2.Zero;
            Invt = new Prepare_Page();
            this.Deploy_selected = false;
            this.Deploy_Confirm = false;
        }
        public override void Update(GameTime gameTime)
        {
            mouse = new Rectangle((int)Mouse.GetState().Position.X, (int)Mouse.GetState().Position.Y, 3, 3);
            Item_management();
            Deploy_check();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {

            Global.spriteBatch.Draw(Invt.BG, new Vector2(0, 0), Color.White);
            Global.spriteBatch.Draw(Invt.Map, Invt.Get_Map_Pos(), Color.White);
            Global.spriteBatch.Draw(Invt.Deploy_select, Invt.Get_Deploy_Pos(0), Color.White);
            Global.spriteBatch.Draw(Invt.Deploy_select, Invt.Get_Deploy_Pos(1), Color.White);
            Global.spriteBatch.Draw(Invt.Deploy_select, Invt.Get_Deploy_Pos(2), Color.White);
            Global.spriteBatch.Draw(Invt.Deploy_select, Invt.Get_Deploy_Pos(3), Color.White);
            Global.spriteBatch.Draw(Invt.Deploy_Button, Invt.Get_Deploy_Button_pos(), Color.White);
            base.Draw(gameTime);
        }
        public override void Unload()
        {

            Invt = null;
            base.Unload();
        }
        public override void Debuging()
        {

            //Console.WriteLine("Deploy_Selected = {0}", Deploy_selected);
            //Console.WriteLine("Deploy_Confirm = {0}",Deploy_Confirm);
            //Console.WriteLine("Mouse = ({0},{1})",mouse.X,mouse.Y);
            Console.WriteLine("Deploye select[0] = ({0},{1})", Invt.Get_Deploy_select_Box(0).X, Invt.Get_Deploy_select_Box(0).Y);
            /* Console.WriteLine("Deploy_Pos = {0}", Deploy_Pos)*/
            ;
            Console.WriteLine("Stash Grace num = " + Stash.Grace_num);



            base.Debuging();
        }

        public void Deploy_check()
        {
            for (int i = 0; i < 4; i++)
            {
                if (mouse.Intersects(Invt.Get_Deploy_select_Box(i)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Deploy_Pos = Invt.Get_Deploy_select_pos(i);
                    Deploy_selected = true;
                }
                if (Deploy_selected == true && mouse.Intersects(Invt.Get_Deploy_Button_Box()) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Deploy_Confirm = true;
                }
            }

        }
        private void Item_management()
        {

        }
    }
}
