using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    class Username1
    {
        static void Main()
        {

            var username = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Sign up")
            {
                var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                if (data.Count < 2)
                {
                    return;
                }

                switch (data[0])
                {
                    case "Case":
                        if (data[1] == "lower")
                        {
                            username = username.ToLower();
                            Console.WriteLine(username);
                        }
                        else if (data[1] == "upper")
                        {
                            username = username.ToUpper();
                            Console.WriteLine(username);
                        }
                        break;
                    case "Reverse":
                        if (data.Count < 3)
                        {
                            break;
                        }
                        int startIndex = int.Parse(data[1]);
                        int endIndex = int.Parse(data[2]);
                        if (CheckIndexValidity(startIndex, username) && CheckIndexValidity(endIndex, username) && startIndex < endIndex)
                        {
                            List<char> list = username.Substring(startIndex, endIndex - startIndex + 1).ToList();
                            list.Reverse();
                            Console.WriteLine(string.Join(null, list));
                        }
                        break;
                    case "Cut":
                        string substringToCut = data[1];
                        if (username.Contains(substringToCut))
                        {
                            username = username.Replace(substringToCut, null);
                            Console.WriteLine(username);
                        }
                        else
                        {
                            Console.WriteLine($"The word {username} doesn't contain {substringToCut}.");
                        }
                        break;
                    case "Replace":
                        char charToReplace = char.Parse(data[1]);
                        username = username.Replace(charToReplace, '*');
                        Console.WriteLine(username);
                        break;
                    case "Check":
                        char charToCheck = char.Parse(data[1]);
                        if (username.Contains(charToCheck))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {charToCheck}.");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }

        public static bool CheckIndexValidity(int index, string username)
        {
            if (index >= 0 && index < username.Length)
            {
                return true;
            }
            return false;
        }
    }
}
