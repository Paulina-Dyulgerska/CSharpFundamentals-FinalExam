using System;
using System.Collections.Generic;

namespace FundamentalsFinalExam
{
    class StringManipulator1
    {
        static void Main()
        {
            var text = Console.ReadLine();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var data = input.Split();
                var list = new List<char>(text);

                switch (data[0])
                {
                    case "Translate":
                        text = text.Replace(char.Parse(data[1]), char.Parse(data[2]));
                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        Console.WriteLine(text.Contains(data[1]));
                        break;
                    case "Start":
                        Console.WriteLine(text.StartsWith(data[1]));
                        break;
                    case "Lowercase":
                        text = text.ToLower();
                        Console.WriteLine(text);
                        break;
                    case "FindIndex":
                        var index = list.LastIndexOf(char.Parse(data[1]));
                        Console.WriteLine(index);
                        break;
                    case "Remove":
                        var startIndex = int.Parse(data[1]);
                        var count = int.Parse(data[2]);
                        list.RemoveRange(startIndex, count);
                        Console.WriteLine(string.Join(null, list));
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
