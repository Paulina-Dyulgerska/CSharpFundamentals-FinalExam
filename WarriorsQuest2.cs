using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentalsFinalExam
{
    class WarriorsQuest2
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var commands = Console.ReadLine();

            while (commands != "For Azeroth")
            {
                var data = commands.Split(' ').ToList();

                List<char> inputList = input.ToList();

                if (commands.StartsWith("GladiatorStance"))
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (commands.StartsWith("DefensiveStance"))
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (commands.StartsWith("Dispel"))
                {
                    var index = int.Parse(data[1]);

                    if (index < 0 || index > input.Length - 1)
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                    else
                    {
                        var letter = char.Parse(data[2]);
                        inputList[index] = letter;
                        input = string.Join(null, inputList);
                        Console.WriteLine("Success!");
                    }
                }
                else if (commands.StartsWith("Target Change"))
                {
                    string toReplace = data[2];
                    string toPut = data[3];
                    input = input.Replace(toReplace, toPut);
                    Console.WriteLine(input);
                }
                else if (commands.StartsWith("Target Remove"))
                {
                    string toRemove = data[2];
                    input = input.Replace(toRemove, null);
                    Console.WriteLine(input);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

                commands = Console.ReadLine();
            }
        }
    }
}
