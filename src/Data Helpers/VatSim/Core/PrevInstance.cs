using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace VatSim.Core
{
    public class PrevInstance
    {
        private static Mutex mutex;
        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int IsIconic(IntPtr hWnd);

        private static IntPtr GetCurrentInstanceWindowHandle()
        {
            IntPtr instanceWindowHandle = IntPtr.Zero;
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (process.Id != currentProcess.Id && process.MainModule.FileName == currentProcess.MainModule.FileName && process.MainWindowHandle != IntPtr.Zero)
                {
                    instanceWindowHandle = process.MainWindowHandle;
                    break;
                }
            }
            return instanceWindowHandle;
        }

        private static void SwitchToCurrentInstance()
        {
            IntPtr instanceWindowHandle = PrevInstance.GetCurrentInstanceWindowHandle();
            if (!(instanceWindowHandle != IntPtr.Zero))
                return;
            if (PrevInstance.IsIconic(instanceWindowHandle) != 0)
                PrevInstance.ShowWindow(instanceWindowHandle, 9);
            PrevInstance.SetForegroundWindow(instanceWindowHandle);
        }

        public static bool Exists()
        {
            if (!PrevInstance.IsAlreadyRunning())
                return false;
            PrevInstance.SwitchToCurrentInstance();
            return true;
        }

        private static bool IsAlreadyRunning()
        {
            bool createdNew;
            PrevInstance.mutex = new Mutex(true, "Global\\" + new FileInfo(Assembly.GetExecutingAssembly().Location).Name, out createdNew);
            if (createdNew)
                PrevInstance.mutex.ReleaseMutex();
            return !createdNew;
        }
    }
}
