using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Defender : Hero
    {
        LoggerConsole logger = new LoggerConsole();

        public Defender(Team team) : base(team, 100, 8, 0.25, "Defender")
        {

        }

        public override string ToString()
        {
            return $"1.Can attack({Damage} damage)\n2.Can protect friends(-25% damage)\n3.Can heal himself(+25% HP)\nIn passive use shield({Protection * 100}% damage)";
        }

        public override void Turn(Team other, Team our)
        {
            int action = logger.Parse(1, 3);
            switch (action)
            {
                case 1:
                    Attack(other);
                    break;
                case 2:
                    ProtectOther(our);
                    break;
                case 3:
                    Healing();
                    break;
            }
        }

        private void ProtectOther(Team our)
        {
            int ourHeroesCount = our.ShowTeamHeroes();
            Console.Write("Choose target: ");
            int target = logger.Parse(1,ourHeroesCount) - 1;
            our.Heroes[target].SetProtection(0.25);
        }
        
        public override void SetProtection(double value)
        {
            Console.WriteLine("Defender cant give shield for himself!");
        }
    }
}
