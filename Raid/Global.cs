using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Raid
{
    public static class Global
    {
        public static SpriteBatch spriteBatch {  get; set; }
        public static GraphicsDeviceManager GraphicsDevice { get; set; }
        public static ContentManager Content {  get; set; }
        public static GraphicsDevice Graphics { get; set; }
    }
}
