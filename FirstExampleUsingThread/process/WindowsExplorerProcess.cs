using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstExampleUsingThread.Base;

namespace FirstExampleUsingThread.Process
{
    public class WindowsExplorerProcess : ProcessBase
    {
        public override int Times { get; }
        public override State State { get; set; }
        public override string ProcessName { get; set; } = "explorer.exe";

        public WindowsExplorerProcess(int times)
        {
            Times = times;
        }
        public override void OpenProgram()
        {
            for (int i = 0; i < Times; i++)
            {
                System.Diagnostics.Process.Start("explorer.exe");
            }
        }
    }
}
