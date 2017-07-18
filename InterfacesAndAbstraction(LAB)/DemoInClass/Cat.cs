﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Cat : IAnimal
{
    public Cat(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string MakeNoise()
    {
        return $"Bauu";
    }
}