using System;

class Startup
{
    public static void Main()
    {
        var driversName = Console.ReadLine();
        ICar ferrari = new Ferrari(driversName);
        Console.WriteLine(ferrari.ToString());


        string ferrariName = typeof(Ferrari).Name;
        string iCarInterfaceName = typeof(ICar).Name;

        bool isCreated = typeof(ICar).IsInterface;
        if (!isCreated)
        {
            throw new Exception("No interface ICar was created");
        }

    }
}