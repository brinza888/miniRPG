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
            Message msg = new Message(hint, Message.Type.HINT);
            Print(msg, false);
            return Console.ReadLine();
        }

        public void Print(Message msg, bool newLine = true)
        {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = (ConsoleColor) msg.MessageColor;

            if (newLine)
                Console.WriteLine(msg.Text);
            else
                Console.Write(msg.Text);

            Console.ForegroundColor = previous;
        }

        public int Parse(int min, int max, string hint = "")
        {
            int parsedValue;
            while (!int.TryParse(Input(hint), out parsedValue) || parsedValue < min || parsedValue > max)
            {
                Message msg = new Message($"Use integer number from {min} to {max}!", Message.Type.ERROR);
                Print(msg);
            }
            return parsedValue;
        }
    }
}
