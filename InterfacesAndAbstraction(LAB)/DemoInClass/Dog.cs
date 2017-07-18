using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dog : IAnimal
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string MakeNoise()
    {
        return $"Ohhh";
    }
}