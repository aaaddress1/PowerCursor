﻿namespace PowerCursor
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
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.byeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubcomaaaddress1PowerCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationBehaviorConfigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // RunAsStartup
            // 
            this.RunAsStartup.AutoSize = true;
            this.RunAsStartup.Location = new System.Drawing.Point(25, 55);
            this.RunAsStartup.Name = "RunAsStartup";
            this.RunAsStartup.Size = new System.Drawing.Size(371, 24);
            this.RunAsStartup.TabIndex = 0;
            this.RunAsStartup.Text = "Run as Windows Startup Program After Reboot";
            this.RunAsStartup.UseVisualStyleBackColor = true;
            this.RunAsStartup.CheckedChanged += new System.EventHandler(this.RunAsStartup_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PowerCursor";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.LinkColor = System.Drawing.Color.Teal;
            this.linkLabel.Location = new System.Drawing.Point(21, 23);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(270, 20);
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
            this.pictureBox.Location = new System.Drawing.Point(25, 94);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(371, 93);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationBehaviorConfigureToolStripMenuItem,
            this.githubcomaaaddress1PowerCursorToolStripMenuItem,
            this.byeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(398, 94);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // byeToolStripMenuItem
            // 
            this.byeToolStripMenuItem.Name = "byeToolStripMenuItem";
            this.byeToolStripMenuItem.Size = new System.Drawing.Size(397, 30);
            this.byeToolStripMenuItem.Text = "Bye~";
            this.byeToolStripMenuItem.Click += new System.EventHandler(this.byeToolStripMenuItem_Click);
            // 
            // githubcomaaaddress1PowerCursorToolStripMenuItem
            // 
            this.githubcomaaaddress1PowerCursorToolStripMenuItem.Name = "githubcomaaaddress1PowerCursorToolStripMenuItem";
            this.githubcomaaaddress1PowerCursorToolStripMenuItem.Size = new System.Drawing.Size(397, 30);
            this.githubcomaaaddress1PowerCursorToolStripMenuItem.Text = "github.com/aaaddress1/PowerCursor";
            this.githubcomaaaddress1PowerCursorToolStripMenuItem.Click += new System.EventHandler(this.githubcomaaaddress1PowerCursorToolStripMenuItem_Click);
            // 
            // applicationBehaviorConfigureToolStripMenuItem
            // 
            this.applicationBehaviorConfigureToolStripMenuItem.Name = "applicationBehaviorConfigureToolStripMenuItem";
            this.applicationBehaviorConfigureToolStripMenuItem.Size = new System.Drawing.Size(397, 30);
            this.applicationBehaviorConfigureToolStripMenuItem.Text = "Application Behavior Configure";
            this.applicationBehaviorConfigureToolStripMenuItem.Click += new System.EventHandler(this.applicationBehaviorConfigureToolStripMenuItem_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 209);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.RunAsStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PowerCursor v1.0";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutForm_FormClosing);
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.Shown += new System.EventHandler(this.AboutForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
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

