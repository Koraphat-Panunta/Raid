using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Raid.MainCharacter;
using Raid.Screen_Code;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;

namespace Raid
{
    public class Camera
        
    {
        public Vector2 CameraPos;
        private Main_Character Char_animate;
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
            //Global.spriteBatch.Draw(World,Object_Vector(new Vector2(0,0)),Color.White);
            //for (int i = 0; i < Enviroment_Texture.Count; i++) 
            //{
            //    Global.spriteBatch.Draw(Enviroment_Texture[i], Enviroment_Pos[i], Color.White);
            //}
            //Char_animate.Animate(Object_Vector(Main_Char_Pos));
            Global.spriteBatch.Draw(World,Object_Vector(new Vector2(0, 0)), Color.White);
            //Global.spriteBatch.Draw(extract_Gate[0].Get_Texture(), Camera.Object_Vector(extract_Gate[0].Get_Position()), Color.White);
            //Global.spriteBatch.Draw(extract_Gate[1].Get_Texture(), Camera.Object_Vector(extract_Gate[1].Get_Position()), Color.White);
            //Global.spriteBatch.Draw(extract_Gate[2].Get_Texture(), Camera.Object_Vector(extract_Gate[2].Get_Position()), Color.White);
            //Global.spriteBatch.Draw(extract_Gate[3].Get_Texture(), Camera.Object_Vector(extract_Gate[3].Get_Position()), Color.White);
            //Global.spriteBatch.Draw(Grace[0].Get_Grace_Texture(), Camera.Object_Vector(Grace[0].Get_GracePosition()), Color.White);
            //Global.spriteBatch.Draw(Grace[1].Get_Grace_Texture(), Camera.Object_Vector(Grace[1].Get_GracePosition()), Color.White);
            //Global.spriteBatch.Draw(Grace[2].Get_Grace_Texture(), Camera.Object_Vector(Grace[2].Get_GracePosition()), Color.White);
            //Global.spriteBatch.Draw(Grace[3].Get_Grace_Texture(), Camera.Object_Vector(Grace[3].Get_GracePosition()), Color.White);
            //Main_Character.Animate(Camera.Object_Vector(Main_Character.Get_MainCharacterPos()));

        }
        public  Vector2 Object_Vector(Vector2 Object)
        {
            return new Vector2(Object.X + (960 - CameraPos.X), Object.Y + (540 -CameraPos.Y)); 
        }
    }
}
