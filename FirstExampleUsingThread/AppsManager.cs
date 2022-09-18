using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstExampleUsingThread.process;

namespace FirstExampleUsingThread
{
    public class AppsManager
    {
        private Semaphore semaphore;
        private InternetExplorerProcess internetExplorerProcess;
        private WindowsExplorerProcess windowsExplorerProcess;
        private NotepadProcess notepadProcess;

        public string OptionFromUser { get; set; } = string.Empty;
        public int Times { get; set; }

        public AppsManager()
        {
            semaphore = new Semaphore(0, 2);
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

            InitializeProcessInstances(Times, semaphore);

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
                    notepadProcess.ExecuteNotepad();
                    break;
                case "E":
                    windowsExplorerProcess.ExecuteWindowsExplorer();
                    break;
                case "I":
                    internetExplorerProcess.ExecuteInternetExplorer();
                    break;
                default:
                    Console.WriteLine("I didn't understand that! ARE YOU LEIGO?");
                    break;
            }
            return Task.CompletedTask;
        }
        private void OpenAllProgramWithoutThreads()
        {
            notepadProcess.ExecuteNotepad();
            windowsExplorerProcess.ExecuteWindowsExplorer();
            internetExplorerProcess.ExecuteInternetExplorer();
        }

        private void OpenAllProgramsUsingThreads()
        {
            Thread threadNotepad = new Thread(notepadProcess.ExecuteNotepad);
            Thread threadWindowsExplorer = new Thread(windowsExplorerProcess.ExecuteWindowsExplorer);
            Thread threadInternetExplorer = new Thread(internetExplorerProcess.ExecuteInternetExplorer);

            threadNotepad.Start();
            threadWindowsExplorer.Start();
            threadInternetExplorer.Start();

            Console.WriteLine(semaphore.Release(1));


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
            Console.WriteLine("  type AT to -> All programs using threads");
            Console.WriteLine("  type AN to -> All programs without threads");
        }

        private void InitializeProcessInstances(int times, Semaphore semaphore)
        {
            this.internetExplorerProcess = new InternetExplorerProcess(times, semaphore);
            this.windowsExplorerProcess = new WindowsExplorerProcess(times, semaphore);
            this.notepadProcess = new NotepadProcess(times, semaphore);
        }
    }
}
