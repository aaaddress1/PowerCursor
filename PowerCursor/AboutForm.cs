using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerCursor
{
    public partial class AboutForm : Form
    {


        // 定義常量
        private const uint EVENT_SYSTEM_FOREGROUND = 0x0003;
        private const uint WINEVENT_OUTOFCONTEXT = 0x0000;
        private const uint WINEVENT_SKIPOWNPROCESS = 0x0002;

        // 定義 WinEventProc 委託
        private delegate void WinEventProc(IntPtr hWinEventHook, uint @event, IntPtr hwnd, int idObject, int idChild, uint idEventThread, uint dwmsEventTime);

        // 定義 API 函數
        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        private static extern IntPtr DispatchMessage(ref MSG lpmsg);

        [DllImport("user32.dll")]
        private static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        // 定義 MSG 結構
        [StructLayout(LayoutKind.Sequential)]
        private struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public POINT pt;
        }

        // 定義 POINT 結構
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);



        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        private const uint MONITOR_DEFAULTTONEAREST = 2;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MONITORINFO
        {
            public uint cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;
        }

        static IntPtr lastSwitchMontor = IntPtr.Zero;
        private const uint EVENT_SYSTEM_SWITCHEND = 0x8000;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);


        [DllImport("user32.dll")]
        static extern IntPtr GetAncestor(IntPtr hWnd, uint gaFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetLastActivePopup(IntPtr hWnd);


        private const uint EVENT_OBJECT_DESTROY = 0x8001;
        const uint GA_ROOTOWNER = 3;
        
        static bool IsAltTabWindow(IntPtr hWnd) // ref: https://devblogs.microsoft.com/oldnewthing/20071008-00/?p=24863
        {
            // Start at the root owner
            IntPtr hwndWalk = GetAncestor(hWnd, GA_ROOTOWNER);
            // See if we are the last active visible popup
            IntPtr hwndTry;
            while ((hwndTry = GetLastActivePopup(hwndWalk)) != hwndTry)
            {
                if (IsWindowVisible(hwndTry)) break;
                hwndWalk = hwndTry;
            }
            return hwndWalk == hWnd;
        }

        private static int lastShowExplorerSwitcher = 0;
        private static void WinEventProcMethod(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint idEventThread, uint dwmsEventTime)
        {
            IntPtr current = GetForegroundWindow();
            StringBuilder className = new StringBuilder(256);
            GetClassName(current, className, className.Capacity);
            // explorer switcher - Foreground window title: XamlExplorerHostIslandWindow
            

            if (eventType == EVENT_OBJECT_DESTROY)
            {
                if (className.ToString().ToLower().Contains("ExplorerHostIslandWindow".ToLower()))
                    lastShowExplorerSwitcher = Environment.TickCount;
                return;
            }

            //Debug.Print($"Foreground window title: {className} - {lastShowExplorerSwitcher} - {IsAltTabWindow(current)}");

            if (eventType == EVENT_SYSTEM_FOREGROUND) {
                // 获取窗口所在的显示器
                IntPtr hMonitor = MonitorFromWindow(current, MONITOR_DEFAULTTONEAREST);

                //Debug.Print($"last tick intveral = {(Environment.TickCount - lastShowExplorerSwitcher)}");
                if (hMonitor != IntPtr.Zero && hMonitor != lastSwitchMontor && IsAltTabWindow(current) && (Environment.TickCount - lastShowExplorerSwitcher) < 500)
                {
                    MONITORINFO mi = new MONITORINFO();
                    mi.cbSize = (uint)Marshal.SizeOf(mi);
                    if (GetMonitorInfo(hMonitor, ref mi))
                    {
                        // 输出显示器信息
                        //Debug.Print($"显示器尺寸: 左 {mi.rcMonitor.Left}, 顶 {mi.rcMonitor.Top}, 右 {mi.rcMonitor.Right}, 底 {mi.rcMonitor.Bottom}");
                        //Debug.Print($"工作区尺寸: 左 {mi.rcWork.Left}, 顶 {mi.rcWork.Top}, 右 {mi.rcWork.Right}, 底 {mi.rcWork.Bottom}");

                        if (GetWindowRect(hwnd, out RECT rect))
                        {
                            int win_centerX = (rect.Left + rect.Right) / 2;
                            int win_centerY = (rect.Top + rect.Bottom) / 2;
                            //Debug.Print($"窗口中央 X= {win_centerX}, {win_centerY}");
                            //int centerX = mi.rcWork.Left + rect.Left;
                            //int centerY = mi.rcWork.Top + rect.Top;
                            SetCursorPos(win_centerX, win_centerY);
                            lastSwitchMontor = hMonitor;
                        }

                    }
                }
            }
        }


        static bool IsStartupItem(string appName)
        {
            string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(key, false))
            {
                if (regKey != null)
                {
                    return regKey.GetValue(appName) != null;
                }
                return false;
            }
        }

        public AboutForm()
        {
            InitializeComponent();
            this.Visible = false;  
            this.RunAsStartup.Checked = IsStartupItem("PowerCursor") ;
            var t = (new Thread(() =>
            { // 設置 WinEvent 掛鉤
                WinEventProc procDelegate = new WinEventProc(WinEventProcMethod);
                IntPtr hWinEventHook = SetWinEventHook(
                    EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND,
                    IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS);

                SetWinEventHook(
                   EVENT_OBJECT_DESTROY, EVENT_OBJECT_DESTROY,
                   IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS);

                // 開啟消息循環，以便 WinEventProc 能夠被調用
                MSG msg;
                while (GetMessage(out msg, IntPtr.Zero, 0, 0))
                {
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }

            })
            { IsBackground = true });
            t.Start();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/aaaddress1/PowerCursor",
                UseShellExecute = true
            });
        }

        private void RunAsStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RunAsStartup.Checked)
            {
                string appPath = Application.ExecutablePath;
                string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
               
                var regKey = Registry.CurrentUser.CreateSubKey(key);
                regKey.SetValue("PowerCursor", appPath);
                
            }
            else
            {
                string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(key, true);
                if (regKey == null)
                {
                    regKey = Registry.CurrentUser.CreateSubKey(key);
                    regKey.DeleteSubKey("PowerCursor");
                }
            }
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.buymeacoffee.com/aaaddress1");
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void githubcomaaaddress1PowerCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/aaaddress1/PowerCursor",
                UseShellExecute = true
            });

        }

        private void applicationBehaviorConfigureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.Show();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.Show();
        }
        private void byeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void AboutForm_Shown(object sender, EventArgs e)
        {
        }
    }
}
