using System;

public class Startup
{
    public static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        Scale<int> sclae = new Scale<int>(firstNumber, secondNumber);

        Console.WriteLine(sclae.GetHavier());
    }
}