using Microsoft.Xna.Framework;

namespace Raid
{
    public static class Camera
        
    {
        public static Vector2 CameraPos;        
        public static void CameraPos_Update(Vector2 Tracking_Object)
        {
            CameraPos = Tracking_Object;
        }
        public static Vector2 Object_Vector(Vector2 Object)
        {
            return new Vector2(Object.X-CameraPos.X, Object.Y-CameraPos.Y);
        }
    }
}
