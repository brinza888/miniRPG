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
        protected string description;

        public Hero(Team team)
        {
            Team = team;
        }

        public override string ToString()
        {
            return description; // по-другому
        }
        
        public void Death()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} из команды {1} убит!", Name, Team.Name);
            Console.ForegroundColor = ConsoleColor.White;
            Team.Remove(this);
        }
        
        protected void Attack(Team other)
        {
            for (int i = 0; i < other.Heroes.Count; i++)
            {
                Console.WriteLine(i + 1 + "." + other.Heroes[i].Name);
                i++;
            }
            Console.Write("Choose target: ");
            int target = int.Parse(Console.ReadLine()) - 1;
            other.Heroes[target].TakeDamage(Damage);
        }

        public virtual void Turn(Team other, Team our)
        {
            Console.WriteLine(false);
        }
        
        public void TakeDamage(int damage)
        {
            damage -= Convert.ToInt32(damage * Defence);
            damage -= Convert.ToInt32(damage * Protection);
            Hp -= damage;
            Protection = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} from team {3} taked {1} damage.Now {0} has {2} hp", Name, Damage, Hp, Team.Name);
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
            Console.WriteLine("{0} from team {3} got {1} healing.Now {0} has {2}HP", Name, healCount, Hp, Team.Name);
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
