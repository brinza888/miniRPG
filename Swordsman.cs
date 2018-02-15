using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Swordsman : Hero
    {
        public Swordsman(Team team) : base(team)
        {
            base.damage = 20;
            base.defence = 0;
            base.hp = 60;
            base.name = "Swordsman";
            base.description = "1.Can attack(15 damage)\n2.Can heal himself(+25% hp).3.Upgrade Sword(damage +1)";
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
                    healing();
                    break;
            }
        }
        public void upgradeSword()
        {
            damage += 1;
        }
    }
}
