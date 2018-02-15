using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    public class Hero
    {
        public int hp { get; protected set; }
        protected int damage;
        protected double defence;
        protected double protection = 0;
        public string name { get; protected set; }
        public Team team { get; protected set; }
        public string description { get; protected set; }
        
        public void death()
        {
            team.removeFromTeam(this);
        }
        
        public Hero(Team team)
        {
            this.team = team;
            description = "NoDescription";
            name = "NoName";
        }
        
        protected void attack(Team other)
        {
            int i = 1;
            foreach (Hero el in other.getHeroes())
            {
                Console.WriteLine("{0}.{1} ({2} hp)", i, el.name, el.hp);
                i++;
            }
            Console.Write("Choose target: ");
            int target = int.Parse(Console.ReadLine()) - 1;
            other.getHeroes()[target].takeDamage(damage);
        }

        public virtual void turn(Team other, Team our)
        {
            Console.WriteLine(false);
        }
        
        public void takeDamage(int damage)
        {
            damage -= Convert.ToInt32(damage * defence);
            damage -= Convert.ToInt32(damage * protection);
            hp -= damage;
            protection = 0;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} from team {3} taked {1} damage.Now {0} has {2} hp", name, damage, hp, team.name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public virtual void setProtection(double value)
        {
            protection = value;
        }
        
        public void healing(double value = 0.25)
        {
            int healCount = Convert.ToInt32(hp * value);
            hp += healCount;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} from team {3} got {1} healing.Now {0} has {2}HP", name, healCount, hp, team.name);
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected int chooseAction()
        {
            int action;
            do
            {
                Console.Write("Choose ability: ");
                action = int.Parse(Console.ReadLine());
            } while (action > 3 || action < 1);
            return action;
        }
    }
}
