using System;
using System.Linq;

namespace FundamentalsFinalExam
{
    class NikuldenCharity
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var commandLine = Console.ReadLine();

            while (commandLine != "Finish")
            {
                var commands = commandLine.Split();

                var inputList = input.Split().ToList();

                switch (commands[0])
                {
                    case "Replace":
                        var currentChar = char.Parse(commands[1]);
                        var newChar = char.Parse(commands[2]);
                        input = input.Replace(currentChar, newChar);
                        Console.WriteLine(input);
                        break;
                    case "Cut":

                        var startIndex = int.Parse(commands[1]);
                        var endIndex = int.Parse(commands[2]);
                        if (startIndex < 0 || startIndex > input.Length - 1 || endIndex < 0 || endIndex > input.Length - 1)
                        {
                            Console.WriteLine("Invalid indexes!");
                            break;
                        }
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(input);
                        break;
                    case "Make":
                        if (commands[1] == "Upper")
                        {
                            input = input.ToUpper();
                        }
                        else if (commands[1] == "Lower")
                        {
                            input = input.ToLower();
                        }
                        Console.WriteLine(input);
                        break;
                    case "Check":
                        var stringToCheck = string.Join(' ', commands.Skip(1));
                        if (input.Contains(stringToCheck))
                        {
                            Console.WriteLine($"Message contains {stringToCheck}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {stringToCheck}");
                        }
                        break;
                    case "Sum":
                        var startOfSum = int.Parse(commands[1]);
                        var endOfSum = int.Parse(commands[2]);
                        if (startOfSum < 0 || startOfSum > input.Length - 1 || endOfSum < 0 || endOfSum > input.Length - 1)
                        {
                            Console.WriteLine("Invalid indexes!");
                            break;
                        }
                        var subString = input.Substring(startOfSum, endOfSum - startOfSum + 1);
                        var sum = subString.Select(x => (int)x).Sum();
                        Console.WriteLine(sum);
                        break;
                }

                commandLine = Console.ReadLine();
            }
        }
    }
}
