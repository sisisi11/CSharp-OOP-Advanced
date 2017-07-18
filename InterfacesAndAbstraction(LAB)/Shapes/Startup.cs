using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    static void Main()
    {
        var radius = int.Parse(Console.ReadLine());
        IDrawable circle = new Circle(radius);

        var width = int.Parse(Console.ReadLine());
        var height = int.Parse(Console.ReadLine());
        IDrawable rect = new Rectangle(width, height);

        circle.Draw();
        rect.Draw();

    }
}