using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class MessageEncripter
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var pattern = @"([\*@])(?<tg>[A-Z][a-z]{2,})\1:[\s]\[(?<f>[A-Za-z])\]\|\[(?<s>[A-Za-z])\]\|\[(?<t>[A-Za-z])\]\|$";

                var hasMatch = Regex.IsMatch(input, pattern);

                if (hasMatch)
                {
                    var match = Regex.Match(input, pattern);
                    string tag = match.Groups["tg"].Value;
                    char char1 = char.Parse(match.Groups["f"].Value);
                    char char2 = char.Parse(match.Groups["s"].Value);
                    char char3 = char.Parse(match.Groups["t"].Value);

                    string result = $"{tag}: {(int)char1} {(int)char2} {(int)char3}";

                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
