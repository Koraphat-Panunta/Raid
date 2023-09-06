using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Raid.Core
{
    public class Map
    {
        private Texture2D[] Area_Texture = new Texture2D[14];
        private Vector2[] Area_Pos = new Vector2[14];
        private Rectangle[] Area_Box = new Rectangle[14];
        public Map() 
        {
            Load();
        }
        private void Load()
        {
            Area_Texture[0] = Global.Content.Load<Texture2D>("A1");
            Area_Pos[0] = new Vector2(2948,8382);
            Area_Box[0] = new Rectangle((int)Area_Pos[0].X, (int)Area_Pos[0].Y,2264,1562);

            Area_Texture[1] = Global.Content.Load<Texture2D>("A2");
            Area_Pos[1] = new Vector2(5212,7288);
            Area_Box[1] = new Rectangle((int)Area_Pos[1].X, (int)Area_Pos[1].Y,1308,2565);

            Area_Texture[2] = Global.Content.Load<Texture2D>("A3");
            Area_Pos[2] = new Vector2(3645, 7288);
            Area_Box[2] = new Rectangle((int)Area_Pos[2].X, (int)Area_Pos[2].Y, 1567, 1092);

            Area_Texture[3] = Global.Content.Load<Texture2D>("A4");
            Area_Pos[3] = new Vector2(2369, 6681);
            Area_Box[3] = new Rectangle((int)Area_Pos[3].X, (int)Area_Pos[3].Y, 1276, 1699);

            Area_Texture[4] = Global.Content.Load<Texture2D>("A5");
            Area_Pos[4] = new Vector2 (1880, 4586);
            Area_Box[4] = new Rectangle((int)Area_Pos[4].X, (int)Area_Pos[4].Y, 2005, 2095);

            Area_Texture[5] = Global.Content.Load<Texture2D>("A6");
            Area_Pos[5] = new Vector2(3885, 4586);
            Area_Box[5] = new Rectangle((int)Area_Pos[5].X, (int)Area_Pos[5].Y, 927, 1057);

            Area_Texture[6] = Global.Content.Load<Texture2D>("A7");
            Area_Pos[6] = new Vector2(1881, 3525);
            Area_Box[6] = new Rectangle((int)Area_Pos[6].X, (int)Area_Pos[6].Y, 2931, 1059);

            Area_Texture[7] = Global.Content.Load<Texture2D>("A8");
            Area_Pos[7] = new Vector2(4812, 3537);
            Area_Box[7] = new Rectangle((int)Area_Pos[7].X, (int)Area_Pos[7].Y, 1357, 2532);

            Area_Texture[8] = Global.Content.Load<Texture2D>("A9");
            Area_Pos[8] = new Vector2(1347, 2660);
            Area_Box[8] = new Rectangle((int)Area_Pos[8].X, (int)Area_Pos[8].Y, 2312, 865);

            Area_Texture[9] = Global.Content.Load<Texture2D>("A10");
            Area_Pos[9] = new Vector2(1347, 1646);
            Area_Box[9] = new Rectangle((int)Area_Pos[9].X, (int)Area_Pos[9].Y, 1208, 1014);

            Area_Texture[10] = Global.Content.Load<Texture2D>("A11");
            Area_Pos[10] = new Vector2(0, 214);
            Area_Box[10] = new Rectangle((int)Area_Pos[10].X, (int)Area_Pos[10].Y, 1347, 3179);

            Area_Texture[11] = Global.Content.Load<Texture2D>("A12");
            Area_Pos[11] = new Vector2(1347, 220);
            Area_Box[11] = new Rectangle((int)Area_Pos[11].X, (int)Area_Pos[11].Y, 1660, 1424);

            Area_Texture[12] = Global.Content.Load<Texture2D>("A13");
            Area_Pos[12] = new Vector2(3659, 1160);
            Area_Box[12] = new Rectangle((int)Area_Pos[12].X, (int)Area_Pos[12].Y, 3880, 2363);

            Area_Texture[13] = Global.Content.Load<Texture2D>("A14");
            Area_Pos[13] = new Vector2(6031, 0);
            Area_Box[13] = new Rectangle((int)Area_Pos[13].X, (int)Area_Pos[13].Y, 1516, 1174);
        }
        public Texture2D Get_Map_Texture(int i)
        {
            return Area_Texture[i];
        }
        public Vector2 Get_Map_Pos(int i) 
        {
            return Area_Pos[i];
        }
        public Rectangle Get_Map_Box(int i) 
        {
            return Area_Box[i];
        }
    }
}
