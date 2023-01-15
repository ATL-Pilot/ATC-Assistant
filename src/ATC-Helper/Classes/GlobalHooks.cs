#region Directives

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace ATC_Helper.Classes
{
    /// <summary>
    /// <description>
    /// This is the base class for global hooks, 
    /// which provides CBT and SHELL hooks
    /// and also processes windows messages
    /// </description>
    /// </summary>
    internal class GlobalHooks
    {
        #region Delegates

        public delegate void ActivateShellWindowEventHandler();

        public delegate void BasicHookEventHandler(IntPtr Handle1, IntPtr Handle2);

        public delegate void HookReplacedEventHandler();

        public delegate void SysCommandEventHandler(int SysCommand, int lParam);

        public delegate void TaskmanEventHandler();

        public delegate void WindowEventHandler(IntPtr Handle);

        public delegate void WndProcEventHandler(IntPtr Handle, IntPtr Message, IntPtr wParam, IntPtr lParam);

        #endregion

        #region GlobalCbtHook.dll Imports

        // Functions imported from our unmanaged DLL
        [DllImport("GlobalCbtHook.dll")]
        private static extern bool InitializeCbtHook(int threadID, IntPtr DestWindow);

        [DllImport("GlobalCbtHook.dll")]
        private static extern void UninitializeCbtHook();

        [DllImport("GlobalCbtHook.dll")]
        private static extern bool InitializeShellHook(int threadID, IntPtr DestWindow);

        [DllImport("GlobalCbtHook.dll")]
        private static extern void UninitializeShellHook();

        [DllImport("GlobalCbtHook.dll")]
        private static extern void InitializeCallWndProcHook(int threadID, IntPtr DestWindow);

        [DllImport("GlobalCbtHook.dll")]
        private static extern void UninitializeCallWndProcHook();

        [DllImport("GlobalCbtHook.dll")]
        private static extern void InitializeGetMsgHook(int threadID, IntPtr DestWindow);

        [DllImport("GlobalCbtHook.dll")]
        private static extern void UninitializeGetMsgHook();

        #endregion

        #region User32.dll Imports

        // API call needed to retreive the value of the messages to intercept from the unmanaged DLL
        //[DllImport("user32.dll")]
        //private static extern int RegisterWindowMessage(string lpString);

        //[DllImport("user32.dll")]
        //private static extern IntPtr GetProp(IntPtr hWnd, string lpString);

        //[DllImport("user32.dll")]
        //private static extern IntPtr GetDesktopWindow();

        #endregion

        #region Members

        // Handle of the window intercepting messages

        private readonly CBTHook _CBT;
        private readonly CallWndProcHook _CallWndProc;
        private readonly GetMsgHook _GetMsg;
        private readonly IntPtr _Handle;
        private ShellHook _Shell;

        #endregion

        #region Constructor

        public GlobalHooks(IntPtr Handle)
        {
            _Handle = Handle;

            _CBT = new CBTHook(_Handle);
            //_Shell = new ShellHook(_Handle);
            _CallWndProc = new CallWndProcHook(_Handle);
            _GetMsg = new GetMsgHook(_Handle);
        }

        #endregion

        #region Destructor

        ~GlobalHooks()
        {
            _CBT.Stop();
            //_Shell.Stop();
            _CallWndProc.Stop();
            _GetMsg.Stop();
        }

        #endregion

        public void ProcessWindowMessage(ref Message m)
        {
            _CBT.ProcessWindowMessage(ref m);
            //_Shell.ProcessWindowMessage(ref m);
            _CallWndProc.ProcessWindowMessage(ref m);
            _GetMsg.ProcessWindowMessage(ref m);
        }

        #region Accessors

        public CBTHook CBT
        {
            get { return _CBT; }
        }

        public ShellHook Shell
        {
            get { return _Shell; }
        }

        public CallWndProcHook CallWndProc
        {
            get { return _CallWndProc; }
        }

        public GetMsgHook GetMsg
        {
            get { return _GetMsg; }
        }

        #endregion

        #region Hook Class

        public abstract class Hook
        {
            protected IntPtr _Handle;
            protected bool _IsActive;

            public Hook(IntPtr Handle)
            {
                _Handle = Handle;
            }

            public bool IsActive
            {
                get { return _IsActive; }
            }

            public void Start()
            {
                if (!_IsActive)
                {
                    _IsActive = true;
                    OnStart();
                }
            }

            public void Stop()
            {
                if (_IsActive)
                {
                    OnStop();
                    _IsActive = false;
                }
            }

            ~Hook()
            {
                Stop();
            }

            protected abstract void OnStart();
            protected abstract void OnStop();
            public abstract void ProcessWindowMessage(ref Message m);
        }

        #endregion

        #region CBTHook Class

        public class CBTHook : Hook
        {
            // Values retreived with RegisterWindowMessage
            private int _MsgID_CBT_Activate;
            private int _MsgID_CBT_CreateWnd;
            private int _MsgID_CBT_DestroyWnd;
            private int _MsgID_CBT_HookReplaced;
            private int _MsgID_CBT_MinMax;
            private int _MsgID_CBT_MoveSize;
            private int _MsgID_CBT_SetFocus;
            private int _MsgID_CBT_SysCommand;

            public CBTHook(IntPtr Handle) : base(Handle)
            {
            }

            public event HookReplacedEventHandler HookReplaced;
            public event WindowEventHandler Activate;
            public event WindowEventHandler CreateWindow;
            public event WindowEventHandler DestroyWindow;
            public event WindowEventHandler MinMax;
            public event WindowEventHandler MoveSize;
            public event WindowEventHandler SetFocus;
            public event SysCommandEventHandler SysCommand;

            protected override void OnStart()
            {
                // Retreive the message IDs that we'll look for in WndProc
                _MsgID_CBT_HookReplaced = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_CBT_REPLACED");
                _MsgID_CBT_Activate = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HCBT_ACTIVATE");
                _MsgID_CBT_CreateWnd = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HCBT_CREATEWND");
                _MsgID_CBT_DestroyWnd = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HCBT_DESTROYWND");
                _MsgID_CBT_MinMax = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HCBT_MINMAX");
                _MsgID_CBT_MoveSize = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HCBT_MOVESIZE");
                _MsgID_CBT_SetFocus = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HCBT_SETFOCUS");
                _MsgID_CBT_SysCommand = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HCBT_SYSCOMMAND");

                // Start the hook
                InitializeCbtHook(0, _Handle);
            }

            protected override void OnStop()
            {
                UninitializeCbtHook();
            }

            public override void ProcessWindowMessage(ref Message m)
            {
                if (m.Msg == _MsgID_CBT_HookReplaced)
                {
                    if (HookReplaced != null)
                        HookReplaced();
                }
                else if (m.Msg == _MsgID_CBT_Activate)
                {
                    if (Activate != null)
                        Activate(m.WParam);
                }
                else if (m.Msg == _MsgID_CBT_CreateWnd)
                {
                    if (CreateWindow != null)
                        CreateWindow(m.WParam);
                }
                else if (m.Msg == _MsgID_CBT_DestroyWnd)
                {
                    if (DestroyWindow != null)
                        DestroyWindow(m.WParam);
                }
                else if (m.Msg == _MsgID_CBT_MinMax)
                {
                    if (MinMax != null)
                        MinMax(m.WParam);
                }
                else if (m.Msg == _MsgID_CBT_MoveSize)
                {
                    if (MoveSize != null)
                        MoveSize(m.WParam);
                }
                else if (m.Msg == _MsgID_CBT_SetFocus)
                {
                    if (SetFocus != null)
                        SetFocus(m.WParam);
                }
                else if (m.Msg == _MsgID_CBT_SysCommand)
                {
                    if (SysCommand != null)
                        SysCommand(m.WParam.ToInt32(), m.LParam.ToInt32());
                }
            }
        }

        #endregion

        #region ShellHook Class

        public class ShellHook : Hook
        {
            // Values retreived with RegisterWindowMessage
            private int _MsgID_Shell_ActivateShellWindow;
            private int _MsgID_Shell_GetMinRect;
            private int _MsgID_Shell_HookReplaced;
            private int _MsgID_Shell_Language;
            private int _MsgID_Shell_Redraw;
            private int _MsgID_Shell_Taskman;
            private int _MsgID_Shell_WindowActivated;
            private int _MsgID_Shell_WindowCreated;
            private int _MsgID_Shell_WindowDestroyed;

            public ShellHook(IntPtr Handle) : base(Handle)
            {
            }

            public event HookReplacedEventHandler HookReplaced;
            public event ActivateShellWindowEventHandler ActivateShellWindow;
            public event WindowEventHandler GetMinRect;
            public event WindowEventHandler Language;
            public event WindowEventHandler Redraw;
            public event TaskmanEventHandler Taskman;
            public event WindowEventHandler WindowActivated;
            public event WindowEventHandler WindowCreated;
            public event WindowEventHandler WindowDestroyed;

            protected override void OnStart()
            {
                // Retreive the message IDs that we'll look for in WndProc
                _MsgID_Shell_HookReplaced = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_SHELL_REPLACED");
                _MsgID_Shell_ActivateShellWindow = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HSHELL_ACTIVATESHELLWINDOW");
                _MsgID_Shell_GetMinRect = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HSHELL_GETMINRECT");
                _MsgID_Shell_Language = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HSHELL_LANGUAGE");
                _MsgID_Shell_Redraw = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HSHELL_REDRAW");
                _MsgID_Shell_Taskman = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HSHELL_TASKMAN");
                _MsgID_Shell_WindowActivated = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HSHELL_WINDOWACTIVATED");
                _MsgID_Shell_WindowCreated = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HSHELL_WINDOWCREATED");
                _MsgID_Shell_WindowDestroyed = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_HSHELL_WINDOWDESTROYED");

                // Start the hook
                InitializeShellHook(0, _Handle);
            }

            protected override void OnStop()
            {
                UninitializeShellHook();
            }

            public override void ProcessWindowMessage(ref Message m)
            {
                if (m.Msg == _MsgID_Shell_HookReplaced)
                {
                    if (HookReplaced != null)
                        HookReplaced();
                }
                else if (m.Msg == _MsgID_Shell_ActivateShellWindow)
                {
                    if (ActivateShellWindow != null)
                        ActivateShellWindow();
                }
                else if (m.Msg == _MsgID_Shell_GetMinRect)
                {
                    if (GetMinRect != null)
                        GetMinRect(m.WParam);
                }
                else if (m.Msg == _MsgID_Shell_Language)
                {
                    if (Language != null)
                        Language(m.WParam);
                }
                else if (m.Msg == _MsgID_Shell_Redraw)
                {
                    if (Redraw != null)
                        Redraw(m.WParam);
                }
                else if (m.Msg == _MsgID_Shell_Taskman)
                {
                    if (Taskman != null)
                        Taskman();
                }
                else if (m.Msg == _MsgID_Shell_WindowActivated)
                {
                    if (WindowActivated != null)
                        WindowActivated(m.WParam);
                }
                else if (m.Msg == _MsgID_Shell_WindowCreated)
                {
                    if (WindowCreated != null)
                        WindowCreated(m.WParam);
                }
                else if (m.Msg == _MsgID_Shell_WindowDestroyed)
                {
                    if (WindowDestroyed != null)
                        WindowDestroyed(m.WParam);
                }
            }
        }

        #endregion

        #region CallWndProcHook Class

        public class CallWndProcHook : Hook
        {
            // Values retreived with RegisterWindowMessage
            private IntPtr _CacheHandle;
            private IntPtr _CacheMessage;
            private int _MsgID_CallWndProc;
            private int _MsgID_CallWndProc_HookReplaced;
            private int _MsgID_CallWndProc_Params;

            public CallWndProcHook(IntPtr Handle) : base(Handle)
            {
            }

            public event HookReplacedEventHandler HookReplaced;
            public event WndProcEventHandler CallWndProc;

            protected override void OnStart()
            {
                // Retreive the message IDs that we'll look for in WndProc
                _MsgID_CallWndProc_HookReplaced = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_CALLWNDPROC_REPLACED");
                _MsgID_CallWndProc = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_CALLWNDPROC");
                _MsgID_CallWndProc_Params = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_CALLWNDPROC_PARAMS");

                // Start the hook
                InitializeCallWndProcHook(0, _Handle);
            }

            protected override void OnStop()
            {
                UninitializeCallWndProcHook();
            }

            public override void ProcessWindowMessage(ref Message m)
            {
                if (m.Msg == _MsgID_CallWndProc)
                {
                    _CacheHandle = m.WParam;
                    _CacheMessage = m.LParam;
                }
                else if (m.Msg == _MsgID_CallWndProc_Params)
                {
                    if (CallWndProc != null && _CacheHandle != IntPtr.Zero && _CacheMessage != IntPtr.Zero)
                        CallWndProc(_CacheHandle, _CacheMessage, m.WParam, m.LParam);
                    _CacheHandle = IntPtr.Zero;
                    _CacheMessage = IntPtr.Zero;
                }
                else if (m.Msg == _MsgID_CallWndProc_HookReplaced)
                {
                    if (HookReplaced != null)
                        HookReplaced();
                }
            }
        }

        #endregion

        #region GetMsgHook Class

        public class GetMsgHook : Hook
        {
            // Values retreived with RegisterWindowMessage
            private IntPtr _CacheHandle;
            private IntPtr _CacheMessage;
            private int _MsgID_GetMsg;
            private int _MsgID_GetMsg_HookReplaced;
            private int _MsgID_GetMsg_Params;

            public GetMsgHook(IntPtr Handle) : base(Handle)
            {
            }

            public event HookReplacedEventHandler HookReplaced;
            public event WndProcEventHandler GetMsg;

            protected override void OnStart()
            {
                // Retreive the message IDs that we'll look for in WndProc
                _MsgID_GetMsg_HookReplaced = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_GETMSG_REPLACED");
                _MsgID_GetMsg = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_GETMSG");
                _MsgID_GetMsg_Params = (int)NativeWrappers.RegisterWindowMessage("DSSO_HOOK_GETMSG_PARAMS");

                // Start the hook
                InitializeGetMsgHook(0, _Handle);
            }

            protected override void OnStop()
            {
                UninitializeGetMsgHook();
            }

            public override void ProcessWindowMessage(ref Message m)
            {
                if (m.Msg == _MsgID_GetMsg)
                {
                    _CacheHandle = m.WParam;
                    _CacheMessage = m.LParam;
                }
                else if (m.Msg == _MsgID_GetMsg_Params)
                {
                    if (GetMsg != null && _CacheHandle != IntPtr.Zero && _CacheMessage != IntPtr.Zero)
                        GetMsg(_CacheHandle, _CacheMessage, m.WParam, m.LParam);
                    _CacheHandle = IntPtr.Zero;
                    _CacheMessage = IntPtr.Zero;
                }
                else if (m.Msg == _MsgID_GetMsg_HookReplaced)
                {
                    if (HookReplaced != null)
                        HookReplaced();
                }
            }
        }

        #endregion
    }

    //End of Class
}

// End of namespace