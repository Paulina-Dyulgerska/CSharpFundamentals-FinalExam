using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundamentalsFinalExam
{
    class Band
    {
        public Band(string name, params string[] members)
        {
            this.Name = name;
            this.Members = new HashSet<string>(members);
        }

        public string Name { get; set; }
        public int Time { get; set; }
        public ICollection<string> Members { get; set; }

        public override string ToString()
        {
            var strb = new StringBuilder();
            strb.AppendLine($"{this.Name}");

            foreach (var member in this.Members)
            {
                strb.AppendLine($"=> {member}");
            }

            return strb.ToString().TrimEnd();
        }

    }
    public class Concert
    {
        static void Main()
        {
            var allData = new Dictionary<string, Band>();

            var input = Console.ReadLine();

            while (input != "start of concert")
            {
                var data = input.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                switch (data[0])
                {
                    case "Add":
                        var bandName = data[1];
                        var bandMembers = data[2].Split(", ", StringSplitOptions.RemoveEmptyEntries);

                        if (!allData.ContainsKey(bandName))
                        {
                            allData[bandName] = new Band(bandName, bandMembers);
                        }

                        foreach (var member in bandMembers)
                        {
                            allData[bandName].Members.Add(member);
                        }
                        break;
                    case "Play":
                        var bandNameToPlay = data[1];
                        var timeToPlay = int.Parse(data[2]);

                        if (!allData.ContainsKey(bandNameToPlay))
                        {
                            allData[bandNameToPlay] = new Band(bandNameToPlay);
                        }

                        allData[bandNameToPlay].Time += timeToPlay;
                        break;
                }

                input = Console.ReadLine();
            }

            var bandToDisplay = Console.ReadLine();

            var totalTime = allData.Select(x => x.Value.Time).Sum();
            Console.WriteLine($"Total time: {totalTime}");

            var orderedBands = allData.OrderByDescending(x => x.Value.Time).ThenBy(x => x.Value.Name);

            foreach (var band in orderedBands)
            {
                Console.WriteLine($"{band.Key} -> {band.Value.Time}");
            }

            Console.WriteLine(allData[bandToDisplay]);
        }
    }
}
