using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    interface ILogger
    {
        void Print(string output, string end = "\n");
        string Input(string hint = "");
        int Parse(int min, int max, string hint = "");
    }
}
