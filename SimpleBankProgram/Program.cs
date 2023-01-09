using System;

namespace SimpleBankProgram
{
    public class SimpleBank
    {
        static void Main(string[] args)
        {
            // To keep program open while debugging
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
            }
        }
    }
}
