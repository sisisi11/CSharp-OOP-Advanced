﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAnimal
{
    string Name { get; }
    int Age { get; }

    string MakeNoise();
}