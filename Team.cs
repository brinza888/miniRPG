using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Team
    {
        public string Name { get; private set; }
        public List<Hero> Heroes { get; private set; }
        public bool IsLose { get; private set; }

        LoggerConsole logger = new LoggerConsole();

        public Team(string name)
        {
            Heroes = new List<Hero>(capacity: 4);
            Name = name;
            IsLose = false;
            /*Heroes.Add(new Swordsman(this));
            Heroes.Add(new Knight(this));
            Heroes.Add(new Wizzard(this));
            Heroes.Add(new Defender(this));*/
        }

        public void Remove(Hero hero)
        {
            Heroes.Remove(hero);
        }

        public void ChooseHeroes()
        {
            Console.WriteLine($"{Name} is choosing heroes!");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Choose {i + 1} hero");
                Console.WriteLine("1.Swordsman\n2.Knight\n3.Defender\n4.Wizzard");
                int hero = logger.Parse(1, 4);
                switch (hero)
                {
                    case 1:
                        Heroes.Add(new Swordsman(this));
                        break;
                    case 2:
                        Heroes.Add(new Knight(this));
                        break;
                    case 3:
                        Heroes.Add(new Defender(this));
                        break;
                    case 4:
                        Heroes.Add(new Wizzard(this));
                        break;
                }
            }
            
        }
        
        public void Turn(Team other, Team our)
        {
            Console.WriteLine($"{Name} is making turn");
            ShowTeamHeroes();
            Console.Write("Choose hero: ");
            int hero = logger.Parse(1, 4) - 1;
            Console.WriteLine(Heroes[hero].ToString());
            Console.Write("Choose action: ");
            Heroes[hero].Turn(other, our);
            other.CheckState();
            CheckState();
        }

        public int ShowTeamHeroes()
        {
            for (int i = 0; i < Heroes.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{Heroes.ToArray()[i].Name} ({Heroes.ToArray()[i].Hp} HP)");
            }

            return Heroes.Count;
        }

        public void CheckState() 
        {
            foreach (Hero el in Heroes.ToArray())
            {
                el.CheckState();
            }

            if(Heroes.Count < 1)
            {
                Console.WriteLine($"Team {Name} losed!");
                IsLose = true;
            }
        }
    }
}
