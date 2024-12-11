namespace PowerCursor
{
    partial class AboutForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.RunAsStartup = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.applicationBehaviorConfigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubcomaaaddress1PowerCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RunAsStartup
            // 
            this.RunAsStartup.AutoSize = true;
            this.RunAsStartup.Location = new System.Drawing.Point(33, 69);
            this.RunAsStartup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RunAsStartup.Name = "RunAsStartup";
            this.RunAsStartup.Size = new System.Drawing.Size(493, 29);
            this.RunAsStartup.TabIndex = 0;
            this.RunAsStartup.Text = "Run as Windows Startup Program After Reboot";
            this.RunAsStartup.UseVisualStyleBackColor = true;
            this.RunAsStartup.CheckedChanged += new System.EventHandler(this.RunAsStartup_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "PowerCursor v1.1";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PowerCursor";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationBehaviorConfigureToolStripMenuItem,
            this.githubcomaaaddress1PowerCursorToolStripMenuItem,
            this.byeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(511, 112);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // applicationBehaviorConfigureToolStripMenuItem
            // 
            this.applicationBehaviorConfigureToolStripMenuItem.Name = "applicationBehaviorConfigureToolStripMenuItem";
            this.applicationBehaviorConfigureToolStripMenuItem.Size = new System.Drawing.Size(510, 36);
            this.applicationBehaviorConfigureToolStripMenuItem.Text = "Application Behavior Configure";
            this.applicationBehaviorConfigureToolStripMenuItem.Click += new System.EventHandler(this.applicationBehaviorConfigureToolStripMenuItem_Click);
            // 
            // githubcomaaaddress1PowerCursorToolStripMenuItem
            // 
            this.githubcomaaaddress1PowerCursorToolStripMenuItem.Name = "githubcomaaaddress1PowerCursorToolStripMenuItem";
            this.githubcomaaaddress1PowerCursorToolStripMenuItem.Size = new System.Drawing.Size(510, 36);
            this.githubcomaaaddress1PowerCursorToolStripMenuItem.Text = "github.com/aaaddress1/PowerCursor";
            this.githubcomaaaddress1PowerCursorToolStripMenuItem.Click += new System.EventHandler(this.githubcomaaaddress1PowerCursorToolStripMenuItem_Click);
            // 
            // byeToolStripMenuItem
            // 
            this.byeToolStripMenuItem.Name = "byeToolStripMenuItem";
            this.byeToolStripMenuItem.Size = new System.Drawing.Size(510, 36);
            this.byeToolStripMenuItem.Text = "Bye~";
            this.byeToolStripMenuItem.Click += new System.EventHandler(this.byeToolStripMenuItem_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.LinkColor = System.Drawing.Color.Teal;
            this.linkLabel.Location = new System.Drawing.Point(28, 29);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(366, 25);
            this.linkLabel.TabIndex = 1;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "github.com/aaaddress1/PowerCursor";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(33, 118);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(494, 116);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 261);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.RunAsStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PowerCursor v1.1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutForm_FormClosing);
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.Shown += new System.EventHandler(this.AboutForm_Shown);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox RunAsStartup;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem byeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubcomaaaddress1PowerCursorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationBehaviorConfigureToolStripMenuItem;
    }
}

