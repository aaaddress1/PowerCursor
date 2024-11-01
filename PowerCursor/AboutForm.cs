using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        private static void WinEventProcMethod(IntPtr hWinEventHook, uint @event, IntPtr hwnd, int idObject, int idChild, uint idEventThread, uint dwmsEventTime)
        {
            IntPtr current = GetForegroundWindow();
            //Debug.Print($"Foreground window changed: {current}");
            // 在這裡可以獲取更多信息，如窗口標題和進程名

            // 获取窗口所在的显示器
            IntPtr hMonitor = MonitorFromWindow(current, MONITOR_DEFAULTTONEAREST);

            if (hMonitor != IntPtr.Zero && hMonitor != lastSwitchMontor)
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

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        public AboutForm()
        {
            InitializeComponent();

            var t = (new Thread(() =>
            { // 設置 WinEvent 掛鉤
                WinEventProc procDelegate = new WinEventProc(WinEventProcMethod);
                IntPtr hWinEventHook = SetWinEventHook(
                    EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND,
                    IntPtr.Zero, procDelegate,
                    0, 0,
                    WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS);

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

    }
}
