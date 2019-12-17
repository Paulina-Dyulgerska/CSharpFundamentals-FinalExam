using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundamentalsFinalExam
{
    class User
    {
        public User(string name)
        {
            this.Name = name;
            this.EMails = new List<string>();
        }

        public string Name { get; set; }
        public ICollection<string> EMails { get; set; }
        public int Sent => this.EMails.Count;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.Name);
            foreach (var email in this.EMails)
            {
                result.AppendLine($" - {email}");
            }
            return result.ToString().TrimEnd();
        }
    }
    class InboxManager
    {
        static void Main()
        {
            var input = Console.ReadLine();

            Dictionary<string, User> users = new Dictionary<string, User>();

            while (input != "Statistics")
            {
                var data = input.Split("->").ToList();

                var userName = data[1];

                switch (data[0])
                {
                    case "Add":
                        if (!users.ContainsKey(userName))
                        {
                            users[userName] = new User(userName);
                        }
                        else
                        {
                            Console.WriteLine($"{userName} is already registered");
                        }
                        break;
                    case "Send":
                        var email = data[2];
                        users[userName].EMails.Add(email);
                        break;
                    case "Delete":
                        if (!users.Remove(userName))
                        {
                            Console.WriteLine($"{userName} not found!");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(x => x.Value.Sent).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine(user.Value);
            }
        }
    }
}
