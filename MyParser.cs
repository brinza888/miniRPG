using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    static class MyParser
    {
        public static int Parse(int min, int max)
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a < min || a > max)
            {
                Console.WriteLine("Use number!");
            }
            return a;
        }
    }
}
