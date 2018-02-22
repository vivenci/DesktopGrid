using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DesktopGrid
{
    public class FileShell
    {
        [DllImport("shell32.dll")]
        public static extern int SHGetFileInfo(string pszPath,
            uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        #region 枚举属性预定义,该内容可在shellapi.h中找到

        public enum FileAttributeFlags : int
        {
            FILE_ATTRIBUTE_READONLY = 0x00000001,
            FILE_ATTRIBUTE_HIDDEN = 0x00000002,
            FILE_ATTRIBUTE_SYSTEM = 0x00000004,
            FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
            FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
            FILE_ATTRIBUTE_DEVICE = 0x00000040,
            FILE_ATTRIBUTE_NORMAL = 0x00000080,
            FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
            FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
            FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
            FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
            FILE_ATTRIBUTE_OFFLINE = 0x00001000,
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
            FILE_ATTRIBUTE_ENCRYPTED = 0x00004000
        }

        public enum GetFileInfoFlags : int
        {
            SHGFI_ICON = 0x000000100,     // get icon
            SHGFI_DISPLAYNAME = 0x000000200,     // get display name
            SHGFI_TYPENAME = 0x000000400,     // get type name
            SHGFI_ATTRIBUTES = 0x000000800,     // get attributes
            SHGFI_ICONLOCATION = 0x000001000,     // get icon location
            SHGFI_EXETYPE = 0x000002000,     // return exe type
            SHGFI_SYSICONINDEX = 0x000004000,     // get system icon index
            SHGFI_LINKOVERLAY = 0x000008000,     // put a link overlay on icon
            SHGFI_SELECTED = 0x000010000,     // show icon in selected state
            SHGFI_ATTR_SPECIFIED = 0x000020000,     // get only specified attributes
            SHGFI_LARGEICON = 0x000000000,     // get large icon
            SHGFI_SMALLICON = 0x000000001,     // get small icon
            SHGFI_OPENICON = 0x000000002,     // get open icon
            SHGFI_SHELLICONSIZE = 0x000000004,     // get shell size icon
            SHGFI_PIDL = 0x000000008,     // pszPath is a pidl
            SHGFI_USEFILEATTRIBUTES = 0x000000010,     // use passed dwFileAttribute
            SHGFI_ADDOVERLAYS = 0x000000020,     // apply the appropriate overlays
            SHGFI_OVERLAYINDEX = 0x000000040      // Get the index of the overlay
        }

        #endregion 枚举属性预定义,该内容可在shellapi.h中找到

        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        /// <summary>
        /// 从shell32.dll获取指定文件信息
        /// </summary>
        /// <param name="path">目标文件路径</param>
        /// <returns>获取的文件基本信息</returns>
        private static SHFILEINFO GetSHFileInfo(string path)
        {
            SHFILEINFO fileInfo = new SHFILEINFO();
            int cbFileInfo = Marshal.SizeOf(fileInfo);

            SHGetFileInfo(path, (uint)FileAttributeFlags.FILE_ATTRIBUTE_NORMAL,
                ref fileInfo, (uint)cbFileInfo, (uint)(GetFileInfoFlags.SHGFI_DISPLAYNAME | GetFileInfoFlags.SHGFI_TYPENAME));

            return fileInfo;
        }

        /// <summary>
        /// 获取文件显示名称
        /// </summary>
        /// <param name="path">目标文件路径</param>
        /// <returns>文件显示名称</returns>
        public static string GetDisplayName(string path)
        {
            return GetSHFileInfo(path).szDisplayName;
        }

        /// <summary>
        /// 获取文件类型名称
        /// </summary>
        /// <param name="path">目标文件路径</param>
        /// <returns>文件类型名称</returns>
        public static string GetTypeName(string path)
        {
            return GetSHFileInfo(path).szTypeName;
        }

        /// <summary>
        /// 获取文件Icon图标
        /// </summary>
        /// <param name="path">目标文件路径</param>
        /// <param name="isLargeIcon">是否大图标</param>
        /// <returns>文件图标</returns>
        public static Icon GetShellIcon(string path, bool isLargeIcon)
        {
            uint iconSize;
            SHFILEINFO shellFileInfo = new SHFILEINFO();

            //SHGFI_ICON|SHGFI_SMALLICON
            if (isLargeIcon == true)
            {
                iconSize = 16640;
            }
            else
            {
                iconSize = 257;
            }
            int iTotal = (int)SHGetFileInfo(path, 0, ref shellFileInfo, 100, iconSize);

            Icon ic = Icon.FromHandle(shellFileInfo.hIcon);
            return ic;
        }
    }
}