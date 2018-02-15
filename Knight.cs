using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Knight : Hero
    {
        public Knight(Team team) : base(team)
        {
            base.hp = 50;
            base.damage = 15;
            base.defence = 0;
            base.name = "Knight";
            base.description = "1.Can attack(15 damage)\n2.Can retreat(unpossible to damage)\n3.Can heal himself(+25% hp)";
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
                    retreat();
                    break;
                case 3:
                    healing();
                    break;
            }
        }

        public void retreat()
        {
            this.setProtection(1.0);
        }
    }
}
