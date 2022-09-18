using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstExampleUsingThread.OlimpoSemaphore
{
    public class SemaphoreOlimpo
    {
        private Semaphore semaphore;

        public SemaphoreOlimpo()
        {
            semaphore = new Semaphore(0, 2);
        }
        
    }
}
