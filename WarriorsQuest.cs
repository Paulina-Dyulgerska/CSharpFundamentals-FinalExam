using System;
using System.Linq;

namespace FundamentalsFinalExam
{
    class WarriorsQuest
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var commands = Console.ReadLine();

            while (commands != "For Azeroth")
            {
                if (string.IsNullOrWhiteSpace(input) || input == "For Azeroth")
                {
                    break;
                }
                var data = commands.Split(' ').ToList();

                var inputList = input.ToList();

                switch (data[0])
                {
                    case "GladiatorStance": //tuk
                        input = input.ToUpper();
                        Console.WriteLine(input);
                        break;

                    case "DefensiveStance": //tuk
                        input = input.ToLower();
                        Console.WriteLine(input);
                        break;

                    case "Dispel":  //checked
                        var index = int.Parse(data[1]);
                        var letter = char.Parse(data[2]);

                        if (index < 0 || index > input.Length - 1)
                        {
                            Console.WriteLine("Dispel too weak.");
                            break;
                        }

                        inputList[index] = letter;
                        input = string.Join(null, inputList);

                        Console.WriteLine("Success!");
                        break;

                    case "Target":
                        if (data[1] == "Change")    //checked
                        {
                            string toReplace = data[2];
                            string toPut = data[3];

                            if (input.Contains(toReplace))
                            {
                                input = input.Replace(toReplace, toPut);
                                Console.WriteLine(input);
                            }
                        }
                        else if (data[1] == "Remove")   //tuk
                        {
                            //string toRemove = data[2];
                            //var i = input.IndexOf(toRemove);
                            //input = input.Remove(i, input.Length + 100); //taka go zabivam, vmesto v Throw Exception
                            //input = input.Remove(i, toRemove.Length);

                            //string toRemove = commands.Substring(14, commands.Length - 14);

                            string toRemove = data[2];

                            input = input.Replace(toRemove, null);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");    //checked
                        }
                        break;

                    default:
                        Console.WriteLine("Command doesn't exist!");    //checked
                        break;
                }

                commands = Console.ReadLine();
            }
        }
    }
}
