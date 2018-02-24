using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Defender : Hero
    {
        public Defender(Team team) : base(team)
        {
            base.Hp = 100;
            base.Damage = 8;
            base.Defence = 0.25;
            base.Name = "Defender";
            base.description = "1.Can attack(8 damage)\n2.Can protect friends(-25% damage)\n3.Can heal himself(+25% HP)\nIn passive use shield(-25% damage)";
        }

        public override void Turn(Team other, Team our)
        {
            int action = MyParser.Parse(1, 3);
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
            int target = MyParser.Parse(1,ourHeroesCount) - 1;
            our.Heroes[target].SetProtection(0.25);
        }
        
        public override void SetProtection(double value)
        {
            Console.WriteLine("Defender cant give shield for himself!");
        }
    }
}
