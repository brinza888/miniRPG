using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Message
    {
        public Type MessageColor { get; private set; }
        public string Text { get; private set; }

        public enum Type
        {
            DEATH = ConsoleColor.Red,
            TAKEDAMAGE = ConsoleColor.Yellow,
            LOSE = ConsoleColor.DarkRed,
            HEALING = ConsoleColor.Cyan,
            GETSHIELD = ConsoleColor.Green,
            TEXT = ConsoleColor.White,
            ERROR = ConsoleColor.DarkRed,
            HINT = ConsoleColor.Magenta
        }

        public Message(string msg, Type type = Type.TEXT)
        { 
            Text = msg;
            MessageColor = type;
        }
    }
}
