using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstExampleUsingThread.Semaphore;
using FirstExampleUsingThread.Process;

namespace FirstExampleUsingThread
{
    public class AppsManager
    {
        private InternetExplorerProcess internetExplorerProcess;
        private WindowsExplorerProcess windowsExplorerProcess;
        private NotepadProcess notepadProcess;

        public string OptionFromUser { get; set; } = string.Empty;
        public int Times { get; set; }

        public AppsManager()
        {
            SemaphoreImplementation.InitSemaphoreImplementation(2);
        }
        private async Task CallAppsAndCountTheTime()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            await LaunchApps();
            stopwatch.Stop();
            PrintTimeSpan(stopwatch);
        }
        private static void PrintInitOptionToUser() => Console.Write("How much times will your program run? ");
        public async void UserInterface()
        {
            PrintInitOptionToUser();

            Times = int.Parse(Console.ReadLine());

            InitializeProcessInstances(Times);

            PrintOptionsMenuToUser();

            OptionFromUser = Console.ReadLine().ToUpper();

            await CallAppsAndCountTheTime();
        }

        public Task LaunchApps()
        {
            switch (OptionFromUser)
            {
                case "AT":
                    OpenAllProgramsUsingThreads();
                    break;
                case "AN":
                    OpenAllProgramWithoutThreads();
                    break;
                case "N":
                    notepadProcess.Execute();
                    break;
                case "E":
                    windowsExplorerProcess.Execute();
                    break;
                case "I":
                    internetExplorerProcess.Execute();
                    break;
                default:
                    Console.WriteLine("I didn't understand that! ARE YOU LEIGO?");
                    break;
            }
            return Task.CompletedTask;
        }
        private void OpenAllProgramWithoutThreads()
        {
            notepadProcess.Execute();
            windowsExplorerProcess.Execute();
            internetExplorerProcess.Execute();
        }

        private void OpenAllProgramsUsingThreads()
        {
            SemaphoreImplementation.DownProcess(notepadProcess);
            SemaphoreImplementation.DownProcess(windowsExplorerProcess);
            SemaphoreImplementation.DownProcess(internetExplorerProcess);
        }

        private void PrintTimeSpan(Stopwatch stopwatch)
        {
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("RunTime " + ts.TotalSeconds);
        }
        private static void PrintOptionsMenuToUser()
        {
            Console.WriteLine("\n~Choose the program you want to open:\n");
            Console.WriteLine("  type N to -> notepad");
            Console.WriteLine("  type E to -> explorer");
            Console.WriteLine("  type I to -> Internet Explorer");
            Console.WriteLine("  type AT to -> All programs using threads through semaphore");
            Console.WriteLine("  type AN to -> All programs without threads");
        }

        private void InitializeProcessInstances(int times)
        {
            this.internetExplorerProcess = new InternetExplorerProcess(times);
            this.windowsExplorerProcess = new WindowsExplorerProcess(times);
            this.notepadProcess = new NotepadProcess(times);
        }
    }
}
