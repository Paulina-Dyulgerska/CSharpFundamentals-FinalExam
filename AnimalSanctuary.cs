using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class AnimalSanctuary
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var totalWeight = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var pattern = @".*n:(?<n>.[^;]+).?t:(?<t>.[^;]+).?c--(?<c>[A-Za-z ]+)";
                var hasMatch = Regex.IsMatch(input, pattern);
                if (hasMatch)
                {
                    var match = Regex.Match(input, pattern);
                    var name = match.Groups["n"].Value;
                    var nameChars = name.Where(x => char.IsLetter(x) || x == ' ');
                    var animalName = string.Join(null, nameChars);

                    var weight = match.Groups["n"].Value.Where(x => char.IsDigit(x))
                        .Select(x => int.Parse(x.ToString())).Sum();

                    var kind = match.Groups["t"].Value.Where(x => !char.IsDigit(x));
                    var kindChars = kind.Where(x => char.IsLetter(x) || x == ' ');
                    var animalKind = string.Join(null, kindChars);

                    weight += match.Groups["t"].Value.Where(x => char.IsDigit(x))
                        .Select(x => int.Parse(x.ToString())).Sum();

                    var country = match.Groups["c"].Value;

                    totalWeight += weight;

                    Console.WriteLine($"{animalName} is a {animalKind} from {country}");
                }
            }
            Console.WriteLine($"Total weight of all animals: {totalWeight}KG");
        }
    }
}
