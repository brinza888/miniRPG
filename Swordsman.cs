using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Swordsman : Hero
    {
        public Swordsman(Team team) : base(team, 60, 15, 0, "Swordsman")
        {

        }

        public override string ToString()
        {
            return $"1.Can attack({Damage} damage)\n2.Can Upgrade Sword(+1 to damage)\n3.Can heal himself(+25% HP)";
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
                    UpgradeSword();
                    break;
                case 3:
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
