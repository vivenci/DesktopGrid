using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopGrid
{
    public partial class GridCaption : UserControl
    {
        private byte alpha;
        private string caption = string.Empty;

        public GridCaption()
        {
            InitializeComponent();
            this.InitStyle();
            this.Init();
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

        public byte Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = value;
                this.Invalidate();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
                this.Invalidate();
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }

        public string Caption
        {
            get
            {
                return this.caption;
            }
            set
            {
                caption = value;
                if (this.tbCaption != null)
                {
                    this.tbCaption.Text = value;
                }
                this.Invalidate();
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
            this.Caption = "[未命名]";
            this.Font = new Font("微软雅黑", 10.5f);
            this.ForeColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!string.IsNullOrEmpty(this.Caption))
            {
                Color foreColor = Color.FromArgb(this.Alpha, this.ForeColor);
                Graphics g = e.Graphics;
                g.Clear(Color.White);
                SizeF size = g.MeasureString(this.Caption, this.Font);
                RectangleF rect = new RectangleF((this.ClientRectangle.Width - size.Width) / 2, (this.ClientRectangle.Height - size.Height) / 2, size.Width, size.Height);
                using (Brush brush = new SolidBrush(foreColor))
                {
                    g.DrawString(this.Caption, this.Font, brush, rect);
                }
            }
        }

        private void GridCaption_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
        }

        private void tbCaption_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void GridCaption_MouseClick(object sender, MouseEventArgs e)
        {
            this.tbCaption.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.Caption = this.tbCaption.Text;
            this.tbCaption.Visible = false;
        }

        private void GridCaption_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.tbCaption.Visible)
            {
                this.tbCaption.Show();
                this.tbCaption.Focus();
            }
        }

        private void GridCaption_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (this.Parent != null)
                {
                    this.SetCaption();
                }
            }
            this.Refresh();
        }

        private void SetCaption()
        {
            var g = this.CreateGraphics();
            SizeF size = g.MeasureString(this.Caption, this.tbCaption.Font);
            this.tbCaption.Width = Convert.ToInt32(size.Width);
            this.tbCaption.Height = Convert.ToInt32(size.Height);
            this.tbCaption.Left = (this.ClientRectangle.Width - this.tbCaption.Width) / 2;
            this.tbCaption.Top = (this.ClientRectangle.Height - this.tbCaption.Height) / 2;
        }
    }
}