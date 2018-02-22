using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Rpg
    {
        public static void Main(string[] args)
        {
            Team[] teams = { new Team("Red"), new Team("Green") };
            int now_turn = 0;
            
            while (!teams[0].IsLose && !teams[1].IsLose)
            {
                teams[now_turn].Turn(teams[(now_turn + 1) % 2], teams[now_turn]);
                now_turn = (now_turn + 1) % 2;
            }

            Console.Read();
        }
    }
}
