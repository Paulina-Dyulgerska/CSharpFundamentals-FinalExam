using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class Password2
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();

                string pattern = @"(.+)[>](?<d>[0-9]{3})\|(?<sl>[a-z]{3})\|(?<cl>[A-Z]{3})\|(?<s>.{3})[<]\1";
                //^(.+?) > (?< first >[0 - 9]{ 3})\| (?< second >[a - z]{ 3})\| (?< third >[A - Z]{ 3})\| (?< fourth >[^<>]{ 3})<\1$
                //^(.*?)>(?<first>[0-9]{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^<>]{3})<\1$

                var match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string password = string.Empty;
                    password += match.Groups["d"].Value;
                    password += match.Groups["sl"].Value;
                    password += match.Groups["cl"].Value;
                    password += match.Groups["s"].Value;
                    Console.WriteLine($"Password: { password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
