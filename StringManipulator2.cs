using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentalsFinalExam
{
    class StringManipulator2
    {
        static void Main()
        {
            var text = Console.ReadLine();
            var input = Console.ReadLine();

            while (input != "Done")
            {
                var allData = input.Split().ToList();

                var list = new List<char>(text);

                switch (allData[0])
                {
                    case "Change":
                        text = text.Replace(char.Parse(allData[1]), char.Parse(allData[2]));
                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        Console.WriteLine(text.Contains(allData[1]));
                        break;
                    case "End":
                        Console.WriteLine(text.EndsWith(allData[1]));
                        break;
                    case "Uppercase":
                        text = text.ToUpper();
                        Console.WriteLine(text);
                        break;
                    case "FindIndex":
                        var index = list.FindIndex(x => x == char.Parse(allData[1]));
                        Console.WriteLine(index);
                        break;
                    case "Cut":
                        int startIndex = int.Parse(allData[1]);
                        int length = int.Parse(allData[2]);
                        string substr = text.Substring(startIndex, length);
                        Console.WriteLine(substr);
                        //list.RemoveRange(0, startIndex);
                        //list.RemoveRange(length, list.Count - length);
                        //Console.WriteLine(string.Join(null, list));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
