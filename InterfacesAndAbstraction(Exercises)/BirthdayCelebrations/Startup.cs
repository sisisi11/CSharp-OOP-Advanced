using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Startup
{
    public static void Main()
    {
        IList<IBirthdatable> birthers = new List<IBirthdatable>();

        var inpueLine = Console.ReadLine();

        while (inpueLine != "End")
        {
            var inputArgs = inpueLine.Split();
            var type = inputArgs[0];

            switch (type)
            {
                case "Citizen":
                    IBirthdatable citizen = new Citizen(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]);
                    birthers.Add(citizen);
                    break;
                case "Pet":
                    IBirthdatable pet = new Pet(inputArgs[1], inputArgs[2]);
                    birthers.Add(pet);
                    break;
                default:
                    break;
            }
            inpueLine = Console.ReadLine();
        }
        var birthYear = Console.ReadLine();
        var birthersInThisYear = birthers.Where(b => b.Birthdate.Substring(6) == birthYear).Select(b => b.Birthdate)
            .ToList();

        foreach (var birthday in birthersInThisYear)
        {
            Console.WriteLine(birthday);
        }
    }
}