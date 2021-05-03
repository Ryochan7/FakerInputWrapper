using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerInputWrapper
{
    [Flags]
    public enum MultimediaKey : byte
    {
        None,
        ScanNextTrack = 1 << 0,
        ScanPreviousTrack = 1 << 1,
        Stop = 1 << 2,
        PlayPause = 1 << 3,
        Mute = 1 << 4,
        VolumeDown = 1 << 5,
        VolumeUp = 1 << 6,
        WWWHome = 1 << 7,
    }

    [Flags]
    public enum EnhancedKey : byte
    {
        None,
        MyComputer = 1 << 0,
        Calculator = 1 << 1,
        WWWFav = 1 << 2,
        WWWSearch = 1 << 3,
        WWWStop = 1 << 4,
        WWWBack = 1 << 5,
        MediaSelect = 1 << 6,
        Mail = 1 << 7,
    }

    public class KeyboardEnhancedReport
    {
        private EnhancedKey enhancedKeys;
        private MultimediaKey mediaKeys;

        public EnhancedKey EnhancedKeys { get => enhancedKeys; set => enhancedKeys = value; }
        public MultimediaKey MediaKeys { get => mediaKeys; set => mediaKeys = value; }

        public void KeyDown(EnhancedKey enhancedKey)
        {
            enhancedKeys |= enhancedKey;
        }

        public void KeyUp(EnhancedKey enhancedKey)
        {
            enhancedKeys &= ~enhancedKey;
        }

        public void KeyDown(MultimediaKey multiKey)
        {
            mediaKeys |= multiKey;
        }

        public void KeyUp(MultimediaKey multiKey)
        {
            mediaKeys &= ~multiKey;
        }

        public void Reset()
        {
            enhancedKeys = 0;
            mediaKeys = 0;
        }
    }
}
