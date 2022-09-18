using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstExampleUsingThread.process
{
    public class WindowsExplorerProcess
    {
        public int Times { get; }
        public Semaphore Semaphore { get; }

        public WindowsExplorerProcess(int times, Semaphore semaphore)
        {
            Times = times;
            Semaphore = semaphore;
        }
        public void ExecuteWindowsExplorer()
        {
            Semaphore.WaitOne();
            for (int i = 0; i < Times; i++)
            {
                Process.Start("explorer.exe");
            }
            Semaphore.Release();

        }
    }
}
