using System.Diagnostics;
using System.Threading;
using FirstExampleUsingThread.Base;

namespace FirstExampleUsingThread.Process
{
    public class InternetExplorerProcess : ProcessBase
    {
        public override int Times { get; }
        public override State State { get; set; }
        public override string ProcessName { get; set; } = "iexplore.exe";

        public InternetExplorerProcess(int times)
        {
            Times = times;
        }
        public override void OpenProgram()
        {
            for (int i = 0; i < Times; i++)
            {
                System.Diagnostics.Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe");
            }
        }
    }
}