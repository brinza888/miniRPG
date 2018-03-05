using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Team[] teams = { new Team("Red"), new Team("Green") };
            foreach (Team team in teams)
            {
                team.ChooseHeroes();
                Console.Clear();
            }

            int now_turn = 0;
            
            while (!teams[0].IsLose && !teams[1].IsLose)
            {
                int next_turn = (now_turn + 1) % 2;
                teams[now_turn].Turn(teams[next_turn], teams[now_turn]);
                now_turn = next_turn;
            }

            Console.Read();
        }
    }
}
