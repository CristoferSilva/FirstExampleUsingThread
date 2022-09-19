using FirstExampleUsingThread.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstExampleUsingThread.Semaphore
{
    public static class SemaphoreImplementation
    {
        public static Queue<ProcessBase> ProcessOnHoldQueue { get; set; }

        private static int processCountInExecution;
        public static int ProcessCountInExecution
        {
            get { return processCountInExecution; }
            set {  processCountInExecution = value; }
        }

        public static int MaxProcess { get; set; }

        public static void InitSemaphoreImplementation(int maxProcess)
        {
            ProcessOnHoldQueue = new Queue<ProcessBase>();
            MaxProcess = maxProcess;
        }
        public static void DownProcess(ProcessBase process)
        {
            if (processCountInExecution != MaxProcess)
            {
                ProcessCountInExecution++;
                process.State = State.Running; 
                process.Execute();
            }
            else
            {
                process.State = State.Waiting;
                ProcessOnHoldQueue.Enqueue(process);
            }
        }

        public static void UpProcess()
        {
            ProcessCountInExecution--;
            if (ProcessOnHoldQueue.Count > 0)
            {
                ProcessBase currentProcess = ProcessOnHoldQueue.Dequeue();
                currentProcess.State = State.Running;
                DownProcess(currentProcess);
            }
        }
    }
}
