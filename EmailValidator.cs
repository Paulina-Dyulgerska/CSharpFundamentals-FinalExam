using System;
using System.Linq;

namespace FundamentalsFinalExam
{
    class EmailValidator
    {
        static void Main()
        {
            string email = Console.ReadLine();
            var emailCharsList = email.ToList();
            var commands = Console.ReadLine().Split().ToList();

            while (commands[0] != "Complete")
            {
                string result = string.Empty;

                switch (commands[0])
                {
                    case "Make":
                        if (commands[1] == "Upper")
                        {
                            email = email.ToUpper();
                        }
                        else if (commands[1] == "Lower")
                        {
                            email = email.ToLower();
                        }
                        Console.WriteLine(email);
                        break;
                    case "GetDomain":
                        var count = int.Parse(commands[1]);
                        result = email.Substring(email.Length - count, count);
                        Console.WriteLine(result);
                        break;
                    case "GetUsername":
                        if (emailCharsList.Any(x => x == '@'))
                        {
                            int indexOfSeparator = emailCharsList.FindIndex(x => x == '@');
                            result = email.Substring(0, indexOfSeparator);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        }
                        break;
                    case "Replace":
                        char charToReplace = char.Parse(commands[1]);
                        email = email.Replace(charToReplace, '-');
                        Console.WriteLine(email);
                        break;
                    case "Encrypt":
                        var ASCIIvalueOfEachSymbol = email.Select(x => (int)x).ToList();
                        Console.WriteLine(string.Join(' ', ASCIIvalueOfEachSymbol));
                        break;
                }

                commands = Console.ReadLine().Split().ToList();
            }
        }
    }
}
