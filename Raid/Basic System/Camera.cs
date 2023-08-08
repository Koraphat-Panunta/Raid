using Microsoft.Xna.Framework;
using SharpDX.Direct2D1.Effects;

namespace Raid
{
    public class Camera
        
    {
        public Vector2 CameraPos;
        private Vector2 CameraPos_before;
        private Vector2 Deployed;
        public Camera()
        { 
        }
        public void track_Object(Vector2 Tracking_Object,Vector2 Deployed)
        {            
            CameraPos_before = Tracking_Object;
            this.Deployed = Deployed;
        }
        public  void CameraPos_Update(Vector2 Tracking_Object)
        {           
            CameraPos = Tracking_Object;            
        }
        public  Vector2 Object_Vector(Vector2 Object)
        {
            return new Vector2(Object.X + (960 - Deployed.X)-(CameraPos.X-CameraPos_before.X), Object.Y + (540 - Deployed.Y)-(CameraPos.Y-CameraPos_before.Y)); 
        }
    }
}
