using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class MessageDecrypter
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var pattern = @"^([\$\%])(?<tg>[A-Z][a-z]{2,})\1: \[(?<f>[0-9]+)\]\|\[(?<s>[0-9]+)\]\|\[(?<t>[0-9]+)\]\|$";

                var hasMatch = Regex.IsMatch(input, pattern);

                if (hasMatch)
                {
                    var match = Regex.Match(input, pattern);
                    var tag = match.Groups["tg"].Value;
                    char char1 = (char)int.Parse(match.Groups["f"].Value);
                    char char2 = (char)int.Parse(match.Groups["s"].Value);
                    char char3 = (char)int.Parse(match.Groups["t"].Value);
                    Console.WriteLine($"{tag}: {char1}{char2}{char3}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
