using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentalsFinalExam
{
    class Guest
    {
        public Guest(string name)
        {
            this.Name = name;
            this.Meals = new List<string>();
        }
        public string Name { get; set; }
        public ICollection<string> Meals { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {string.Join(", ", this.Meals)}";
        }
    }
    class NikuldenMeals
    {
        static void Main()
        {
            var guests = new Dictionary<string, Guest>();

            var commandLine = Console.ReadLine();

            var countUnlikedMeals = 0;

            while (commandLine != "Stop")
            {
                var commands = commandLine.Split('-');
                var name = commands[1];
                var meal = commands[2];

                switch (commands[0])
                {
                    case "Like":

                        if (!guests.ContainsKey(name))
                        {
                            guests[name] = new Guest(name);
                        }
                        if (!guests[name].Meals.Contains(meal))
                        {
                            guests[name].Meals.Add(meal);
                        }
                        break;
                    case "Unlike":
                        if (guests.ContainsKey(name))
                        {
                            if (guests[name].Meals.Remove(meal))
                            {
                                Console.WriteLine($"{name} doesn't like the {meal}.");
                                countUnlikedMeals++;
                            }
                            else
                            {
                                Console.WriteLine($"{name} doesn't have the {meal} in his/her collection.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{name} is not at the party.");
                        }
                        break;
                }

                commandLine = Console.ReadLine();
            }

            foreach (var guest in guests.OrderByDescending(x => x.Value.Meals.Count).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine(guest.Value);
            }

            Console.WriteLine($"Unliked meals: {countUnlikedMeals}");
        }
    }
}
