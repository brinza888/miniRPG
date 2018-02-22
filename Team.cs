using System;
using System.Collections.Generic;
using System.Linq;


namespace RPG
{
    public class Team
    {
        public string Name { get; private set; }
        public List<Hero> Heroes { get; private set; }
        public bool IsLose { get; private set; }

        public Team(string name)
        {
            Heroes = new List<Hero>(capacity: 4);
            Name = name;
            IsLose = false;
            Heroes.Add(new Swordsman(this));
            Heroes.Add(new Knight(this));
            Heroes.Add(new Wizzard(this));
            Heroes.Add(new Defender(this));
        }

        public void Remove(Hero hero)
        {
            Heroes.Remove(hero);
        }
        
        public void Turn(Team other, Team our)
        {
            Console.WriteLine("{0} is making turn", Name);
            for (int i = 0; i < Heroes.Count; i++)
            {
                Console.WriteLine(i+1 + "." + Heroes.ToArray()[i].Name);
            }
            Console.Write("Choose hero: ");
            int hero = MyParser.Parse(1, 4) - 1;
            Console.WriteLine(Heroes[hero].ToString());
            Console.Write("Choose action: ");
            Heroes[hero].Turn(other, our);
            other.CheckState();
            CheckState();
        }

        public void CheckState() 
        {
            foreach (Hero el in Heroes.ToArray())
            {
                el.CheckState();
            }

            if(Heroes.Count < 1)
            {
                Console.WriteLine("Команда {0} проиграла!", Name);
                IsLose = true;
            }
        }
    }
}
