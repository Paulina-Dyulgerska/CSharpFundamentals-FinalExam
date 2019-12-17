using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class MessageTranslator
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var pattern = @"!(?<c>[A-Z][a-z]{2,})!:.*\[(?<m>[A-Za-z]{8,})\]";
                var hasMatch = Regex.IsMatch(input, pattern);
                if (hasMatch)
                {
                    var match = Regex.Match(input, pattern);
                    var command = match.Groups["c"].Value;
                    var message = match.Groups["m"].Value;
                    var messageASCIIs = message.Select(x => (int)x);
                    var messageASCIIsString = string.Join(' ', messageASCIIs);
                    Console.WriteLine($"{command}: {messageASCIIsString}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
