using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Defender : Hero
    {
        public Defender(Team team) : base(team)
        {
            base.hp = 100;
            base.damage = 8;
            base.defence = 0.25;
            base.name = "Defender";
            base.description = "1.Can attack(8 damage)\n2.Can protect friends(-25% damage)\n3.Can heal himself(+25% hp)\nIn passive use shield(-25% damage)";
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
                    protectOther(our);
                    break;
                case 3:
                    healing();
                    break;
            }
        }

        public void protectOther(Team our)
        {
            int i = 1;
            foreach (Hero el in our.getHeroes())
            {
                Console.WriteLine(i + " " + el.name);
                i++;
            }
            Console.Write("Choose target: ");
            int target = int.Parse(Console.ReadLine()) - 1;
            our.getHeroes()[target].setProtection(0.25);
        }
        
        public override void setProtection(double value)
        {
            Console.WriteLine("Defender cant give shield for himself!");
        }
    }
}
