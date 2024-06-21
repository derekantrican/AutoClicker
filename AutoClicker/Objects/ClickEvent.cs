using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClicker.Objects
{
    public enum MouseButton
    {
        Left,
        Middle,
        Right,
    }

    public class ClickEvent : IBaseEvent
    {
        public MouseButton MouseButton { get; set; }

        public Point ClickLocation { get; set; }

        public void PerformAction()
        {
            if (Cursor.Position != ClickLocation)
            {
                MouseMoveEvent.MoveMouse(Cursor.Position.X, Cursor.Position.Y, ClickLocation.X, ClickLocation.Y);
            }

            switch(MouseButton)
            {
                case MouseButton.Left:
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)ClickLocation.X, (uint)ClickLocation.Y, 0, 0);
                    break;
                case MouseButton.Middle:
                    mouse_event(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP, (uint)ClickLocation.X, (uint)ClickLocation.Y, 0, 0);
                    break;
                case MouseButton.Right:
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)ClickLocation.X, (uint)ClickLocation.Y, 0, 0);
                    break;
            }
        }

        public override string ToString()
        {
            return $"[Click] MouseButton: {MouseButton}; Location: {ClickLocation}";
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        private const int MOUSEEVENTF_MIDDLEUP = 0x40;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
    }
}
