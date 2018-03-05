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

        ILogger logger = new LoggerConsole();

        public Team(string name)
        {
            Heroes = new List<Hero>(capacity: 4);
            Name = name;
            IsLose = false;
        }

        public void Remove(Hero hero)
        {
            Heroes.Remove(hero);
        }

        public void ChooseHeroes()
        {
            logger.Print($"{Name} is choosing heroes!");
            for (int i = 0; i < 4; i++)
            {
                logger.Print($"Choose {i + 1} hero");
                logger.Print("1.Swordsman\n2.Knight\n3.Defender\n4.Wizzard");
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
            logger.Print($"{Name} is making turn");
            ShowTeamHeroes();

            int hero = logger.Parse(1, 4, "Choose hero: ") - 1;
            logger.Print(Heroes[hero].ToString());
            Heroes[hero].Turn(other, our);

            other.CheckTeam();
            CheckTeam();
        }

        public int ShowTeamHeroes()
        {
            for (int i = 0; i < Heroes.Count; i++)
            {
                logger.Print($"{i + 1}.{Heroes[i].Name} ({Heroes[i].Hp} HP)");
            }

            return Heroes.Count;
        }

        public void CheckTeam() 
        {
            foreach (Hero el in Heroes)
            {
                el.CheckState();
            }

            if(Heroes.Count < 1)
            {
                logger.Print($"Team {Name} losed!");
                IsLose = true;
            }
        }
    }
}
