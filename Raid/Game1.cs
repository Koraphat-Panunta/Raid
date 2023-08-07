using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Content;
using Raid.MainCharacter;
using Raid.Screen_Code;
using System;

namespace Raid
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Screen Curent_Screen;
        public Screen_Menu Menu_Screen;
        public Screen_Inventory_and_Mission Management_Screen;
        public Screen_Gameplay Gameplay_Screen;
        public SpriteFont Font;
        public string Scene_State;
        public string Gameplay = "Gameplay";
        public string MagScence = "Management";
        public string Menu = "Menu";
        float Debug_Update;
        bool keyinput = false;
        bool DebugCheck;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.Graphics = GraphicsDevice;
            /////////////////////////////////////// Set Global /////////////////////////////////////////
            Global.Content = Content;
            Global.spriteBatch = _spriteBatch;
            Global.GraphicsDevice = _graphics;           
            /////////////////////////////////////// Set Resolution /////////////////////////////////////
            Global.GraphicsDevice.PreferredBackBufferHeight = 1080;
            Global.GraphicsDevice.PreferredBackBufferWidth = 1920;
            Global.GraphicsDevice.ApplyChanges();
            /////////////////////////////////////// Set Screen /////////////////////////////////////////            
            Gameplay_Screen = new Screen_Gameplay();
            Menu_Screen = new Screen_Menu();
            Management_Screen = new Screen_Inventory_and_Mission();
            Curent_Screen = Menu_Screen;
            Scene_State = Menu;
            Curent_Screen.load(new Main_Character(), Vector2.Zero);
            /////////////////////////////////////// Set Variable ///////////////////////////////////////
            Debug_Update = 0;
            DebugCheck = true;
            
            /////////////////////////////////////// Set Object /////////////////////////////////////////
           
        }

        protected override void Update(GameTime gameTime)
        {
            Global.gameTime = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Set_Scene_State();            
            Curent_Screen.Update(gameTime);
            Debuging(gameTime);
            base.Update(gameTime);           
        }

        protected override void Draw(GameTime gameTime)
        {                    
            Global.spriteBatch.Begin();            
            Curent_Screen.Draw(gameTime);           
            Global.spriteBatch.End();
            
            base.Draw(gameTime);
        }
        public void Set_Scene_State()
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.D0))
            //{
            //    Curent_Screen.Unload();
            //    Scene_State = Menu;
            //    Update_Scence();
            //    Curent_Screen.load();
            //}
            //if(Keyboard.GetState().IsKeyDown(Keys.D1)) 
            //{
            //    Curent_Screen.Unload();
            //    Scene_State = MagScence;
            //    Update_Scence();
            //    Curent_Screen.load();

            //}
            //if(Keyboard.GetState().IsKeyDown(Keys.D2))
            //{
            //    Curent_Screen.Unload();
            //    Scene_State = Gameplay;
            //    Update_Scence();
            //    Curent_Screen.load();
            //}
            if (Scene_State == Menu && Keyboard.GetState().IsKeyDown(Keys.Enter) && keyinput ==false) 
            {
                Curent_Screen.Unload();
                Scene_State = MagScence;
                Update_Scence();
                Curent_Screen.load(new Main_Character(),Vector2.Zero);
                keyinput = true;
                
            }
            if(Scene_State == MagScence && Keyboard.GetState().IsKeyDown(Keys.Enter)&&keyinput == false)
            {
                Curent_Screen.Unload();
                Scene_State = Gameplay;
                Update_Scence();
                Curent_Screen.load(Management_Screen.main_Character,Vector2.Zero);
                if (Keyboard.GetState().IsKeyUp(Keys.Enter))
                {
                    keyinput = false;
                }
            }
            if(Scene_State == MagScence && Management_Screen.Deploy_Confirm == true)
            {
                Management_Screen.Deploy_Confirm = false;
                Curent_Screen.Unload();
                Scene_State = Gameplay;
                Update_Scence();
                Curent_Screen.load(Management_Screen.main_Character,Management_Screen.Deploy_Pos);
            }
            if(Gameplay_Screen.Extract == true)
            {
                Gameplay_Screen.Extract = false;
                Curent_Screen.Unload();
                Scene_State = MagScence;
                Update_Scence();
                Curent_Screen.load(Gameplay_Screen.Main_Character, Vector2.Zero);

               
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Enter))
            {
                keyinput = false;
            }
            //if(Management_Screen.Deployed == true) 
            //{
            //    Curent_Screen.Unload();
            //    Scene_State = Gameplay;
            //    Update_Scence();
            //    Curent_Screen.load();
            //}
        }
        public void Update_Scence()
        {
            if(Scene_State == Menu) 
            {
                Curent_Screen = Menu_Screen;                
            }
            if(Scene_State == MagScence)
            {                
                Curent_Screen = Management_Screen;            
            }
            if(Scene_State == Gameplay)
            {                               
                Curent_Screen = Gameplay_Screen;
            }
            
        }
        protected void Debuging(GameTime gameTime)
        {         
            Debug_Update += (float)gameTime.ElapsedGameTime.TotalSeconds;
            ///////////////////////////////////// Add your debuging variable //////////////////////////
            if( DebugCheck == true)
            {
                if(Curent_Screen == Gameplay_Screen)
                {
                    Console.WriteLine("Curent_Screen = Gameplay_screen");
                }
                if(Curent_Screen == Menu_Screen)
                {
                    Console.WriteLine("Curent_Screen = Menu_Screen");
                }
                if(Curent_Screen == Management_Screen)
                {
                    Console.WriteLine("Curent_Screen = Management_Screen");
                }
                Console.WriteLine("Keyinput ={0}",keyinput);
                //Console.WriteLine("Extract Complete = {0}", Gameplay_Screen.Extract);
                Curent_Screen.Debuging();
                DebugCheck = false;
            }           
            /////////////////////////////////// Char_state/////////////////////////////////////////////           
            ////////////////////////////////////// Clear Console //////////////////////////////////////
            if (Debug_Update > 0.1)
            {
                Console.Clear();
                Debug_Update = 0;
                DebugCheck = true;
                
            }
        }
    }
}