using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class TheIsleofManTTRace
    {

        static void Main()
        {
            var input = Console.ReadLine();
            var hasCode = false;

            while (!hasCode)
            {
                var pattern = @"^([\#\$\%\&\*]{1})(?<n>[A-Za-z]+)\1=(?<l>[0-9]+)!!(?<c>.+?)$";
                var hasMatch = Regex.IsMatch(input, pattern);
                if (hasMatch)
                {
                    var match = Regex.Match(input, pattern);
                    var name = match.Groups["n"].Value;
                    var length = int.Parse(match.Groups["l"].Value);
                    var code = match.Groups["c"].Value;
                    if (code.Length == length)
                    {
                        var newCode = code.ToCharArray().Select(x => (char)(x + length));
                        Console.WriteLine($"Coordinates found! {name} -> {string.Join(null, newCode)}");
                        hasCode = true;
                        return;
                    }
                }
                Console.WriteLine("Nothing found!");

                input = Console.ReadLine();
            }
        }
    }
}
