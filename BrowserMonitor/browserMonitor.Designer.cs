namespace BrowserMonitor
{
    partial class BrowserMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserMonitor));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.MemAvgLabel = new System.Windows.Forms.Label();
            this.MemMaxLabel = new System.Windows.Forms.Label();
            this.MemMinLabel = new System.Windows.Forms.Label();
            this.MemCurrentLabel = new System.Windows.Forms.Label();
            this.CPUAvgLabel = new System.Windows.Forms.Label();
            this.CPUMaxLabel = new System.Windows.Forms.Label();
            this.CPUMinLabel = new System.Windows.Forms.Label();
            this.CPUCurrentLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.seletedURLLabel = new System.Windows.Forms.Label();
            this.selectedBrowserLabel = new System.Windows.Forms.Label();
            this.stopMonitoringButton = new System.Windows.Forms.Button();
            this.privateBrowser = new System.Windows.Forms.CheckBox();
            this.url = new System.Windows.Forms.TextBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.browserLabel = new System.Windows.Forms.Label();
            this.monitorButton = new System.Windows.Forms.Button();
            this.currentURLLabel = new System.Windows.Forms.Label();
            this.browsers = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.monitorTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIconStrip.SuspendLayout();
            this.selectionPanel.SuspendLayout();
            this.graphPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Browser Monitor will continue to run in the background. To quit the app select qu" +
    "it from the notification icon\'s context menu.";
            this.notifyIcon.BalloonTipTitle = "Browser Monitor";
            this.notifyIcon.ContextMenuStrip = this.notifyIconStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "BrowserMonitor";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyIconStrip
            // 
            this.notifyIconStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitApp});
            this.notifyIconStrip.Name = "notifyIconStrip";
            this.notifyIconStrip.Size = new System.Drawing.Size(95, 26);
            // 
            // quitApp
            // 
            this.quitApp.Name = "quitApp";
            this.quitApp.Size = new System.Drawing.Size(94, 22);
            this.quitApp.Text = "Quit";
            this.quitApp.ToolTipText = "Quit Browser Monitor";
            this.quitApp.Click += new System.EventHandler(this.quitApp_Click);
            // 
            // selectionPanel
            // 
            this.selectionPanel.Controls.Add(this.privateBrowser);
            this.selectionPanel.Controls.Add(this.url);
            this.selectionPanel.Controls.Add(this.quitButton);
            this.selectionPanel.Controls.Add(this.browserLabel);
            this.selectionPanel.Controls.Add(this.monitorButton);
            this.selectionPanel.Controls.Add(this.currentURLLabel);
            this.selectionPanel.Controls.Add(this.browsers);
            this.selectionPanel.Location = new System.Drawing.Point(12, 5);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(428, 155);
            this.selectionPanel.TabIndex = 0;
            // 
            // graphPanel
            // 
            this.graphPanel.Controls.Add(this.MemAvgLabel);
            this.graphPanel.Controls.Add(this.MemMaxLabel);
            this.graphPanel.Controls.Add(this.MemMinLabel);
            this.graphPanel.Controls.Add(this.MemCurrentLabel);
            this.graphPanel.Controls.Add(this.CPUAvgLabel);
            this.graphPanel.Controls.Add(this.CPUMaxLabel);
            this.graphPanel.Controls.Add(this.CPUMinLabel);
            this.graphPanel.Controls.Add(this.CPUCurrentLabel);
            this.graphPanel.Controls.Add(this.label6);
            this.graphPanel.Controls.Add(this.label5);
            this.graphPanel.Controls.Add(this.label4);
            this.graphPanel.Controls.Add(this.label3);
            this.graphPanel.Controls.Add(this.label2);
            this.graphPanel.Controls.Add(this.label1);
            this.graphPanel.Controls.Add(this.seletedURLLabel);
            this.graphPanel.Controls.Add(this.selectedBrowserLabel);
            this.graphPanel.Controls.Add(this.stopMonitoringButton);
            this.graphPanel.Location = new System.Drawing.Point(12, 5);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(428, 155);
            this.graphPanel.TabIndex = 1;
            this.graphPanel.Visible = false;
            // 
            // MemAvgLabel
            // 
            this.MemAvgLabel.AutoSize = true;
            this.MemAvgLabel.Location = new System.Drawing.Point(307, 111);
            this.MemAvgLabel.MaximumSize = new System.Drawing.Size(65, 13);
            this.MemAvgLabel.Name = "MemAvgLabel";
            this.MemAvgLabel.Size = new System.Drawing.Size(49, 13);
            this.MemAvgLabel.TabIndex = 16;
            this.MemAvgLabel.Text = "MemAvg";
            // 
            // MemMaxLabel
            // 
            this.MemMaxLabel.AutoSize = true;
            this.MemMaxLabel.Location = new System.Drawing.Point(250, 111);
            this.MemMaxLabel.MaximumSize = new System.Drawing.Size(65, 13);
            this.MemMaxLabel.Name = "MemMaxLabel";
            this.MemMaxLabel.Size = new System.Drawing.Size(50, 13);
            this.MemMaxLabel.TabIndex = 15;
            this.MemMaxLabel.Text = "MemMax";
            // 
            // MemMinLabel
            // 
            this.MemMinLabel.AutoSize = true;
            this.MemMinLabel.Location = new System.Drawing.Point(191, 111);
            this.MemMinLabel.MaximumSize = new System.Drawing.Size(65, 13);
            this.MemMinLabel.Name = "MemMinLabel";
            this.MemMinLabel.Size = new System.Drawing.Size(47, 13);
            this.MemMinLabel.TabIndex = 14;
            this.MemMinLabel.Text = "MemMin";
            // 
            // MemCurrentLabel
            // 
            this.MemCurrentLabel.AutoSize = true;
            this.MemCurrentLabel.Location = new System.Drawing.Point(116, 111);
            this.MemCurrentLabel.MaximumSize = new System.Drawing.Size(65, 13);
            this.MemCurrentLabel.Name = "MemCurrentLabel";
            this.MemCurrentLabel.Size = new System.Drawing.Size(64, 13);
            this.MemCurrentLabel.TabIndex = 13;
            this.MemCurrentLabel.Text = "MemCurrent";
            // 
            // CPUAvgLabel
            // 
            this.CPUAvgLabel.AutoSize = true;
            this.CPUAvgLabel.Location = new System.Drawing.Point(307, 80);
            this.CPUAvgLabel.MaximumSize = new System.Drawing.Size(65, 13);
            this.CPUAvgLabel.Name = "CPUAvgLabel";
            this.CPUAvgLabel.Size = new System.Drawing.Size(48, 13);
            this.CPUAvgLabel.TabIndex = 12;
            this.CPUAvgLabel.Text = "CPUAvg";
            // 
            // CPUMaxLabel
            // 
            this.CPUMaxLabel.AutoSize = true;
            this.CPUMaxLabel.Location = new System.Drawing.Point(250, 80);
            this.CPUMaxLabel.MaximumSize = new System.Drawing.Size(65, 13);
            this.CPUMaxLabel.Name = "CPUMaxLabel";
            this.CPUMaxLabel.Size = new System.Drawing.Size(49, 13);
            this.CPUMaxLabel.TabIndex = 11;
            this.CPUMaxLabel.Text = "CPUMax";
            // 
            // CPUMinLabel
            // 
            this.CPUMinLabel.AutoSize = true;
            this.CPUMinLabel.Location = new System.Drawing.Point(191, 80);
            this.CPUMinLabel.MaximumSize = new System.Drawing.Size(65, 13);
            this.CPUMinLabel.Name = "CPUMinLabel";
            this.CPUMinLabel.Size = new System.Drawing.Size(46, 13);
            this.CPUMinLabel.TabIndex = 10;
            this.CPUMinLabel.Text = "CPUMin";
            // 
            // CPUCurrentLabel
            // 
            this.CPUCurrentLabel.AutoSize = true;
            this.CPUCurrentLabel.Location = new System.Drawing.Point(116, 80);
            this.CPUCurrentLabel.MaximumSize = new System.Drawing.Size(65, 13);
            this.CPUCurrentLabel.Name = "CPUCurrentLabel";
            this.CPUCurrentLabel.Size = new System.Drawing.Size(63, 13);
            this.CPUCurrentLabel.TabIndex = 9;
            this.CPUCurrentLabel.Text = "CPUCurrent";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Average";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Memory Usage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CPU Usage";
            // 
            // seletedURLLabel
            // 
            this.seletedURLLabel.AutoSize = true;
            this.seletedURLLabel.Location = new System.Drawing.Point(95, 17);
            this.seletedURLLabel.MaximumSize = new System.Drawing.Size(235, 13);
            this.seletedURLLabel.Name = "seletedURLLabel";
            this.seletedURLLabel.Size = new System.Drawing.Size(234, 13);
            this.seletedURLLabel.TabIndex = 2;
            this.seletedURLLabel.Text = "SeletedURLGoesHereSeletedURLGoesHereSeletedURLGoesHere";
            // 
            // selectedBrowserLabel
            // 
            this.selectedBrowserLabel.AutoSize = true;
            this.selectedBrowserLabel.Location = new System.Drawing.Point(12, 17);
            this.selectedBrowserLabel.Name = "selectedBrowserLabel";
            this.selectedBrowserLabel.Size = new System.Drawing.Size(81, 13);
            this.selectedBrowserLabel.TabIndex = 1;
            this.selectedBrowserLabel.Text = "SeletedBrowser";
            // 
            // stopMonitoringButton
            // 
            this.stopMonitoringButton.Location = new System.Drawing.Point(334, 12);
            this.stopMonitoringButton.Name = "stopMonitoringButton";
            this.stopMonitoringButton.Size = new System.Drawing.Size(75, 23);
            this.stopMonitoringButton.TabIndex = 0;
            this.stopMonitoringButton.Text = "Stop";
            this.stopMonitoringButton.UseVisualStyleBackColor = true;
            this.stopMonitoringButton.Click += new System.EventHandler(this.stopMonitoringButton_Click);
            // 
            // privateBrowser
            // 
            this.privateBrowser.AutoSize = true;
            this.privateBrowser.Location = new System.Drawing.Point(253, 20);
            this.privateBrowser.Name = "privateBrowser";
            this.privateBrowser.Size = new System.Drawing.Size(59, 17);
            this.privateBrowser.TabIndex = 7;
            this.privateBrowser.Text = "Private";
            this.privateBrowser.UseVisualStyleBackColor = true;
            // 
            // url
            // 
            this.url.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.url.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.url.Location = new System.Drawing.Point(98, 45);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(311, 20);
            this.url.TabIndex = 6;
            this.toolTip.SetToolTip(this.url, "URL to be monitored");
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(334, 110);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 5;
            this.quitButton.Text = "Quit";
            this.toolTip.SetToolTip(this.quitButton, "Quit Browser Monitor");
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // browserLabel
            // 
            this.browserLabel.AutoSize = true;
            this.browserLabel.Location = new System.Drawing.Point(12, 21);
            this.browserLabel.Name = "browserLabel";
            this.browserLabel.Size = new System.Drawing.Size(45, 13);
            this.browserLabel.TabIndex = 1;
            this.browserLabel.Text = "Browser";
            // 
            // monitorButton
            // 
            this.monitorButton.Location = new System.Drawing.Point(253, 110);
            this.monitorButton.Name = "monitorButton";
            this.monitorButton.Size = new System.Drawing.Size(75, 23);
            this.monitorButton.TabIndex = 4;
            this.monitorButton.Text = "Monitor";
            this.toolTip.SetToolTip(this.monitorButton, "Start monitoring current URL of the selected browser");
            this.monitorButton.UseVisualStyleBackColor = true;
            this.monitorButton.Click += new System.EventHandler(this.monitorButton_Click);
            // 
            // currentURLLabel
            // 
            this.currentURLLabel.AutoSize = true;
            this.currentURLLabel.Location = new System.Drawing.Point(12, 52);
            this.currentURLLabel.Name = "currentURLLabel";
            this.currentURLLabel.Size = new System.Drawing.Size(75, 13);
            this.currentURLLabel.TabIndex = 2;
            this.currentURLLabel.Text = "Enter the URL";
            this.toolTip.SetToolTip(this.currentURLLabel, "Current URL of the selected browser");
            // 
            // browsers
            // 
            this.browsers.FormattingEnabled = true;
            this.browsers.Items.AddRange(new object[] {
            "IE",
            "Chrome"});
            this.browsers.Location = new System.Drawing.Point(98, 18);
            this.browsers.Name = "browsers";
            this.browsers.Size = new System.Drawing.Size(132, 21);
            this.browsers.TabIndex = 0;
            this.toolTip.SetToolTip(this.browsers, "Brower to Monitor");
            this.browsers.SelectedIndexChanged += new System.EventHandler(this.browsers_SelectedIndexChanged);
            // 
            // monitorTimer
            // 
            this.monitorTimer.Interval = 1000;
            this.monitorTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BrowserMonitor
            // 
            this.AcceptButton = this.monitorButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 176);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.selectionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BrowserMonitor";
            this.Text = "Browser Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserMonitor_FormClosing);
            this.Resize += new System.EventHandler(this.BrowserMonitor_Resize);
            this.notifyIconStrip.ResumeLayout(false);
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            this.graphPanel.ResumeLayout(false);
            this.graphPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.ContextMenuStrip notifyIconStrip;
        private System.Windows.Forms.ToolStripMenuItem quitApp;
        private System.Windows.Forms.Label currentURLLabel;
        private System.Windows.Forms.Label browserLabel;
        private System.Windows.Forms.ComboBox browsers;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button monitorButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer monitorTimer;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Label seletedURLLabel;
        private System.Windows.Forms.Label selectedBrowserLabel;
        private System.Windows.Forms.Button stopMonitoringButton;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Label MemAvgLabel;
        private System.Windows.Forms.Label MemMaxLabel;
        private System.Windows.Forms.Label MemMinLabel;
        private System.Windows.Forms.Label MemCurrentLabel;
        private System.Windows.Forms.Label CPUAvgLabel;
        private System.Windows.Forms.Label CPUMaxLabel;
        private System.Windows.Forms.Label CPUMinLabel;
        private System.Windows.Forms.Label CPUCurrentLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox privateBrowser;
    }
}

