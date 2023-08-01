using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.MainCharacter
{
    public class Main_Character_Animate:AnimatedTexture
    {
        public Main_Character_Animate(Vector2 Origin,float Rotation,float Scale,float Depth):base(Origin, Rotation, Scale, Depth)
        {
            base.Depth = Depth;
            base.Scale = Scale;
            base.Origin = Origin;
            base.Rotation = Rotation;
        }
    }
}
