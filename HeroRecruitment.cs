using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentalsFinalExam
{
    class Hero
    {
        public Hero(string name)
        {
            this.Name = name;
            this.Spellbook = new List<string>();
        }
        public string Name { get; set; }
        public List<string> Spellbook { get; set; }

        public override string ToString()
        {
            return $"== {this.Name}: {string.Join(", ", this.Spellbook)}";
        }
    }
    class HeroRecruitment
    {
        static void Main()
        {
            var heros = new Dictionary<string, Hero>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var data = input.Split();

                var command = data[0];

                switch (command)
                {
                    case "Enroll":
                        var heroName = data[1];

                        if (heros.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} is already enrolled.");
                        }
                        else
                        {
                            var hero = new Hero(heroName);
                            heros[heroName] = hero;
                        }
                        break;

                    case "Learn":

                        var heroToLearn = data[1];
                        var spellName = data[2];

                        if (!heros.ContainsKey(heroToLearn))
                        {
                            Console.WriteLine($"{heroToLearn} doesn't exist.");
                            break;
                        }

                        if (heros[heroToLearn].Spellbook.Contains(spellName))
                        {
                            Console.WriteLine($"{heroToLearn} has already learnt {spellName}.");
                            break;
                        }

                        heros[heroToLearn].Spellbook.Add(spellName);

                        break;

                    case "Unlearn":

                        var heroToUnlearn = data[1];
                        var spellNameToRemove = data[2];

                        if (!heros.ContainsKey(heroToUnlearn))
                        {
                            Console.WriteLine($"{heroToUnlearn} doesn't exist.");
                            break;
                        }

                        if (!heros[heroToUnlearn].Spellbook.Contains(spellNameToRemove))
                        {
                            Console.WriteLine($"{heroToUnlearn} doesn't know {spellNameToRemove}.");
                            break;
                        }

                        heros[heroToUnlearn].Spellbook.Remove(spellNameToRemove);

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Heroes:");

            foreach (var hero in heros.Values.OrderByDescending(x => x.Spellbook.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine(hero);
            }
        }
    }
}
