using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Raid.Core
{
    public class Map
    {
        private Texture2D Area_Texture;
        private Vector2 Area_Pos;
        private Rectangle Area_Box;
        public Map() 
        {
            Load();
        }
        private void Load()
        {
            Area_Texture = Global.Content.Load<Texture2D>("A5");
            Area_Pos = new Vector2 (1974,4621);
            Area_Box = new Rectangle((int)Area_Pos.X, (int)Area_Pos.Y, 2007, 2101);

        }
        public Texture2D Get_Map_Texture(int i)
        {
            return Area_Texture;
        }
        public Vector2 Get_Map_Pos(int i) 
        {
            return Area_Pos;
        }
        public Rectangle Get_Map_Box(int i) 
        {
            return Area_Box;
        }
    }
}
