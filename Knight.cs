using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Knight : Hero
    {
        ILogger logger = new LoggerConsole();

        public Knight(Team team) : base(team, 50, 15, 0, "Knight")
        {
            
        }

        public override string ToString()
        {
            return $"1.Can attack({Damage} damage)\n2.Can retreat(unpossible to damage)\n3.Can heal himself(+25% HP)";
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
                    Retreat();
                    break;
                case 3:
                    Healing();
                    break;
            }
        }

        public void Retreat()
        {
            Protection = 1.0;
        }
    }
}
