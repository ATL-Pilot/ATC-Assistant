using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ATC_Helper.Classes
{
    /// <summary>
    /// <description>
    /// This class has the definitions for CbtSetFocus, 
    /// which processes the global system event messages and supplies credentials 
    /// for various desktop applications subscribed by the user.
    /// </description>
    /// </summary>
    internal class HookHandlers
    {
        #region Cbt Handlers

        public static void GlobalHooks_CbtSetFocus(IntPtr Handle)
        {
            //This is where we will process the messages and look for our target window

            IntPtr pThreadProcessID = IntPtr.Zero;
            IntPtr pThreadId = NativeWrappers.GetWindowThreadProcessId(Handle, pThreadProcessID);
            IntPtr pParentHandle = NativeWrappers.GetParent(Handle);
            IntPtr pMainWndHandle = NativeWrappers.GetAncestor(Handle, 2); //GetMainWindowHandle(Handle);
            //IntPtr pForegroundWnd = GetForegroundWindow();

            // Get Application Handle and Process name
            uint nProcessId;
            NativeWrappers.GetWindowThreadProcessId(Handle, out nProcessId);
            IntPtr ApplicationHandle = GetApplicationHandle(Handle);


            string sAppName = string.Empty;
            string sAppCreds = string.Empty;
            string username = string.Empty;
            string password = string.Empty;
            string szCredentialDialogProperty = string.Empty;
            int nAppDelay = 0;

            //for (int G = 0; G < Global.mUserApplications.Length; G++)
            //{
            //    if (Global.mUserApplications[G].ApplicationTypeId == 2) // AppTypeId = 2 represents desktop applications
            //    {
            //        Debug.WriteLine("Class: " + GetClassName(Handle));
            //        Debug.WriteLine("Caption: " + GetWindowName(Handle));

            //        Debug.WriteLine("Parent Class: " + GetClassName(pParentHandle));
            //        Debug.WriteLine("Parent Caption: " + GetWindowName(pParentHandle));

            //        Debug.WriteLine("Main Class: " + GetClassName(pMainWndHandle));
            //        Debug.WriteLine("Main Caption: " + GetWindowName(pMainWndHandle));

            //        Debug.WriteLine("Application Class: " + GetClassName(ApplicationHandle));
            //        Debug.WriteLine("Application Caption: " + GetWindowName(ApplicationHandle));
            //        Debug.WriteLine("Process(App) Name: " + GetApplicationName(Handle));   //Debug.WriteLine("Application Name: " + GetProcessNameFromProcessId((int)nProcessId));

            //        if (((Global.mUserApplications[G].Class == "1") ||
            //             (GetClassName(Handle) == Global.mUserApplications[G].Class)) //Window Class
            //            &&
            //            ((Global.mUserApplications[G].Caption == "1") ||
            //             (GetWindowName(Handle) == Global.mUserApplications[G].Caption)) //Window Caption
            //            &&
            //            ((Global.mUserApplications[G].ParentClass == "1") ||
            //             (GetClassName(pParentHandle) == Global.mUserApplications[G].ParentClass)) //Parent Class
            //            &&
            //            ((Global.mUserApplications[G].ParentCaption == "1") ||
            //             (GetWindowName(pParentHandle) == Global.mUserApplications[G].ParentCaption)) //Parent Caption
            //            &&
            //            ((Global.mUserApplications[G].MainClass == "1") ||
            //             (GetClassName(pMainWndHandle) == Global.mUserApplications[G].MainClass)) //Main Class
            //            &&
            //            ((Global.mUserApplications[G].MainCaption == "1") ||
            //             (GetWindowName(pMainWndHandle) == Global.mUserApplications[G].MainCaption)) //Main Caption
            //            &&
            //            ((Global.mUserApplications[G].ApplicationClass == "1") ||
            //             (GetClassName(ApplicationHandle) == Global.mUserApplications[G].ApplicationClass)) //Application Class
            //            &&
            //            ((Global.mUserApplications[G].ApplicationCaption == "1") ||
            //             (GetWindowName(ApplicationHandle) == Global.mUserApplications[G].ApplicationCaption)) //Application Caption
            //            &&
            //            ((Global.mUserApplications[G].ProcessName == "1") ||
            //             (GetApplicationName(Handle) == Global.mUserApplications[G].ProcessName)) //Process(App) Name
            //            )

            //        {
            //            sAppName = Global.mUserApplications[G].ApplicationName;

            //            int result;
            //            if (!int.TryParse(Global.mUserApplications[G].Delay, out result))
            //                result = 0;

            //            /// Check if credentials are supplied to this application in a timespan less than a minute
            //            /// 
            //            if (!CanSupply(sAppName))
            //            {
            //                DSSOUtils.Log("Info", string.Format("Preventing account lockout for {0}", sAppName));
            //                return;
            //            }

            //            if (Global.mUserApplications[G].CredentialGroupID == 1)
            //            {
            //                string Creds = string.Empty;

            //                sAppCreds = Global.mUserApplications[G].ApplicationCredential;
            //                if (string.IsNullOrEmpty(sAppCreds))
            //                {
            //                    DSSOUtils.Log("Warning",
            //                                  string.Format(
            //                                      "{0} application credentials are empty, exiting the hook handler.",
            //                                      sAppName));
            //                    return;
            //                }

            //                if (Crypto.Decrypt(sAppCreds, Global.mLocalUserDetails.szVzId, out Creds) !=
            //                    DSSO_RET.DSSO_SUCCESS)
            //                {
            //                    // Set Error Log Properties
            //                    Global.SetErrorLog
            //                        (
            //                            "GlobalHooks_CbtSetFocus",
            //                            DSSO_RET.DSSO_ERROR_CRYPTO_PADDING.ToString(),
            //                            "Decrypting desktop application credentials failed",
            //                            "Decrypting desktop application credentials failed",
            //                            null
            //                        );
            //                }

            //                int nIndex = 0;
            //                nIndex = Creds.IndexOf("<<");
            //                if (nIndex > 0)
            //                {
            //                    username = Creds.Remove(nIndex);
            //                    password = Creds.Substring(nIndex + 2);
            //                }

            //                szCredentialDialogProperty = Global.mUserApplications[G].CredentialDialogProperty;
            //            }
            //            else if (Global.mUserApplications[G].CredentialGroupID > 1)
            //            {
            //                string Creds = string.Empty;

            //                sAppCreds = Global.mUserApplications[G].GroupCredential;

            //                if (string.IsNullOrEmpty(sAppCreds))
            //                {
            //                    DSSOUtils.Log("Warning",
            //                                  string.Format("{0} group credentials are empty, exiting the hook handler.", Global.mUserApplications[G].ApplicationName));
            //                    return;
            //                }

            //                if (Crypto.Decrypt(sAppCreds, Global.mLocalUserDetails.szVzId, out Creds) !=
            //                    DSSO_RET.DSSO_SUCCESS)
            //                {
            //                    // Set Error Log Properties
            //                    Global.SetErrorLog
            //                        (
            //                            "GlobalHooks_CbtSetFocus",
            //                            DSSO_RET.DSSO_ERROR_CRYPTO_PADDING.ToString(),
            //                            "Decrypting desktop application credentials failed",
            //                            "Decrypting desktop application credentials failed",
            //                            null
            //                        );

            //                    // Send Error Log 
            //                    Global.SaveErrorLog();
            //                }

            //                int nIndex = 0;
            //                nIndex = Creds.IndexOf("<<");
            //                if (nIndex > 0)
            //                {
            //                    username = Creds.Remove(nIndex);
            //                    password = Creds.Substring(nIndex + 2);
            //                }

            //                szCredentialDialogProperty = Global.mUserApplications[G].CredentialDialogProperty;
            //            }

            //            if (!string.IsNullOrEmpty(password))
            //            {
            //                if (string.IsNullOrEmpty(username))
            //                {
            //                    if ((bool)Global.mUserApplications[G].IsSSOEnabled)
            //                    {
            //                        username = Global.mLocalUserDetails.szVzId;
            //                        SupplyCredentials(sAppName, Handle, username, password, szCredentialDialogProperty,
            //                                          nAppDelay, Global.mUserApplications[G].Id);
            //                    }
            //                    else
            //                    {
            //                        // Set Error Log Properties
            //                        Global.SetErrorLog
            //                            (
            //                                "GlobalHooks_CbtSetFocus",
            //                                DSSO_RET.DSSO_ERROR_DESBW_NULL_CREDS.ToString(),
            //                                "Desktop application's Username cannot be empty",
            //                                "Desktop application's Username cannot be empty",
            //                                null
            //                            );

            //                        // Send Error Log 
            //                        Global.SaveErrorLog();

            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    SupplyCredentials(sAppName, Handle, username, password, szCredentialDialogProperty,
            //                                      nAppDelay, Global.mUserApplications[G].Id);
            //                }
            //            }
            //            else
            //            {
            //                // Set Error Log Properties
            //                Global.SetErrorLog
            //                    (
            //                        "GlobalHooks_CbtSetFocus",
            //                        DSSO_RET.DSSO_ERROR_DESBW_NULL_CREDS.ToString(),
            //                        "Desktop application's Password cannot be empty",
            //                        "Desktop application's Password cannot be empty",
            //                        null
            //                    );

            //                // Send Error Log 
            //                Global.SaveErrorLog();

            //                return;
            //            }

            //            break;
            //        }
            //    }
            //}

            //throw new Exception("The method or operation is not implemented.");
        }

        private static void SupplyCredentials(string szAppName, IntPtr wndHandle, string szUsername, string szPassword,
                                              string CredDiagProperty, int nDelay, int appId)
        {
            try
            {
                //Log Usage
                //WebServiceWrapper.LogActivity(UsageType.DesktopToolbarApplicationSelected, appId);

                Console.WriteLine("Supplying credentials for " + szAppName);

                //Logging the statistics

                // TurnCapsLockOff
                TurnOffCapsLock();

                /// Understanding the Application Credentials Dialog property value
                /// 
                int Z = 0;
                string NoofCreds = string.Empty;
                string Sequence = string.Empty;
                NoofCreds = CredDiagProperty.Remove(Z + 1);
                Z = CredDiagProperty.LastIndexOf("#");
                if (Z > 1) Sequence = CredDiagProperty.Substring(Z + 1);

                // Set the window to which we are supplying credentials as foreground window
                NativeWrappers.SetForegroundWindow(wndHandle);
                Thread.Sleep(nDelay);
                if (NoofCreds == "1")
                {
                    for (int Y = 0; Y < Sequence.Length; Y++)
                    {
                        if (Sequence[Y] == '1')
                        {
                            SendKeys.SendWait("{HOME}");
                            SendKeys.SendWait("+{END}");
                            SendKeys.SendWait("{DEL}");
                            //SendKeys.SendWait("^a{DEL}");
                            SendKeys.SendWait(szPassword);

                            if (nDelay > 0) System.Threading.Thread.Sleep(nDelay);
                            continue;
                        }
                        if (Sequence[Y] == 'T')
                        {
                            SendKeys.SendWait("{TAB}");

                            if (nDelay > 0) System.Threading.Thread.Sleep(nDelay);
                            continue;
                        }
                        if (Sequence[Y] == 'E')
                        {
                            SendKeys.SendWait("{ENTER}");

                            if (nDelay > 0) System.Threading.Thread.Sleep(nDelay);
                            continue;
                        }

                        //Thread.Sleep(nDelay);
                    }
                }
                else if (NoofCreds == "2")
                {
                    for (int Y = 0; Y < Sequence.Length; Y++)
                    {
                        if (Sequence[Y] == '1')
                        {
                            SendKeys.SendWait("{HOME}");
                            SendKeys.SendWait("+{END}");
                            SendKeys.SendWait("{DEL}");
                            //SendKeys.SendWait("^a{DEL}");
                            SendKeys.SendWait(szUsername);  //SendKeys.Send(szUsername);

                            if (nDelay > 0) System.Threading.Thread.Sleep(nDelay);
                            continue;
                        }
                        if (Sequence[Y] == '2')
                        {
                            SendKeys.SendWait("{HOME}");
                            SendKeys.SendWait("+{END}");
                            SendKeys.SendWait("{DEL}");
                            //SendKeys.SendWait("^a{DEL}");
                            SendKeys.SendWait(szPassword);  //SendKeys.Send(szPassword);

                            if (nDelay > 0) System.Threading.Thread.Sleep(nDelay);
                            continue;
                        }
                        if (Sequence[Y] == 'T')
                        {
                            SendKeys.SendWait("{TAB}");

                            if (nDelay > 0) System.Threading.Thread.Sleep(nDelay);
                            continue;
                        }
                        if (Sequence[Y] == 'E')
                        {
                            SendKeys.SendWait("{ENTER}");

                            if (nDelay > 0) System.Threading.Thread.Sleep(nDelay);
                            continue;
                        }

                        //Thread.Sleep(nDelay);
                    }
                }

               }
            catch (Exception ex)
            {
                
            }
        }

        private static bool CanSupply(string sAppName)
        {
            //List<string> appKeys = new List<string>(Global.SuppliedCredentials.Keys);

            //for (int i = 0; i < appKeys.Count; i++)
            //{
            //    TimeSpan ts = DateTime.Now - Global.SuppliedCredentials[appKeys[i]];
            //    if (ts.Minutes > 1)
            //        Global.SuppliedCredentials.Remove(appKeys[i]);
            //}

            //if (Global.SuppliedCredentials.ContainsKey(sAppName))
            //    return false;
            //else
                return true;
        }

        #endregion

        #region Shell Handlers

        private static void GlobalHooks_ShellWindowCreated(IntPtr Handle)
        {
            //this.ListShell.Items.Add("Created: " + GetWindowName(Handle));
            //Console.WriteLine("Created: " + GetWindowName(Handle));
        }

        #endregion

        #region User32.dll Imports

        // API calls to give us a bit more information about the data we get from the hook
        //internal const int WM_SETTEXT = 0x000C;

        //[DllImport("user32.dll")]
        //private static extern int GetWindowText(IntPtr hWnd, StringBuilder title, int size);

        //[DllImport("user32.dll")]
        //private static extern uint RealGetWindowClass(IntPtr hWnd, StringBuilder pszType, uint cchType);

        //[DllImport("user32.dll")]
        //public static extern IntPtr GetParent(IntPtr hWnd);

        //[DllImport("user32.dll")]
        //public static extern IntPtr GetDesktopWindow();

        //[DllImport("user32.dll")]
        //public static extern IntPtr GetWindow(IntPtr hwnd, int wFlag);

        ////GW_HWNDPREV 3
        //[DllImport("user32.dll")]
        //public static extern IntPtr GetAncestor(IntPtr hWnd, int flags);

        //[DllImport("user32.dll")]
        //public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        ////public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        //[DllImport("user32.dll")]
        //public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);

        //[DllImport("user32.dll")]
        //static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        //public static extern IntPtr GetActiveWindow();

        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        //public static extern IntPtr GetForegroundWindow();

        //[DllImport("user32.dll", EntryPoint = "SendMessageW")]
        //internal static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        //[DllImport("user32.dll", EntryPoint = "SendMessageW")]
        //internal static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam,
        //                                          [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        //[DllImport("USER32.DLL")]
        //public static extern bool SetForegroundWindow(IntPtr hWnd);

        //[DllImport("user32.dll")]
        //static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        #endregion

        #region Helper Functions(Windows API)

        private static string GetWindowName(IntPtr Hwnd)
        {
            // This function gets the name of a window from its handle
            StringBuilder Title = new StringBuilder(256);
            NativeWrappers.GetWindowText(Hwnd, Title, 256);

            return Title.ToString().Trim();
        }

        private static string GetWindowClass(IntPtr Hwnd)
        {
            // This function gets the name of a window class from a window handle
            StringBuilder Title = new StringBuilder(256);
            NativeWrappers.RealGetWindowClass(Hwnd, Title, 256);

            return Title.ToString().Trim();
        }

        private static string GetClassName(IntPtr hWnd)
        {
            StringBuilder className = new StringBuilder(100);
            if (NativeWrappers.GetClassName(hWnd, className, className.Capacity) > 0)
            {
                return className.ToString();
            }

            return String.Empty;
        }

        private static IntPtr GetApplicationHandle(IntPtr hWnd)
        {
            try
            {
                int procId;
                NativeWrappers.GetWindowThreadProcessId(hWnd, out procId);
                Process proc = Process.GetProcessById(procId);
                return proc.MainWindowHandle;   // proc.MainModule.ModuleName;
            }
            catch
            {
                return IntPtr.Zero;
            }
        }

        private static string GetApplicationName(IntPtr hWnd)
        {
            try
            {
                int procId;
                NativeWrappers.GetWindowThreadProcessId(hWnd, out procId);
                Process proc = Process.GetProcessById(procId);
                return proc.MainModule.ModuleName;
            }
            catch
            {
                return null;
            }
        }

        private static IntPtr GetMainWindowHandle(IntPtr Hwnd)
        {
            IntPtr hDesktop = NativeWrappers.GetDesktopWindow();
            Console.WriteLine(hDesktop.ToString());

            IntPtr hTemp = Hwnd;
            IntPtr hPrevTemp = IntPtr.Zero;
            int i = 0;
            do
            {
                hPrevTemp = hTemp;
                hTemp = NativeWrappers.GetAncestor(hPrevTemp, 2); //GetWindow(hPrevTemp, 4);
                i++;

                Console.WriteLine(hTemp.ToString());
            } while (hTemp != IntPtr.Zero);

            return hPrevTemp;
        }

        private static string GetProcessNameFromProcessId(int pProcessId)
        {
            Process chosen;
            try
            {
                //int pid = (int)pProcessId.ToInt32();
                chosen = Process.GetProcessById(pProcessId);
                //Console.WriteLine("MainWindowHandle: " + chosen.MainWindowHandle + "MainWindowTitle" + chosen.MainWindowTitle);
                return chosen.ProcessName;
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect entry.");
                return "Error";
            }
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
        private static void TurnOffCapsLock()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                Console.WriteLine("Caps Lock key is ON.  We'll turn it off");
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            else
            {
                Console.WriteLine("Caps Lock key is OFF");
            }
        }

        #endregion

        /*
        public static void GlobalHooks_CbtSetFocus(IntPtr Handle)
        {
            System.Diagnostics.Debug.WriteLine("Focused: " + GetWindowName(Handle) + ", " + GetWindowClass(Handle));
            Console.WriteLine("Focused: " + GetWindowName(Handle) + ", " + GetWindowClass(Handle));

            IntPtr pThreadProcessID = IntPtr.Zero;
            IntPtr pThreadId = GetWindowThreadProcessId(Handle, pThreadProcessID);
            //Console.WriteLine("Thread Process Id: " + pThreadId.ToString());

            IntPtr pParentHandle = GetParent(Handle);
            //Console.WriteLine("Parent: " + GetWindowName(pParentHandle) + ", " + GetWindowClass(pParentHandle));

            IntPtr pMainWndHandle1 = GetAncestor(Handle, 2); //GetMainWindowHandle(Handle);
            //Console.WriteLine("MainWnd: " + GetWindowName(pMainWndHandle1) + ", " + GetWindowClass(pMainWndHandle1));

            IntPtr pForegroundWnd = GetForegroundWindow();
            //Console.WriteLine("ForeGroundWnd: " + GetWindowName(pForegroundWnd) + ", " + GetWindowClass(pForegroundWnd));

            //if ((GetWindowClass(Handle) == "Edit") && (GetWindowName(pParentHandle) == "Untitled - Notepad"))
            //    SendMessage(Handle, WM_SETTEXT, IntPtr.Zero, "Check");

            string sAppName = string.Empty;
            string sAppCreds = string.Empty;
            string username = string.Empty;
            string password = string.Empty;
            string szCredentialDialogProperty = string.Empty;

            for (int G = 0; G < Global.mUserApplications.Length; G++)
            {
                if (Global.mUserApplications[G].ApplicationTypeId == 2)  // AppTypeId = 2 represents desktop applications
                {
                    if ((GetWindowClass(Handle) == Global.mUserApplications[G].Class)   
                        && (GetWindowClass(pParentHandle) == Global.mUserApplications[G].ParentClass)
                        && (GetWindowClass(pMainWndHandle1) == Global.mUserApplications[G].ApplicationClass))
                    {
                        sAppName = Global.mUserApplications[G].ApplicationName;

                        if (Global.mUserApplications[G].CredentialGroupID == 1)
                        {
                            string Creds = string.Empty;

                            sAppCreds = Global.mUserApplications[G].ApplicationCredential;
                            if (string.IsNullOrEmpty(sAppCreds))
                            {
                                DSSOUtils.Log('W', string.Format("{0} application credentials are empty, exiting the hook handler."));
                                return;
                            }

                            if (Crypto.Decrypt(sAppCreds, Global.mLocalUserDetails.szVzId, out Creds) != DSSO_RET.DSSO_SUCCESS)
                            {
                                Global.sError = DSSO_RET.DSSO_ERROR_CRYPTO_PADDING.ToString();
                                DSSOUtils.Log('E', "Decrypting desktop application credentials failed");
                            }

                            int nIndex = 0;
                            nIndex = Creds.IndexOf("<<");
                            if (nIndex > 0)
                            {
                                username = Creds.Remove(nIndex);
                                password = Creds.Substring(nIndex + 2);
                            }

                            szCredentialDialogProperty = Global.mUserApplications[G].CredentialDialogProperty;
                        }
                        else if (Global.mUserApplications[G].CredentialGroupID > 1)
                        {
                            string Creds = string.Empty;

                            sAppCreds = Global.mUserApplications[G].GroupCredential;

                            if (string.IsNullOrEmpty(sAppCreds))
                            {
                                DSSOUtils.Log('W', string.Format("{0} group credentials are empty, exiting the hook handler."));
                                return;
                            }

                            if (Crypto.Decrypt(sAppCreds, Global.mLocalUserDetails.szVzId, out Creds) != DSSO_RET.DSSO_SUCCESS)
                            {
                                Global.sError = DSSO_RET.DSSO_ERROR_CRYPTO_PADDING.ToString();
                                DSSOUtils.Log('E', "Decrypting desktop application credentials failed");
                            }

                            int nIndex = 0;
                            nIndex = Creds.IndexOf("<<");
                            if (nIndex > 0)
                            {
                                username = Creds.Remove(nIndex);
                                password = Creds.Substring(nIndex + 2);
                            }

                            szCredentialDialogProperty = Global.mUserApplications[G].CredentialDialogProperty;
                        }

                        if (!string.IsNullOrEmpty(password))
                        {
                            if (!string.IsNullOrEmpty(username))
                            {
                                if ((bool)Global.mUserApplications[G].IsSSOEnabled)
                                {
                                    username = Global.mLocalUserDetails.szVzId;
                                    SupplyCredentials(sAppName, Handle, username, password, szCredentialDialogProperty);
                                }
                                else
                                {
                                    DSSOUtils.Log('E', "Desktop application's Username cannot be empty");
                                    return;
                                }
                            }
                            else
                            {
                                SupplyCredentials(sAppName, Handle, username, password, szCredentialDialogProperty);
                            }
                        }
                        else
                        {
                            DSSOUtils.Log('E', "Desktop application's Password cannot be empty");
                            return;
                        }

                        break;
                    }
                }
            }

            //if ((GetWindowClass(Handle) == "Internet Explorer_Server") 
            //    && (GetWindowClass(pParentHandle) == "Shell DocObject View") 
            //    && (GetWindowClass(pMainWndHandle1) == "#32770"))
            //{   
            //    DSSOUtils.Log('I', string.Format("Supplying credentials for {0} desktop application", sAppName));
            //    SendKeys.Send("^a{DEL}check{TAB}^a{DEL}check");
            //}

            //if ((GetWindowClass(Handle) == "Internet Explorer_Server")
            //    && (GetWindowClass(pParentHandle) == "Shell DocObject View")
            //    && (GetWindowClass(pMainWndHandle1) == "#32770"))
            //{
            //    //SendMessage(Handle, WM_SETTEXT, IntPtr.Zero, "Check");
            //    SendKeys.Send("^a{DEL}check{TAB}^a{DEL}check");
            //}

            //throw new Exception("The method or operation is not implemented.");
        }

        private static void SupplyCredentials(string szAppName, IntPtr wndHandle, string szUsername, string szPassword, string CredDiagProperty)
        {
            Console.WriteLine("Supplying credentials for " + szAppName);

            // already checked
            //if (string.IsNullOrEmpty(szUsername))
            //{
            //    szUsername = Global.mLocalUserDetails.szVzId;
            //}

            /// Understanding the Application Credentials Dialog property value
            /// 
            int Z = 0;
            string NoofCreds = string.Empty;
            string Sequence = string.Empty;
            NoofCreds = CredDiagProperty.Remove(Z + 1);
            Z = CredDiagProperty.LastIndexOf("#");
            if(Z > 1) Sequence = CredDiagProperty.Substring(Z + 1);
            SetForegroundWindow(wndHandle);

            if (NoofCreds == "1")
            {
                for (int Y = 0; Y < Sequence.Length; Y++)
                {
                    if (Sequence[Y] == '1')
                    {
                        SendKeys.SendWait("^a{DEL}");
                        SendKeys.Send(szPassword);
                        continue;
                    }
                    if (Sequence[Y] == 'T')
                    {
                        SendKeys.SendWait("{TAB}");
                        continue;
                    }
                    if (Sequence[Y] == 'E')
                    {
                        SendKeys.SendWait("{ENTER}");
                        continue;
                    }
                }
            }
            else if (NoofCreds == "2")
            {
                for (int Y = 0; Y < Sequence.Length; Y++)
                {
                    if (Sequence[Y] == '1')
                    {
                        SendKeys.SendWait("^a{DEL}");
                        SendKeys.Send(szUsername);
                        continue;
                    }
                    if (Sequence[Y] == '2')
                    {
                        SendKeys.SendWait("^a{DEL}");
                        SendKeys.Send(szPassword);
                        continue;
                    }
                    if (Sequence[Y] == 'T')
                    {
                        SendKeys.SendWait("{TAB}");
                        continue;
                    }
                    if (Sequence[Y] == 'E')
                    {
                        SendKeys.SendWait("{ENTER}");
                        continue;
                    }
                }
            }

            /*
            // Customization for Sametime application
            if (szAppName == "sametime")
            {
                SendKeys.Send(string.Format("^a{DEL}{0}{TAB}{ENTER}", szPassword));
                return;
            }
            
            // For Generalized Applications like ISF
            //SendKeys.Send(string.Format("^a{DEL}{0}{TAB}^a{DEL}{1}{TAB}{ENTER}", szUsername, szPassword));
            SendKeys.Send("^a{DEL}check{TAB}^a{DEL}check{TAB}");

        }
        #endregion

        #region Shell Handlers
        private static void GlobalHooks_ShellWindowCreated(IntPtr Handle)
        {
            //this.ListShell.Items.Add("Created: " + GetWindowName(Handle));
            Console.WriteLine("Created: " + GetWindowName(Handle));
        }
        #endregion

        #region Imports
        // API calls to give us a bit more information about the data we get from the hook
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder title, int size);
        [DllImport("user32.dll")]
        private static extern uint RealGetWindowClass(IntPtr hWnd, StringBuilder pszType, uint cchType);
        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, int wFlag);   //GW_HWNDPREV 3
        [DllImport("user32.dll")]
        public static extern IntPtr GetAncestor(IntPtr hWnd, int flags);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);  //public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        internal const int WM_SETTEXT = 0x000C;
        #endregion

        #region Windows API Helper Functions

        private static string GetWindowName(IntPtr Hwnd)
        {
            // This function gets the name of a window from its handle
            StringBuilder Title = new StringBuilder(256);
            GetWindowText(Hwnd, Title, 256);

            return Title.ToString().Trim();
        }

        private static string GetWindowClass(IntPtr Hwnd)
        {
            // This function gets the name of a window class from a window handle
            StringBuilder Title = new StringBuilder(256);
            RealGetWindowClass(Hwnd, Title, 256);

            return Title.ToString().Trim();
        }

        private static IntPtr GetMainWindowHandle(IntPtr Hwnd)
        {
            IntPtr hDesktop = GetDesktopWindow();
            Console.WriteLine(hDesktop.ToString());

            IntPtr hTemp = Hwnd;
            IntPtr hPrevTemp = IntPtr.Zero;
            int i = 0;
            do
            {
                hPrevTemp = hTemp;
                hTemp = GetAncestor(hPrevTemp, 2); //GetWindow(hPrevTemp, 4);
                i++;

                Console.WriteLine(hTemp.ToString());

            } while (hTemp != IntPtr.Zero);

            return hPrevTemp;
        }

        #endregion

        */
    }
}
