using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam
{
    class SongEncryption
    {
        static void Main()
        {
            var input = Console.ReadLine();

            while (input != "end")
            {
                var pattern = @"^(?<a>[A-Z][a-z'\s]+):(?<s>[A-Z\s]+)$";
                var hasMatch = Regex.IsMatch(input, pattern);

                if (hasMatch)
                {
                    var match = Regex.Match(input, pattern);
                    var artist = match.Groups["a"].Value;
                    var encriptionKey = artist.Length;
                    var data = input.ToCharArray();

                    for (int i = 0; i < data.Length; i++)
                    {
                        if (char.IsLetter(data[i]))
                        {
                            if (char.IsUpper(data[i]))
                            {
                                var currentCharASCII = data[i] - 65; //89-64 = 25 + 5 = 30
                                var newCharASCII = (currentCharASCII + encriptionKey) % 26 + 65;
                                data[i] = (char)newCharASCII;
                            }
                            else
                            {
                                var currentCharASCII = data[i] - 97;
                                var newCharASCII = (currentCharASCII + encriptionKey) % 26 + 97;
                                data[i] = (char)newCharASCII;
                            }
                        }
                        else if (data[i] == ':')
                        {
                            data[i] = '@';
                        }
                    }

                    Console.WriteLine($"Successful encryption: {string.Join(null, data)}");

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
