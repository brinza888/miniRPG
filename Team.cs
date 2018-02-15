using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Team
    {
        public string name { get; protected set; }
        List<Hero> team = new List<Hero>(capacity: 4);
        
        public List<Hero> getHeroes() { return team; }

        public Team(string name)
        {
          this.name = name;
          team.Add(new Wizzard(this));
          team.Add(new Defender(this));
          team.Add(new Swordsman(this));
          team.Add(new Knight(this));
        }

        public void removeFromTeam(Hero hero)
        {
            team.Remove(hero);
        }
        
        public void turn(Team other, Team our)
        {
            Console.WriteLine("{0} is making turn", name);
            int i = 1;
            foreach(Hero v in team)
            {
                Console.WriteLine(i +  "." + v.name);
                i++;
            }
            Console.Write("Choose hero: ");
            int hero = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine(team[hero].description);
            team[hero].turn(other, our);
            other.checkHeroes();
            checkHeroes();
        }

        private void checkHeroes()
        {
            foreach(Hero el in team.ToArray())
            {
                if (el.hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} из команды {1} убит!", el.name, name);
                    Console.ForegroundColor = ConsoleColor.White;
                    el.death();
                }
            }
        }

        public bool checkTeam()
        {
            if(team.Count < 1)
            {
                Console.WriteLine("Команда {0} проиграла!", name);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
