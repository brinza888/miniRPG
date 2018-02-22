using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Wizzard : Hero
    {
        
        public Wizzard(Team team) : base(team)
        {
            base.Hp = 40;
            base.Damage = 8;
            base.Defence = 0;
            base.Name = "Wizzard";
            base.description = "1.Can attack(-8)\n2.Can heal others(+50%)\n3.Can heal himself(+25%)";
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
                    HealOther(our);
                    break;
                case 3:
                    Healing();
                    break;
            }
        }
        
        private void HealOther(Team our)
        {
            for (int i = 0; i < our.Heroes.Count; i++)
            {
                Console.WriteLine(i+1 + "." + our.Heroes[i].Name);
                i++;
            }
            Console.Write("Choose target: ");
            int target = MyParser.Parse(1, 4) - 1;
            our.Heroes[target].Healing(0.5);
        }
    }
}
