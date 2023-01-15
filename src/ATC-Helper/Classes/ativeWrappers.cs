using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;

namespace ATC_Helper.Classes
{ 
    /// <summary>
    /// <description>
    ///  Have the definitions for all the InteropServices.
    /// </description>
    /// </summary>
    class NativeWrappers
    {
        #region Constants
        #endregion

        #region Variables
        //public static uint ReloadMessage;
        //public static uint AppLoginMessage;
        //public static uint ActiveLoginMessage;
        #endregion

        #region Delegates
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
        #endregion

        #region Enumerations

        public enum ChangeWindowMessageFilterExAction : uint
        {
            Reset = 0, Allow = 1, DisAllow = 2
        };

        public enum MessageFilterInfo : uint
        {
            None = 0, AlreadyAllowed = 1, AlreadyDisAllowed = 2, AllowedHigher = 3
        };

        #endregion

        #region Structures

        [StructLayout(LayoutKind.Sequential)]
        public struct CHANGEFILTERSTRUCT
        {
            public uint size;
            public MessageFilterInfo info;
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
            public POINT(Point pt)
            {
                X = Convert.ToInt32(pt.X);
                Y = Convert.ToInt32(pt.Y);
            }
        };

        #endregion

        #region PInvokes

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr ChangeWindowMessageFilterEx(uint message, uint dwFlag);

        [DllImport("user32")]
        public static extern bool ChangeWindowMessageFilterEx(IntPtr hWnd, uint msg, ChangeWindowMessageFilterExAction action, ref CHANGEFILTERSTRUCT changeInfo);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrl, string lpszCookieName, string lpszCookieData);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern uint RegisterWindowMessage(string msg);

        //[DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
        //public static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

        //[DllImport("User32.dll", CharSet = CharSet.Auto)]
        //private static extern int RegisterWindowMessage(string msg);

        /// Hook related stuff

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetAncestor(IntPtr hWnd, int flags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, int wFlag);

        //[DllImport("user32.dll")]
        //public static extern int GetWindowText(IntPtr hWnd, StringBuilder title, int size);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        //public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern uint RealGetWindowClass(IntPtr hWnd, StringBuilder pszType, uint cchType);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("user32.dll")]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// End Hook related stuff
        #endregion

        #region Methods
        /*
        public static DSSO_RET EnableUIPI(IntPtr hWnd)
        {
            ReloadMessage = RegisterWindowMessage("OneClick-Reload User Profile-IEToolbar");
            AppLoginMessage = RegisterWindowMessage("OneClick-Login User Application-IEToolbar");
            ActiveLoginMessage = RegisterWindowMessage("OneClick-Login Active Application-IEToolbar");

            if (ReloadMessage == 0 || AppLoginMessage == 0 || ActiveLoginMessage == 0)
            {
                // TODO - deal with the logging stuff
                // Close();
            }
            else
            {
                CHANGEFILTERSTRUCT filterStatus = new CHANGEFILTERSTRUCT();
                filterStatus.size = (uint)Marshal.SizeOf(filterStatus);
                filterStatus.info = MessageFilterInfo.None;
                if (!ChangeWindowMessageFilterEx(hWnd, ReloadMessage, ChangeWindowMessageFilterExAction.Allow, ref filterStatus))
                {
                    // TODO - deal with the logging stuff
                    // Close();
                }
                if (!ChangeWindowMessageFilterEx(hWnd, AppLoginMessage, ChangeWindowMessageFilterExAction.Allow, ref filterStatus))
                {
                    // TODO - deal with the logging stuff
                    // Close();
                }
                if (!ChangeWindowMessageFilterEx(hWnd, ActiveLoginMessage, ChangeWindowMessageFilterExAction.Allow, ref filterStatus))
                {
                    // TODO - deal with the logging stuff
                    // Close();
                }
            }

            return DSSO_RET.DSSO_SUCCESS;
        }
         */

        #endregion
    }
}
