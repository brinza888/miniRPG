using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    public abstract class Hero
    {
        public int Hp { get; protected set; }
        public int Damage { get; protected set; }
        public double Defence { get; protected set; }
        private double _protection;
        public double Protection
        {
            get
            {
                return _protection;
            }
            set
            {
                _protection = value;
                Message msg = new Message($"{Name} from team {HisTeam.Name} got -{value * 100}% damage for next turn" , Message.Type.GETSHIELD);
                logger.Print(msg);
            }
        }
        public string Name { get; protected set; }
        public Team HisTeam { get; protected set; }

        ILogger logger = new LoggerConsole();

        public Hero(Team team, int hp, int damage, double defence, string name)
        {
            Hp = hp;
            Damage = damage;
            Defence = defence;
            Name = name;
            HisTeam = team;
            _protection = 0.0;
        }
        
        public void Death()
        {
            Message msg = new Message($"{Name} from team {HisTeam.Name} killed!", Message.Type.DEATH);
            logger.Print(msg);
            HisTeam.Remove(this);
        }
        
        protected void Attack(Team other)
        {
            int otherHeroesCount = other.ShowTeamHeroes();
            int target = logger.Parse(1, otherHeroesCount, "Choose target: ") - 1;
            other.Heroes[target].TakeDamage(Damage);
        }

        public abstract void Turn(Team other);    
        
        public void TakeDamage(int damage)
        {
            damage -= Convert.ToInt32(damage * Defence);
            damage -= Convert.ToInt32(damage * _protection);
            Hp -= damage;
            _protection = 0;

            Message msg = new Message($"{Name} from team {HisTeam.Name} taked {damage} damage.Now {Name} has {Hp} HP", Message.Type.TAKEDAMAGE);
            logger.Print(msg);
        }
        
        public void Healing(double value = 0.25)
        {
            int healCount = Convert.ToInt32(Hp * value);
            Hp += healCount;

            Message msg = new Message($"{Name} from team {HisTeam.Name} got {healCount} healing.Now {Name} has {Hp} HP", Message.Type.HEALING);
            logger.Print(msg);
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
