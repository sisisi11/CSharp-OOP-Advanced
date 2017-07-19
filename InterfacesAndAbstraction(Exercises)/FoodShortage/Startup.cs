using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        IList<IBuyer> buyers = new List<IBuyer>();

        var numOfPerson = int.Parse(Console.ReadLine());

        for (int index = 0; index < numOfPerson; index++)
        {
            var inputLine = Console.ReadLine().Split();
            if (inputLine.Length == 3)
            {
                IBuyer rebel = new Rebel(inputLine[0], int.Parse(inputLine[1]), inputLine[2]);
                buyers.Add(rebel);
            }
            else
            {
                IBuyer citizen = new Citizen(inputLine[3], inputLine[0], int.Parse(inputLine[1]), inputLine[2]);
                buyers.Add(citizen);
            }
        }
        var name = Console.ReadLine().Split();
        
        while (name[0] != "End")
        {
            foreach (var buyer in buyers)
            {
                if (buyer.Name == name[0])
                {
                    buyer.BuyFood();
                }
            }
            name = Console.ReadLine().Split();
        }
        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}