using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstExampleUsingThread.process
{
    public class NotepadProcess
    {
        public int Times { get; }
        public Semaphore Semaphore { get; }

        public NotepadProcess(int times, Semaphore semaphore)
        {
            Times = times;
            Semaphore = semaphore;
        }

        public void ExecuteNotepad()
        {
            Semaphore.WaitOne();
            for (int i = 0; i < Times; i++)
            {
                Process.Start("notepad.exe");
            }
            Semaphore.Release();
        }
    }
}
