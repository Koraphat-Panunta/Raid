using Microsoft.Xna.Framework;
using Raid.MainCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Screen_Code
{
    public class Screen
    {
        public Main_Character Main_Character = new Main_Character();
        public string Curt_Scene;
        protected string Gameplay = "Gameplay";
        protected string Menu = "Menu";
        public bool Extract;
        
        public Screen() { }
        public virtual void load()
        {            
            Curt_Scene = Menu;
            Extract = false;
            
        }
        public virtual void Update(GameTime gameTime)
        {
            
        }
        public virtual void Draw(GameTime gameTime)
        {
        }
        
        public virtual void Unload()
        {
        }
        public virtual void Debuging()
        {
            Console.WriteLine("mother scene ={0}", Main_Character.inventory.Grace.Num);
        }
        protected void add_item()
        {
            Main_Character.inventory.Grace.Num += 1;
            Main_Character.inventory.Grace.disapear(0);
        }

    }
}
