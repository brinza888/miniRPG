using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class LoggerConsole : ILogger
    {
        public string Input(string hint = "")
        {
            Print(hint, end: "");
            return Console.ReadLine();
        }

        public void Print(string output, string end = "\n")
        {
            Console.Write(output + end);
        }

        public int Parse(int min, int max)
        {
            int parsedValue;
            while (!int.TryParse(Input(), out parsedValue) || parsedValue < min || parsedValue > max)
            {
                Print($"Use number from {min} to {max}");
            }
            return parsedValue;
        }
    }
}
