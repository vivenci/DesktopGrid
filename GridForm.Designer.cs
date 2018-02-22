namespace DesktopGrid
{
    partial class GridForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridForm));
            this.nfyGrid = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.FlowLayoutPanel();
            this.caption = new DesktopGrid.GridCaption();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // nfyGrid
            // 
            this.nfyGrid.ContextMenuStrip = this.cmsMain;
            this.nfyGrid.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyGrid.Icon")));
            this.nfyGrid.Text = "桌面管理";
            this.nfyGrid.Visible = true;
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::DesktopGrid.Properties.Resources.exit;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(100, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AllowDrop = true;
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 30);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(361, 207);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlMain_ControlAdded);
            this.pnlMain.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlMain_ControlRemoved);
            this.pnlMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragDrop);
            this.pnlMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragEnter);
            // 
            // caption
            // 
            this.caption.Alpha = ((byte)(200));
            this.caption.Caption = "[未命名]";
            this.caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.caption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.caption.ForeColor = System.Drawing.SystemColors.Highlight;
            this.caption.Location = new System.Drawing.Point(0, 0);
            this.caption.Margin = new System.Windows.Forms.Padding(0);
            this.caption.MaximumSize = new System.Drawing.Size(0, 30);
            this.caption.MinimumSize = new System.Drawing.Size(0, 30);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(361, 30);
            this.caption.TabIndex = 1;
            // 
            // GridForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(361, 237);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.caption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GridForm";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GridForm";
            this.TransparencyKey = System.Drawing.SystemColors.ControlLight;
            this.Load += new System.EventHandler(this.GridForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GridForm_MouseDoubleClick);
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfyGrid;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private GridCaption caption;
        private System.Windows.Forms.FlowLayoutPanel pnlMain;
    }
}

