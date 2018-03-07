using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Wizzard : Hero
    {
        ILogger logger = new LoggerConsole();

        public Wizzard(Team team) : base(team, 40, 8, 0, "Wizzard")
        {
            
        }

        public override string ToString()
        {
            return $"1.Can attack({Damage} damage)\n2.Can heal others(+50% HP)\n3.Can heal himself(+25% HP)";
        }

        public override void Turn(Team other)
        {
            int action = logger.Parse(1, 3, "Choose action: ");
            switch (action)
            {
                case 1:
                    Attack(other);
                    break;
                case 2:
                    HealOther(HisTeam);
                    break;
                case 3:
                    Healing();
                    break;
            }
        }
        
        private void HealOther(Team our)
        {
            int ourHeroesCount = our.ShowTeamHeroes();
            int target = logger.Parse(1, ourHeroesCount, "Choose target: ") - 1;
            our.Heroes[target].Healing(0.5);
        }
    }
}
