// See https://aka.ms/new-console-template for more information
using FirstExampleUsingThread;
using System.Diagnostics;


AppsManager mainApp = new AppsManager();
string optionFromUser = "";
Console.WriteLine("******** WELCOME TO OLIMPO PROGRAM MANAGER ********\n");

do
{
    mainApp.UserInterface();
    Console.WriteLine("Do you want repeat this program again? (Y/N)");
    optionFromUser = CheckerUserInput();

} while (optionFromUser.Equals("Y"));


static string CheckerUserInput()
{
    string optionFromUser = Console.ReadLine().ToUpper();

    while (!optionFromUser.Equals("N") && !optionFromUser.Equals("Y"))
    {
        Console.WriteLine("I didn't understand that! ARE YOU LEIGO?\n");
        Console.WriteLine("Do you want repeat this program again? (Y/N)\n");
        optionFromUser = Console.ReadLine().ToUpper();
    }

    return optionFromUser;
}