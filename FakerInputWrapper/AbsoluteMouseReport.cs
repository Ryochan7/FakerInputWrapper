using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerInputWrapper
{
    public class AbsoluteMouseReport
    {
        private MouseButton buttons;
        public MouseButton Buttons => buttons;
        private HashSet<MouseButton> heldButtons = new HashSet<MouseButton>();
        public HashSet<MouseButton> HeldButtons => heldButtons;

        private ushort mouseX;
        private ushort mouseY;
        public ushort MouseX { get => mouseX; set => mouseX = value; }
        public ushort MouseY { get => mouseY; set => mouseY = value; }

        private byte wheelPosition;
        public byte WheelPosition
        {
            get => wheelPosition;
            set => wheelPosition = value;
        }

        private byte hWheelPosition;
        public byte HWheelPosition
        {
            get => hWheelPosition;
            set => hWheelPosition = value;
        }

        public void ResetMousePos()
        {
            mouseX = mouseY = 0;
            wheelPosition = 0;
            hWheelPosition = 0;
        }

        public void Reset()
        {
            ResetMousePos();
            buttons = 0;
            heldButtons.Clear();
        }

        public void ButtonDown(MouseButton button)
        {
            buttons |= button;
            heldButtons.Add(button);
        }

        public void ButtonUp(MouseButton button)
        {
            buttons &= ~button;
            heldButtons.Remove(button);
        }
    }
}
