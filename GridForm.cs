using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopGrid
{
    public partial class GridForm : Form
    {
        private List<string> files = new List<string>();

        public GridForm()
        {
            this.InitStyle();
            InitializeComponent();
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000020;
        //        return cp;
        //    }
        //}

        private void InitStyle()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true); // 调整大小时重绘
            SetStyle(ControlStyles.AllPaintingInWmPaint, false);
            SetStyle(ControlStyles.Opaque, true);
            base.CreateControl();
        }

        private void GridForm_Load(object sender, EventArgs e)
        {
            this.pnlMain.VerticalScroll.Visible = false;
            this.nfyGrid.Visible = true;
            this.caption.MouseDown += new MouseEventHandler(GridForm_MouseDown);
            this.pnlMain.MouseDown += new MouseEventHandler(GridForm_MouseDown);

            int pWnd = DeskTopEntry.FindWindow("Progman", null);
            //int pWnd2 = DeskTopEntry.FindWindowEx((IntPtr)pWnd, IntPtr.Zero, "SHELLDLL_DefVIew", null);//查找受限
            //int pWnd3 = DeskTopEntry.FindWindowEx((IntPtr)pWnd2, IntPtr.Zero, "SysListView32", null);//查找受限
            //int pWnd4 = DeskTopEntry.FindWindow("SysListView32", null);//查不到结果

            DeskTopEntry.SetParent(this.Handle.ToInt32(), (int)DesktopHandle.Progman);
            //Rectangle ScreenArea = Screen.GetWorkingArea(this);
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;

            //获取窗口标题
            //IntPtr handle = this.Handle;
            //StringBuilder sbTit = new StringBuilder(256);
            //int it = DeskTopEntry.GetWindowText(handle, sbTit, sbTit.Capacity);
            ////获取窗口类名
            //StringBuilder sbCls = new StringBuilder(256);
            //int ic = DeskTopEntry.GetClassName(handle, sbCls, sbCls.Capacity);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GridForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.caption.Visible)
            {
                this.caption.Show();
            }
        }

        #region 窗口拖动

        private void GridForm_MouseDown(object sender, MouseEventArgs e)
        {
            DeskTopEntry.ReleaseCapture();
            DeskTopEntry.SendMessage(this.Handle, DeskTopEntry.WM_SYSCOMMAND, DeskTopEntry.SC_MOVE + DeskTopEntry.HTCAPTION, 0);
        }

        #endregion 窗口拖动

        private void pnlMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void pnlMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    this.files = ((string[])e.Data.GetData(DataFormats.FileDrop)).ToList();

                    if (this.files.Count > 0)
                    {
                        for (int i = 0; i < this.files.Count; i++)
                        {
                            string path = files[i];
                            FileSection section = new FileSection(path);
                            this.pnlMain.Controls.Add(section);
                        }
                    }
                }
            }
        }

        private void pnlMain_ControlAdded(object sender, ControlEventArgs e)
        {
            int lastCnt = this.pnlMain.Controls.Count - 1;
            FileSection c = e.Control as FileSection;
            if (lastCnt > 0)
            {
                int cntPerRow = Convert.ToInt32(Math.Floor((double)(this.pnlMain.Width - c.Margin.Left) / (c.Width + c.Margin.Right)));
                int fittableWidth = cntPerRow * c.Width + (cntPerRow + 1) * c.Margin.Left;
            }
        }

        private void pnlMain_ControlRemoved(object sender, ControlEventArgs e)
        {
        }
    }
}