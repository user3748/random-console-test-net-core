using System;
using System.Threading;
using System.Reflection.Metadata.Ecma335;

namespace random_console_test_net_core
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo: eyecandy bool flags <<<<<<<<<<<<<<<<<<<<<<<<<<---------------------------------------
            bool showTextHighscoretrys = false;
            bool showTextLowscoretrys = false;
            //init Random()
            Random rnd = new Random();
            int wait = 1000;//seconds to wait between each try.

            //random lucky numbers
            int totalcalls = 0;
            int xyz = 0;
            int highscoretrys = 0;
            int lowscoretrys = 999999;
            //todo: make sure that x and y are two different numbers <<<<<<<<<<<<<<<<<<<<<<<<<<---------------------------------------
            int x = rnd.Next(1, 101);//generate value from 1(inclusive) to 100(inclusive) lucky number 1
            int y = rnd.Next(1, 101);//generate value from 1(inclusive) to 100(inclusive) lucky number 2
            while (true)
            {
                totalcalls++;
                //Console.WriteLine($"{xyz}");
                xyz++;
                //simulating 2 percent chance
                
                int a = rnd.Next(1, 101);//random number generated
                Console.WriteLine($"{totalcalls}try: {xyz} random number a: {a} lucky number x: {x} lucky number y: {y} least trys:{lowscoretrys} most trys:{highscoretrys}");
                if (a == x || a == y)
                {
                    if (xyz > highscoretrys)
                    {
                        highscoretrys = xyz;
                    }
                    if (xyz < lowscoretrys)
                    {
                        lowscoretrys = xyz;
                    }
                    Console.WriteLine($"random number a : {a} matched: x:{x} or y:{y} in {xyz} trys most trys:{highscoretrys}///least trys:{lowscoretrys}");
                    Console.WriteLine("Press any key to try again... Press Ctrl + C to exit this program.");
                    xyz = 0;//reset trys var because we want to start fresh
                }

                if(xyz == Int32.MaxValue - 1)
                {
                    Console.WriteLine($"Sorry but to prevent the program from crashing we need to stop the simulation now because we have reached the Int32 limit which is: {Int32.MaxValue}");
                    Console.WriteLine($"Press any key to restart the simulation...");
                    xyz = 0;//reset trys because we have reached the Int32.MaxValue
                }
                Thread.Sleep(wait);//Sleep for x milliseconds
            }
        }
    }
}
