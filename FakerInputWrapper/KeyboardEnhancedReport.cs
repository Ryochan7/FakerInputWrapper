using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerInputWrapper
{
    [Flags]
    public enum EnhancedKey : ushort
    {
        None,
        // Enhanced keys
        MyComputer = 1 << 0,
        Calculator = 1 << 1,
        WWWSearch = 1 << 2,
        WWWHome = 1 << 3,
        WWWBack = 1 << 4,
        WWWForward = 1 << 5,
        MediaSelect = 1 << 6,
        Mail = 1 << 7,

        // Multimedia keys
        ScanNextTrack = 1 << 8,
        ScanPreviousTrack = 1 << 9,
        Stop = 1 << 10,
        PlayPause = 1 << 11,
        Mute = 1 << 12,
        VolumeDown = 1 << 13,
        VolumeUp = 1 << 14,
        Eject = 1 << 15,
    }

    public class KeyboardEnhancedReport
    {
        private EnhancedKey enhancedKeys;
        //private MultimediaKey mediaKeys;

        public EnhancedKey EnhancedKeys { get => enhancedKeys; set => enhancedKeys = value; }
        public ushort EnhancedKeysUShort
        {
            get => (ushort)enhancedKeys; set => enhancedKeys = (EnhancedKey)value;
        }
        //public MultimediaKey MediaKeys { get => mediaKeys; set => mediaKeys = value; }

        public void KeyDown(EnhancedKey enhancedKey)
        {
            enhancedKeys |= enhancedKey;
        }

        public void KeyUp(EnhancedKey enhancedKey)
        {
            enhancedKeys &= ~enhancedKey;
        }

        //public void KeyDown(MultimediaKey multiKey)
        //{
        //    mediaKeys |= multiKey;
        //}

        //public void KeyUp(MultimediaKey multiKey)
        //{
        //    mediaKeys &= ~multiKey;
        //}

        public void Reset()
        {
            enhancedKeys = 0;
            //mediaKeys = 0;
        }
    }
}
