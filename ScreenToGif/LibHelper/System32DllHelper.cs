using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ScreenToGif.LibHelper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CursorInfo
    {
        public Int32 cbSize;
        public Int32 flags;
        public IntPtr hCursor;
        public Point ptScreenPos;
    }

    public enum DeviceCap
    {
        HORZRES = 8,
        VERTRES = 10,
        LOGPIXELSX = 88,
        LOGPIXELSY = 90,
        PHYSICALWIDTH = 110,
        SCALINGFACTORX = 114,
        DESKTOPVERTRES = 117,
        DESKTOPHORZRES = 118
    }

    public class System32DllHelper
    {
        [DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps", SetLastError = true)]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        private const Int32 CURSOR_SHOWING = 0x00000001;
        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out CursorInfo cursorInfo);
    }
}
