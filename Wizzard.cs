using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Wizzard : Hero
    {
        
        public Wizzard(Team team) : base(team)
        {
            base.hp = 40;
            base.damage = 8;
            base.defence = 0;
            base.name = "Wizzard";
            base.description = "1.Can attack(-8)\n2.Can heal others(+50%)\n3.Can heal himself(+25%)";
        }

        public override void turn(Team other, Team our)
        {
            int action = chooseAction();
            switch (action)
            {
                case 1:
                    attack(other);
                    break;
                case 2:
                    healOther(our);
                    break;
                case 3:
                    healing();
                    break;
            }
        }
        
        public void healOther(Team our)
        {
            int i = 1;
            foreach (Hero el in our.getHeroes())
            {
                Console.WriteLine(i + "." + el.name);
                i++;
            }
            Console.Write("Choose target: ");
            int target = int.Parse(Console.ReadLine()) - 1;
            our.getHeroes()[target].healing(0.5);
        }
    }
}
