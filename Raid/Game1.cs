using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Raid.Screen_Code;

namespace Raid
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Screen Curent_Screen;
        public Screen_Menu Menu_Screen;
        public Screen_Gameplay Gameplay_Screen;        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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
            Curent_Screen = Menu_Screen;
            /////////////////////////////////////// Set Variable ///////////////////////////////////////           
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();            
            
          
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {                    
            Global.spriteBatch.Begin();
            Curent_Screen.Draw();
            Global.spriteBatch.End();           
            base.Draw(gameTime);
        }
    }
}