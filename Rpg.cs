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
            
            while (teams[0].checkTeam() && teams[1].checkTeam())
            {
                teams[now_turn].turn(teams[(now_turn + 1) % 2], teams[now_turn]);
                now_turn = (now_turn + 1) % 2;
            }

            Console.Read();
        }
    }
}
