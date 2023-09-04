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
        public string Curent_Screen;
        public Screen_Menu Menu_Screen;
        public Screen_Inventory_and_Mission Management_Screen;
        public Screen_Gameplay Gameplay_Screen;
        public SpriteFont Font;       
        public string Gameplay = "Gameplay";
        public string Management = "Management";
        public string Title = "Title";
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
            Global.GraphicsDevice.PreferredBackBufferHeight = 540;
            Global.GraphicsDevice.PreferredBackBufferWidth = 960;
            Global.GraphicsDevice.ApplyChanges();
            /////////////////////////////////////// Set Screen /////////////////////////////////////////  
            Curent_Screen = Title;
            Gameplay_Screen = new Screen_Gameplay();
            Menu_Screen = new Screen_Menu();
            Management_Screen = new Screen_Inventory_and_Mission();                       
            Menu_Screen.load(new Main_Character(), Vector2.Zero);
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
            SceneUpdate(gameTime);            
            Debuging(gameTime);
            base.Update(gameTime);           
        }

        protected override void Draw(GameTime gameTime)
        {                    
            Global.spriteBatch.Begin();            
            GraphicsDevice.Clear(Color.Black);
            SceneDraw(gameTime);
            Global.spriteBatch.End();
            
            base.Draw(gameTime);
        }
        public void SceneUpdate(GameTime gameTime)
        {
            if(Curent_Screen == Title)
            {               
                Menu_Screen.Update(gameTime);
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
                {
                    Curent_Screen = Management;
                    Management_Screen.load(new Main_Character(),Vector2.Zero);
                }
            }
            if(Curent_Screen == Management)
            {
                Management_Screen.Update(gameTime);                
                if (Management_Screen.Deploy_Confirm == true)
                {
                    Curent_Screen = Gameplay;
                    Gameplay_Screen.load(new Main_Character(),Management_Screen.Deploy_Pos);
                    Gameplay_Screen.Main_Character.inventory.Grace_num = Management_Screen.main_Character.inventory.Grace_num;
                    Gameplay_Screen.Main_Character.inventory.carry_weight = Management_Screen.main_Character.inventory.carry_weight;
                    Management_Screen.Deploy_Confirm = false;
                }
            }
            if(Curent_Screen == Gameplay)
            {
                Gameplay_Screen.Update(gameTime);
                if(Gameplay_Screen.Extract == true)
                {
                    Gameplay_Screen.Extract = false;
                    Curent_Screen = Management;
                    Management_Screen.load(new Main_Character(),Vector2.Zero);
                    Management_Screen.main_Character.inventory.Grace_num = Gameplay_Screen.Main_Character.inventory.Grace_num;
                    
                }
                if (Gameplay_Screen.Main_Character.Get_Char_Alive() == false)
                {
                    Curent_Screen = Management;
                    Management_Screen.main_Character.inventory.Grace_num = Gameplay_Screen.Main_Character.inventory.Grace_num;                    
                    Gameplay_Screen.Main_Character.Set_Char_Alive(true);
                }
            }
        }
        public void SceneDraw(GameTime gameTime)
        {
            if (Curent_Screen == Title)
            {
                Menu_Screen.Draw(gameTime);
            }
            if (Curent_Screen == Management)
            {
                Management_Screen.Draw(gameTime);
            }
            if (Curent_Screen == Gameplay)
            {
                Gameplay_Screen.Draw(gameTime);
            }
        }
        
        protected void Debuging(GameTime gameTime)
        {         
            Debug_Update += (float)gameTime.ElapsedGameTime.TotalSeconds;
            ///////////////////////////////////// Add your debuging variable //////////////////////////
            if( DebugCheck == true)
            {                
                Console.WriteLine("Curent_Screen = {0}",Curent_Screen);               
                Console.WriteLine("Keyinput ={0}",keyinput);
                //Console.WriteLine("Extract Complete = {0}", Gameplay_Screen.Extract);                                
                if (Curent_Screen == Title)
                {
                    Menu_Screen.Debuging();
                }
                if (Curent_Screen == Management)
                {
                    Management_Screen.Debuging();
                }
                if (Curent_Screen == Gameplay)
                {
                    Gameplay_Screen.Debuging();
                }

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