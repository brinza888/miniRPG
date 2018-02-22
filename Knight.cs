using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Knight : Hero
    {
        public Knight(Team team) : base(team)
        {
            base.Hp = 50;
            base.Damage = 15;
            base.Defence = 0;
            base.Name = "Knight";
            base.description = "1.Can attack(15 damage)\n2.Can retreat(unpossible to damage)\n3.Can heal himself(+25% hp)";
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
                    Retreat();
                    break;
                case 3:
                    Healing();
                    break;
            }
        }

        public void Retreat()
        {
            this.SetProtection(1.0);
        }
    }
}
