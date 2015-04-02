using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrowserMonitor;

namespace BrowserMonitor
{
    
    public partial class BrowserMonitor : Form
    {
        #region local variables
        
        public ProcessHandler ph;
        public Logger logger;
        public GraphHandler gh;
        private int count;
        private short currCPU, minCPU, maxCPU, avgCPU;
        private float currMem, minMem, maxMem, avgMem;

        public short THRESHOLD_CPU;
        public float THRESHOLD_MEMORY;

        #endregion

        #region constructor
        
        public BrowserMonitor()
        {
            InitializeComponent();
            ph = new ProcessHandler();
            logger = new Logger();
            gh = new GraphHandler();
            setLabelText();
            currCPU = maxCPU = avgCPU = 0;
            currMem = maxMem = avgMem = 0;
            minCPU = short.MaxValue;
            minMem = float.MaxValue;
            count = 0;
            refreshValues();
            THRESHOLD_CPU = Properties.Settings.Default.CPUThreshold;
            THRESHOLD_MEMORY = Properties.Settings.Default.MemoryThreshold;
            string[] userURLs = Properties.Settings.Default.URLCache.Split(';');
            this.url.AutoCompleteCustomSource.AddRange(userURLs);
        }
        
        #endregion
        
        #region methods
        
        private void setLabelText()
        {
            this.seletedURLLabel.Text = "";
            this.selectedBrowserLabel.Text = "";
            setRunningBubbleTip();
            notifyIcon.Visible = true;
        }

        private void setRunningBubbleTip()
        {
            this.notifyIcon.BalloonTipText = "Browser monitor will be running in the background";
            this.notifyIcon.BalloonTipTitle = "Browser Monitor is running";
            this.notifyIcon.ShowBalloonTip(500);
        }

        private void setNTMBubbleTip()
        {
            this.notifyIcon.BalloonTipText = "The monitored process has ended, nothing to monitor";
            this.notifyIcon.BalloonTipTitle = "Nothing to monitor";
            this.notifyIcon.ShowBalloonTip(500);
        }

        private void setHighLoadTip()
        {
            this.notifyIcon.BalloonTipText = "The monitored process exceeds the set CPU Threshold value";
            this.notifyIcon.BalloonTipTitle = "High CPU usage";
            this.notifyIcon.ShowBalloonTip(500);
        }

        private void setHighMemoryTip()
        {
            this.notifyIcon.BalloonTipText = "The monitored process exceeds the set Memory Threshold value";
            this.notifyIcon.BalloonTipTitle = "High Memory usage";
            this.notifyIcon.ShowBalloonTip(500);
        }

        private bool validateURL(string url)
        {
            if (url.StartsWith("http") && !url.Contains(" "))
            {
                if (!Properties.Settings.Default.URLCache.Contains(url) && !url.Contains(";"))
                {
                    Properties.Settings.Default.URLCache = Properties.Settings.Default.URLCache + ";" + url;
                    Properties.Settings.Default.Save();
                }
                return true;
            }
            return false;
        }

        #endregion

        //#region event handlers

        

        private void BrowserMonitor_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                this.setRunningBubbleTip();

                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                //notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) 
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Activate();
            }
        }

        private void quitApp_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BrowserMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.ph.IsProcessAlive)
            {
                this.setNTMBubbleTip();
                
                this.monitorTimer.Stop();
                graphPanel.Visible = false;
                selectionPanel.Visible = true;
                logger.persistLog();
            }
            else
            {
                object[] log = this.ph.measure();
                if(log[0] != null && log[1]!=null)
                {
                    short tempCPU = short.Parse(log[0].ToString());
                    currCPU = tempCPU == -1 ? (short)0 : tempCPU;
                    currMem = float.Parse(log[1].ToString()) / (1024 * 1024);
                    if (THRESHOLD_CPU < currCPU)
                    {
                        setHighLoadTip();
                    }
                    if (THRESHOLD_MEMORY < currMem)
                    {
                        setHighMemoryTip();
                    }
                    minCPU = minCPU > currCPU ? currCPU : minCPU;
                    maxCPU = maxCPU < currCPU ? currCPU : maxCPU;
                    minMem = minMem > currMem ? currMem : minMem;
                    maxMem = maxMem < currMem ? currMem : maxMem;
                    avgCPU = (short)((avgCPU * count + currCPU) / (count + 1));
                    avgMem = (avgMem * count + currMem) / (count + 1);
                    count++;
                    refreshValues();
                    this.logger.addLogEntry(currCPU, currMem);
                }
                else
                {
                    this.setNTMBubbleTip();

                    this.monitorTimer.Stop();
                    graphPanel.Visible = false;
                    selectionPanel.Visible = true;
                    logger.persistLog();
                }
                
            }

        }

        private void refreshValues()
        {
            this.CPUAvgLabel.Text = String.Format("{0:##0}%", avgCPU);
            this.CPUMinLabel.Text = String.Format("{0:##0}%", minCPU);
            this.CPUMaxLabel.Text = String.Format("{0:##0}%", maxCPU);
            this.CPUCurrentLabel.Text = String.Format("{0:##0}%", currCPU);
            this.MemAvgLabel.Text = String.Format("{0:####0.##} MB", avgMem);
            this.MemMinLabel.Text = String.Format("{0:####0.##} MB", minMem);
            this.MemMaxLabel.Text = String.Format("{0:####0.##} MB", maxMem);
            this.MemCurrentLabel.Text = String.Format("{0:####0.##} MB", currMem);
            if (minCPU == short.MaxValue)
            {
                this.CPUMinLabel.Text = "0%";
                this.MemMinLabel.Text = "0 MB";
            }
            if (currCPU > THRESHOLD_CPU)
            {
                this.CPUCurrentLabel.ForeColor = Color.Red;
            }
            else
            {
                this.CPUCurrentLabel.ForeColor = Color.Black;
            }
            if (currMem > THRESHOLD_MEMORY)
            {
                this.MemCurrentLabel.ForeColor = Color.Red;
            }
            else
            {
                this.MemCurrentLabel.ForeColor = Color.Black;
            }
        }

        private void monitorButton_Click(object sender, EventArgs e)
        {
            
            this.seletedURLLabel.Text = this.url.Text;
            this.selectedBrowserLabel.Text = (string)this.browsers.SelectedItem;
            if (this.browsers.SelectedItem == null)
            {
                MessageBox.Show("Error! Please select an browser from the drop down", "Browser not yet selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (validateURL(this.url.Text))
            {
                ph.createNewProcess((string)this.browsers.SelectedItem, this.url.Text, this.privateBrowser.Checked);
                graphPanel.Visible = true;
                selectionPanel.Visible = false;
                logger = new Logger(this.url.Text, (string)this.browsers.SelectedItem);
                this.monitorTimer.Start();
            }
            else
            {
                MessageBox.Show("Error! URL should begin with http", "Invaild URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void browsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void stopMonitoringButton_Click(object sender, EventArgs e)
        {
            this.monitorTimer.Stop();
            graphPanel.Visible = false;
            selectionPanel.Visible = true;
            logger.persistLog();
        }
    }
}
