using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AutoClicker.Helpers;

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

        public ImpreciseLocation Location { get; set; }

        public void PerformAction()
        {
            Point adjustedClickLocation;
            if (Location.CoordinateSystem == CoordinateSystem.Absolute)
            {
                adjustedClickLocation = new Point(Location.X + Rand.Int(-Location.Variance.X, Location.Variance.X), Location.Y + Rand.Int(-Location.Variance.Y, Location.Variance.Y));
            }
            else
            {
                adjustedClickLocation = new Point(Cursor.Position.X + Location.X + Rand.Int(-Location.Variance.X, Location.Variance.X), Cursor.Position.Y + Location.Y + Rand.Int(-Location.Variance.Y, Location.Variance.Y));
            }

            if (Cursor.Position != adjustedClickLocation)
            {
                MouseMoveEvent.MoveMouse(Cursor.Position.X, Cursor.Position.Y, adjustedClickLocation.X, adjustedClickLocation.Y);
            }

            switch(MouseButton)
            {
                case MouseButton.Left:
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Location.X, (uint)Location.Y, 0, 0);
                    break;
                case MouseButton.Middle:
                    mouse_event(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP, (uint)Location.X, (uint)Location.Y, 0, 0);
                    break;
                case MouseButton.Right:
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)Location.X, (uint)Location.Y, 0, 0);
                    break;
            }
        }

        public override string ToString()
        {
            return $"[Click] MouseButton: {MouseButton}; Location: ({Location.X}±{Location.Variance.X}, {Location.Y}±{Location.Variance.Y})";
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
