using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentalsFinalExam
{
    class Person
    {
        public Person(string name, int health, int enegry)
        {
            this.Name = name;
            this.Health = health;
            this.Enegry = enegry;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Enegry { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Health} - {this.Enegry}";
        }
    }
    class BattleManager
    {
        static void Main()
        {
            SortedList<string, Person> persons = new SortedList<string, Person>();

            var input = Console.ReadLine();

            while (input != "Results")
            {
                var data = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (data[0])
                {
                    case "Add":
                        var name = data[1];
                        var health = int.Parse(data[2]);
                        var energy = int.Parse(data[3]);
                        if (!persons.ContainsKey(name))
                        {
                            persons.Add(name, new Person(name, 0, energy));
                        }
                        persons[name].Health += health;
                        break;
                    case "Attack":
                        var attackerName = data[1];
                        var defenderName = data[2];
                        var damage = int.Parse(data[3]);
                        if (persons.ContainsKey(attackerName) && persons.ContainsKey(defenderName))
                        {
                            persons[defenderName].Health -= damage;
                            persons[attackerName].Enegry--;
                            if (persons[defenderName].Health <= 0)
                            {
                                persons.Remove(defenderName);
                                Console.WriteLine($"{defenderName} was disqualified!");
                            }
                            if (persons[attackerName].Enegry <= 0)
                            {
                                persons.Remove(attackerName);
                                Console.WriteLine($"{attackerName} was disqualified!");
                            }
                        }
                        break;
                    case "Delete":
                        var username = data[1];
                        if (persons.ContainsKey(username))
                        {
                            persons.Remove(username);
                        }
                        else if (username == "All")
                        {
                            persons.Clear();
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"People count: {persons.Count}");
            foreach (var person in persons.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine(person.Value);
            }
        }
    }
}


//Battle Manager 
class Person
{
    public Person(string name, int health, int energy)
    {
        this.Name = name;
        this.Health = health;
        this.Energy = energy;
    }
    public string Name { get; set; }
    public int Health { get; set; }
    public int Energy { get; set; }
}
class Class1
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split(':');
        string action = inputs[0];
        List<Person> allDatas = new List<Person>();
        while (action != "Results")
        {
            switch (action)
            {
                case "Add":
                    string name = inputs[1];
                    int health = int.Parse(inputs[2]);
                    int energy = int.Parse(inputs[3]);
                    bool hasThisName = allDatas.Any(x => x.Name == name);
                    if (hasThisName)
                    {
                        int index = allDatas.FindIndex(x => x.Name == name);
                        allDatas[index].Health += health;
                    }
                    else
                    {
                        Person currentPerson = new Person(name, health, energy);
                        allDatas.Add(currentPerson);
                    }
                    break;
                case "Attack":
                    string attackerName = inputs[1];
                    string defenderName = inputs[2];
                    int damage = int.Parse(inputs[3]);
                    bool hasBothPlayers = allDatas.Any(x => x.Name == attackerName) & allDatas.Any(x => x.Name == defenderName);
                    if (hasBothPlayers)
                    {
                        int defenderIndex = allDatas.FindIndex(x => x.Name == defenderName);
                        allDatas[defenderIndex].Health -= damage;
                        if (allDatas[defenderIndex].Health <= 0)
                        {
                            allDatas.RemoveAt(defenderIndex);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }
                        int attackerIndex = allDatas.FindIndex(x => x.Name == attackerName);
                        allDatas[attackerIndex].Energy--;
                        if (allDatas[attackerIndex].Energy <= 0)
                        {
                            allDatas.RemoveAt(attackerIndex);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                    break;
                case "Delete":
                    string userToDelete = inputs[1];
                    bool hasThisUser = allDatas.Any(x => x.Name == userToDelete);
                    if (hasThisUser)
                    {
                        int indexUserToDelete = allDatas.FindIndex(x => x.Name == userToDelete);
                        allDatas.RemoveAt(indexUserToDelete);
                    }
                    else
                    {
                        if (userToDelete == "All")
                        {
                            allDatas.Clear();
                        }
                    }
                    break;
            }
            inputs = Console.ReadLine().Split(':');
            action = inputs[0];
        }
        Console.WriteLine($"People count: {allDatas.Count}");
        var result = allDatas.OrderByDescending(x => x.Health).ThenBy(x => x.Name);
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} - {item.Health} - {item.Energy}");
        }
    }
}
