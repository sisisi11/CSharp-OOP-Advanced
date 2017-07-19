using System;

public class Startup
{
    public static void Main()
    {
        var phoneNumbers = Console.ReadLine().Split(new char[] {' '});
        var sites = Console.ReadLine().Split(new char[] { ' ' });

        SmartPhone smartPhone = new SmartPhone();

        foreach (var number in phoneNumbers)
        {
            smartPhone.CallNumber(number);
        }
        foreach (var site in sites)
        {
            smartPhone.BrowseSites(site);
        }
    }
}