namespace DesktopGrid
{
    partial class GridCaption
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbCaption = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbCaption
            // 
            this.tbCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tbCaption.BackColor = System.Drawing.SystemColors.Control;
            this.tbCaption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCaption.Location = new System.Drawing.Point(136, 4);
            this.tbCaption.Margin = new System.Windows.Forms.Padding(0);
            this.tbCaption.Name = "tbCaption";
            this.tbCaption.Size = new System.Drawing.Size(52, 19);
            this.tbCaption.TabIndex = 0;
            this.tbCaption.Text = "[未命名]";
            this.tbCaption.Enter += new System.EventHandler(this.tbCaption_Enter);
            // 
            // GridCaption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbCaption);
            this.Name = "GridCaption";
            this.Size = new System.Drawing.Size(354, 30);
            this.Load += new System.EventHandler(this.GridCaption_Load);
            this.VisibleChanged += new System.EventHandler(this.GridCaption_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridCaption_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GridCaption_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCaption;
    }
}
