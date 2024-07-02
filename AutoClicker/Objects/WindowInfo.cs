using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AutoClicker.Objects
{
    public class WindowInfo
    {
        public WindowInfo(Process process)
        {
            Process = process;
        }

        public Process Process { get; set; }

        public Rect GetBounds()
        {
            Rect bounds = new Rect();
            GetWindowRect(Process.MainWindowHandle, ref bounds);

            return bounds;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public override string ToString()
        {
            return Process.MainWindowTitle;
        }
    }
}
