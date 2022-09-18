using System.Diagnostics;
using System.Threading;

namespace FirstExampleUsingThread.process
{
    public class InternetExplorerProcess
    {
        public int Times { get; }
        public Semaphore Semaphore { get; set; }

        public InternetExplorerProcess(int times, Semaphore semaphore)
        {
            Times = times;
            Semaphore = semaphore;
        }
        public void ExecuteInternetExplorer()
        {
            Semaphore.WaitOne();
            for (int i = 0; i < Times; i++)
            {
                Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe");
            }
            Semaphore.Release();
        }
    }
}