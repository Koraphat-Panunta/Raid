using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Raid.Basic_System;
using Raid.Core;
using Raid.Enemy;
using Raid.Enviroment;
using Raid.Item;
using Raid.MainCharacter;
using System;
using System.Collections.Generic;


namespace Raid.Screen_Code
{
    public class Screen_Gameplay:Screen
    {
        
        Random random = new Random();
        public Main_Char Main_Char;
        List<EnemyClose> enemyClose = new List<EnemyClose>();
        List<EnemyRange> enemyRanges = new List<EnemyRange>();
        List<EnemyBoss> enemyBosses = new List<EnemyBoss>();       
        Map map;
        Camera Camera;       
        public List<Grace> graces = new List<Grace>();  
        bool Hit =false;
        public Extract_gate[] extract_Gate;
        public bool Extract_success;
        public bool Extract_fail;
        private Time Time;
    
        Texture2D Pos;
        Texture2D Blood_Feedback;       
        public Quest Quest;
        private HP_BAR HP_BAR;
        private Hitstrak_Bar Hitstreak_bar;
        private Weight_UI Weight_UI;
        private Buiding[] Buidings = new Buiding[77];
        public Screen_Gameplay() 
        {
            
        }
        public override void load(Vector2 Deploy_Pos)
        {                      
            Main_Char = new Main_Char();
           
            Extract_fail = false;
            Extract_success = false;
            map = new Map();                                 
            extract_Gate = new Extract_gate[3];
            extract_Gate[0] = new Extract_gate(new Vector2(2238,6153));
            extract_Gate[1] = new Extract_gate(new Vector2(5547,4563));
            extract_Gate[2] = new Extract_gate(new Vector2(2001,4145));
            Main_Char.Deploy(Deploy_Pos);                                   
            Camera = new Camera(Main_Char.Get_Pos());                       
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count *Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
            HP_BAR = new HP_BAR();
        }
        public void load(Vector2 Deploy_Pos,Inventory inventory,Quest quest)
        {
            Main_Char = new Main_Char();
            Main_Char.inventory = inventory;
   
            
           
            Extract_fail = false;
            Extract_success = false;
            map = new Map();
            extract_Gate = new Extract_gate[3];
            extract_Gate[0] = new Extract_gate(new Vector2(4573, 9479));
            extract_Gate[1] = new Extract_gate(new Vector2(4618, 6774));
            extract_Gate[2] = new Extract_gate(new Vector2(9317, 6618));
            for(int i = 0; i < extract_Gate.Length; i++)
            {
                if (Deploy_Pos.X >= extract_Gate[i].Get_Box().Left&& Deploy_Pos.X <= extract_Gate[i].Get_Box().Right)
                {
                    if(Deploy_Pos.Y >= extract_Gate[i].Get_Box().Top && Deploy_Pos.Y <= extract_Gate[i].Get_Box().Bottom)
                    {
                        extract_Gate[i].Extract_gate_enable = false;
                        break;
                    }
                }
            }
            Main_Char.Deploy(Deploy_Pos);
            Camera = new Camera(Main_Char.Get_Pos());
            Camera.Load();
            MediaPlayer.Play(Audio.Wind_ambient);
            MediaPlayer.IsRepeating = true;
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(200 + (Main_Char.inventory.Rune_Times.Count * Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");
            this.Quest = quest;
            HP_BAR = new HP_BAR();
            Hitstreak_bar = new Hitstrak_Bar();
            Weight_UI = new Weight_UI();
            Add_buidling();
            //Add_Enemy

            Add_Enemy();

        }
        private void Add_buidling()
        {
            //ADD BUIDING
            Buidings[0] = new House_Contryside_font(new Vector2(4848, 7573));
            Buidings[1] = new House_Countryside_back(new Vector2(4981, 9040));
            Buidings[2] = new House_Countryside_side(new Vector2(4271, 8149));
            Buidings[3] = new House_Countryside_back(new Vector2(6121, 8081));
            Buidings[4] = new House_Countryside_side(new Vector2(6016, 9016));
            Buidings[5] = new House_Countryside_back(new Vector2(6133, 6672));
            Buidings[6] = new House_Contryside_font(new Vector2(6958, 5780));
            Buidings[7] = new House_Countryside_side(new Vector2(7788, 6227));
            Buidings[8] = new House_Contryside_font(new Vector2(8055, 7252));
            Buidings[9] = new JapHouse_Single_Back(new Vector2(7393, 4623));
            Buidings[10] = new JapHouse_Single_Back(new Vector2(9735, 4322));
            Buidings[11] = new JapHouse_Single_Back(new Vector2(10439, 4322));
            Buidings[12] = new JapHouse_Single_Back(new Vector2(7415, 2280));
            Buidings[13] = new JapHouse_Single_Back(new Vector2(8103, 2280));
            Buidings[14] = new JapHouse_Single_Back(new Vector2(8791, 2280));

            Buidings[15] = new JapHouse_Single_Front(new Vector2(8392, 3235));
            Buidings[16] = new JapHouse_Single_Front(new Vector2(9101, 3235));
            Buidings[17] = new JapHouse_Single_Front(new Vector2(9723, 3616));
            Buidings[18] = new JapHouse_Single_Front(new Vector2(7210, 1616));

            Buidings[19] = new JapHouse_Single_Side(new Vector2(6672, 3712));
            Buidings[20] = new JapHouse_Single_Side(new Vector2(10096, 2782));
            Buidings[21] = new JapHouse_Single_Side(new Vector2(11265, 2767));

           

            Buidings[22] = new JapHouse_Double_Front(new Vector2(7331, 6737));          
            Buidings[23] = new JapHouse_Double_Side(new Vector2(7355, 2944));
            Buidings[24] = new JapHouse_Double_Side(new Vector2(6700, 1351));
            Buidings[25] = new JapHouse_Double_Side(new Vector2(9379, 1704));
           

            Buidings[26] = new JapHouse_Single_Front(new Vector2(3533, 3363));
            Buidings[27] = new JapHouse_Single_Front(new Vector2(6048, 11093));
            Buidings[28] = new JapHouse_Single_Front(new Vector2(6784, 11093));
            Buidings[29] = new JapHouse_Single_Front(new Vector2(7530, 11093));
            Buidings[30] = new JapHouse_Single_Front(new Vector2(8281, 11093));
            Buidings[31] = new JapHouse_Single_Front(new Vector2(8989, 11093));

            Buidings[32] = new JapHouse_Single_Side(new Vector2(1856, 2240));
            Buidings[33] = new JapHouse_Single_Side(new Vector2(5110, 10219));
            Buidings[34] = new JapHouse_Single_Side(new Vector2(6016, 10219));
            Buidings[35] = new JapHouse_Single_Side(new Vector2(5098, 11008));
            Buidings[36] = new JapHouse_Single_Side(new Vector2(6195, 12416));
            Buidings[37] = new JapHouse_Single_Side(new Vector2(6195, 13291));

            Buidings[38] = new JapHouse_Double_Front(new Vector2(2908, 1644));
            Buidings[39] = new JapHouse_Double_Front(new Vector2(7445, 11703));
            Buidings[40] = new JapHouse_Double_Front(new Vector2(8805, 11703));
            Buidings[41] = new JapHouse_Double_Front(new Vector2(7525, 13333));
            Buidings[42] = new JapHouse_Double_Front(new Vector2(8790, 13342));

            Buidings[43] = new JapHouse_Double_Side(new Vector2(1905, 4262));
            Buidings[44] = new JapHouse_Double_Side(new Vector2(7048, 11660));
            Buidings[45] = new JapHouse_Double_Side(new Vector2(7057, 12160));
            Buidings[46] = new JapHouse_Double_Side(new Vector2(7051, 12729));
            Buidings[47] = new JapHouse_Double_Side(new Vector2(7057, 13149));

            Buidings[48] = new JapHouse_Double_Side(new Vector2(9489, 11638));
            Buidings[49] = new JapHouse_Double_Side(new Vector2(9498, 12133));
            Buidings[50] = new JapHouse_Double_Side(new Vector2(9506, 12655));
            Buidings[51] = new JapHouse_Double_Side(new Vector2(9506, 13094));
            //Tree
            Buidings[52] = new Tree_Red(new Vector2(3872, 1990));
            Buidings[53] = new Tree_Red(new Vector2(2385, 1936));
            Buidings[54] = new Tree_Red(new Vector2(3045, 2616));
            Buidings[55] = new Tree_Red(new Vector2(3695, 2616));
            Buidings[56] = new Tree_Red(new Vector2(3281, 3152));
            Buidings[57] = new Tree_Red(new Vector2(4163, 3128));
            Buidings[58] = new Tree_Red(new Vector2(1937, 3468));
            Buidings[59] = new Tree_Red(new Vector2(4842, 3591));
            Buidings[60] = new Tree_Red(new Vector2(1904, 3806));
            Buidings[61] = new Tree_Red(new Vector2(2024, 5358));
            Buidings[62] = new Tree_Red(new Vector2(3331, 5200));


            Buidings[63] = new Tree_Red(new Vector2(5137, 11920));
            Buidings[64] = new Tree_Red(new Vector2(5443, 11975));
            Buidings[65] = new Tree_Red(new Vector2(5851, 12432));
            Buidings[66] = new Tree_Red(new Vector2(5854, 12792));
            Buidings[67] = new Tree_Red(new Vector2(5857, 13168));
            Buidings[68] = new Tree_Red(new Vector2(5857, 13562));
            Buidings[69] = new Tree_Red(new Vector2(5881, 13922));
            Buidings[70] = new Tree_Red(new Vector2(9719, 11243));
            Buidings[71] = new Tree_Red(new Vector2(10012, 11280));

            //EXTENDED
            Buidings[72] = new JapHouse_Double_Front(new Vector2(7331, 3676));
            Buidings[74] = new Tree_Red(new Vector2(2958, 3676));
            Buidings[75] = new Tree_Red(new Vector2(4415, 3836));
            Buidings[76] = new Tree_Red(new Vector2(3366, 2624));



            //landMark
            Buidings[73] = new _3Kings(new Vector2(8704, 4034));
        }
        private void Add_Enemy() 
        {
            //1
            Add_Enemy(random.Next(2, 4), random.Next(2, 3), 7849, 7849 + 1495, 14060, 14060 + 208);
            //2
            Add_Enemy(random.Next(2, 4), random.Next(2, 3), 6773, 6773 + 184, 13168, 13168 + 1048);
            //3
            Add_Enemy(random.Next(2, 4), random.Next(2, 2), 10026, 10026 + 172, 13354, 13354 + 876);
            //4
            Add_Enemy(random.Next(2, 4), random.Next(2, 3), 10026, 10026 + 172, 11810, 11810 + 876);
            //5
            Add_Enemy(random.Next(3, 4), random.Next(1, 2), 9192, 9192 + 272, 12524, 12524 + 916);
            //6
            Add_Enemy(random.Next(2, 3), random.Next(2, 2), 8329, 8329 + 312, 11776, 11776 + 719);
            //7
            Add_Enemy(random.Next(2, 3), random.Next(2, 2), 7645, 7645 + 183, 12569, 12569 + 916);
            //8
            Add_Enemy(random.Next(2, 2), random.Next(2, 3), 8064, 8064 + 919, 13568, 13568 + 82);
            //9
            Add_Enemy(random.Next(2, 4), random.Next(1, 2), 6749, 6749 + 239, 11781, 11781 + 748);
            //10
            Add_Enemy(random.Next(3, 5), random.Next(2, 2), 5663, 5677 + 267, 10432, 10432 + 1353);
            //11
            Add_Enemy(random.Next(4, 6), random.Next(2, 3), 4959, 4959 + 1021, 8288, 8288 + 715);
            //12 
            Add_Enemy(random.Next(3, 5), random.Next(1, 2), 5709, 5709 + 243, 6842, 6842 + 1350);
            //13
            Add_Enemy(random.Next(6, 8), random.Next(1, 5), 6464, 6464 + 2460, 7954, 7954 + 283);
            //14
            Add_Enemy(random.Next(4, 6), random.Next(2, 3), 9127, 9127 + 258, 7645, 7645 + 1291);
            //15
            Add_Enemy(random.Next(4, 6), random.Next(2, 3), 6976, 6976 + 712, 6470, 6470 + 506);
            //16
            Add_Enemy(random.Next(3, 5), random.Next(1, 2), 5696, 5696 + 260, 5836, 5836 + 896);
            //17
            Add_Enemy(random.Next(2, 4), random.Next(2, 2), 4608, 4608 + 1280, 5440, 5440 + 273);
            //18
            Add_Enemy(random.Next(9, 11), random.Next(3, 4), 2624, 2624 + 1945, 4262, 4262 + 922);
            //19
            Add_Enemy(random.Next(2, 4), random.Next(1, 2), 2496, 2496 + 380, 2801, 2801 + 1299);
            //20
            Add_Enemy(random.Next(2, 3), random.Next(2, 2), 2501, 2501 + 1355, 2414, 2414 + 263);
            //21
            Add_Enemy(random.Next(3, 5), random.Next(3, 3), 4352, 4352 + 532, 2112, 2112 + 864);
            //22
            Add_Enemy(random.Next(2, 4), random.Next(2, 2), 8992, 8992 + 264, 4826, 4826 + 999);
            //23
            Add_Enemy(random.Next(3, 5), random.Next(2, 2), 7257, 7257 + 1304, 4418, 4418 + 254);
            //24
            Add_Enemy(random.Next(2, 4), random.Next(2, 2), 8527, 8527 + 1058, 3928, 3928 + 223);
            //25 
            Add_Enemy(random.Next(5, 7), random.Next(2, 3), 7199, 7199 + 97, 2222, 2222 + 2066);
            //26
            Add_Enemy(random.Next(4, 6), random.Next(1, 2), 7360, 7360 + 1950, 2234, 2234 + 243);
            //27
            Add_Enemy(random.Next(2, 4), random.Next(2, 4), 9639, 9639 + 937, 4186, 4186 + 223);
            //28
            Add_Enemy(random.Next(4, 6), random.Next(1, 2), 10642, 10642 + 494, 3072, 3072 + 1139);
            //29
            Add_Enemy(random.Next(3, 5), random.Next(1, 3), 10434, 10434 + 850, 1792, 1792 + 663);

            //Boss1
            enemyBosses.Add(new EnemyBoss(new Vector2(10840, 2085)));

            //Boss2
            enemyBosses.Add(new EnemyBoss(new Vector2(4650, 2496)));

            //Boss3
            enemyBosses.Add(new EnemyBoss(new Vector2(8505, 13699)));
        }
        private void Add_Enemy(int close_num,int range_num,int PosX_min,int PosX_max,int PosY_min,int PosY_max)
        {
            //Close_Enemy
           for(int i = 0; i < close_num; i++)
            {
                enemyClose.Add(new EnemyClose(new Vector2(random.Next(PosX_min, PosX_max), random.Next(PosY_min, PosY_max))));
            }
           //Range_Enemy
           for(int i = 0; i < range_num; i++)
            {
                enemyRanges.Add(new EnemyRange(new Vector2(random.Next(PosX_min, PosX_max), random.Next(PosY_min, PosY_max))));
            }
        }
        public void load(Vector2 Deploy_Pos, Inventory inventory)
        {

            Main_Char = new Main_Char();
            Main_Char.inventory = inventory;
            
            Extract_fail = false;
            Extract_success = false;
            map = new Map();
            extract_Gate = new Extract_gate[3];
            extract_Gate[0] = new Extract_gate(new Vector2(2238, 6153));
            extract_Gate[1] = new Extract_gate(new Vector2(5547, 4563));
            extract_Gate[2] = new Extract_gate(new Vector2(2001, 4145));
            Main_Char.Deploy(Deploy_Pos);
            Camera = new Camera(Main_Char.Get_Pos());
            
            Pos = Global.Content.Load<Texture2D>("Rectangle 159");
            this.Time = new Time(60 + (Main_Char.inventory.Rune_Times.Count * Rune_Time.time_plus));
            Blood_Feedback = Global.Content.Load<Texture2D>("Blood-Feedback");

        }
        float SceneEnd_time = 0;
        public override void Update(GameTime gameTime)
        {
            foreach(var buiding in Buidings)
            {
                buiding.Layer = 3;
                buiding.Trans = false;
            }           
            Main_Char.Update();
            Collision();
            Main_Char.Last_Pos = Main_Char.Get_Pos();
            Camera.Camera_Movement(Main_Char);            
            if (Main_Char.Alive == true)
            {
                Extractionsystem();
                lootingsystem();
                Time.Time_Count();

                for (int i = 0; i < enemyClose.Count; i++)
                {                                      
                    if (enemyClose[i].Alive == false)
                    {
                        graces.Add(new Grace(enemyClose[i].Get_Pos()));
                        enemyClose.Remove(enemyClose[i]);
                        break;
                    }
                    enemyClose[i].Update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));

                    //ENEMY Trans building vheck
                    for (int n = 0; n < Buidings.Length; n++)
                    {                       
                            if (enemyClose[i].Box.Intersects(Buidings[n].Box_Trans))
                            {
                                Buidings[n].Layer = 2;
                                Buidings[n].Trans = true;
                            }                                               
                    }
                    Collision(enemyClose[i]);
                    enemyClose[i].Last_Pos = enemyClose[i].Get_Pos();
                        if (enemyClose[i].Enemy_is_attack == true)
                        {
                            if (Main_Char.ATK_state != 3)
                            {
                                Main_Char.Get_Dmg(enemyClose[i].Enemt_ATK_DMG);
                                feedback_time_start = true;
                                break;
                            }
                        }
                        if (enemyClose[i].immune == false)
                        {
                            if (Main_Char.ATK_state == 1)
                            {
                                if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 90 && enemyClose[i].Get_Pos().Y <= Main_Char.Get_Pos().Y+96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Commom_ATK_Push,Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 90 && enemyClose[i].Get_Pos().Y >= Main_Char.Get_Pos().Y- 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 90 && enemyClose[i].Get_Pos().X <= Main_Char.Get_Pos().X+ 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        enemyClose[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                        Camera.CameraShake();
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus();
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_common_Range + 90 && enemyClose[i].Get_Pos().X >= Main_Char.Get_Pos().X- 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Common_ATK);
                                        Camera.CameraShake(); 
                                        enemyClose[i].Get_Push(Main_Char.Commom_ATK_Push,Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        Main_Char.Hitstreak_Plus(); 
                                        break;
                                    }
                                }

                            }
                            if (Main_Char.ATK_state == 2)
                            {
                                if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 90 && enemyClose[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;

                                    }
                                }
                                if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 90 && enemyClose[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 90 && enemyClose[i].Get_Pos().X <= Main_Char.Get_Pos().X + 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        Camera.CameraShake();
                                        enemyClose[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                                if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                                {
                                    if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 90 && enemyClose[i].Get_Pos().X >= Main_Char.Get_Pos().X - 96 && enemyClose[i].immune == false)
                                    {
                                        enemyClose[i].Get_DMG(Main_Char.Heavy_ATK);
                                        enemyClose[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                        Camera.CameraShake();
                                        enemyClose[i].stunt = true;
                                        enemyClose[i].immune = true;
                                        break;
                                    }
                                }
                            }
                            if (Main_Char.ATK_state == 4)
                            {
                                if (enemyClose[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 90 && enemyClose[i].immune == false)
                                {
                                    enemyClose[i].Get_DMG(Main_Char.Roll_ATK);
                                    enemyClose[i].Get_Push(Main_Char.Roll_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyClose[i].stunt = true;
                                    enemyClose[i].immune = true;
                                    break;
                                }
                            }
                        }
                        
                }
                for (int i = 0; i < enemyRanges.Count; i++)
                {
                    if (enemyRanges[i].Alive == false)
                    {
                        graces.Add(new Grace(enemyRanges[i].Get_Pos()));
                        enemyRanges.Remove(enemyRanges[i]);
                        break;
                    }
                    enemyRanges[i].Update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));
                    enemyRanges[i].Last_Pos = enemyRanges[i].Get_Pos();
                    Collision(enemyRanges[i]);
                    //ENEMY Trans building vheck
                    for (int n = 0; n < Buidings.Length; n++)
                    {
                        if (Buidings[n].Layer == 3)
                        {
                            if (enemyRanges[i].Box.Intersects(Buidings[n].Box_Trans))
                            {
                                Buidings[n].Layer = 2;
                                Buidings[n].Trans = true;
                            }
                            else
                            {
                                Buidings[n].Layer = 3;
                            }
                        }
                    }
                    if (enemyRanges[i].fire_ball.Count > 0)
                    {
                        if (enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count-1].Return_box().Intersects(Main_Char.Get_Box()))
                        {
                            if (Main_Char.ATK_state != 3)
                            {
                                Main_Char.Get_Dmg(enemyRanges[i].Enemt_ATK_DMG);
                                feedback_time_start = true;
                                enemyRanges[i].fire_ball.Remove(enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1]);
                                break;
                            }
                        }
                    }
                    if (enemyRanges[i].immune == false)
                    {
                        if (Main_Char.ATK_state == 1)
                        {
                            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 35 && enemyRanges[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 35 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 35 && enemyRanges[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 35 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 35 && enemyRanges[i].Get_Pos().X <= Main_Char.Get_Pos().X + 35 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_common_Range + 35 && enemyRanges[i].Get_Pos().X >= Main_Char.Get_Pos().X - 35 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }

                        }
                        if (Main_Char.ATK_state == 2)
                        {
                            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyRanges[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;

                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyRanges[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyRanges[i].Get_Pos().X <= Main_Char.Get_Pos().X + 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 45 && enemyRanges[i].Get_Pos().X >= Main_Char.Get_Pos().X - 48 && enemyRanges[i].immune == false)
                                {
                                    enemyRanges[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyRanges[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyRanges[i].stunt = true;
                                    enemyRanges[i].immune = true;
                                    break;
                                }
                            }
                        }
                        if (Main_Char.ATK_state == 4)
                        {
                            if (enemyRanges[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 48 && enemyRanges[i].immune == false)
                            {
                                enemyRanges[i].Get_DMG(Main_Char.Roll_ATK);
                                enemyRanges[i].Get_Push(Main_Char.Roll_ATK_Push, Main_Char.Get_Pos());
                                Camera.CameraShake();
                                enemyRanges[i].stunt = true;
                                enemyRanges[i].immune = true;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < enemyBosses.Count; i++)
                {
                    if (enemyBosses[i].Alive == false)
                    {
                        graces.Add(new Grace(enemyBosses[i].Get_Pos()));
                        enemyBosses.Remove(enemyBosses[i]);
                        if(Quest.Quest_Code == 1 && i==0)
                        {
                            Quest.Quest_Done = true;
                        }
                        if (Quest.Quest_Code == 2 && i == 1)
                        {
                            Quest.Quest_Done = true;
                        }
                        if (Quest.Quest_Code == 3 && i == 2)
                        {
                            Quest.Quest_Done = true;
                        }
                        break;
                    }
                    enemyBosses[i].Update(new Vector2(Main_Char.Get_Pos().X, Main_Char.Get_Pos().Y));
                    enemyBosses[i].Last_Pos = enemyBosses[i].Get_Pos();
                    Collision(enemyBosses[i]);
                    //ENEMY Trans building vheck
                    for (int n = 0; n < Buidings.Length; n++)
                    {
                        if (Buidings[n].Layer == 3)
                        {
                            if (enemyBosses[i].Box.Intersects(Buidings[n].Box_Trans))
                            {
                                Buidings[n].Layer = 2;
                                Buidings[n].Trans = true;
                            }
                            else
                            {
                                Buidings[n].Layer = 3;
                            }
                        }
                    }
                    if (enemyBosses[i].Enemy_is_attack == true)
                    {
                        if (Main_Char.ATK_state != 3)
                        {
                            Main_Char.Get_Dmg(enemyBosses[i].Enemt_ATK_DMG);
                            feedback_time_start = true;
                            break;
                        }
                    }
                    if (enemyBosses[i].immune == false)
                    {
                        if (Main_Char.ATK_state == 1)
                        {
                            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 164 && enemyBosses[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 164 && enemyBosses[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 164 && enemyBosses[i].Get_Pos().X <= Main_Char.Get_Pos().X + 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_common_Range + 164 && enemyBosses[i].Get_Pos().X >= Main_Char.Get_Pos().X - 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Common_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Commom_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    Main_Char.Hitstreak_Plus();
                                    break;
                                }
                            }

                        }
                        if (Main_Char.ATK_state == 2)
                        {
                            if (Main_Char.Curt_state == 1 || Main_Char.Curt_state == 5)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 164 && enemyBosses[i].Get_Pos().Y <= Main_Char.Get_Pos().Y + 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;

                                }
                            }
                            if (Main_Char.Curt_state == 2 || Main_Char.Curt_state == 6)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 164 && enemyBosses[i].Get_Pos().Y >= Main_Char.Get_Pos().Y - 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 3 || Main_Char.Curt_state == 7)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 164 && enemyBosses[i].Get_Pos().X <= Main_Char.Get_Pos().X + 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                            if (Main_Char.Curt_state == 4 || Main_Char.Curt_state == 8)
                            {
                                if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Heavy_Range + 164 && enemyBosses[i].Get_Pos().X >= Main_Char.Get_Pos().X - 164 && enemyBosses[i].immune == false)
                                {
                                    enemyBosses[i].Get_DMG(Main_Char.Heavy_ATK);
                                    enemyBosses[i].Get_Push(Main_Char.Heavy_ATK_Push, Main_Char.Get_Pos());
                                    Camera.CameraShake();
                                    enemyBosses[i].stunt = true;
                                    enemyBosses[i].immune = true;
                                    break;
                                }
                            }
                        }
                        if (Main_Char.ATK_state == 4)
                        {
                            if (enemyBosses[i].Enemy_Distance <= Main_Char.ATK_Roll_Range + 164 && enemyBosses[i].immune == false)
                            {
                                enemyBosses[i].Get_DMG(Main_Char.Roll_ATK);
                                enemyBosses[i].Get_Push(Main_Char.Roll_ATK_Push, Main_Char.Get_Pos());
                                Camera.CameraShake();
                                enemyBosses[i].stunt = true;
                                enemyBosses[i].immune = true;
                                break;
                            }
                        }
                    }

                }
                //Player check trans building
                for (int i = 0; i < Buidings.Length; i++)
                {                   
                    if (Main_Char.Box.Intersects(Buidings[i].Box_Trans))
                    {
                        Buidings[i].Layer = 1;
                        Buidings[i].Trans = true;
                    }
                   
                }
                if (Time.Get_Time_Count() <= 0)
                {
                    Main_Char.Alive = false;
                }
            }
            if(Main_Char.Alive == false)
            {
                SceneEnd_time += (float)Global.gameTime.ElapsedGameTime.TotalSeconds;
                Quest.Quest_Done = false;
                if(SceneEnd_time >= 4)
                {
                    Extract_fail = true;
                    Main_Char.inventory.Graces.Clear();
                    Main_Char.inventory.Rune_Armor.Clear();
                    Main_Char.inventory.Rune_ATK.Clear();
                    Main_Char.inventory.Rune_Lives.Clear();
                    Main_Char.inventory.Rune_Times.Clear();
                }
            }            
                base.Update(gameTime);            
        }
        public override void Draw(GameTime gameTime)
        {
            Draw_Form_Pos_inWorld();
            Draw_UI();
            base.Draw(gameTime);
        }
            
        public override void Unload()
        {                               
            base.Unload();
        }
        public override void Debuging()
        {
            base.Debuging();
            
        }
        ///////////////////////////////////////////////////////////////////////// Main-method /////////////////////////////////////////////////////       
        public void lootingsystem()
        {
            Main_Char.inventory.Cal_Weight();
            for (int i = 0; i < graces.Count;i++)
            {
                if (graces[i].Get_Grace_Hitbox().Intersects(Main_Char.Get_Box()) && Keyboard.GetState().IsKeyDown(Keys.E) && Main_Char.inventory.carry_weight + Main_Char.inventory.weight_Grace.Get_Weight() <= Main_Char.inventory.Max_weight) 
                {
                    graces.Remove(graces[i]);
                    Main_Char.inventory.add_grace();
                    break;
                }
            }

        }
        private void Extractionsystem()
        {
            for (int i = 0; i < extract_Gate.Length; i++)
            {
                if (extract_Gate[i].Get_Box().Intersects(Main_Char.Get_Box()) && Keyboard.GetState().IsKeyDown(Keys.E) && extract_Gate[i].Extract_gate_enable==true)
                {
                    Extract_success = true;
                    if (Quest.Quest_Code != 0)
                    {
                        if (Quest.Quest_Done == true)
                        {
                            Quest.Quest_Completed = true;
                        }
                    }
                    break;
                }
            }
        }       
       
        private void Draw_Form_Pos_inWorld()
        {
            //Map0
            for(int i = 0; i < map.Extend.Length; i++)
            {
                Global.spriteBatch.Draw(map.Extend[i],Camera.Object_Vector(map.Extend_Pos[i]), Color.White);
            }
            //MAP
            for (int i = 0; i < map.Area_Texture.Length; i++)
            {
                if (Main_Char.Get_Pos().Y > map.Get_Map_Pos(i).Y - 1400 && Main_Char.Get_Pos().Y < map.Get_Map_Pos(i).Y + map.Get_Map_Texture(i).Height + 1400 && Main_Char.Get_Pos().X > map.Get_Map_Pos(i).X - 1400 && Main_Char.Get_Pos().X < map.Get_Map_Pos(i).X + map.Get_Map_Texture(i).Width + 1400)
                {
                    Global.spriteBatch.Draw(map.Get_Map_Texture(i), Camera.Object_Vector(map.Get_Map_Pos(i)), Color.White);
                    
                }
            }
            //EXTRACT GATE
            for(int i = 0; i < extract_Gate.Length; i++)
            {
                if (extract_Gate[i].Extract_gate_enable == true)
                {
                    Global.spriteBatch.Draw(extract_Gate[i].Get_Texture(), Camera.Object_Vector(extract_Gate[i].Get_Position()), Color.White);
                }
                if (extract_Gate[i].Extract_gate_enable == false)
                {
                    Global.spriteBatch.Draw(extract_Gate[i].Get_Texture(), Camera.Object_Vector(extract_Gate[i].Get_Position()), Color.DeepSkyBlue);
                }
            }
           
            //MAP SHADOW
            for (int i = 0; i < map.Area_Shadow.Length; i++)
            {
                if (Main_Char.Get_Pos().Y > map.Get_Map_Pos(i).Y - 1400 && Main_Char.Get_Pos().Y < map.Get_Map_Pos(i).Y + map.Get_Map_Texture(i).Height + 1400 && Main_Char.Get_Pos().X > map.Get_Map_Pos(i).X - 1400 && Main_Char.Get_Pos().X < map.Get_Map_Pos(i).X + map.Get_Map_Texture(i).Width + 1400)
                {
                    Global.spriteBatch.Draw(map.Get_Map_Shadow(i), Camera.Object_Vector(map.Get_Map_Pos(i)), Color.White);
                }
            }
            //Wallmaria
            for (int i = 0; i < 6; i++)
            {
                if (i == 0 || i == 1 || i == 5)
                {
                    Global.spriteBatch.Draw(map.Wallmaria[i], Camera.Object_Vector(map.Get_Map_Pos(15 + i)), Color.White);
                }
            }
            //BUILDING LAYER 3
            Global.spriteBatch.Draw(map.Landmark[0], Camera.Object_Vector(new Vector2(8000, 12608)), Color.White);
            Global.spriteBatch.Draw(map.Landmark[1], Camera.Object_Vector(new Vector2(8000, 12608)), Color.White);
            foreach (var buidling in Buidings)
            {
                if (buidling.Layer ==3)
                {
                    buidling.Show(Camera.Object_Vector(buidling.Get_Pos()));
                }
            }                    
            //TREES LAYER2

            //GRACE
            for (int i = 0; i < graces.Count; i++)
            {
                Global.spriteBatch.Draw(graces[i].Get_Grace_Texture(), Camera.Object_Vector(graces[i].Get_GracePosition()), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.5f);
            }

            //ENEMY
            for (int i = 0; i < enemyClose.Count; i++)
            {
                enemyClose[i].animate(Camera.Object_Vector(enemyClose[i].Get_Pos()));
                
            }            
            for(int i = 0;i<enemyBosses.Count;i++)
            {
                enemyBosses[i].animate(Camera.Object_Vector(enemyBosses[i].Get_Pos()));
            }
            for (int i = 0; i < enemyRanges.Count; i++)
            {
                enemyRanges[i].animate(Camera.Object_Vector(enemyRanges[i].Get_Pos()));
                if (enemyRanges[i].fire_ball.Count > 0)
                {
                    enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1].animate(Camera.Object_Vector(enemyRanges[i].fire_ball[enemyRanges[i].fire_ball.Count - 1].Return_Pos()));

                }
            }
            for(int i = 0; i < Main_Char.Get_FrameEffect().Count; i++)
            {
                Main_Char.Get_FrameEffect()[i].Animate(Camera.Object_Vector(Main_Char.Get_FrameEffect()[i].Get_Vector()));
            }

            //BUILDING LAYER 2
            foreach (var buidling in Buidings)
            {
                if (buidling.Layer == 2)
                {
                    buidling.Show(Camera.Object_Vector(buidling.Get_Pos()));
                }
            }

            //PLAYER
            Main_Char.animate(Camera.Object_Vector(Main_Char.Get_Pos()));

            //TREE GROUP2
            foreach (var tree in map.Trees2)
            {
                tree.Draw(Camera.Object_Vector(tree.Get_Pos()));
            }                            
            //BUILDING LAYER 1
            foreach (var buidling in Buidings)
            {
                if (buidling.Layer == 1)
                {
                    buidling.Show(Camera.Object_Vector(buidling.Get_Pos()));
                }
                buidling.Draw_Shadow(Camera.Object_Vector(buidling.Get_Pos()));
            }
            Global.spriteBatch.Draw(map.Landmark[2], Camera.Object_Vector(new Vector2(8025,12482)),Color.White);
            //Global.spriteBatch.Draw(map.Landmark[3], Camera.Object_Vector(new Vector2(8704,4159)), Color.White);
            //TREE GROUP2
            foreach (var tree in map.Trees2)
            {
                tree.Draw(Camera.Object_Vector(tree.Get_Pos()));
            }
            //WALL_MARIA
            for (int i = 0; i < 6; i++)
            {
                if (i == 2 || i == 3 || i == 4)
                {
                    Global.spriteBatch.Draw(map.Wallmaria[i], Camera.Object_Vector(map.Get_Map_Pos(15 + i)), Color.White);
                }
            }
            //TREES LAYER1
            foreach (var tree in map.Trees)
            {
                tree.Draw(Camera.Object_Vector(tree.Get_Pos()));
            }




        }
        double feedback_time = 0;
        bool feedback_time_start = false;
        private void Draw_UI()
        {         
            if(feedback_time_start == true)
            {
                feedback_time += (double)Global.gameTime.ElapsedGameTime.TotalSeconds;                
                Global.spriteBatch.Draw(Blood_Feedback, Vector2.Zero,null, Color.White*0.7f,0f,Vector2.Zero,1f,SpriteEffects.None,0.5f);
                if (feedback_time >= 0.5)
                {
                    feedback_time = 0;
                    feedback_time_start = false;
                }
            }
            Time.animate();           
            if(Quest.Quest_Code != 0)
            {
                if (Quest.Quest_Done == false)
                {
                    Global.spriteBatch.DrawString(Quest.Quest_Detail_font, Quest.Quest_Detail_string, new Vector2(1312, 64), Color.WhiteSmoke,0f,Vector2.Zero,1.5f,SpriteEffects.None,0.5f);
                }
                else if(Quest.Quest_Done == true) 
                {
                    Global.spriteBatch.DrawString(Quest.Quest_Detail_font, Quest.Quest_Detail_string, new Vector2(1312, 64), Color.WhiteSmoke * 0.4f,0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.5f);
                }
            }
            
                Global.spriteBatch.Draw(HP_BAR.HP_Bar, HP_BAR.HP_pos, null, Color.White, 0f, Vector2.Zero, new Vector2((float)Main_Char.HP / 30,1), SpriteEffects.None, 0.5f);                                      
                Global.spriteBatch.Draw(HP_BAR.Armmor_Bar, HP_BAR.Armmor_Pos, null, Color.LightBlue, 0f, Vector2.Zero, new Vector2(Main_Char.Armor /(Main_Char.inventory.Rune_Armor.Count*Rune_Armor.HP_plus), 1), SpriteEffects.None, 0.5f);
            
            Global.spriteBatch.Draw(HP_BAR.Texture, HP_BAR.Vector2, Color.White);
            
            int life = Main_Char.inventory.Rune_Lives.Count;
            
            Global.spriteBatch.DrawString(HP_BAR.Font,"ATK:"+(int)Main_Char.Common_ATK+"  AR:"+(int)Main_Char.Armor+"  Life:"+life,new Vector2(99,80),Color.Black);
            Hitstreak_bar.Hitstrak_Bar_Show(Main_Char.Hitsteak);
            Weight_UI.Show_UI(Main_Char.inventory.carry_weight,Main_Char.inventory.Max_weight);
        }
        public void Reset()
        {
            MediaPlayer.Stop();
             SceneEnd_time = 0;
            enemyClose.Clear();
            enemyRanges.Clear();
            enemyBosses.Clear();
            graces.Clear();
        }              
        private void Collision()
        {
            foreach (var buiding in Buidings)
            {
                if (Main_Char.Box.Intersects(buiding.Box_Colli))
                {
                    if (Main_Char.Get_Box().Top < buiding.Box_Colli.Bottom && Main_Char.Get_Box().Top > buiding.Box_Colli.Bottom - 7)
                    {
                        Main_Char.Set_Pos(new Vector2(Main_Char.Get_Pos().X, buiding.Box_Colli.Bottom + Global.Tile));
                    }
                    if (Main_Char.Get_Box().Bottom > buiding.Box_Colli.Top && Main_Char.Get_Box().Bottom < buiding.Box_Colli.Top + 7)
                    {
                        Main_Char.Set_Pos(new Vector2(Main_Char.Get_Pos().X, buiding.Box_Colli.Top - Global.Tile));
                    }
                    if (Main_Char.Get_Box().Right > buiding.Box_Colli.Left && Main_Char.Get_Box().Right < buiding.Box_Colli.Left + 7)
                    {
                        Main_Char.Set_Pos(new Vector2(buiding.Box_Colli.Left - Global.Tile / 2, Main_Char.Get_Pos().Y));
                    }
                    if (Main_Char.Get_Box().Left < buiding.Box_Colli.Right && Main_Char.Get_Box().Left > buiding.Box_Colli.Right - 7)
                    {
                        Main_Char.Set_Pos(new Vector2(buiding.Box_Colli.Right + Global.Tile / 2, Main_Char.Get_Pos().Y));
                    }
                }
            }
            foreach (var Mapbox in map.mapBox)
            {
                if (Main_Char.Box.Intersects(Mapbox))
                {
                    if (Main_Char.Get_Box().Top < Mapbox.Bottom && Main_Char.Get_Box().Top > Mapbox.Bottom - 7)
                    {
                        Main_Char.Set_Pos(new Vector2(Main_Char.Get_Pos().X, Mapbox.Bottom + Global.Tile));
                    }
                    if (Main_Char.Get_Box().Bottom > Mapbox.Top && Main_Char.Get_Box().Bottom < Mapbox.Top + 7)
                    {
                        Main_Char.Set_Pos(new Vector2(Main_Char.Get_Pos().X, Mapbox.Top - Global.Tile));
                    }
                    if (Main_Char.Get_Box().Right > Mapbox.Left && Main_Char.Get_Box().Right < Mapbox.Left + 7)
                    {
                        Main_Char.Set_Pos(new Vector2(Mapbox.Left - Global.Tile / 2, Main_Char.Get_Pos().Y));
                    }
                    if (Main_Char.Get_Box().Left < Mapbox.Right && Main_Char.Get_Box().Left > Mapbox.Right - 7)
                    {
                        Main_Char.Set_Pos(new Vector2(Mapbox.Right + Global.Tile / 2, Main_Char.Get_Pos().Y));
                    }
                }
            }

        }        
        private void Collision(EnemyClose enemy)
        {
            foreach (var buiding in Buidings)
            {
                if (enemy.Box.Intersects(buiding.Box_Colli))
                {
                    if (enemy.Box.Top < buiding.Box_Colli.Bottom && enemy.Box.Top > buiding.Box_Colli.Bottom - 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, buiding.Box_Colli.Bottom + enemy.Box.Height/2));
                    }
                    else if (enemy.Box.Bottom > buiding.Box_Colli.Top && enemy.Box.Bottom < buiding.Box_Colli.Top + 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, buiding.Box_Colli.Top - enemy.Box.Height / 2));
                    }
                    if (enemy.Box.Right > buiding.Box_Colli.Left && enemy.Get_Box().Right < buiding.Box_Colli.Left + 20)
                    {
                        enemy.Set_Pos(new Vector2(buiding.Box_Colli.Left - enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                    if (enemy.Get_Box().Left < buiding.Box_Colli.Right && enemy.Get_Box().Left > buiding.Box_Colli.Right - 20)
                    {
                        enemy.Set_Pos(new Vector2(buiding.Box_Colli.Right + enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }

                }
            }
            foreach (var Mapbox in map.mapBox)
            {
                if (enemy.Box.Intersects(Mapbox))
                {
                    if (enemy.Box.Top < Mapbox.Bottom && enemy.Box.Top > Mapbox.Bottom - 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, Mapbox.Bottom + enemy.Box.Height/2));
                    }
                    if (enemy.Box.Bottom > Mapbox.Top && enemy.Box.Bottom < Mapbox.Top + 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, Mapbox.Top - enemy.Box.Height/2));
                    }
                    if (enemy.Box.Right > Mapbox.Left && enemy.Get_Box().Right < Mapbox.Left + 20)
                    {
                        enemy.Set_Pos(new Vector2(Mapbox.Left - enemy.Box.Width/2, enemy.Get_Pos().Y));
                    }
                    if (enemy.Get_Box().Left < Mapbox.Right && enemy.Get_Box().Left > Mapbox.Right - 20)
                    {
                        enemy.Set_Pos(new Vector2(Mapbox.Right + enemy.Box.Width/2, enemy.Get_Pos().Y));
                    }
                }
            }
        }
        private void Collision(EnemyRange enemy)
        {
            foreach (var buiding in Buidings)
            {
                if (enemy.Box.Intersects(buiding.Box_Colli))
                {
                    if (enemy.Box.Top < buiding.Box_Colli.Bottom && enemy.Box.Top > buiding.Box_Colli.Bottom - 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, buiding.Box_Colli.Bottom + enemy.Box.Height / 2));
                    }
                    else if (enemy.Box.Bottom > buiding.Box_Colli.Top && enemy.Box.Bottom < buiding.Box_Colli.Top + 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, buiding.Box_Colli.Top - enemy.Box.Height / 2));
                    }
                    if (enemy.Box.Right > buiding.Box_Colli.Left && enemy.Get_Box().Right < buiding.Box_Colli.Left + 20)
                    {
                        enemy.Set_Pos(new Vector2(buiding.Box_Colli.Left - enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                    if (enemy.Get_Box().Left < buiding.Box_Colli.Right && enemy.Get_Box().Left > buiding.Box_Colli.Right - 20)
                    {
                        enemy.Set_Pos(new Vector2(buiding.Box_Colli.Right + enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                }
            }
            foreach (var Mapbox in map.mapBox)
            {
                if (enemy.Box.Intersects(Mapbox))
                {
                    if (enemy.Box.Top < Mapbox.Bottom && enemy.Box.Top > Mapbox.Bottom - 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, Mapbox.Bottom + enemy.Box.Height / 2));
                    }
                    if (enemy.Box.Bottom > Mapbox.Top && enemy.Box.Bottom < Mapbox.Top + 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, Mapbox.Top - enemy.Box.Height / 2));
                    }
                    if (enemy.Box.Right > Mapbox.Left && enemy.Get_Box().Right < Mapbox.Left + 20)
                    {
                        enemy.Set_Pos(new Vector2(Mapbox.Left - enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                    if (enemy.Get_Box().Left < Mapbox.Right && enemy.Get_Box().Left > Mapbox.Right - 20)
                    {
                        enemy.Set_Pos(new Vector2(Mapbox.Right + enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                }
            }

        }
        private void Collision(EnemyBoss enemy)
        {
            foreach (var buiding in Buidings)
            {
                if (enemy.Box.Intersects(buiding.Box_Colli))
                {
                    if (enemy.Box.Top < buiding.Box_Colli.Bottom && enemy.Box.Top > buiding.Box_Colli.Bottom - 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, buiding.Box_Colli.Bottom + enemy.Box.Height / 2));
                    }
                    else if (enemy.Box.Bottom > buiding.Box_Colli.Top && enemy.Box.Bottom < buiding.Box_Colli.Top + 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, buiding.Box_Colli.Top - enemy.Box.Height / 2));
                    }
                    if (enemy.Box.Right > buiding.Box_Colli.Left && enemy.Get_Box().Right < buiding.Box_Colli.Left + 20)
                    {
                        enemy.Set_Pos(new Vector2(buiding.Box_Colli.Left - enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                    if (enemy.Get_Box().Left < buiding.Box_Colli.Right && enemy.Get_Box().Left > buiding.Box_Colli.Right - 20)
                    {
                        enemy.Set_Pos(new Vector2(buiding.Box_Colli.Right + enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                }
            }
            foreach (var Mapbox in map.mapBox)
            {
                if (enemy.Box.Intersects(Mapbox))
                {
                    if (enemy.Box.Top < Mapbox.Bottom && enemy.Box.Top > Mapbox.Bottom - 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, Mapbox.Bottom + enemy.Box.Height / 2));
                    }
                    if (enemy.Box.Bottom > Mapbox.Top && enemy.Box.Bottom < Mapbox.Top + 20)
                    {
                        enemy.Set_Pos(new Vector2(enemy.Get_Pos().X, Mapbox.Top - enemy.Box.Height / 2));
                    }
                    if (enemy.Box.Right > Mapbox.Left && enemy.Get_Box().Right < Mapbox.Left + 20)
                    {
                        enemy.Set_Pos(new Vector2(Mapbox.Left - enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                    if (enemy.Get_Box().Left < Mapbox.Right && enemy.Get_Box().Left > Mapbox.Right - 20)
                    {
                        enemy.Set_Pos(new Vector2(Mapbox.Right + enemy.Box.Width / 2, enemy.Get_Pos().Y));
                    }
                }
            }

        }
    }
}
