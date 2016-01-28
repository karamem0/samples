using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Karamem0.Samples
{

    public static class Win32
    {

        [DllImport("user32")]
        public static extern int GetWindowLong(IntPtr handle, int index);

        [DllImport("User32")]
        public static extern bool SetWindowLong(IntPtr handle, int index, int value);

        public enum GetWindowLongIndex
        {

            GWL_WNDPROC = -4,

            GWL_HINSTANCE = -6,

            GWL_HWNDPARENT = -8,

            GWL_ID = -12,

            GWL_STYLE = -16,

            GWL_EXSTYLE = -20,

            GWL_USERDATA = -21,

        }

        public enum HitTestResult
        {

            HTERROR = -2,

            HTTRANSPARENT = -1,

            HTNOWHERE = 0,

            HTCLIENT = 1,

            HTCAPTION = 2,

            HTSYSMENU = 3,

            HTSIZE = 4,

            HTGROWBOX = HTSIZE,

            HTMENU = 5,

            HTHSCROOL = 6,

            HTVSCROLL = 7,

            HTMINBUTTON = 8,

            HTREDUCE = HTMINBUTTON,

            HTMAXBUTTON = 9,

            HTZOOM = HTMAXBUTTON,

            HTLEFT = 10,

            HTRIGHT = 11,

            HTTOP = 12,

            HTTOPLEFT = 13,

            HTTOPRIGHT = 14,

            HTBOTTOM = 15,

            HTBOTTOMLEFT = 16,

            HTBOTTOMRIGHT = 17,

            HTBORDER = 18,

        }

        [Flags()]
        public enum WindowStyles
        {

            WS_OVERLAPPED = 0x00000000,

            WS_POPUP = unchecked((int)0x80000000),

            WS_CHILD = 0x40000000,

            WS_MINIMIZE = 0x20000000,

            WS_VISIBLE = 0x10000000,

            WS_DISABLED = 0x08000000,

            WS_CLIPSIBLINGS = 0x04000000,

            WS_CLIPCHILDREN = 0x02000000,

            WS_MAXIMIZE = 0x01000000,

            WS_BORDER = 0x00800000,

            WS_DLGFRAME = 0x00400000,

            WS_VSCROLL = 0x00200000,

            WS_HSCROLL = 0x00100000,

            WS_SYSMENU = 0x00080000,

            WS_THICKFRAME = 0x00040000,

            WS_GROUP = 0x00020000,

            WS_TABSTOP = 0x00010000,

            WS_MINIMIZEBOX = 0x00020000,

            WS_MAXIMIZEBOX = 0x00010000,

            WS_CAPTION = WS_BORDER | WS_DLGFRAME,

            WS_TILED = WS_OVERLAPPED,

            WS_ICONIC = WS_MINIMIZE,

            WS_SIZEBOX = WS_THICKFRAME,

            WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,

            WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,

            WS_CHILDWINDOW = WS_CHILD,

        }

        public enum ResizeMode
        {

            SIZE_RESTORED = 0,

            SIZE_MINIMIZED = 1,

            SIZE_MAXIMIZED = 2,

            SIZE_MAXSHOW = 3,

            SIZE_MAXHIDE = 4,

        }

        public enum WindowMessages
        {

            WM_NCHITTEST = 0x0084,

            WM_SIZE = 0x0005,

        }

    }

}
