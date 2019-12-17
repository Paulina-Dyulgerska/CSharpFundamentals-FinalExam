using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class Registration
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var pattern = @"(U\$)(?<un>[A-Z][a-z]{2,})\1(P\@\$)(?<p>[A-Za-z]{5,}[0-9]+)\2";
                var hasMatch = Regex.IsMatch(input, pattern);
                if (hasMatch)
                {
                    var match = Regex.Match(input, pattern);
                    var name = match.Groups["un"].Value;
                    var pass = match.Groups["p"].Value;

                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {name}, Password: {pass}");

                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {count}");
        }
    }
}
