using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstExampleUsingThread.Base;

namespace FirstExampleUsingThread.Process
{
    public class NotepadProcess : ProcessBase
    {
        public override int Times { get; }
        public override State State { get; set; }
        public override string ProcessName { get; set; } = "notepad.exe";
        public NotepadProcess(int times)
        {
            Times = times;
        }
        public override void OpenProgram()
        {
            for (int i = 0; i < Times; i++)
            {
                System.Diagnostics.Process.Start("notepad.exe");
            }
        }
    }
}
