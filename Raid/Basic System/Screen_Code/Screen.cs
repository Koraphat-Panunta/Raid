﻿using Microsoft.Xna.Framework;
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
        //public string Curt_Scene;
        protected string Gameplay = "Gameplay";
        protected string Menu = "Menu";        
        
        public Screen() { }
        public virtual void load(Main_Character main_Character,Vector2 Pos)
        {            
            //Curt_Scene = Menu;                       
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
            
        }
        
    }
}
