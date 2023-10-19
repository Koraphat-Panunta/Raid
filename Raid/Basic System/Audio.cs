using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid.Basic_System
{
    public static class Audio
    {
        public static List<SoundEffect> soundEffects = new List<SoundEffect>();
        public static Song Wind_ambient;
        public static bool SoundEffect_6 = false;
        //0:woosh
        //1:Swing
        public static List<SoundEffect> BG = new List<SoundEffect>();
        public static void Audio_Load()
        {
            soundEffects.Add(Global.Content.Load<SoundEffect>("Sword woosh"));//0
            soundEffects.Add(Global.Content.Load<SoundEffect>("Sword Swing"));//1
            soundEffects.Add(Global.Content.Load<SoundEffect>("Sword Hit Enemy1"));//2
            soundEffects.Add(Global.Content.Load<SoundEffect>("Sword Hit Enemy2"));//3
            soundEffects.Add(Global.Content.Load<SoundEffect>("Sword Hit Enemy3"));//4
            soundEffects.Add(Global.Content.Load<SoundEffect>("Feed back effect"));//5
            soundEffects.Add(Global.Content.Load<SoundEffect>("footsteps"));//6
            soundEffects.Add(Global.Content.Load<SoundEffect>("Dash"));//7

            Wind_ambient = Global.Content.Load<Song>("Wind-BGM");
        }
    }
}
