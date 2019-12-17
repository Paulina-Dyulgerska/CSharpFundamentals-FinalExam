using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentalsFinalExam
{
    class User
    {
        public User(string name, int sentMessages, int receivedMessages)
        {
            this.Name = name;
            this.SentMessages = sentMessages;
            this.ReceivedMessages = receivedMessages;
        }

        public string Name { get; set; }
        public int SentMessages { get; set; }
        public int ReceivedMessages { get; set; }
        public int TotalMessages { get => this.SentMessages + this.ReceivedMessages; }

        public override string ToString()
        {
            return $"{this.Name} - {this.SentMessages + this.ReceivedMessages}";
        }
    }
    class MessagesManager
    {
        static void Main()
        {
            var users = new SortedList<string, User>();
            var users = new SortedDictionary<string, User>();

            var capacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                var data = input.Split("=", StringSplitOptions.RemoveEmptyEntries);

                switch (data[0])
                {
                    case "Add":
                        var username = data[1];
                        var sent = int.Parse(data[2]);
                        var received = int.Parse(data[3]);
                        if (!users.ContainsKey(username))
                        {
                            users.Add(username, new User(username, sent, received));
                        }
                        break;
                    case "Message":
                        var sender = data[1];
                        var receiver = data[2];
                        if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                        {
                            users[sender].SentMessages++;
                            users[receiver].ReceivedMessages++;

                            if (users[sender].TotalMessages == capacity)
                            {
                                users.Remove(sender);
                                Console.WriteLine($"{sender} reached the capacity!");
                            }
                            if (users[receiver].TotalMessages == capacity)
                            {
                                users.Remove(receiver);
                                Console.WriteLine($"{receiver} reached the capacity!");
                            }
                        }
                        break;
                    case "Empty":
                        var usernameTodelete = data[1];
                        if (users.ContainsKey(usernameTodelete))
                        {
                            users.Remove(usernameTodelete);
                        }
                        else if (usernameTodelete == "All")
                        {
                            users.Clear();
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(x => x.Value.ReceivedMessages).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine(user.Value);
            }
        }
    }
}

//Messages Manager
class User
{
    public User(string name, int sentMessages, int receivedMessages, int capacity)
    {
        this.Name = name;
        this.SentMessages = sentMessages;
        this.ReceivedMessages = receivedMessages;
        this.CapacityUsed = capacity;
    }
    public string Name { get; set; }
    public int SentMessages { get; set; }
    public int ReceivedMessages { get; set; }
    public int CapacityUsed { get; set; }
}
class Class1
{
    static void Main()
    {
        int capacity = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        List<User> allDatas = new List<User>();
        while (input != "Statistics")
        {
            string[] commands = input.Split("=");
            string action = commands[0];
            switch (action)
            {
                case "Add":
                    string name = commands[1];
                    int sentMessages = int.Parse(commands[2]);
                    int receivedMessages = int.Parse(commands[3]);
                    int capacityUsed = sentMessages + receivedMessages;
                    User currentUser = new User(name, sentMessages, receivedMessages, capacityUsed);
                    if (!allDatas.Any(x => x.Name == commands[1]))
                    {
                        allDatas.Add(currentUser);
                    }
                    break;
                case "Message":
                    string sender = commands[1];
                    string receiver = commands[2];
                    bool hasUsers = allDatas.Any(x => x.Name == sender) & allDatas.Any(x => x.Name == receiver);
                    if (hasUsers)
                    {
                        int indexSender = allDatas.FindIndex(x => x.Name == sender);
                        int indexReceiver = allDatas.FindIndex(x => x.Name == receiver);
                        allDatas[indexSender].SentMessages++;
                        allDatas[indexSender].CapacityUsed++;
                        allDatas[indexReceiver].ReceivedMessages++;
                        allDatas[indexReceiver].CapacityUsed++;
                        if (allDatas[indexSender].CapacityUsed == capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            allDatas.RemoveAt(indexSender);
                            indexReceiver = allDatas.FindIndex(x => x.Name == receiver);
                        }
                        if (allDatas[indexReceiver].CapacityUsed == capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            allDatas.RemoveAt(indexReceiver);
                        }
                    }
                    break;
                case "Empty":
                    string userToDelete = commands[1];
                    if (userToDelete == "All")
                    {
                        //allDatas = new List<User>();
                        allDatas.Clear();
                    }
                    else
                    {
                        if (allDatas.Any(x => x.Name == userToDelete))
                        {
                            int indexToDelete = allDatas.FindIndex(x => x.Name == userToDelete);
                            allDatas.RemoveAt(indexToDelete);
                        }
                    }
                    break;
            }
            input = Console.ReadLine();
        }
        Console.WriteLine($"Users count: {allDatas.Count}");
        var result = allDatas.OrderByDescending(x => x.ReceivedMessages).ThenBy(x => x.Name);
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} - {item.CapacityUsed}");
        }
    }
}
