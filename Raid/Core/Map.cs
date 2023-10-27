using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Raid.Enviroment;

namespace Raid.Core
{
    public class Map
    {
        public int num_zone = 9;
        public Texture2D[] Area_Texture = new Texture2D[21];
        public Texture2D[] Area_Shadow = new Texture2D[21];
        private Vector2[] Area_Pos = new Vector2[21];
        private Rectangle[] Area_Box = new Rectangle[21];
        public Texture2D[] Wallmaria = new Texture2D[6];

        public Rectangle[] mapBox = new Rectangle[57];

        public Tree_Group[] Trees = new Tree_Group[9];

        public Tree_Group[] Trees2 = new Tree_Group[2];

        //public Buiding[] Buidings = new Buiding[17];

        public Texture2D[] Landmark = new Texture2D[3];
        public Map() 
        {
            Load();
            
        }
        private void Load()
        {
            //Landmark
            Landmark[0] = Global.Content.Load<Texture2D>("Fence_Temple_Shadow");
            Landmark[1] = Global.Content.Load<Texture2D>("Fence_Temple");
            Landmark[2] = Global.Content.Load<Texture2D>("PrasingOriginal");

            //Building
            //Buidings[0] = new JapHouse_Single_Back(new Vector2(7393, 4623));
            //Buidings[1] = new JapHouse_Single_Back(new Vector2(9735, 4322));
            //Buidings[2] = new JapHouse_Single_Back(new Vector2(10439, 4322));
            //Buidings[3] = new JapHouse_Single_Back(new Vector2(7415, 2280));
            //Buidings[4] = new JapHouse_Single_Back(new Vector2(8103, 2280));
            //Buidings[5] = new JapHouse_Single_Back(new Vector2(8791, 2280));

            //Buidings[6] = new JapHouse_Single_Front(new Vector2(8392, 3235));
            //Buidings[7] = new JapHouse_Single_Front(new Vector2(9101, 3235));
            //Buidings[8] = new JapHouse_Single_Front(new Vector2(9723, 3616));
            //Buidings[9] = new JapHouse_Single_Front(new Vector2(7210, 1616));

            //Buidings[10]= new JapHouse_Single_Side(new Vector2(6672, 3712));
            //Buidings[11] = new JapHouse_Single_Side(new Vector2(10106, 2826));
            //Buidings[12] = new JapHouse_Single_Side(new Vector2(11265, 2767));

            //Buidings[13] = new JapHouse_Double_Front(new Vector2(7331, 6737));
            //Buidings[14] = new JapHouse_Double_Side(new Vector2(7355, 2944));
            //Buidings[15] = new JapHouse_Double_Side(new Vector2(6700, 1351));
            //Buidings[16] = new JapHouse_Double_Side(new Vector2(9379, 1704));
            //Tree Group
            Trees[0] = new Tree_Group(new Vector2(5016, 4711), "Trees Green PNG 1");
            Trees[1] = new Tree_Group(new Vector2(8727, 7893), "Trees Green PNG 3");
            Trees[2] = new Tree_Group(new Vector2(7849, 5737), "Trees Green PNG 2");
            Trees[3] = new Tree_Group(new Vector2(4240, 5760), "Trees Green PNG 4");
            Trees[4] = new Tree_Group(new Vector2(4121, 8950), "Trees Green PNG 5");
            Trees[5] = new Tree_Group(new Vector2(6652, 5465), "Trees Blue PNG 7");
            Trees[6] = new Tree_Group(new Vector2(9449, 5464), "Trees Blue PNG 6");
            Trees[7] = new Tree_Group(new Vector2(9900, 1326), "Trees Blue PNG 1");
            Trees[8] = new Tree_Group(new Vector2(6716, 1704), "Trees Blue PNG 2");

            Trees2[0] = new Tree_Group(new Vector2(9818, 3727), "Trees Blue PNG 5");
            Trees2[1] = new Tree_Group(new Vector2(6726, 4710), "Trees Blue PNG 4");
            //ชนบท
            Area_Texture[0] = Global.Content.Load<Texture2D>("A5");
            Area_Shadow[0] = Global.Content.Load<Texture2D>("A5_FenceShadow");
            Area_Pos[0] = new Vector2(4224, 7360);
            Area_Box[0] = new Rectangle((int)Area_Pos[0].X, (int)Area_Pos[0].Y, 2624, 2816);

            Area_Texture[1] = Global.Content.Load<Texture2D>("A6");
            Area_Shadow[1] = Global.Content.Load<Texture2D>("A6_FenceShadow");
            Area_Pos[1] = new Vector2(6848, 7360);
            Area_Box[1] = new Rectangle((int)Area_Pos[1].X, (int)Area_Pos[1].Y, 1344, 1920);

            Area_Texture[2] = Global.Content.Load<Texture2D>("A7_1");
            Area_Shadow[2] = Global.Content.Load<Texture2D>("A7_1_Fence_Shadow");
            Area_Pos[2] = new Vector2(4224, 5952);
            Area_Box[2] = new Rectangle((int)Area_Pos[2].X, (int)Area_Pos[2].Y, 2304, 1408);

            Area_Texture[3] = Global.Content.Load<Texture2D>("A7_2");
            Area_Shadow[3] = Global.Content.Load<Texture2D>("A7_2_FenceShadow");
            Area_Pos[3] = new Vector2(6528, 5952);
            Area_Box[3] = new Rectangle((int)Area_Pos[3].X, (int)Area_Pos[3].Y, 1664, 1408);

            Area_Texture[4] = Global.Content.Load<Texture2D>("A8");
            Area_Shadow[4] = Global.Content.Load<Texture2D>("A8_FenceShadow");
            Area_Pos[4] = new Vector2(8192, 5952);
            Area_Box[4] = new Rectangle((int)Area_Pos[4].X, (int)Area_Pos[4].Y, 1728, 3392);


            //Japtown
            Area_Texture[5] = Global.Content.Load<Texture2D>("A1");
            Area_Shadow[5] = Global.Content.Load<Texture2D>("Emty");
            Area_Pos[5] = new Vector2(5824, 12416);
            Area_Box[5] = new Rectangle((int)Area_Pos[5].X, (int)Area_Pos[5].Y, 2880, 2048);

            Area_Texture[6] = Global.Content.Load<Texture2D>("A2");
            Area_Shadow[6] = Global.Content.Load<Texture2D>("Emty");
            Area_Pos[6] = new Vector2(8704, 11072);
            Area_Box[6] = new Rectangle((int)Area_Pos[6].X, (int)Area_Pos[6].Y, 1664, 3392);

            Area_Texture[7] = Global.Content.Load<Texture2D>("A3");
            Area_Shadow[7] = Global.Content.Load<Texture2D>("Emty");
            Area_Pos[7] = new Vector2(6592, 11072);
            Area_Box[7] = new Rectangle((int)Area_Pos[7].X, (int)Area_Pos[7].Y, 2112, 1344);

            Area_Texture[8] = Global.Content.Load<Texture2D>("A4");
            Area_Shadow[8] = Global.Content.Load<Texture2D>("Emty");
            Area_Pos[8] = new Vector2(5056, 10176);
            Area_Box[8] = new Rectangle((int)Area_Pos[8].X, (int)Area_Pos[8].Y, 1536, 2240);


            //DockTown
            Area_Texture[9] = Global.Content.Load<Texture2D>("A9");
            Area_Shadow[9] = Global.Content.Load<Texture2D>("A9_FenceShadow");
            Area_Pos[9] = new Vector2(3520, 4864);
            Area_Box[9] = new Rectangle((int)Area_Pos[9].X, (int)Area_Pos[9].Y, 3072, 1088);
           
            Area_Texture[10] = Global.Content.Load<Texture2D>("A10");
            Area_Shadow[10] = Global.Content.Load<Texture2D>("A10_FenceShadow");
            Area_Pos[10] = new Vector2(3520, 3456);
            Area_Box[10] = new Rectangle((int)Area_Pos[10].X, (int)Area_Pos[10].Y, 1728, 1408);

            Area_Texture[11] = Global.Content.Load<Texture2D>("A11_1");
            Area_Shadow[11] = Global.Content.Load<Texture2D>("A11_1_FenceShadow");
            Area_Pos[11] = new Vector2(1600, 1856);
            Area_Box[11] = new Rectangle((int)Area_Pos[11].X, (int)Area_Pos[11].Y, 1920, 1600);

            Area_Texture[12] = Global.Content.Load<Texture2D>("A11_2");
            Area_Shadow[12] = Global.Content.Load<Texture2D>("A11_2_FenceShadow");
            Area_Pos[12] = new Vector2(1600, 3456);
            Area_Box[12] = new Rectangle((int)Area_Pos[12].X, (int)Area_Pos[12].Y, 1920, 1408);

            Area_Texture[13] = Global.Content.Load<Texture2D>("A11_3");
            Area_Shadow[13] = Global.Content.Load<Texture2D>("A11_3_FenceShadow");
            Area_Pos[13] = new Vector2(1600, 4864);
            Area_Box[13] = new Rectangle((int)Area_Pos[13].X, (int)Area_Pos[13].Y, 1920, 1088);

            Area_Texture[14] = Global.Content.Load<Texture2D>("A12");
            Area_Shadow[14] = Global.Content.Load<Texture2D>("A12_FenceShadow");
            Area_Pos[14] = new Vector2(3520, 1856);
            Area_Box[14] = new Rectangle((int)Area_Pos[14].X, (int)Area_Pos[14].Y, 1920, 1600);

            //Elden Ring Town
            Area_Texture[15] = Global.Content.Load<Texture2D>("A13_1");
            Area_Shadow[15] = Global.Content.Load<Texture2D>("A13_1_Fence_Shadow");
            Wallmaria[0] = Global.Content.Load<Texture2D>("A13_1_Wall");
            Area_Pos[15] = new Vector2(8192, 1216);
            Area_Box[15] = new Rectangle((int)Area_Pos[15].X, (int)Area_Pos[15].Y, 1600, 2368);

            Area_Texture[16] = Global.Content.Load<Texture2D>("A13_2");
            Area_Shadow[16] = Global.Content.Load<Texture2D>("A13_2_FenceShadow");
            Wallmaria[1] = Global.Content.Load<Texture2D>("A13_2_Wall");
            Area_Pos[16] = new Vector2(6592, 1216);
            Area_Box[16] = new Rectangle((int)Area_Pos[16].X, (int)Area_Pos[16].Y, 1600, 2368);

            Area_Texture[17] = Global.Content.Load<Texture2D>("A13_3");
            Area_Shadow[17] = Global.Content.Load<Texture2D>("A13_3_FenceShadow");
            Wallmaria[2] = Global.Content.Load<Texture2D>("A13_3_Wall");
            Area_Pos[17] = new Vector2(6592, 3584);
            Area_Box[17] = new Rectangle((int)Area_Pos[17].X, (int)Area_Pos[17].Y, 1600, 2368);

            Area_Texture[18] = Global.Content.Load<Texture2D>("A13_4");
            Area_Shadow[18] = Global.Content.Load<Texture2D>("A13_4_FenceShadow");
            Wallmaria[3] = Global.Content.Load<Texture2D>("A13_4_Wall");
            Area_Pos[18] = new Vector2(8192, 3584);
            Area_Box[18] = new Rectangle((int)Area_Pos[18].X, (int)Area_Pos[18].Y, 1600, 2368);

            Area_Texture[19] = Global.Content.Load<Texture2D>("A14_1");
            Area_Shadow[19] = Global.Content.Load<Texture2D>("A14_1_FenceShadow");
            Wallmaria[4] = Global.Content.Load<Texture2D>("A14_1_Wall");
            Area_Pos[19] = new Vector2(9792, 3584);
            Area_Box[19] = new Rectangle((int)Area_Pos[19].X, (int)Area_Pos[19].Y, 2048, 2368);

            Area_Texture[20] = Global.Content.Load<Texture2D>("A14_2");
            Area_Shadow[20] = Global.Content.Load<Texture2D>("A14_2_FenceShadow");
            Wallmaria[5] = Global.Content.Load<Texture2D>("A14_2_Wall");
            Area_Pos[20] = new Vector2(9792, 1216);
            Area_Box[20] = new Rectangle((int)Area_Pos[20].X, (int)Area_Pos[20].Y, 2048, 2368);

            //ADD Tree
            addBox();

        }
        public Texture2D Get_Map_Texture(int i)
        {
            return Area_Texture[i];
        }
        public Texture2D Get_Map_Shadow(int i)
        {
            return Area_Shadow[i];
        }
        public Vector2 Get_Map_Pos(int i) 
        {
            return Area_Pos[i];
        }
        public Rectangle Get_Map_Box(int i) 
        {
            return Area_Box[i];
        }
        private void addBox()
        {
            //Zoneท่าเรือ              
            mapBox[0] = new Rectangle(4736, 9216, 323, 22);
            mapBox[1] = new Rectangle(6058, 8320, 2966, 975);
            mapBox[2] = new Rectangle(10304, 11122, 22, 3278);
            mapBox[3] = new Rectangle(6528, 10212, 3798, 908);
            mapBox[4] = new Rectangle(6058, 9856, 790, 335);
            mapBox[5] = new Rectangle(5956, 10190, 572, 28);
            mapBox[6] = new Rectangle(5874, 14400, 4430, 50);
            mapBox[7] = new Rectangle(5056, 12352, 818, 2048);
            mapBox[8] = new Rectangle(5120, 10190, 508, 28);
            mapBox[9] = new Rectangle(8042, 12608, 1046, 852);
            mapBox[10] = new Rectangle(5098, 10212, 22, 2162);
            mapBox[11] = new Rectangle(4266, 9856, 1238, 334);
            mapBox[12] = new Rectangle(4381, 9472, 22, 384);
            mapBox[13] = new Rectangle(4381, 8832, 355, 640);
            mapBox[14] = new Rectangle(4664, 8150, 72, 253);
            mapBox[15] = new Rectangle(9706, 6631, 22, 409);
            mapBox[16] = new Rectangle(11074, 2560, 360, 448);
            mapBox[17] = new Rectangle(9808, 2560, 816, 448);
            mapBox[18] = new Rectangle(6080, 1408, 640, 3935);
            mapBox[19] = new Rectangle(6592, 5504, 2304, 128);
            mapBox[20] = new Rectangle(9344, 5504, 2480, 128);
            mapBox[21] = new Rectangle(6720, 1664, 3088, 128);
            mapBox[22] = new Rectangle(10304, 1600, 1066, 22);
            mapBox[23] = new Rectangle(9808, 1664, 496, 896);
            mapBox[24] = new Rectangle(11712, 1344, 128, 4160);
            mapBox[25] = new Rectangle(11370, 1664, 342, 896);
            mapBox[26] = new Rectangle(11306, 3840, 342, 1152);
            mapBox[27] = new Rectangle(9386, 5632, 338, 913);
            mapBox[28] = new Rectangle(9514, 7040, 222, 2048);
            mapBox[29] = new Rectangle(9834, 4992, 1878, 512);
            mapBox[30] = new Rectangle(7848, 1790, 1944, 273);
            mapBox[31] = new Rectangle(7530, 2880, 2262, 466);
            mapBox[32] = new Rectangle(6720, 2304, 320, 1302);
            mapBox[33] = new Rectangle(8106, 3584, 278, 662);
            //mapBox[34] = new Rectangle(-700, -700, 1, 1);
            mapBox[34] = new Rectangle(8106, 4800, 278, 704);
            mapBox[35] = new Rectangle(8622, 5632, 274, 2124);
            mapBox[36] = new Rectangle(5401, 5846, 167, 2240);
            mapBox[37] = new Rectangle(4970, 5824, 576, 854);
            mapBox[38] = new Rectangle(5226, 6742, 22, 576);
            mapBox[39] = new Rectangle(4330, 6720, 22, 576);
            mapBox[40] = new Rectangle(4330, 7296, 918, 29);
            mapBox[41] = new Rectangle(5398, 8020, 22, 108);
            mapBox[42] = new Rectangle(4736, 7994, 253, 82);
            mapBox[43] = new Rectangle(7525, 6109, 347, 185);
            mapBox[44] = new Rectangle(6720, 6133, 379, 161);
            mapBox[45] = new Rectangle(6058, 5343, 662, 1143);
            mapBox[46] = new Rectangle(9024, 9088, 490, 192);
            mapBox[47] = new Rectangle(6058, 7104, 2138, 652);
            mapBox[48] = new Rectangle(1770, 5824, 2774, 854);
            mapBox[49] = new Rectangle(2985, 3072, 2269, 598);
            mapBox[50] = new Rectangle(1770, 1920, 3456, 22);
            mapBox[51] = new Rectangle(6057, 7040, 154, 64);
            mapBox[52] = new Rectangle(7786, 6976, 89, 128);
            mapBox[53] = new Rectangle(6720, 6358, 67, 128);
            mapBox[54] = new Rectangle(4714, 3731, 1366, 1604);
            mapBox[55] = new Rectangle(1770, 1984, 22, 3862);
            mapBox[56] = new Rectangle(5226, 1942, 22, 1110);

        }
    }
}
