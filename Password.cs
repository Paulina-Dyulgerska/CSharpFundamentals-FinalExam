using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Password
            int numberOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"^(.*?)>(?<first>[0-9]{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^<>]{3})<\1$";
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string password = string.Empty;
                    password += match.Groups["first"].Value;
                    password += match.Groups["second"].Value;
                    password += match.Groups["third"].Value;
                    password += match.Groups["fourth"].Value;
                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine($"Try another password!");
                }
            }
            //^(.+?) > (?< first >[0 - 9]{ 3})\| (?< second >[a - z]{ 3})\| (?< third >[A - Z]{ 3})\| (?< fourth >[^<>]{ 3})<\1$
        }
    }
}
