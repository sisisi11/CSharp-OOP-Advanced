using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        IList<IIdentifiable> list = new List<IIdentifiable>();

        var inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            var inputArgs = inputLine.Split();
            if (inputArgs.Length == 3)
            {
                IIdentifiable citizen = new Citizens(inputArgs[2], inputArgs[0], int.Parse(inputArgs[1]));
                list.Add(citizen);
            }
            else
            {
                IIdentifiable robot = new Robots(inputArgs[0], inputArgs[1]);
                list.Add(robot);
            }
            inputLine = Console.ReadLine();
        }
        var fakesId = Console.ReadLine();

        var detained = list.Where(li => li.Id.EndsWith(fakesId)).Select(li => li.Id).ToList();

        foreach (var det in detained)
        {
            Console.WriteLine(det);
        }
    }
}