using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace AutoClicker.Helpers
{
    public static class MouseLocationHelper
    {
        public static Action<Point> LocationChangeCallback;

        public static void Init()
        {
            Hook.GlobalEvents().MouseClick += MouseLocationHelper_MouseClick;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator Point(POINT p)
            {
                return new Point(p.X, p.Y);
            }

            public static implicit operator POINT(Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        private static void MouseLocationHelper_MouseClick(object sender, MouseEventArgs e)
        {
            if (GetCursorPos(out POINT p))
            {
                LocationChangeCallback?.Invoke(new Point(p.X, p.Y));
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);
    }
}
