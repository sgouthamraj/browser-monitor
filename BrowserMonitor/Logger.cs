using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BrowserMonitor
{
    class LogEntry
    {
        private string _logTime;
        private short _cpuUsage;
        private float _memoryUsage;

        public LogEntry(short cpuUsage, float memoryUsage)
        {
            _logTime = DateTime.Now.ToLongDateString() + "_" + DateTime.Now.ToLongTimeString();
            _cpuUsage = cpuUsage;
            _memoryUsage = memoryUsage;
        }

        public short CpuUsage 
        {
            get
            {
                return this._cpuUsage;
            }
            set
            {
                this._cpuUsage = value;
            }
        }
        public float MemoryUsage
        {
            get
            {
                return this._memoryUsage;
            }
            set
            {
                this._memoryUsage = value;
            }
        }
        public string LogTime
        {
            get
            {
                return this._logTime;
            }
        }
    }
    
    public class Logger
    {

        private LinkedList<LogEntry> _logger; 

        private string _url, _browser;

        public Logger()
        {
            _logger = new LinkedList<LogEntry>();
            _url = "";
            _browser = "";
        }

        public Logger(string url, string browser)
        {
            _logger = new LinkedList<LogEntry>();
            _url = url;
            _browser = browser;
        }

        public void persistLog()
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BrowserMonitor";
            
            try
            {
                // Determine whether the directory exists. 
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(path + "\\log_" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss-tt") + ".log");
                sw.WriteLine("Browser\t\t=>\t" + _browser);
                sw.WriteLine("URL\t\t=>\t" + _url);
                sw.WriteLine("================================================================");
                LinkedList<LogEntry>.Enumerator i = _logger.GetEnumerator();
                while (i.MoveNext())
                {
                    sw.WriteLine(i.Current.LogTime + " => " + i.Current.CpuUsage + "\t" + i.Current.MemoryUsage);
                }
                sw.WriteLine("================================================================");
                sw.Close();
                this.clearLogs();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

            
        }

        public void addLogEntry(short cpuUsage, float memoryUsage)
        {
            this._logger.AddLast(new LogEntry(cpuUsage, memoryUsage));
        }

        public void clearLogs()
        {
            this._logger.Clear();
        }
    }
}
