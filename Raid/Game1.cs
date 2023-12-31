﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Basic_System;
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
            Global.GraphicsDevice.PreferredBackBufferHeight = 1080;
            Global.GraphicsDevice.PreferredBackBufferWidth = 1920;
            Global.GraphicsDevice.ApplyChanges();
            /////////////////////////////////////// Set Screen /////////////////////////////////////////  
            Curent_Screen = Title;
            Gameplay_Screen = new Screen_Gameplay();
            Menu_Screen = new Screen_Menu();
            Management_Screen = new Screen_Inventory_and_Mission();                       
            Menu_Screen.load( Vector2.Zero);
            Audio.Audio_Load();
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
            //Debuging(gameTime);
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
                    Management_Screen.load(Vector2.Zero);
                }
            }
            if(Curent_Screen == Management)
            {
                Management_Screen.Update(gameTime);                
                if (Management_Screen.Deploy_Confirm == true)
                {
                    Curent_Screen = Gameplay;
                    Management_Screen.Reset();
                    Gameplay_Screen.load(Management_Screen.Deploy_Pos,Management_Screen.inventory,Management_Screen.quest);                    
                    Management_Screen.Deploy_Confirm = false;
                    //Gameplay_Screen.Main_Char.inventory = Management_Screen.inventory;
                }
            }
            if(Curent_Screen == Gameplay)
            {
                Gameplay_Screen.Update(gameTime);
                if(Gameplay_Screen.Extract_success == true)
                {                   
                    Curent_Screen = Management;
                    Gameplay_Screen.Reset();
                    Management_Screen.load(Gameplay_Screen.Main_Char.inventory,Gameplay_Screen.Quest);                    
                }
                if(Gameplay_Screen.Extract_fail == true)
                {
                    Curent_Screen = Management;
                    Gameplay_Screen.Reset();
                    Management_Screen.load(Gameplay_Screen.Main_Char.inventory,Gameplay_Screen.Quest);
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
            /////////////////////////////////// Add your debuging variable //////////////////////////
            if (DebugCheck == true)
            {
                Console.WriteLine("Curent_Screen = {0}", Curent_Screen);
                Console.WriteLine("Keyinput ={0}", keyinput);
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