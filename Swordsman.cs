using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Swordsman : Hero
    {
        public Swordsman(Team team) : base(team) // поменять конструтор
        {
            base.Damage = 15;
            base.Defence = 0;
            base.Hp = 60;
            base.Name = "Swordsman";
            base.description = "1.Can attack(15 damage)\n2.Can heal himself(+25% HP).3.Upgrade Sword(damage +1)";
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
                    Healing();
                    break;
            }
        }
        public void UpgradeSword()
        {
            Damage += 1;
        }
    }
}
