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

        public void AdjustWindow(int x, int y, int width, int height) //Todo: use
        {
            MoveWindow(Process.MainWindowHandle, x, y, width, height, true);
        }

        public override string ToString()
        {
            return Process.MainWindowTitle;
        }

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    }
}
