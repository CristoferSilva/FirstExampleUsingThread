using FirstExampleUsingThread.Semaphore;

namespace FirstExampleUsingThread.Base
{
    public abstract class ProcessBase
    {
        public abstract string ProcessName { get; set; }
        public abstract int Times { get; }
        public abstract State State { get; set; }
        public abstract void OpenProgram();

        public void Execute()
        {
            Thread thread = new Thread(this.Run);
            thread.Start();
        }

        private void Run()
        {
            OpenProgram();
            State = State.Finished;
            SemaphoreImplementation.UpProcess();
        }
    }
}