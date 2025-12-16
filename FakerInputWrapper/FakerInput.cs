using System;
using System.Runtime.InteropServices;
using System.Security;

namespace FakerInputWrapper
{
    using PFAKERINPUT_HANDLE = IntPtr;

    [SuppressUnmanagedCodeSecurity]
    public class FakerInput
    {
        [DllImport("FakerInputDll.dll")]
        public static extern IntPtr fakerinput_alloc();

        [DllImport("FakerInputDll.dll")]
        public static extern void fakerinput_free(PFAKERINPUT_HANDLE vmulti);

        [DllImport("FakerInputDll.dll")]
        public static extern bool fakerinput_connect(PFAKERINPUT_HANDLE vmulti);

        [DllImport("FakerInputDll.dll")]
        public static extern void fakerinput_disconnect(PFAKERINPUT_HANDLE vmulti);

        [DllImport("FakerInputDll.dll")]
        public static extern UInt32 fakerinput_versionAPINumber(PFAKERINPUT_HANDLE vmulti);

        [DllImport("FakerInputDll.dll")]
        public static extern UInt32 fakerinput_driverVersionNumber(PFAKERINPUT_HANDLE vmulti);

        [DllImport("FakerInputDll.dll")]
        public static extern bool fakerinput_update_keyboard(PFAKERINPUT_HANDLE vmulti, byte shiftKeyFlags, byte[] keyCodes);

        [DllImport("FakerInputDll.dll")]
        public static extern bool fakerinput_update_keyboard_enhanced(PFAKERINPUT_HANDLE vmulti, byte mediaKeys, byte enhancedKeys);

        [DllImport("FakerInputDll.dll")]
        public static extern bool fakerinput_update_relative_mouse(PFAKERINPUT_HANDLE clientHandle, byte button,
            short x, short y, byte wheelPosition, byte hWheelPosition);

        [DllImport("FakerInputDll.dll")]
        public static extern bool fakerinput_update_absolute_mouse(PFAKERINPUT_HANDLE clientHandle, byte button, ushort x, ushort y,
            byte wheelPosition, byte hWheelPosition);


        private PFAKERINPUT_HANDLE deviceHandle;
        private bool connected;

        public FakerInput()
        {
            deviceHandle = fakerinput_alloc();
        }

        public bool IsConnected()
        {
            return connected;
        }

        public bool Connect()
        {
            this.connected = fakerinput_connect(deviceHandle);
            return this.connected;
        }

        public void Disconnect()
        {
            if (connected)
            {
                fakerinput_disconnect(deviceHandle);
            }
        }

        public void Free()
        {
            if (deviceHandle != PFAKERINPUT_HANDLE.Zero)
            {
                fakerinput_free(deviceHandle);
                deviceHandle = PFAKERINPUT_HANDLE.Zero;
            }
        }

        public bool UpdateKeyboard(KeyboardReport report)
        {
            if (connected)
            {
                return fakerinput_update_keyboard(deviceHandle,
                    report.GetRawShiftKeyFlags(), report.GetRawKeyCodes());
            }
            else
            {
                return false;
            }
        }

        public bool UpdateKeyboardEnhanced(KeyboardEnhancedReport report)
        {
            if (connected)
            {
                //return fakerinput_update_keyboard_enhanced(deviceHandle,
                //    (byte)report.MediaKeys, (byte)report.EnhancedKeys);
                return fakerinput_update_keyboard_enhanced(deviceHandle,
                    (byte)(report.EnhancedKeysUInt >> 8),
                    (byte)report.EnhancedKeys);
            }
            else
            {
                return false;
            }
        }

        public bool UpdateRelativeMouse(RelativeMouseReport report)
        {
            if (connected)
            {
                return fakerinput_update_relative_mouse(deviceHandle, (byte)report.Buttons,
                    report.MouseX, report.MouseY, report.WheelPosition, report.HWheelPosition);
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAbsoluteMouse(AbsoluteMouseReport report)
        {
            if (connected)
            {
                return fakerinput_update_absolute_mouse(deviceHandle, (byte)report.Buttons,
                    report.MouseX, report.MouseY, report.WheelPosition, report.HWheelPosition);
            }
            else
            {
                return false;
            }
        }

        public UInt32 GetAPIVersion()
        {
            UInt32 result = 0;
            result = fakerinput_versionAPINumber(deviceHandle);
            return result;
        }

        public UInt32 GetDriverVersion()
        {
            UInt32 result = 0;
            result = fakerinput_driverVersionNumber(deviceHandle);
            return result;
        }
    }
}
