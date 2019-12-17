using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundamentalsFinalExam
{
    class PracticeSessions
    {
        static void Main()
        {
            var roads = new Dictionary<string, Road>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var commands = input.Split("->", StringSplitOptions.RemoveEmptyEntries);

                var roadName = commands[1];
                var racerName = string.Empty;

                switch (commands[0])
                {
                    case "Add":
                        racerName = commands[2];
                        if (!roads.ContainsKey(roadName))
                        {
                            roads[roadName] = new Road(roadName);
                        }
                        //if (!roads[roadName].Racers.Contains(racerName))
                        //{
                        roads[roadName].Racers.Add(racerName);
                        //}
                        break;
                    case "Move":
                        racerName = commands[2];
                        var nextRoad = commands[3];
                        if (roads[roadName].Racers.Contains(racerName))
                        {
                            roads[nextRoad].Racers.Add(racerName);
                            roads[roadName].Racers.Remove(racerName);
                        }
                        break;
                    case "Close":
                        if (roads.ContainsKey(roadName))
                        {
                            roads.Remove(roadName);
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Practice sessions:");

            //foreach (var road in roads.Values.OrderByDescending(x => x.Racers.Count).ThenBy(x => x.Name))
            //{
            //    Console.WriteLine(road);
            //}

            foreach (var road in roads.OrderByDescending(x => x.Value.Racers.Count).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine(road.Value);
            }
        }
    }

    internal class Road
    {
        public Road(string name)
        {
            this.Name = name;
            this.Racers = new List<string>();
        }
        public string Name { get; set; }
        public ICollection<string> Racers { get; set; }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendLine(this.Name);
            foreach (var racer in this.Racers)
            {
                str.AppendLine($"++{racer}");
            }
            return str.ToString().TrimEnd();
        }
    }
}
