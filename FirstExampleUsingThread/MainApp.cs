using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstExampleUsingThread
{
    public class MainApp
    {
        public string OptionFromUser { get; set; } = string.Empty;
        public int Times { get; set; }
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
                    ExecuteNotepad();
                    break;
                case "E":
                    ExecuteWindowsExplorer();
                    break;
                case "I":
                    ExecuteInternetExplorer();
                    break;
                default:
                    Console.WriteLine("I didn't understand that! ARE YOU LEIGO?");
                    break;
            }
            return Task.CompletedTask;
        }
        private void OpenAllProgramWithoutThreads()
        {
            ExecuteNotepad();
            ExecuteWindowsExplorer();
            ExecuteInternetExplorer();
        }

        private void OpenAllProgramsUsingThreads()
        {
            Thread threadNotepad = new Thread(ExecuteNotepad);
            Thread threadWindowsExplorer = new Thread(ExecuteWindowsExplorer);
            Thread threadInternetExplorer = new Thread(ExecuteInternetExplorer);

            threadNotepad.Start();
            threadWindowsExplorer.Start();
            threadInternetExplorer.Start();
        }

        private void ExecuteInternetExplorer()
        {
            for (int i = 0; i < Times; i++)
            {
                Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe");
            }
        }

        private void ExecuteWindowsExplorer()
        {
            for (int i = 0; i < Times; i++)
            {
                Process.Start("explorer.exe");
            }
        }

        private void ExecuteNotepad()
        {
            for (int i = 0; i < Times; i++)
            {
                Process.Start("notepad.exe");
            }
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


    }
}
