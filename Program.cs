using System;
using System.Threading;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace random_console_test_net_core
{
    class Program
    {
        public static int x = 0;
        public static int y = 0; 
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 150;
            bool showTextLowHighScore = false;
            //init Random()
            Random rnd = new Random();
            int wait = 1000;//seconds to wait between each try.
            //random lucky numbers
            int totalLoops = 0;
            int attempt = 0;
            int highscoretrys = 0;
            int lowscoretrys = 999999;
            while (true)
            {
                x = rnd.Next(1, 101);//generate value from 1(inclusive) to 100(inclusive) lucky number 1
                y = rnd.Next(1, 101);//generate value from 1(inclusive) to 100(inclusive) lucky number 2
                if (x != y)
                {
                    break;
                }
            }

            while (true)
            {
                totalLoops++;
                //Console.WriteLine($"{xyz}");
                attempt++;
                //simulating 2 percent chance
                
                int a = rnd.Next(1, 101);//random number generated
                if (showTextLowHighScore)
                {
                    //with lowest highest statistics
                    Console.WriteLine($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff")}{totalLoops}] | attempt: {attempt} | random number a: {a} | lucky number x: {x}\tlucky number y: {y} | least attempts:{lowscoretrys} most attempts:{highscoretrys}");
                }
                else
                {
                    //without lowest highest statistics
                    Console.WriteLine($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff")}{totalLoops}] | attempt: {attempt} | random number a: {a} | lucky number x: {x}\tlucky number y: {y}");
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
                    Console.WriteLine($"random number a : {a} matched: x:{x} or y:{y} in {attempt} attempts least attempts:{lowscoretrys} most attempts:{highscoretrys}");
                    Console.WriteLine("Press any key to try again... Press Ctrl + C to exit this program.");
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
        }
    }
}
