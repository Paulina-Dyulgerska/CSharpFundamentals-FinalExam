using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentalsFinalExam
{
    class Follower
    {
        public Follower(string name, int likes, int comments)
        {
            this.Name = name;
            this.Likes = likes;
            this.Comments = comments;
        }
        public string Name { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Likes + this.Comments}";
        }
    }
    class Followers
    {
        static void Main()
        {
            var followers = new List<Follower>();

            string input = Console.ReadLine();

            while (input != "Log out")
            {
                var data = input.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToList();

                switch (data[0])
                {
                    case "New follower":
                        if (!followers.Any(x => x.Name == data[1]))
                        {
                            followers.Add(new Follower(data[1], 0, 0));
                        }
                        break;
                    case "Like":
                        if (!followers.Any(x => x.Name == data[1]))
                        {
                            followers.Add(new Follower(data[1], int.Parse(data[2]), 0));
                        }
                        else
                        {
                            followers.FirstOrDefault(x => x.Name == data[1]).Likes += int.Parse(data[2]);
                        }
                        break;
                    case "Comment":
                        if (!followers.Any(x => x.Name == data[1]))
                        {
                            followers.Add(new Follower(data[1], 0, 1));
                        }
                        else
                        {
                            followers.FirstOrDefault(x => x.Name == data[1]).Comments++;
                        }
                        break;
                    case "Blocked":
                        if (!followers.Any(x => x.Name == data[1]))
                        {
                            Console.WriteLine($"{data[1]} doesn't exist.");
                        }
                        else
                        {
                            followers.Remove(followers.FirstOrDefault(x => x.Name == data[1]));
                        }
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{followers.Count} followers");
            foreach (var follower in followers.OrderByDescending(x => x.Likes).ThenBy(x => x.Name))
            {
                Console.WriteLine(follower);
            }
        }
    }
}

//Final Exam Followers
class Follower
{
    public Follower(string name, int likes = 0, int comments = 0)
    {
        this.Name = name;
        this.Likes = likes;
        this.Comments = comments;
    }
    public string Name { get; set; }
    public int Likes { get; set; }
    public int Comments { get; set; }
}
class Class1
{
    static void Main()
    {
        List<Follower> allDatas = new List<Follower>();
        string command = Console.ReadLine();
        while (command != "Log out")
        {
            string[] commands = command.Split(": ");
            string action = commands[0];
            string name = commands[1];
            bool hasThisName = allDatas.Any(x => x.Name == name);
            Follower currentFollower = new Follower(name);
            switch (action)
            {
                case "New follower":
                    if (!hasThisName)
                    {
                        allDatas.Add(currentFollower);
                    }
                    break;
                case "Like":
                    if (!hasThisName)
                    {
                        allDatas.Add(currentFollower);
                    }
                    int indexLike = allDatas.FindIndex(x => x.Name == name);
                    allDatas[indexLike].Likes += int.Parse(commands[2]);
                    break;
                case "Comment":
                    if (!hasThisName)
                    {
                        allDatas.Add(currentFollower);
                    }
                    int indexComment = allDatas.FindIndex(x => x.Name == name);
                    allDatas[indexComment].Comments++;
                    break;
                case "Blocked":
                    if (!hasThisName)
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        allDatas.RemoveAll(x => x.Name == name);
                    }
                    break;
            }
            command = Console.ReadLine();
        }
        Console.WriteLine($"{allDatas.Count} followers");
        var result = allDatas.OrderByDescending(x => x.Likes).ThenBy(x => x.Name);
        //var result = allDatas.OrderByDescending(x => x.Likes + x.Comments).ThenBy(x => x.Name); //moga da sybiram s lambda expretions
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name}: {item.Likes + item.Comments}");
        }
    }
}
