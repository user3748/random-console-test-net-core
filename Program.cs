using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace random_console_test_net_core
{
    class Program
    {
        //Console Output Interval: Do program tasks in the background and only print a status update every x seconds
        //formatting https://docs.microsoft.com/de-de/dotnet/standard/base-types/composite-formatting
        //string formatting 1: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
        //string formatting 2: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
        public static int x = 0;
        public static int y = 0;
        public static int programRuntimeInSeconds = 0;
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 170;
            bool showTextLowHighScore = false;
            //init Random()
            Random rnd = new Random();
            int wait = 0;//seconds to wait between each try.
            //random lucky numbers
            int totalLoops = 0;
            int attempt = 0;
            int highscoretrys = 0;
            int lowscoretrys = 999999;
            //init timer: https://stackoverflow.com/questions/186084/how-do-you-add-a-timer-to-a-c-sharp-console-application
            Timer t = new Timer(TimerCallback, null, 0, 1000);

            //Ask the user for settings
            Console.WriteLine("Please enter ... settings ...");

            while (true)
            {
                x = rnd.Next(1, 101);//generate value from 1(inclusive) to 100(inclusive) lucky number 1
                y = rnd.Next(1, 101);//generate value from 1(inclusive) to 100(inclusive) lucky number 2
                if (x != y)
                {
                    Console.WriteLine($"x != y GOOD");
                    break;
                }
                if (x == y)
                {
                    Console.WriteLine($"found x:{x} = y:{y} NOT GOOD trying again.");
                }
            }

            while (true)
            {
                totalLoops++;
                //Console.WriteLine($"{xyz}");
                attempt++;
                //simulating 2 percent chance
                
                int a = rnd.Next(1, 101);//random number generated
                if (showTextLowHighScore)//for eye candy
                {
                    //with lowest highest statistics
                    Console.WriteLine($"\r[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff")}][{totalLoops}][{programRuntimeInSeconds}][attempt: {attempt:D5}][r. number a: {a:D3}][lucky x: {x:D3}][lucky y: {y:D3}][least:{lowscoretrys}][most:{highscoretrys}]");
                }
                else
                {
                    //without lowest highest statistics
                    Console.WriteLine($"\r[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff")}][{totalLoops}][{programRuntimeInSeconds}][attempt: {attempt:D5}][r. number a: {a:D3}][lucky x: {x:D3}][lucky y: {y:D3}]");
                }
                if (a == x || a == y)
                {
                    showTextLowHighScore = true;
                    if (attempt > highscoretrys)
                    {
                        highscoretrys = attempt;
                    }
                    if (attempt < lowscoretrys)
                    {
                        lowscoretrys = attempt;
                    }

                    Console.WriteLine($"\r[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff")}][{totalLoops}][{programRuntimeInSeconds}][attempt: {attempt:D5}][r. number a: {a:D3}][lucky x: {x:D3}][lucky y: {y:D3}][least:{lowscoretrys}][most:{highscoretrys}][r number a : {a} matched: x:{x} or y:{y} in {attempt} attempts Ctrl + C to exit this program.]");
                    //Thread.Sleep(5000);//5000 for test
                    attempt = 0;//reset attempts var because we want to start fresh
                }

                //exception handling
                if(attempt == Int32.MaxValue - 1)
                {
                    Console.WriteLine($"Sorry but to prevent the program from crashing we need to stop the simulation now because we have reached the Int32 limit which is: {Int32.MaxValue}");
                    Console.WriteLine($"Press any key to restart the simulation...");
                    attempt = 0;//reset attempts because we have reached the Int32.MaxValue
                }
                Thread.Sleep(wait);//Sleep for x milliseconds
            }
            static void TimerCallback(Object o)
            {
                programRuntimeInSeconds++;
            }
        }
    }
}
