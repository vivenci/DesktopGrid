using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DesktopGrid
{
    public class DeskTopEntry
    {
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// 设置窗口的父窗体
        /// </summary>
        /// <param name="hWndChild">当前窗口句柄</param>
        /// <param name="hWndNewParent">父窗口句柄</param>
        /// <returns>父窗口的父窗口句柄</returns>
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);

        /// <summary>
        /// 查找窗口
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题</param>
        /// <returns>目标窗口句柄</returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 查找子窗口，从给定的子窗口后面的下一个子窗口开始查找
        /// </summary>
        /// <param name="hwndParent">要查找子窗口的父窗口句柄,如果为NULL，则函数以桌面窗口为父窗口</param>
        /// <param name="hwndChildAfter">子窗口句柄。查找从在Z序中的下一个子窗口开始如果为 NULL，查找从hwndParent的第一个子窗口开始</param>
        /// <param name="lpszClass">窗口类名</param>
        /// <param name="lpszWindow">窗口标题</param>
        /// <returns>子窗口句柄</returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// 获取窗口标题
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpString">标题</param>
        /// <param name="nMaxCount">最大值</param>
        /// <returns>窗口标题实际长度</returns>
        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 获取类的名字
        /// </summary>
        /// <param name="hWnd">句柄</param>
        /// <param name="lpString">类名</param>
        /// <param name="nMaxCount">最大值</param>
        /// <returns>窗口类名实际长度</returns>
        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 根据坐标获取窗口句柄
        /// </summary>
        /// <param name="Point">坐标</param>
        /// <returns>窗口句柄</returns>

        [DllImport("user32")]
        public static extern IntPtr WindowFromPoint(Point Point);
    }

    ///  桌面窗体
    ///  -----------------------------------------------------
    ///  句柄,           标题,               类名
    ///  0x00010166,     FolderView,         SysListView32
    ///  0x00010164,               ,         SHELLDLL_DefView
    ///  0x00010162,     Program Manager,    Progman
    ///  0x00010010,               ,         #32769
    ///  -----------------------------------------------------
    public enum DesktopHandle
    {
        SysListView32 = 65894,      //0x00010166
        SHELLDLL_DefView = 65892,   //0x00010164
        Progman = 65890,            //0x00010162
        C32769 = 65552              //0x00010010
    }
}