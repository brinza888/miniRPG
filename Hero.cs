using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    public class Hero
    {
        public int Hp { get; protected set; }
        public int Damage { get; protected set; }
        public double Defence { get; protected set; }
        public double Protection { get; protected set; }
        public string Name { get; protected set; }
        public Team Team { get; protected set; }

        ILogger logger = new LoggerConsole();

        public Hero(Team team, int hp, int damage, double defence, string name)
        {
            Hp = hp;
            Damage = damage;
            Defence = defence;
            Name = name;
            Team = team;
        }
        
        public void Death()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            logger.Print($"{Name} from team {Team.Name} killed!");
            Console.ForegroundColor = ConsoleColor.White;
            Team.Remove(this);
        }
        
        protected void Attack(Team other)
        {
            int otherHeroesCount = other.ShowTeamHeroes();
            int target = logger.Parse(1, otherHeroesCount, "Choose target: ") - 1;
            other.Heroes[target].TakeDamage(Damage);
        }

        public virtual void Turn(Team other, Team our)
        {
            // пустой метод
        }
        
        public void TakeDamage(int damage)
        {
            damage -= Convert.ToInt32(damage * Defence);
            damage -= Convert.ToInt32(damage * Protection);
            Hp -= damage;
            Protection = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            logger.Print($"{Name} from team {Team.Name} taked {damage} damage.Now {Name} has {Hp} HP");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public virtual void SetProtection(double value)
        {
            Protection = value;
        }
        
        public void Healing(double value = 0.25)
        {
            int healCount = Convert.ToInt32(Hp * value);
            Hp += healCount;

            Console.ForegroundColor = ConsoleColor.Cyan;
            logger.Print($"{Name} from team {Team.Name} got {healCount} healing.Now {Name} has {Hp} HP");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void CheckState()
        {
            if (Hp <= 0)
            {
                this.Death();
            }
        }
    }
}
