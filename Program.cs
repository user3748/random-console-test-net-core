using System;
using System.Threading;
using System.Reflection.Metadata.Ecma335;

namespace random_console_test_net_core
{
    class Program
    {
        static void Main(string[] args)
        {
            //init Random()
            Random rnd = new Random();
            int trys = 0;
            int wait = 1000;//seconds to wait between each try.

            //random lucky numbers
            int x = rnd.Next(1, 101);//generate value from 1(inclusive) to 100(inclusive) lucky number 1
            int y = rnd.Next(1, 101);//generate value from 1(inclusive) to 100(inclusive) lucky number 2
            while (true)
            {
                trys++;
                //simulating 2 percent chance
                
                int a = rnd.Next(1, 101);//random number generated
                Console.WriteLine($"try: {trys} random number a: {a} lucky number x: {x} lucky number y: {y}");
                if (a == x || a == y)
                {
                    Console.WriteLine($"random number a : {a} matched: x:{x} or y:{y} in {trys} trys");
                    Console.WriteLine("Press any key to try again... Press Ctrl + C to exit this program.");
                    Console.ReadKey();
                    trys = 0;//reset trys var because we want to start fresh
                }

                if(trys >= Int32.MaxValue)
                {
                    Console.WriteLine($"Sorry but to prevent the program from crashing we need to stop the simulation now because we have reached the Int32 limit which is: {Int32.MaxValue}");
                    Console.WriteLine($"Press any key to restart the simulation...");
                    trys = 0;//reset trys because we have reached the Int32.MaxValue
                }
                Thread.Sleep(wait);//Sleep for x milliseconds
            }
        }
    }
}
