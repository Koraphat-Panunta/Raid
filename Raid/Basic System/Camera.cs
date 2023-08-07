using Microsoft.Xna.Framework;
using SharpDX.Direct2D1.Effects;

namespace Raid
{
    public class Camera
        
    {
        public Vector2 CameraPos;
        public Vector2 MainCharPos;
        private Vector2 CameraPos_before;
        public Camera()
        { 
        }
        public void track_Object(Vector2 Tracking_Object)
        {
            
            CameraPos_before = Tracking_Object;
        }
        public  void CameraPos_Update(Vector2 Tracking_Object)
        {           
            CameraPos = Tracking_Object;            
        }
        public  Vector2 Object_Vector(Vector2 Object)
        {
            return new Vector2(Object.X-CameraPos.X+CameraPos_before.X, Object.Y-CameraPos.Y+CameraPos_before.Y);
        }
    }
}
