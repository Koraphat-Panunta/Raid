using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Raid.MainCharacter;
using System.Collections.Generic;

namespace Raid
{
    public class Camera
        
    {
        public Vector2 CameraPos;
        private Vector2 Main_Char_Pos;
        private Texture2D World;
        private List<Texture2D> Enviroment_Texture = new List<Texture2D>();
        private List<Vector2> Enviroment_Pos = new List<Vector2>();
        public Camera()
        {
           
        }
        public void Load()
        {
            
        }
        public  void CameraPos_Update(Vector2 Tracking_Object)
        {           
            CameraPos = Tracking_Object;           
        }
        public void Camera_Show()
        {                              
        }
        public  Vector2 Object_Vector(Vector2 Object)
        {
            return new Vector2(Object.X + (Global.GraphicsDevice.PreferredBackBufferWidth/2 - CameraPos.X), Object.Y + (Global.GraphicsDevice.PreferredBackBufferHeight/2 -CameraPos.Y)); 
        }
    }
}
