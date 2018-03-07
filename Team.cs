using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Team
    {
        public string Name { get; private set; }
        public List<Hero> Heroes { get; private set; }
        public bool IsLose
        {
            get
            {
                if (Heroes.Count < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        ILogger logger = new LoggerConsole();

        public Team(string name)
        {
            Heroes = new List<Hero>(capacity: 4);
            Name = name;
        }

        public void Remove(Hero hero)
        {
            Heroes.Remove(hero);
        }

        public void ChooseHeroes()
        {
            Message msg1 = new Message($"{Name} is choosing heroes!");
            logger.Print(msg1);
            for (int i = 0; i < 4; i++)
            {
                Message heroes = new Message("1.Swordsman\n2.Knight\n3.Defender\n4.Wizzard");
                logger.Print(heroes);
                int hero = logger.Parse(1, 4, $"Choose {i + 1} hero: ");
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
        
        public void Turn(Team other)
        {
            Message msg = new Message($"{Name} is making turn");
            logger.Print(msg);
            ShowTeamHeroes();

            int hero = logger.Parse(1, 4, "Choose hero: ") - 1;
            Message heroMsg = new Message(Heroes[hero].ToString());
            logger.Print(heroMsg);
            Heroes[hero].Turn(other);

            other.CheckTeam();
            CheckTeam();
        }

        public int ShowTeamHeroes()
        {
            for (int i = 0; i < Heroes.Count; i++)
            {
                Message msg = new Message($"{i + 1}.{Heroes[i].Name} ({Heroes[i].Hp} HP)");
                logger.Print(msg);
            }

            return Heroes.Count;
        }

        public void CheckTeam() 
        {
            foreach (Hero el in Heroes.ToArray())
            {
                el.CheckState();
            }
        }
    }
}
