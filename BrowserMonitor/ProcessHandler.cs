using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Automation;
using ComTypes = System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace BrowserMonitor
{
    class CpuUsage
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetSystemTimes(
                    out ComTypes.FILETIME lpIdleTime,
                    out ComTypes.FILETIME lpKernelTime,
                    out ComTypes.FILETIME lpUserTime
                    );

        ComTypes.FILETIME _prevSysKernel;
        ComTypes.FILETIME _prevSysUser;

        TimeSpan _prevProcTotal;

        Int16 _cpuUsage;
        DateTime _lastRun;
        long _runCount;
        Process _process;

        public CpuUsage(Process process)
        {
            _cpuUsage = -1;
            _lastRun = DateTime.MinValue;
            _prevSysUser.dwHighDateTime = _prevSysUser.dwLowDateTime = 0;
            _prevSysKernel.dwHighDateTime = _prevSysKernel.dwLowDateTime = 0;
            _prevProcTotal = TimeSpan.MinValue;
            _runCount = 0;
            _process = process;
        }

        public short GetUsage()
        {
            short cpuCopy = _cpuUsage;
            if (Interlocked.Increment(ref _runCount) == 1)
            {
                if (!EnoughTimePassed)
                {
                    Interlocked.Decrement(ref _runCount);
                    return cpuCopy;
                }

                ComTypes.FILETIME sysIdle, sysKernel, sysUser;
                TimeSpan procTime;

                procTime = _process.TotalProcessorTime;

                if (!GetSystemTimes(out sysIdle, out sysKernel, out sysUser))
                {
                    Interlocked.Decrement(ref _runCount);
                    return cpuCopy;
                }

                if (!IsFirstRun)
                {
                    UInt64 sysKernelDiff =
                        SubtractTimes(sysKernel, _prevSysKernel);
                    UInt64 sysUserDiff =
                        SubtractTimes(sysUser, _prevSysUser);

                    UInt64 sysTotal = sysKernelDiff + sysUserDiff;

                    Int64 procTotal = procTime.Ticks - _prevProcTotal.Ticks;

                    if (sysTotal > 0)
                    {
                        _cpuUsage = (short)((100.0 * procTotal) / sysTotal);
                    }
                }

                _prevProcTotal = procTime;
                _prevSysKernel = sysKernel;
                _prevSysUser = sysUser;

                _lastRun = DateTime.Now;

                cpuCopy = _cpuUsage;
            }
            Interlocked.Decrement(ref _runCount);

            return cpuCopy;

        }

        private UInt64 SubtractTimes(ComTypes.FILETIME a, ComTypes.FILETIME b)
        {
            UInt64 aInt =
            ((UInt64)(a.dwHighDateTime << 32)) | (UInt64)a.dwLowDateTime;
            UInt64 bInt =
            ((UInt64)(b.dwHighDateTime << 32)) | (UInt64)b.dwLowDateTime;

            return aInt - bInt;
        }

        private bool EnoughTimePassed
        {
            get
            {
                const int minimumElapsedMS = 250;
                TimeSpan sinceLast = DateTime.Now - _lastRun;
                return sinceLast.TotalMilliseconds > minimumElapsedMS;
            }
        }

        private bool IsFirstRun
        {
            get
            {
                return (_lastRun == DateTime.MinValue);
            }
        }
    }
    class ProcessUsage
    {
        public Process process;
        public CpuUsage cpuUsage;
        public string processName;
        public PerformanceCounter memUsage;
        public ProcessUsage(Process proc)
        {
            process = proc;
            cpuUsage = new CpuUsage(this.process);
            processName = this.process.ProcessName + "_" + this.process.Id;
            memUsage = new PerformanceCounter("Process", "Working Set - Private", this.processName, true);
        }
    }
    public class ProcessHandler
    {

        #region local variables

        private bool _isProcessAlive = false;
        private LinkedList<ProcessUsage> selectedProcesses;
        private static Dictionary<string, string> browserMap = new Dictionary<string, string>();
        private string _browser;


        #endregion

        #region constructor

        public ProcessHandler()
        {
            if (browserMap.Count == 0)
            {
                browserMap.Add("IE", "iexplore");
                browserMap.Add("Chrome", "chrome");
            }

        }

        #endregion

        #region properties

        public bool IsProcessAlive
        {
            get
            {
                return this._isProcessAlive;
            }
        }


        #endregion

        #region methods

        private void setProcessStatus(bool status)
        {
            _isProcessAlive = status;
        }

        public object[] measure()
        {
            short currCPU = 0;
            float currMem = 0;
            bool flag = false;
            LinkedList<ProcessUsage>.Enumerator proc = selectedProcesses.GetEnumerator();
            while (proc.MoveNext())
            {
                if (!proc.Current.process.HasExited)
                {
                    short tempCPU = proc.Current.cpuUsage.GetUsage();
                    currCPU += tempCPU > 0 ? tempCPU : (short)0;
                    currMem += proc.Current.memUsage.NextValue();
                    flag = true;
                }
                
            }
            if (flag)
            {
                object[] arr = new object[2];
                arr[0] = (object)currCPU;
                arr[1] = (object)currMem;
                return arr;
            }
            else
            {
                return new object[2];
            }
           
        }

        public int createNewProcess(string browser, string url, bool privateBrowser)
        {
            selectedProcesses = new LinkedList<ProcessUsage>();

            bool isValidBrowser = browserMap.TryGetValue(browser, out _browser);

            LinkedList<int> pids = new LinkedList<int>();
            LinkedList<Process> newProcesses = new LinkedList<Process>();
            LinkedList<int> newpids = new LinkedList<int>();

            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName(_browser))
            {
               pids.AddLast(process.Id);
            }
            
            if (isValidBrowser)
            {
                Process newProcess = new Process();
                if (privateBrowser)
                {
                    string extraArg = "";
                    if(_browser == "iexplore")
                    {
                        extraArg = "-private ";
                    }
                    else if(_browser =="chrome")
                    {
                        extraArg = "--incognito ";
                    }
                    newProcess.StartInfo = new System.Diagnostics.ProcessStartInfo(_browser, extraArg + url);
                }
                else
                {
                    newProcess.StartInfo = new System.Diagnostics.ProcessStartInfo(_browser, url);
                }
                
                newProcess.Start();
                System.Threading.Thread.Sleep(1000);
                foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName(_browser))
                {
                   if (!pids.Contains(process.Id))
                   {
                       selectedProcesses.AddLast(new ProcessUsage(process));
                   }
                }
            }
            setProcessStatus(true);
            return 1;
        }

        #endregion
    }
}
