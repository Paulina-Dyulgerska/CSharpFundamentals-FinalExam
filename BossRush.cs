using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class BossRush
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var pattern = @"\|(?<n>[A-Z]{4,})\|:#(?<fw>[A-Za-z]+ [A-Za-z]+)#";

                var hasMatch = Regex.IsMatch(input, pattern);

                if (hasMatch)
                {
                    var match = Regex.Match(input, pattern);

                    var name = match.Groups["n"].Value;
                    var title = match.Groups["fw"].Value;
                    Console.WriteLine($"{name}, The {title}");
                    Console.WriteLine($">> Strength: {name.Length}");
                    Console.WriteLine($">> Armour: { title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
