using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace DesktopGrid
{
    public partial class FileSection : UserControl
    {
        private byte alpha;
        private string fileName;
        private string filePath;
        private SectionSize sectionSize;
        private FontFamily ff = new FontFamily("微软雅黑");

        public FileSection(string path)
        {
            this.filePath = path;
            InitializeComponent();
            this.InitStyle();
            this.Init();
            this.LoadInfo(path);
            this.InitEvents();
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                fileName = value;
                this.lblText.Text = value;
                this.UpdateToolTip(value);
                this.Invalidate();
            }
        }

        public Image Image
        {
            get
            {
                return this.pbImage.Image;
            }
            set
            {
                this.pbImage.Image = value;
                this.Invalidate();
            }
        }

        public SectionSize SectionSize
        {
            get
            {
                return sectionSize;
            }
            set
            {
                sectionSize = value;
                switch (value)
                {
                    case SectionSize.Small:
                        this.Width = 32;
                        this.pnlText.Height = 22;
                        this.Height = 54;
                        this.Font = new Font(ff, 8.5f);
                        break;

                    case SectionSize.Middle:
                        this.Width = 48;
                        this.pnlText.Height = 24;
                        this.Height = 72;
                        this.Font = new Font(ff, 9f);
                        break;

                    case SectionSize.Large:
                        this.Width = 64;
                        this.pnlText.Height = 26;
                        this.Height = 90;
                        this.Font = new Font(ff, 9.5f);
                        break;

                    case SectionSize.Largest:
                        this.Width = 72;
                        this.pnlText.Height = 28;
                        this.Height = 100;
                        this.Font = new Font(ff, 10f);
                        break;

                    default:
                        break;
                }
            }
        }

        public byte Alpha
        {
            get
            {
                return alpha;
            }

            set
            {
                alpha = value;
            }
        }

        private void InitStyle()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true); // 调整大小时重绘
            SetStyle(ControlStyles.AllPaintingInWmPaint, false);
            SetStyle(ControlStyles.Opaque, true);
            base.CreateControl();
        }

        private void Init()
        {
            this.Alpha = 180;
            this.SectionSize = SectionSize.Middle;
            this.ForeColor = Color.Black;
            this.pbImage.Cursor = Cursors.Hand;
            this.lblText.Cursor = Cursors.Hand;
            this.lblText.Font = this.Font;
        }

        private void pnlText_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            //if (!string.IsNullOrEmpty(this.FileName))
            //{
            //    Color foreColor = Color.FromArgb(this.Alpha, this.ForeColor);
            //    Graphics g = e.Graphics;
            //    g.Clear(Color.White);
            //    SizeF size = g.MeasureString(this.FileName, this.Font);
            //    RectangleF rect = new RectangleF((this.pnlText.Width - size.Width) / 2, (this.pnlText.Height - size.Height) / 2, size.Width, size.Height);
            //    using (Brush brush = new SolidBrush(foreColor))
            //    {
            //        g.DrawString(this.FileName, this.Font, brush, rect);
            //    }
            //}
        }

        private void LoadInfo(string path)
        {
            this.FileName = FileShell.GetDisplayName(path);

            bool flag = true;
            if (this.SectionSize == SectionSize.Small)
            {
                flag = false;
            }
            Icon icon = FileShell.GetShellIcon(path, flag);
            Bitmap bm = Util.GetScalingBitmap(icon.ToBitmap(), this.pbImage.Height, this.pbImage.Width);

            this.Image = bm;
        }

        private void InitEvents()
        {
            this.pbImage.Click += new EventHandler(OnSectionClick);
            this.lblText.Click += new EventHandler(OnSectionClick);
        }

        private void OnSectionClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.filePath))
            {
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();

                if (Directory.Exists(filePath))
                {
                    psi.FileName = "explorer.exe";
                    psi.Arguments = filePath;
                }
                else if (File.Exists(filePath))
                {
                    psi.FileName = filePath;
                }

                p.StartInfo = psi;
                p.Start();
            }
        }

        private void UpdateToolTip(string text)
        {
            this.tip.SetToolTip(this.lblText, text);
            this.tip.SetToolTip(this.pbImage, text);
        }
    }

    public enum SectionSize
    {
        Small,
        Middle,
        Large,
        Largest
    }
}