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
            base.description = "1.Can attack(8 damage)\n2.Can protect friends(-25% damage)\n3.Can heal himself(+25% hp)\nIn passive use shield(-25% damage)";
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
            for (int i = 0; i < our.Heroes.Count; i++)
            {
                Console.WriteLine(i + 1 + "." + our.Heroes[i].Name);
                i++;
            }
            Console.Write("Choose target: ");
            int target = int.Parse(Console.ReadLine()) - 1;
            our.Heroes[target].SetProtection(0.25);
        }
        
        public override void SetProtection(double value)
        {
            Console.WriteLine("Defender cant give shield for himself!");
        }
    }
}
