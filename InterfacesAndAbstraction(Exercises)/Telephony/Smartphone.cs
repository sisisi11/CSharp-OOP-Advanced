using System;

public class SmartPhone : ICallable, IBrowsable
{
    public void BrowseSites(string site)
    {
        foreach (var character in site)
        {
            if (char.IsDigit(character))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }
        }
        Console.WriteLine($"Browsing: {site}!");
    }

    public void CallNumber(string number)
    {
        foreach (var character in number)
        {
            if (!char.IsDigit(character))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
        }
        Console.WriteLine($"Calling... {number}");
    }
}